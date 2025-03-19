using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using coldmak;        // Namespace para a classe Banco
using coldmakClass;  // Namespace da classe Usuario
using MySql.Data.MySqlClient; // Para usar MySqlCommand diretamente
using System.Linq;   // Adicionado para Any() e First()

namespace coldmakApp
{
    public partial class FrmUsuarios : Form
    {
        private List<Nivel> niveis; // Lista de níveis

        public FrmUsuarios()
        {
            InitializeComponent();
            CarregarNiveis(); // Carrega os níveis ao abrir o formulário
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaGridUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarNiveis()
        {
            try
            {
                niveis = new List<Nivel>();
                MySqlCommand cmd = Banco.Abrir();
                cmd.CommandText = "SELECT IdNivel, Sigla FROM Nivel"; // Busca Sigla em vez de Nome
                var leitor = cmd.ExecuteReader();
                while (leitor.Read())
                {
                    niveis.Add(new Nivel
                    {
                        IdNivel = leitor.GetInt32("IdNivel"),
                        Sigla = leitor.GetString("Sigla") // Mapeia Sigla
                    });
                }
                leitor.Close();
                Banco.Fechar(cmd);

                cmbNivel.DataSource = niveis;
                cmbNivel.DisplayMember = "Sigla"; // Exibe Sigla no ComboBox
                cmbNivel.ValueMember = "IdNivel"; // Valor associado é IdNivel

                cmbNivel.SelectedIndexChanged += (s, e) =>
                {
                    if (cmbNivel.SelectedValue != null)
                    {
                        textIdNivel.Text = cmbNivel.SelectedValue.ToString();
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar níveis: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int ObterIdNivel()
        {
            if (int.TryParse(textIdNivel.Text, out int idNivel) && niveis.Any(n => n.IdNivel == idNivel))
            {
                return idNivel;
            }
            MessageBox.Show("Nível inválido. Selecionando o primeiro nível disponível.", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return niveis.First().IdNivel; // Retorna o primeiro nível válido como padrão
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                if (!DateTime.TryParseExact(textDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido. Use dd/MM/yyyy.", "Erro",
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
                    ObterIdNivel(),
                    chkAtivo.Checked
                );

                string dados = $"Nome: '{usuario.Nome}', RG: '{usuario.Rg}', CPF: '{usuario.Cpf}', " +
                              $"Endereço: '{usuario.Endereco}', CEP: '{usuario.Cep}', Email: '{usuario.Email}', " +
                              $"Telefone: '{usuario.Telefone}', Senha: '{usuario.Senha}', " +
                              $"DataNasc: {usuario.DataNascimento}, IdNivel: {usuario.IdNivel}, Ativo: {usuario.Ativo}";
                MessageBox.Show(dados, "Dados a Inserir");

                usuario.Inserir(); // Deveria chamar o método acima
                CarregaGridUsuarios();
                MessageBox.Show($"Usuário {usuario.Nome} inserido com sucesso", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnInserir.Enabled = false;
                LimparCampos();
            }
            catch (Exception ex)
            {
                File.WriteAllText("erro_log.txt", $"Erro: {ex.Message}\nStackTrace: {ex.StackTrace}\n{DateTime.Now}");
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
                int linha = 0;
                foreach (var usuario in listaDeUsuarios)
                {
                    dgvUsuarios.Rows.Add();
                    dgvUsuarios.Rows[linha].Cells[0].Value = usuario.IdUsuario;
                    dgvUsuarios.Rows[linha].Cells[1].Value = usuario.Nome;
                    dgvUsuarios.Rows[linha].Cells[2].Value = usuario.Rg;
                    dgvUsuarios.Rows[linha].Cells[3].Value = usuario.Cpf;
                    dgvUsuarios.Rows[linha].Cells[4].Value = usuario.Endereco;
                    dgvUsuarios.Rows[linha].Cells[5].Value = usuario.Cep;
                    dgvUsuarios.Rows[linha].Cells[6].Value = usuario.Email;
                    dgvUsuarios.Rows[linha].Cells[7].Value = usuario.Telefone;
                    dgvUsuarios.Rows[linha].Cells[8].Value = usuario.Senha;
                    dgvUsuarios.Rows[linha].Cells[9].Value = usuario.DataNascimento.ToString("dd/MM/yyyy");
                    dgvUsuarios.Rows[linha].Cells[10].Value = usuario.IdNivel;
                    dgvUsuarios.Rows[linha].Cells[11].Value = usuario.Ativo ? "Sim" : "Não";
                    linha++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar grid: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCamposAtualizacao()) return;

                if (!DateTime.TryParseExact(textDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido. Use dd/MM/yyyy.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    DataNascimento = dataNascimento,
                    IdNivel = ObterIdNivel(),
                    Ativo = chkAtivo.Checked
                };

                if (usuario.Atualizar())
                {
                    CarregaGridUsuarios();
                    MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAtualizar.Enabled = false;
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
                        btnDeletar.Enabled = false;
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvUsuarios.CurrentRow.Index;
                int idUsuario = Convert.ToInt32(dgvUsuarios.Rows[linhaAtual].Cells[0].Value);
                var usuario = Usuario.ObterPorId(idUsuario);

                if (usuario != null)
                {
                    PreencherCampos(usuario);
                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                    btnInserir.Enabled = false;
                }
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
            if (string.IsNullOrWhiteSpace(textRg.Text) || textRg.Text.Length != 9)
            {
                MessageBox.Show("O RG deve ter exatamente 9 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textRg.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textCpf.Text) || textCpf.Text.Length != 11)
            {
                MessageBox.Show("O CPF deve ter exatamente 11 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCpf.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textCep.Text) || textCep.Text.Length != 8)
            {
                MessageBox.Show("O CEP deve ter exatamente 8 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCep.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textEmail.Text) || !textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
            {
                MessageBox.Show("Insira um email válido.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textSenha.Text) || textSenha.Text.Length > 32)
            {
                MessageBox.Show("A senha é obrigatória e não pode exceder 32 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSenha.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textIdNivel.Text) || !niveis.Any(n => n.IdNivel == int.Parse(textIdNivel.Text)))
            {
                MessageBox.Show("Selecione um nível válido.", "Atenção",
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
            textIdNivel.Text = usuario.IdNivel.ToString();
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
            textIdNivel.Clear();
            cmbNivel.SelectedIndex = -1;
            chkAtivo.Checked = false;
            btnInserir.Enabled = true;
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
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