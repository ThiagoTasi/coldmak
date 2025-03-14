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
            cmbNivel.DataSource = Nivel.ObterLista(); // Assumindo que Nivel tem um método ObterLista()
            cmbNivel.DisplayMember = "Nome";
            cmbNivel.ValueMember = "Id";
            cmbNivel.SelectedIndex = -1;
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

                // Criando o usuário com o construtor de 11 parâmetros + null para Nivel
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
                    IdNivel,
                    chkAtivo.Checked,
                    null // Nivel será inicializado como new Nivel() pelo construtor
                );

                // Inserir o usuário (método void, sucesso é verificado pelo IdUsuario)
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
                        usuario.Nivel?.Nome,
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
                    IdNivel = IdNivel,
                    Ativo = chkAtivo.Checked
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
                        MessageBox.Show("Falha ao excluir o usuário.", "Erro",
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
            cmbNivel.SelectedValue = usuario.IdNivel;
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
            cmbNivel.SelectedIndex = -1;
            chkAtivo.Checked = false;
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
            textNome.Focus();
        }
    }
}