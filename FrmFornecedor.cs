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

namespace coldmakApp
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
            // Garantir que o textId seja somente leitura
            textId.ReadOnly = true; // Ou textId.Enabled = false, dependendo do que você usou para "congelar"
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            CarregaGridFornecedores();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações básicas
                if (string.IsNullOrWhiteSpace(textRazaosoc.Text))
                {
                    MessageBox.Show("Por favor, preencha a razão social.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textCnpj.Text))
                {
                    MessageBox.Show("Por favor, preencha o CNPJ.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Padronizar o CNPJ: remover pontos, barras, hífens e espaços
                string cnpjLimpo = textCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "").Trim();

                Fornecedor fornecedor = new Fornecedor(
                    textRazaosoc.Text,
                    textFanta.Text,
                    cnpjLimpo, // Usar o CNPJ padronizado
                    textTelefone.Text,
                    textEmail.Text
                );

                string erro;
                int idFornecedor;
                if (fornecedor.Inserir(out erro, out idFornecedor))
                {
                    CarregaGridFornecedores();
                    MessageBox.Show($"Fornecedor {fornecedor.RazaoSocial} inserido com sucesso! ID: {idFornecedor}");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show($"Erro ao inserir fornecedor: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnInserir.Enabled = true; // Reativar o botão em caso de erro
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnInserir.Enabled = true; // Reativar o botão em caso de erro
            }
        }

        private void CarregaGridFornecedores()
        {
            try
            {
                dgvFornecedor.Rows.Clear();
                string erro;
                var listaDeFornecedores = Fornecedor.ObterLista(out erro);
                if (!string.IsNullOrEmpty(erro))
                {
                    MessageBox.Show($"Erro ao carregar lista de fornecedores: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int linha = 0;
                foreach (var fornecedor in listaDeFornecedores)
                {
                    dgvFornecedor.Rows.Add();
                    dgvFornecedor.Rows[linha].Cells[0].Value = fornecedor.IdFornecedor;
                    dgvFornecedor.Rows[linha].Cells[1].Value = fornecedor.RazaoSocial;
                    dgvFornecedor.Rows[linha].Cells[2].Value = fornecedor.Fantasia;
                    dgvFornecedor.Rows[linha].Cells[3].Value = fornecedor.Cnpj;
                    dgvFornecedor.Rows[linha].Cells[4].Value = fornecedor.Telefone;
                    dgvFornecedor.Rows[linha].Cells[5].Value = fornecedor.Email;
                    linha++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar grid de fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int linhaAtual = dgvFornecedor.CurrentRow.Index;
                    int idFornecedor = Convert.ToInt32(dgvFornecedor.Rows[linhaAtual].Cells[0].Value);
                    string erro;
                    var fornecedor = Fornecedor.ObterPorId(idFornecedor, out erro);

                    if (fornecedor == null || !string.IsNullOrEmpty(erro))
                    {
                        MessageBox.Show($"Erro ao carregar fornecedor: {erro ?? "Fornecedor não encontrado."}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    textId.Text = fornecedor.IdFornecedor.ToString();
                    textRazaosoc.Text = fornecedor.RazaoSocial;
                    textFanta.Text = fornecedor.Fantasia;
                    textCnpj.Text = fornecedor.Cnpj;
                    textTelefone.Text = fornecedor.Telefone;
                    textEmail.Text = fornecedor.Email;

                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao clicar na célula: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textId.Text, out int idFornecedor))
                {
                    MessageBox.Show("ID do fornecedor inválido. Selecione um fornecedor na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Padronizar o CNPJ: remover pontos, barras, hífens e espaços
                string cnpjLimpo = textCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "").Trim();

                Fornecedor fornecedor = new Fornecedor(
                    idFornecedor,
                    textRazaosoc.Text,
                    textFanta.Text,
                    cnpjLimpo,
                    textTelefone.Text,
                    textEmail.Text
                );

                string erro;
                if (fornecedor.Atualizar(out erro))
                {
                    CarregaGridFornecedores();
                    MessageBox.Show("Fornecedor atualizado com sucesso!");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show($"Erro ao atualizar fornecedor: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textId.Text, out int idFornecedor))
                {
                    MessageBox.Show("ID do fornecedor inválido. Selecione um fornecedor na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string erro;
                var fornecedor = Fornecedor.ObterPorId(idFornecedor, out erro);

                if (fornecedor == null || !string.IsNullOrEmpty(erro))
                {
                    MessageBox.Show($"Erro ao carregar fornecedor para exclusão: {erro ?? "Fornecedor não encontrado."}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Deseja realmente excluir o fornecedor {fornecedor.RazaoSocial}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (fornecedor.Deletar(out erro))
                    {
                        CarregaGridFornecedores();
                        MessageBox.Show("Fornecedor excluído com sucesso!");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao excluir fornecedor: {erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textRazaosoc.Text = "";
            textFanta.Text = "";
            textCnpj.Text = "";
            textTelefone.Text = "";
            textEmail.Text = "";

            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaGridFornecedores();
                MessageBox.Show("Lista de fornecedores atualizada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            btnDeletar_Click(sender, e); // Remova se não for necessário
        }
    }
}