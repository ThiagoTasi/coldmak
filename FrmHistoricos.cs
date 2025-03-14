using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using coldmak;
using coldmakClass;

namespace coldmakApp
{
    public partial class FrmHistoricos : Form
    {
        public FrmHistoricos()
        {
            InitializeComponent();
        }

        private void FrmHistoricos_Load(object sender, EventArgs e)
        {
            CarregaGridHistoricos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataVenda = DateTime.ParseExact(textDatven.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                Historicos historico = new Historicos(
                    int.Parse(textIdCli.Text),
                    int.Parse(textIdord.Text),
                    int.Parse(textIdForn.Text),
                    int.Parse(textIdProd.Text),
                    dataVenda
                );

                historico.Inserir();

                if (historico.IdHistoricos > 0)
                {
                    CarregaGridHistoricos();
                    MessageBox.Show($"Histórico inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data inválido. Use AAAA-MM-DD.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridHistoricos()
        {
            dgvhist.Rows.Clear();
            var listaDeHistoricos = Historicos.ObterLista();
            int linha = 0;
            foreach (var historico in listaDeHistoricos)
            {
                dgvhist.Rows.Add();
                dgvhist.Rows[linha].Cells[0].Value = historico.IdHistoricos;
                dgvhist.Rows[linha].Cells[1].Value = historico.IdCliente;
                dgvhist.Rows[linha].Cells[2].Value = historico.IdOrdemdeServico;
                dgvhist.Rows[linha].Cells[3].Value = historico.IdFornecedor;
                dgvhist.Rows[linha].Cells[4].Value = historico.IdProduto;
                dgvhist.Rows[linha].Cells[5].Value = historico.DataVenda.ToString("yyyy-MM-dd"); // Formata a data para exibição
                linha++;
            }
        }

        private void dgvHistoricos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvhist.CurrentRow.Index;
                int idHistorico = Convert.ToInt32(dgvhist.Rows[linhaAtual].Cells[0].Value);
                var historico = Historicos.ObterPorId(idHistorico);
                textIdHist.Text = historico.IdHistoricos.ToString();
                textIdCli.Text = historico.IdCliente.ToString();
                textIdord.Text = historico.IdOrdemdeServico.ToString();
                textIdForn.Text = historico.IdFornecedor.ToString();
                textIdProd.Text = historico.IdProduto.ToString();
                textDatven.Text = historico.DataVenda.ToString("yyyy-MM-dd"); // Formata a data para exibição
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Historicos historico = new Historicos();
                historico.IdHistoricos = int.Parse(textIdHist.Text);
                historico.IdCliente = int.Parse(textIdCli.Text);
                historico.IdOrdemdeServico = int.Parse(textIdord.Text);
                historico.IdFornecedor = int.Parse(textIdForn.Text);
                historico.IdProduto = int.Parse(textIdProd.Text);
                historico.DataVenda = DateTime.ParseExact(textDatven.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                if (historico.Atualizar())
                {
                    CarregaGridHistoricos();
                    MessageBox.Show("Histórico atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data inválido. Use AAAA-MM-DD.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHistorico = int.Parse(textIdHist.Text);
                Historicos historico = Historicos.ObterPorId(idHistorico);

                if (historico != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o histórico {historico.IdHistoricos}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (historico.Deletar())
                        {
                            CarregaGridHistoricos();
                            MessageBox.Show("Histórico excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Histórico não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textIdHist.Text = "";
            textIdCli.Text = "";
            textIdord.Text = "";
            textIdForn.Text = "";
            textIdProd.Text = "";
            textDatven.Text = "";
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
