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
    public partial class FrmItemPedido : Form
    {
        public FrmItemPedido()
        {
            InitializeComponent();
        }

        private void FrmItemPedido_Load(object sender, EventArgs e)
        {
            CarregaGridItensPedido();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                ItemPedido itemPedido = new ItemPedido(
                    int.Parse(textIdord.Text),
                    int.Parse(textIdprod.Text),
                    decimal.Parse(textValorunit.Text),
                    int.Parse(textQuant.Text),
                    decimal.Parse(textDesc.Text)
                );

                itemPedido.Inserir();

                if (itemPedido.IdItemPedido > 0)
                {
                    CarregaGridItensPedido();
                    MessageBox.Show($"Item de pedido inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir item de pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridItensPedido()
        {
            dgvitped.Rows.Clear();
            var listaDeItensPedido = ItemPedido.ObterLista();
            int linha = 0;
            foreach (var itemPedido in listaDeItensPedido)
            {
                dgvitped.Rows.Add();
                dgvitped.Rows[linha].Cells[0].Value = itemPedido.IdItemPedido;
                dgvitped.Rows[linha].Cells[1].Value = itemPedido.IdOrdemdeServico;
                dgvitped.Rows[linha].Cells[2].Value = itemPedido.IdProduto;
                dgvitped.Rows[linha].Cells[3].Value = itemPedido.ValorUnitario;
                dgvitped.Rows[linha].Cells[4].Value = itemPedido.QuantidadeItem;
                dgvitped.Rows[linha].Cells[5].Value = itemPedido.DescontoItem;
                linha++;
            }
        }

        private void dgvItensPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvitped.CurrentRow.Index;
                int idItemPedido = Convert.ToInt32(dgvitped.Rows[linhaAtual].Cells[0].Value);
                var itemPedido = ItemPedido.ObterPorId(idItemPedido);
                textIdItemp.Text = itemPedido.IdItemPedido.ToString();
                textIdord.Text = itemPedido.IdOrdemdeServico.ToString();
                textIdprod.Text = itemPedido.IdProduto.ToString();
                textValorunit.Text = itemPedido.ValorUnitario.ToString();
                textQuant.Text = itemPedido.QuantidadeItem.ToString();
                textDesc.Text = itemPedido.DescontoItem.ToString();
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ItemPedido itemPedido = new ItemPedido();
                itemPedido.IdItemPedido = int.Parse(textIdItemp.Text);
                itemPedido.IdOrdemdeServico = int.Parse(textIdord.Text);
                itemPedido.IdProduto = int.Parse(textIdprod.Text);
                itemPedido.ValorUnitario = decimal.Parse(textValorunit.Text);
                itemPedido.QuantidadeItem = int.Parse(textQuant.Text);
                itemPedido.DescontoItem = decimal.Parse(textDesc.Text);

                if (itemPedido.Atualizar())
                {
                    CarregaGridItensPedido();
                    MessageBox.Show("Item de pedido atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar item de pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idItemPedido = int.Parse(textIdItemp.Text);
                ItemPedido itemPedido = ItemPedido.ObterPorId(idItemPedido);

                if (itemPedido != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o item de pedido {itemPedido.IdItemPedido}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (itemPedido.Deletar())
                        {
                            CarregaGridItensPedido();
                            MessageBox.Show("Item de pedido excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o item de pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item de pedido não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir item de pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textIdItemp.Text = "";
            textIdord.Text = "";
            textIdprod.Text = "";
            textValorunit.Text = "";
            textQuant.Text = "";
            textDesc.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            btnDeletar_Click(sender, e);
        }

        private void FrmItemPedido_Load_1(object sender, EventArgs e)
        {

        }
    }
}