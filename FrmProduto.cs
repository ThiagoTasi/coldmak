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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregaGridProdutos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto(
                    textCodBar.Text,
                    textCat.Text,
                    int.Parse(textIdForn.Text),
                    textDesc.Text,
                    decimal.Parse(textValun.Text),
                    textUnidvend.Text,
                    int.Parse(textEstmin.Text),
                    textCladesc.Text,
                    pictureBoxImagem.Image != null ? ImageToByteArray(pictureBoxImagem.Image) : null,
                    DateTime.Parse(textDatcad.Text)
                );

                produto.Inserir();

                if (produto.IdProduto > 0)
                {
                    CarregaGridProdutos();
                    MessageBox.Show("Produto inserido com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto(
                    int.Parse(textIdProd.Text),
                    textCodBar.Text,
                    textCat.Text,
                    int.Parse(textIdForn.Text),
                    textDesc.Text,
                    decimal.Parse(textValun.Text),
                    textUnidvend.Text,
                    int.Parse(textEstmin.Text),
                    textCladesc.Text,
                    pictureBoxImagem.Image != null ? ImageToByteArray(pictureBoxImagem.Image) : null,
                    DateTime.Parse(textDatcad.Text)
                );

                if (produto.Atualizar())
                {
                    CarregaGridProdutos();
                    MessageBox.Show("Produto atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProduto = int.Parse(textIdProd.Text);
                Produto produto = Produto.ObterPorId(idProduto);

                if (produto != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o produto {produto.Descricao}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Implemente a lógica de exclusão no banco de dados aqui
                        // Exemplo:
                        // if (Produto.Deletar(idProduto))
                        // {
                        //     CarregaGridProdutos();
                        //     MessageBox.Show("Produto excluído com sucesso!");
                        //     LimparCampos();
                        // }
                        // else
                        // {
                        //     MessageBox.Show("Falha ao excluir o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // }
                        MessageBox.Show("Implemente a lógica de exclusão no banco de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagem.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void CarregaGridProdutos()
        {
            dgvprod.Rows.Clear();
            List<Produto> produtos = Produto.ObterLista();

            foreach (Produto produto in produtos)
            {
                int rowIndex = dgvprod.Rows.Add();
                dgvprod.Rows[rowIndex].Cells["IdProduto"].Value = produto.IdProduto;
                dgvprod.Rows[rowIndex].Cells["CodBarras"].Value = produto.CodBarras;
                dgvprod.Rows[rowIndex].Cells["IdCategoria"].Value = produto.Categoria;
                dgvprod.Rows[rowIndex].Cells["IdFornecedor"].Value = produto.IdFornecedor;
                dgvprod.Rows[rowIndex].Cells["Descricao"].Value = produto.Descricao;
                dgvprod.Rows[rowIndex].Cells["ValorUnitario"].Value = produto.ValorUnitario;
                dgvprod.Rows[rowIndex].Cells["UnidadeVenda"].Value = produto.UnidadeVenda;
                dgvprod.Rows[rowIndex].Cells["EstoqueMinimo"].Value = produto.EstoqueMinimo;
                dgvprod.Rows[rowIndex].Cells["ClasseDesconto"].Value = produto.ClasseDesconto;
                dgvprod.Rows[rowIndex].Cells["Imagem"].Value = ByteArrayToImage(produto.Imagem);
                dgvprod.Rows[rowIndex].Cells["DataCadastro"].Value = produto.DataCadastro;
            }
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvprod.Rows[e.RowIndex];
                textIdProd.Text = row.Cells["IdProduto"].Value.ToString();
                textCodBar.Text = row.Cells["CodBarras"].Value.ToString();
                textCat.Text = row.Cells["IdCategoria"].Value.ToString();
                textIdForn.Text = row.Cells["IdFornecedor"].Value.ToString();
                textDesc.Text = row.Cells["Descricao"].Value.ToString();
                textValun.Text = row.Cells["ValorUnitario"].Value.ToString();
                textUnidvend.Text = row.Cells["UnidadeVenda"].Value.ToString();
                textEstmin.Text = row.Cells["EstoqueMinimo"].Value.ToString();
                textCladesc.Text = row.Cells["ClasseDesconto"].Value.ToString();
                pictureBoxImagem.Image = row.Cells["Imagem"].Value as Image;
                textDatcad.Text = ((DateTime)row.Cells["DataCadastro"].Value).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void LimparCampos()
        {
            textIdProd.Text = "";
            textCodBar.Text = "";
            textCat.Text = "";
            textIdForn.Text = "";
            textDesc.Text = "";
            textValun.Text = "";
            textUnidvend.Text = "";
            textEstmin.Text = "";
            textCladesc.Text = "";
            pictureBoxImagem.Image = null;
            textDatcad.Text = "";
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
