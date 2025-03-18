using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coldmakClass;
using MySql.Data.MySqlClient;

namespace coldmakApp
{
    public partial class FrmEnderecos : Form
    {
        public FrmEnderecos()
        {
            InitializeComponent();
        }

        private void FrmEnderecos_Load(object sender, EventArgs e)
        {
            // Configura as colunas do DataGridView (se não estiverem configuradas no designer)
            if (dgvEndereco.Columns.Count == 0)
            {
                dgvEndereco.Columns.Add("IdEndereco", "ID");
                dgvEndereco.Columns.Add("Cep", "CEP");
                dgvEndereco.Columns.Add("Logradouro", "Logradouro");
                dgvEndereco.Columns.Add("NumeroResidencial", "Número");
                dgvEndereco.Columns.Add("Complemento", "Complemento");
                dgvEndereco.Columns.Add("Bairro", "Bairro");
                dgvEndereco.Columns.Add("Cidade", "Cidade");
                dgvEndereco.Columns.Add("UF", "UF");
            }

            // Carrega os dados automaticamente ao abrir o formulário
            CarregaGridEnderecos();

            if (btnListar != null)
            {
                btnListar.Visible = true; // Garantir visibilidade do botão Listar
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textLogra.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de logradouro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textCep.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textCep.Text.Replace("-", ""), @"^\d{8}$"))
                {
                    MessageBox.Show("Formato de CEP inválido. Use 8 dígitos (ex.: 12345678) ou com máscara (ex.: 12345-678).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textLogra.Text.Length > 100) { MessageBox.Show("O logradouro não pode exceder 100 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (textNumRes.Text.Length > 10) { MessageBox.Show("O número residencial não pode exceder 10 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (textComple.Text.Length > 60) { MessageBox.Show("O complemento não pode exceder 60 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (textBairro.Text.Length > 30) { MessageBox.Show("O bairro não pode exceder 30 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (textCidade.Text.Length > 60) { MessageBox.Show("A cidade não pode exceder 60 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (textUf.Text.Length != 2) { MessageBox.Show("A UF deve ter exatamente 2 caracteres (ex.: SP).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                Endereco endereco = new Endereco(
                    textCep.Text.Replace("-", ""),
                    textLogra.Text,
                    textNumRes.Text,
                    textComple.Text,
                    textBairro.Text,
                    textCidade.Text,
                    textUf.Text
                );

                string valores = $"CEP: {endereco.Cep}, Logradouro: {endereco.Logradouro}, Número: {endereco.NumeroResidencial}, " +
                                $"Complemento: {endereco.Complemento}, Bairro: {endereco.Bairro}, Cidade: {endereco.Cidade}, UF: {endereco.UF}";
                MessageBox.Show($"Valores a inserir: {valores}", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string erro;
                if (endereco.Inserir(out erro))
                {
                    CarregaGridEnderecos();
                    MessageBox.Show($"Endereço {endereco.Logradouro} inserido com sucesso. ID: {endereco.IdEndereco}");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show($"Falha ao inserir o endereço: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridEnderecos()
        {
            // Limpa o DataGridView
            dgvEndereco.Rows.Clear();

            // Obtém a lista de endereços
            string erro;
            var listaDeEnderecos = Endereco.ObterLista(out erro);

            // Verificação de erro
            if (!string.IsNullOrEmpty(erro))
            {
                MessageBox.Show($"Erro ao carregar a lista de endereços: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Depuração: Verificar a contagem de itens e conteúdo
            MessageBox.Show($"Número de endereços retornados: {listaDeEnderecos.Count}", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (listaDeEnderecos.Count > 0)
            {
                MessageBox.Show($"Primeiro endereço: Logradouro = {listaDeEnderecos[0].Logradouro}, CEP = {listaDeEnderecos[0].Cep}", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nenhum endereço encontrado no banco de dados.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Preenche o DataGridView manualmente
            int linha = 0;
            foreach (var endereco in listaDeEnderecos)
            {
                try
                {
                    dgvEndereco.Rows.Add();
                    dgvEndereco.Rows[linha].Cells[0].Value = endereco.IdEndereco;
                    dgvEndereco.Rows[linha].Cells[1].Value = endereco.Cep;
                    dgvEndereco.Rows[linha].Cells[2].Value = endereco.Logradouro;
                    dgvEndereco.Rows[linha].Cells[3].Value = endereco.NumeroResidencial ?? "";
                    dgvEndereco.Rows[linha].Cells[4].Value = endereco.Complemento ?? "";
                    dgvEndereco.Rows[linha].Cells[5].Value = endereco.Bairro ?? "";
                    dgvEndereco.Rows[linha].Cells[6].Value = endereco.Cidade ?? "";
                    dgvEndereco.Rows[linha].Cells[7].Value = endereco.UF ?? "";
                    linha++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao preencher linha {linha}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Força a atualização do DataGridView
            dgvEndereco.Refresh();
        }

        private void dgvEnderecos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvEndereco.CurrentRow.Index;
                int idEndereco = Convert.ToInt32(dgvEndereco.Rows[linhaAtual].Cells[0].Value);
                var endereco = Endereco.ObterPorId(idEndereco, out string erro);
                if (!string.IsNullOrEmpty(erro))
                {
                    MessageBox.Show($"Erro ao carregar o endereço: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textId.Text = endereco.IdEndereco.ToString();
                textCep.Text = endereco.Cep ?? "";
                textLogra.Text = endereco.Logradouro ?? "";
                textNumRes.Text = endereco.NumeroResidencial ?? "";
                textComple.Text = endereco.Complemento ?? "";
                textBairro.Text = endereco.Bairro ?? "";
                textCidade.Text = endereco.Cidade ?? "";
                textUf.Text = endereco.UF ?? "";
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textId.Text))
                {
                    MessageBox.Show("Por favor, selecione um endereço ou preencha o ID para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textLogra.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de logradouro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEndereco = Convert.ToInt32(textId.Text);
                Endereco endereco = new Endereco();
                endereco.IdEndereco = idEndereco;
                endereco.Logradouro = textLogra.Text;

                string erro;
                if (endereco.Atualizar(out erro))
                {
                    CarregaGridEnderecos();
                    MessageBox.Show("Logradouro atualizado com sucesso!");
                    btnAtualizar.Enabled = false;
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show($"Falha ao atualizar o endereço: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textId.Text))
                {
                    MessageBox.Show("Por favor, selecione um endereço ou preencha o ID para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEndereco = Convert.ToInt32(textId.Text);
                Endereco endereco = new Endereco();
                endereco.IdEndereco = idEndereco;

                if (MessageBox.Show($"Deseja realmente excluir o endereço com ID {endereco.IdEndereco}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string erro;
                    if (endereco.Deletar(out erro))
                    {
                        CarregaGridEnderecos();
                        MessageBox.Show("Endereço excluído com sucesso!");
                        btnDeletar.Enabled = false;
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show($"Falha ao excluir o endereço: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textCep.Text = "";
            textLogra.Text = "";
            textNumRes.Text = "";
            textComple.Text = "";
            textBairro.Text = "";
            textCidade.Text = "";
            textUf.Text = "";
            btnInserir.Enabled = true;
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregaGridEnderecos();
        }
    }
}