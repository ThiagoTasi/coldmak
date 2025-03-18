using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using coldmak;        // Namespace para a classe Banco
using coldmakClass;  // Namespace da classe Usuario

namespace coldmakApp
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load_1(object sender, EventArgs e)
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

        private int ObterIdNivel()
        {
            // Método que obtém o IdNivel do textIdNivel com validação temporária
            if (int.TryParse(textIdNivel.Text, out int idNivel))
            {
                if (idNivel == 1 || idNivel == 2) // Valores temporários (1 = ADM, 2 = CLI)
                    return idNivel;
                else
                    return 2; // Valor padrão (CLI) se inválido
            }
            return 2; // Valor padrão se não puder converter

            // Quando a tabela Nivel estiver pronta, substitua por:
            // return NivelDAO.ObterIdNivel(); // Exemplo de consulta futura
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                DateTime dataNascimento;
                if (!DateTime.TryParseExact(textDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido. Use dd/MM/yyyy.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ajuste no instanciamento do Usuario para garantir compatibilidade com o método Inserir
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
                    MessageBox.Show("Falha ao inserir o usuário. Verifique os dados e tente novamente.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Ajuste no log para incluir stack trace
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
                        usuario.Telefone,
                        usuario.Senha,
                        usuario.DataNascimento.ToString("dd/MM/yyyy")
                    );
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
                    IdNivel = ObterIdNivel(),
                    Ativo = chkAtivo.Checked
                };

                if (!DateTime.TryParse(textDataNascimento.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido. Use dd/MM/yyyy.", "Erro",
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
            if (textRg.Text.Length != 9)
            {
                MessageBox.Show("O RG deve ter exatamente 9 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textRg.Focus();
                return false;
            }
            if (textCpf.Text.Length != 11)
            {
                MessageBox.Show("O CPF deve ter exatamente 11 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCpf.Focus();
                return false;
            }
            if (textCep.Text.Length != 8)
            {
                MessageBox.Show("O CEP deve ter exatamente 8 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCep.Focus();
                return false;
            }
            if (textSenha.Text.Length > 32)
            {
                MessageBox.Show("A senha não pode exceder 32 caracteres.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSenha.Focus();
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
            chkAtivo.Checked = usuario.Ativo;
            textIdNivel.Text = usuario.IdNivel.ToString();
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