using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coldmak;
using coldmakClass;


namespace coldmakApp
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            CarregaGridFornecedores();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor(
                    textRazaosoc.Text,
                    textFanta.Text,
                    textCnpj.Text,
                    textTelefone.Text,
                    textEmail.Text
                );

                fornecedor.Inserir();

                if (fornecedor.Id_Fornecedor > 0)
                {
                    CarregaGridFornecedores();
                    MessageBox.Show($"Fornecedor {fornecedor.Razao_Social} inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridFornecedores()
        {
            dgvFornecedor.Rows.Clear();
            var listaDeFornecedores = Fornecedor.ObterLista();
            int linha = 0;
            foreach (var fornecedor in listaDeFornecedores)
            {
                dgvFornecedor.Rows.Add();
                dgvFornecedor.Rows[linha].Cells[0].Value = fornecedor.Id_Fornecedor;
                dgvFornecedor.Rows[linha].Cells[1].Value = fornecedor.Razao_Social;
                dgvFornecedor.Rows[linha].Cells[2].Value = fornecedor.Fantasia;
                dgvFornecedor.Rows[linha].Cells[3].Value = fornecedor.Cnpj;
                dgvFornecedor.Rows[linha].Cells[4].Value = fornecedor.Telefone;
                dgvFornecedor.Rows[linha].Cells[5].Value = fornecedor.Email;
                linha++;
            }
        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvFornecedor.CurrentRow.Index;
                int idFornecedor = Convert.ToInt32(dgvFornecedor.Rows[linhaAtual].Cells[0].Value);
                var fornecedor = Fornecedor.ObterPorId(idFornecedor);

                textId.Text = fornecedor.Id_Fornecedor.ToString();
                textRazaosoc.Text = fornecedor.Razao_Social;
                textFanta.Text = fornecedor.Fantasia;
                textCnpj.Text = fornecedor.Cnpj;
                textTelefone.Text = fornecedor.Telefone;
                textEmail.Text = fornecedor.Email;

                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor(
                    int.Parse(textId.Text),
                    textRazaosoc.Text,
                    textFanta.Text,
                    textCnpj.Text,
                    textTelefone.Text,
                    textEmail.Text
                );

                if (fornecedor.Atualizar())
                {
                    CarregaGridFornecedores();
                    MessageBox.Show("Fornecedor atualizado com sucesso!");
                    LimparCampos();
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
                int idFornecedor = int.Parse(textId.Text);
                Fornecedor fornecedor = Fornecedor.ObterPorId(idFornecedor);

                if (fornecedor != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o fornecedor {fornecedor.Razao_Social}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (fornecedor.Deletar())
                        {
                            CarregaGridFornecedores();
                            MessageBox.Show("Fornecedor excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o fornecedor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            btnDeletar_Click(sender, e);
        }
    }
}