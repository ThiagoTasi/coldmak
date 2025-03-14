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
    public partial class FrmSolicitacaodeAtendimento : Form
    {
        public FrmSolicitacaodeAtendimento()
        {
            InitializeComponent();
            maskedtextHorarioAgendamento.Mask = "00:00"; // Máscara para HH:mm
            maskedtextHorarioAgendamento.ValidatingType = typeof(DateTime);
        }

        private void FrmSolicitacaodeAtendimento_Load(object sender, EventArgs e)
        {
            CarregaGridSolicitacoesAtendimento();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataAgendamento = DateTime.ParseExact(textDatag.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                if (!maskedtextHorarioAgendamento.MaskCompleted)
                    throw new FormatException("Horário incompleto. Preencha no formato HH:mm.");
                DateTime horarioAgendamento = DateTime.ParseExact(maskedtextHorarioAgendamento.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                // Combinamos a data atual com o horário para criar um datetime completo
                DateTime horarioCompleto = DateTime.Today.Add(horarioAgendamento.TimeOfDay);

                SolicitacaodeAtendimento solicitacaoAtendimento = new SolicitacaodeAtendimento(
                    dataAgendamento,
                    horarioCompleto,
                    textTipserv.Text
                );

                solicitacaoAtendimento.Inserir();

                if (solicitacaoAtendimento.IdSolicitacaodeAtendimento > 0)
                {
                    CarregaGridSolicitacoesAtendimento();
                    MessageBox.Show($"Solicitação de atendimento inserida com sucesso!");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Erro no formato de data ou hora: {ex.Message}. Use AAAA-MM-DD para data e HH:mm para hora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir solicitação de atendimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridSolicitacoesAtendimento()
        {
            dgvsolaten.Rows.Clear();
            var listaDeSolicitacoes = SolicitacaodeAtendimento.ObterLista();
            int linha = 0;
            foreach (var solicitacao in listaDeSolicitacoes)
            {
                dgvsolaten.Rows.Add();
                dgvsolaten.Rows[linha].Cells[0].Value = solicitacao.IdSolicitacaodeAtendimento;
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
                var solicitacaoAtendimento = SolicitacaodeAtendimento.ObterPorId(idSolicitacaoAtendimento);

                if (solicitacaoAtendimento != null)
                {
                    textIdSolicitacaodeAtendimento.Text = solicitacaoAtendimento.IdSolicitacaodeAtendimento.ToString();
                    textDatag.Text = solicitacaoAtendimento.DataAgendamento.ToString("yyyy-MM-dd");
                    maskedtextHorarioAgendamento.Text = solicitacaoAtendimento.HorarioAgendamento.ToString("HH:mm");
                    textTipserv.Text = solicitacaoAtendimento.TipoServico;

                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!maskedtextHorarioAgendamento.MaskCompleted)
                    throw new FormatException("Horário incompleto. Preencha no formato HH:mm.");

                DateTime dataAgendamento = DateTime.ParseExact(textDatag.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime horarioAgendamento = DateTime.ParseExact(maskedtextHorarioAgendamento.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime horarioCompleto = DateTime.Today.Add(horarioAgendamento.TimeOfDay);

                SolicitacaodeAtendimento solicitacaoAtendimento = new SolicitacaodeAtendimento(
                    int.Parse(textIdSolicitacaodeAtendimento.Text),
                    dataAgendamento,
                    horarioCompleto,
                    textTipserv.Text
                );

                if (solicitacaoAtendimento.Atualizar())
                {
                    CarregaGridSolicitacoesAtendimento();
                    MessageBox.Show("Solicitação de atendimento atualizada com sucesso!");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar solicitação de atendimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Erro no formato de data ou hora: {ex.Message}. Use AAAA-MM-DD para data e HH:mm para hora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int idSolicitacaoAtendimento = int.Parse(textIdSolicitacaodeAtendimento.Text);
                SolicitacaodeAtendimento solicitacaoAtendimento = SolicitacaodeAtendimento.ObterPorId(idSolicitacaoAtendimento);

                if (solicitacaoAtendimento != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir a solicitação de atendimento {solicitacaoAtendimento.IdSolicitacaodeAtendimento}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (solicitacaoAtendimento.Deletar())
                        {
                            CarregaGridSolicitacoesAtendimento();
                            MessageBox.Show("Solicitação de atendimento excluída com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir solicitação de atendimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            textIdSolicitacaodeAtendimento.Text = "";
            textDatag.Text = "";
            maskedtextHorarioAgendamento.Text = "";
            textTipserv.Text = "";

            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {

        }
    }
}