using System;
using System.Collections.Generic;
using System.Windows.Forms;
using coldmak;        // Namespace assumido para a classe Banco
using coldmakClass;  // Namespace da classe Usuario

namespace coldmakApp
{
    public partial class FrmUsuarios : Form
    {
        private int IdNivel => cmbNivel.SelectedValue != null ? Convert.ToInt32(cmbNivel.SelectedValue) : 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarComboNivel();
                if (cmbNivel.Items.Count == 0)
                {
                    MessageBox.Show("Erro: Nenhum nível disponível para seleção.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CarregaGridUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarComboNivel()
        {
            // Limpa o combobox para evitar duplicatas
            cmbNivel.Items.Clear();

            // Define as opções como uma lista de KeyValuePair
            var niveis = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "ADM"), // Administrador
                new KeyValuePair<int, string>(2, "CLI")  // Cliente
            };

            // Atribui o DataSource
            cmbNivel.DataSource = niveis;
            cmbNivel.DisplayMember = "Value"; // Mostra "ADM" ou "CLI"
            cmbNivel.ValueMember = "Key";     // Usa 1 ou 2 como valor interno
            cmbNivel.SelectedIndex = -1;      // Sem seleção inicial para inserção manual

            // Verificação de depuração
            if (cmbNivel.Items.Count != 2)
            {
                MessageBox.Show($"Erro: Esperado 2 itens no combobox, mas encontrado {cmbNivel.Items.Count}.",
                    "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                DateTime dataNascimento;
                if (!DateTime.TryParse(textDataNascimento.Text, out dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuario = new Usuario(
                    textNome.Text.Trim(),
                    textRg.Text.Trim(),
                    textCpf.Text.Trim(),
                    textEndereco.Text.Trim(),
                    textCep.Text.Trim(),
                    textEmail.Text.Trim(),
                    textTelefone.Text.Trim(),
                    textSenha.Text,
                    dataNascimento,
                    IdNivel, // 1 para ADM, 2 para CLI
                    chkAtivo.Checked,
                    null
                );

                usuario.Inserir();
                if (usuario.IdUsuario > 0)
                {
                    CarregaGridUsuarios();
                    MessageBox.Show($"Usuário {usuario.Nome} inserido com sucesso", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao inserir o usuário. O ID não foi gerado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir usuário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridUsuarios()
        {
            try
            {
                dgvUsuarios.Rows.Clear();
                var listaDeUsuarios = Usuario.ObterLista();

                foreach (var usuario in listaDeUsuarios)
                {
                    string nivelNome = usuario.IdNivel == 1 ? "ADM" : usuario.IdNivel == 2 ? "CLI" : "Desconhecido";

                    dgvUsuarios.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Nome,
                        usuario.Rg,
                        usuario.Cpf,
                        usuario.Endereco,
                        usuario.Cep,
                        usuario.Email,
                        usuario.Senha,
                        usuario.Telefone,
                        usuario.DataNascimento.ToString("dd/MM/yyyy"),
                        nivelNome,
                        usuario.Ativo
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar grid: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int idUser = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value);
                var usuario = Usuario.ObterPorId(idUser);

                if (usuario != null)
                {
                    PreencherCampos(usuario);
                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                    btnInserir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar usuário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposAtualizacao()) return;

                var usuario = new Usuario
                {
                    IdUsuario = int.Parse(textId.Text),
                    Nome = textNome.Text.Trim(),
                    Rg = textRg.Text.Trim(),
                    Cpf = textCpf.Text.Trim(),
                    Endereco = textEndereco.Text.Trim(),
                    Cep = textCep.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Telefone = textTelefone.Text.Trim(),
                    Senha = textSenha.Text,
                    IdNivel = IdNivel
                };

                if (!DateTime.TryParse(textDataNascimento.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                usuario.DataNascimento = dataNascimento;

                if (usuario.Atualizar())
                {
                    CarregaGridUsuarios();
                    MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o usuário.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textId.Text))
                {
                    MessageBox.Show("Selecione um usuário para excluir.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idUsuario = int.Parse(textId.Text);
                var usuario = Usuario.ObterPorId(idUsuario);

                if (usuario != null && MessageBox.Show($"Deseja realmente excluir o usuário {usuario.Nome}?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (usuario.Deletar())
                    {
                        CarregaGridUsuarios();
                        MessageBox.Show("Usuário excluído com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textNome.Text))
            {
                MessageBox.Show("O nome é obrigatório.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNome.Focus();
                return false;
            }
            if (IdNivel == 0)
            {
                MessageBox.Show("Selecione um nível.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNivel.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarCamposAtualizacao()
        {
            if (string.IsNullOrEmpty(textId.Text))
            {
                MessageBox.Show("Selecione um usuário para atualizar.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return ValidarCampos();
        }

        private void PreencherCampos(Usuario usuario)
        {
            textId.Text = usuario.IdUsuario.ToString();
            textNome.Text = usuario.Nome;
            textRg.Text = usuario.Rg;
            textCpf.Text = usuario.Cpf;
            textEndereco.Text = usuario.Endereco;
            textCep.Text = usuario.Cep;
            textEmail.Text = usuario.Email;
            textTelefone.Text = usuario.Telefone;
            textSenha.Text = usuario.Senha;
            textDataNascimento.Text = usuario.DataNascimento.ToString("dd/MM/yyyy");

            // Preenchimento automático baseado na chave estrangeira IdNivel
            if (usuario.IdNivel > 0)
            {
                cmbNivel.SelectedValue = usuario.IdNivel; // Preenche com "ADM" (1) ou "CLI" (2)
                cmbNivel.Enabled = false; // Inativo ao editar
            }
            else
            {
                cmbNivel.SelectedIndex = -1; // Sem seleção
                cmbNivel.Enabled = true; // Ativo para inserção manual
            }

            chkAtivo.Checked = usuario.Ativo;
        }

        private void LimparCampos()
        {
            textId.Clear();
            textNome.Clear();
            textRg.Clear();
            textCpf.Clear();
            textEndereco.Clear();
            textCep.Clear();
            textEmail.Clear();
            textTelefone.Clear();
            textSenha.Clear();
            textDataNascimento.Clear();
            cmbNivel.SelectedIndex = -1; // Reseta para inserção manual
            cmbNivel.Enabled = true; // Ativo para seleção manual
            chkAtivo.Checked = false;
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
            textNome.Focus();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaGridUsuarios();
                MessageBox.Show("Lista de usuários atualizada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar usuários: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}