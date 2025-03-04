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
    public partial class FrmCaixa : Form
    {
        public FrmCaixa()
        {
            InitializeComponent();
        }

        private void FrmCaixa_Load(object sender, EventArgs e)
        {
            CarregaGridCaixas();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Caixa caixa = new Caixa(
                    int.Parse(textIdUsuario.Text),
                    DateTime.Parse(textDatab.Text),
                    decimal.Parse(textSalini.Text),
                    textStt.Text
                );

                caixa.Inserir();

                if (caixa.IdCaixa > 0)
                {
                    CarregaGridCaixas();
                    MessageBox.Show($"Caixa inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir caixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridCaixas()
        {
            dgvcaixa.Rows.Clear();
            var listaDeCaixas = Caixa.ObterLista();
            int linha = 0;
            foreach (var caixa in listaDeCaixas)
            {
                dgvcaixa.Rows.Add();
                dgvcaixa.Rows[linha].Cells[0].Value = caixa.IdCaixa;
                dgvcaixa.Rows[linha].Cells[1].Value = caixa.IdUsuario;
                dgvcaixa.Rows[linha].Cells[2].Value = caixa.DataAbertura;
                dgvcaixa.Rows[linha].Cells[3].Value = caixa.SaldoInicial;
                dgvcaixa.Rows[linha].Cells[4].Value = caixa.Status;
                linha++;
            }
        }

        private void dgvCaixa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvcaixa.CurrentRow.Index;
                int idCaixa = Convert.ToInt32(dgvcaixa.Rows[linhaAtual].Cells[0].Value);
                var caixa = Caixa.ObterPorId(idCaixa);
                textIdCaixa.Text = caixa.IdCaixa.ToString();
                textIdUsuario.Text = caixa.IdUsuario.ToString();
                textDatab.Text = caixa.DataAbertura.ToString();
                textSalini.Text = caixa.SaldoInicial.ToString();
                textStt.Text = caixa.Status;
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Caixa caixa = new Caixa();
                caixa.IdCaixa = int.Parse(textIdCaixa.Text);
                caixa.IdUsuario = int.Parse(textIdUsuario.Text);
                caixa.DataAbertura = DateTime.Parse(textDatab.Text);
                caixa.SaldoInicial = decimal.Parse(textSalini.Text);
                caixa.Status = textStt.Text;

                if (caixa.Atualizar())
                {
                    CarregaGridCaixas();
                    MessageBox.Show("Caixa atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar caixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCaixa = int.Parse(textIdCaixa.Text);
                Caixa caixa = Caixa.ObterPorId(idCaixa);

                if (caixa != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o caixa {caixa.IdCaixa}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Adicione um método deletar na classe Caixa.
                        // if (caixa.Deletar())
                        // {
                        //     CarregaGridCaixas();
                        //     MessageBox.Show("Caixa excluído com sucesso!");
                        //     LimparCampos();
                        // }
                        // else
                        // {
                        //     MessageBox.Show("Falha ao excluir o caixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // }
                        MessageBox.Show("Metodo deletar não implementado na classe Caixa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Caixa não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir caixa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textIdCaixa.Text = "";
            textIdUsuario.Text = "";
            textDatab.Text = "";
            textSalini.Text = "";
            textStt.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }
    }
}