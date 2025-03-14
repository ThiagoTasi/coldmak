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
    public partial class FrmOrdemDeServico : Form
    {
        public FrmOrdemDeServico()
        {
            InitializeComponent();
        }

        private void FrmOrdemDeServico_Load(object sender, EventArgs e)
        {
            CarregaGridOrdemDeServico();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                OrdemdeServico ordemDeServico = new OrdemdeServico(
                    int.Parse(textIdusu.Text),
                    int.Parse(textIdcli.Text),
                    DateTime.Parse(textData.Text),
                    textStatus.Text,
                    decimal.Parse(textDesc.Text),
                    decimal.Parse(textVato.Text)
                );

                ordemDeServico.Inserir();

                if (ordemDeServico.IdOrdemdeServico > 0)
                {
                    CarregaGridOrdemDeServico();
                    MessageBox.Show($"Ordem de serviço inserida com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridOrdemDeServico()
        {
            dgvords.Rows.Clear();
            var listaDeOrdemDeServico = OrdemdeServico.ObterLista();
            int linha = 0;
            foreach (var ordem in listaDeOrdemDeServico)
            {
                dgvords.Rows.Add();
                dgvords.Rows[linha].Cells[0].Value = ordem.IdOrdemdeServico;
                dgvords.Rows[linha].Cells[1].Value = ordem.IdUsuario;
                dgvords.Rows[linha].Cells[2].Value = ordem.IdCliente;
                dgvords.Rows[linha].Cells[3].Value = ordem.Data;
                dgvords.Rows[linha].Cells[4].Value = ordem.Status;
                dgvords.Rows[linha].Cells[5].Value = ordem.Desconto;
                dgvords.Rows[linha].Cells[6].Value = ordem.ValorTotal;
                linha++;
            }
        }

        private void dgvOrdemDeServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvords.CurrentRow.Index;
                int idOrdemDeServico = Convert.ToInt32(dgvords.Rows[linhaAtual].Cells[0].Value);
                var ordemDeServico = OrdemdeServico.ObterPorId(idOrdemDeServico);

                textId.Text = ordemDeServico.IdOrdemdeServico.ToString();
                textIdusu.Text = ordemDeServico.IdUsuario.ToString();
                textIdcli.Text = ordemDeServico.IdCliente.ToString();
                textData.Text = ordemDeServico.Data.ToString();
                textStatus.Text = ordemDeServico.Status;
                textDesc.Text = ordemDeServico.Desconto.ToString();
                textVato.Text = ordemDeServico.ValorTotal.ToString();

                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                OrdemdeServico ordemDeServico = new OrdemdeServico(
                    int.Parse(textId.Text),
                    int.Parse(textIdusu.Text),
                    int.Parse(textIdcli.Text),
                    DateTime.Parse(textData.Text),
                    textStatus.Text,
                    decimal.Parse(textDesc.Text),
                    decimal.Parse(textVato.Text)
                );

                if (ordemDeServico.Atualizar())
                {
                    CarregaGridOrdemDeServico();
                    MessageBox.Show("Ordem de serviço atualizada com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idOrdemDeServico = int.Parse(textId.Text);
                OrdemdeServico ordemDeServico = OrdemdeServico.ObterPorId(idOrdemDeServico);

                if (ordemDeServico != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir a ordem de serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ordemDeServico.Deletar())
                        {
                            CarregaGridOrdemDeServico();
                            MessageBox.Show("Ordem de serviço excluída com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir a ordem de serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ordem de serviço não encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textIdusu.Text = "";
            textIdcli.Text = "";
            textData.Text = "";
            textStatus.Text = "";
            textDesc.Text = "";
            textVato.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {
            btnDeletar_Click(sender, e);
        }
    }
}