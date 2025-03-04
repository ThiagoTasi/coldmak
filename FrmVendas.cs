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
    public partial class FrmVendas : Form
    {
        public FrmVendas()
        {
            InitializeComponent();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            CarregaGridVendas();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataVenda = DateTime.ParseExact(textData.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                Vendas venda = new Vendas(
                    dataVenda,
                    decimal.Parse(textPreco.Text),
                    decimal.Parse(textDesc.Text),
                    decimal.Parse(textVendtot.Text)
                );

                venda.Inserir();

                if (venda.IdVendas > 0)
                {
                    CarregaGridVendas();
                    MessageBox.Show($"Venda inserida com sucesso");
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
                MessageBox.Show($"Erro ao inserir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridVendas()
        {
            dgvendas.Rows.Clear();
            var listaDeVendas = Vendas.ObterLista();
            int linha = 0;
            foreach (var venda in listaDeVendas)
            {
                dgvendas.Rows.Add();
                dgvendas.Rows[linha].Cells[0].Value = venda.IdVendas;
                dgvendas.Rows[linha].Cells[1].Value = venda.DataVenda.ToString("yyyy-MM-dd"); // Formata a data para exibição
                dgvendas.Rows[linha].Cells[2].Value = venda.PrecoVenda;
                dgvendas.Rows[linha].Cells[3].Value = venda.Desconto;
                dgvendas.Rows[linha].Cells[4].Value = venda.VendaTotal;
                linha++;
            }
        }

        private void dgvVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvendas.CurrentRow.Index;
                int idVenda = Convert.ToInt32(dgvendas.Rows[linhaAtual].Cells[0].Value);
                var venda = Vendas.ObterPorId(idVenda);
                textIdvendas.Text = venda.IdVendas.ToString();
                textData.Text = venda.DataVenda.ToString("yyyy-MM-dd"); // Formata a data para exibição
                textPreco.Text = venda.PrecoVenda.ToString();
                textDesc.Text = venda.Desconto.ToString();
                textVendtot.Text = venda.VendaTotal.ToString();
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Vendas venda = new Vendas();
                venda.IdVendas = int.Parse(textIdvendas.Text);
                venda.DataVenda = DateTime.ParseExact(textData.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                venda.PrecoVenda = decimal.Parse(textPreco.Text);
                venda.Desconto = decimal.Parse(textDesc.Text);
                venda.VendaTotal = decimal.Parse(textVendtot.Text);

                if (venda.Atualizar())
                {
                    CarregaGridVendas();
                    MessageBox.Show("Venda atualizada com sucesso!");
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data inválido. Use AAAA-MM-DD.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idVenda = int.Parse(textIdvendas.Text);
                Vendas venda = Vendas.ObterPorId(idVenda);

                if (venda != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir a venda {venda.IdVendas}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Adicione um método deletar na classe Vendas.
                        MessageBox.Show("Método deletar não implementado na classe Vendas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Venda não encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textIdvendas.Text = "";
            textData.Text = ""; // Limpa o TextBox de data
            textPreco.Text = "";
            textDesc.Text = "";
            textVendtot.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }
    }
}