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
    public partial class FrmSolicitacaoAtendimento : Form
    {
        public FrmSolicitacaoAtendimento()
        {
            InitializeComponent();
        }

        private void FrmSolicitacaoAtendimento_Load(object sender, EventArgs e)
        {
            CarregaGridSolicitacoesAtendimento();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataAgendamento = DateTime.ParseExact(textDatag.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime horarioAgendamento = DateTime.ParseExact(maskedtextHoag.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                SolicitacaoAtendimento solicitacaoAtendimento = new SolicitacaoAtendimento(
                    dataAgendamento,
                    horarioAgendamento,
                    textTipserv.Text
                );

                solicitacaoAtendimento.Inserir();

                if (solicitacaoAtendimento.IdSolicitacaoAtendimento > 0)
                {
                    CarregaGridSolicitacoesAtendimento();
                    MessageBox.Show($"Solicitação de atendimento inserida com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data ou hora inválido. Use AAAA-MM-DD para data e HH:mm para hora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir solicitação de atendimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridSolicitacoesAtendimento()
        {
            dgvsolaten.Rows.Clear();
            var listaDeSolicitacoesAtendimento = SolicitacaoAtendimento.ObterLista();
            int linha = 0;
            foreach (var solicitacao in listaDeSolicitacoesAtendimento)
            {
                dgvsolaten.Rows.Add();
                dgvsolaten.Rows[linha].Cells[0].Value = solicitacao.IdSolicitacaoAtendimento;
                dgvsolaten.Rows[linha].Cells[1].Value = solicitacao.DataAgendamento.ToString("yyyy-MM-dd");
                dgvsolaten.Rows[linha].Cells[2].Value = solicitacao.HorarioAgendamento.ToString("HH:mm");
                dgvsolaten.Rows[linha].Cells[3].Value = solicitacao.TipoServico;
                linha++;
            }
        }

        private void dgvSolicitacoesAtendimento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvsolaten.CurrentRow.Index;
                int idSolicitacaoAtendimento = Convert.ToInt32(dgvsolaten.Rows[linhaAtual].Cells[0].Value);
                var solicitacaoAtendimento = SolicitacaoAtendimento.ObterPorId(idSolicitacaoAtendimento);

                textId.Text = solicitacaoAtendimento.IdSolicitacaoAtendimento.ToString();
                textDatag.Text = solicitacaoAtendimento.DataAgendamento.ToString("yyyy-MM-dd");
                maskedtextHoag.Text = solicitacaoAtendimento.HorarioAgendamento.ToString("HH:mm");
                textTipserv.Text = solicitacaoAtendimento.TipoServico;

                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitacaoAtendimento solicitacaoAtendimento = new SolicitacaoAtendimento();
                solicitacaoAtendimento.IdSolicitacaoAtendimento = int.Parse(textId.Text);
                solicitacaoAtendimento.DataAgendamento = DateTime.ParseExact(textDatag.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                solicitacaoAtendimento.HorarioAgendamento = DateTime.ParseExact(maskedtextHoag.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                solicitacaoAtendimento.TipoServico = textTipserv.Text;

                if (solicitacaoAtendimento.Atualizar())
                {
                    CarregaGridSolicitacoesAtendimento();
                    MessageBox.Show("Solicitação de atendimento atualizada com sucesso!");
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data ou hora inválido. Use AAAA-MM-DD para data e HH:mm para hora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar solicitação de atendimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idSolicitacaoAtendimento = int.Parse(textId.Text);
                SolicitacaoAtendimento solicitacaoAtendimento = SolicitacaoAtendimento.ObterPorId(idSolicitacaoAtendimento);

                if (solicitacaoAtendimento != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir a solicitação de atendimento {solicitacaoAtendimento.IdSolicitacaoAtendimento}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        solicitacaoAtendimento.Deletar();
                        CarregaGridSolicitacoesAtendimento();
                        MessageBox.Show("Solicitação de atendimento excluída com sucesso!");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Solicitação de atendimento não encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir solicitação de atendimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textDatag.Text = "";
            maskedtextHoag.Clear();
            textTipserv.Text = "";
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