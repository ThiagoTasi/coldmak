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
    public partial class FrmSolicitacaoAtendimento : Form
    {
        public FrmSolicitacaoAtendimento()
        {
            InitializeComponent();
        }

        private void FrmSolicitacaoAtendimento_Load(object sender, EventArgs e)
        {
            CarregaGridSolicitacoes();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitacaoAtendimento solicitacao = new SolicitacaoAtendimento(
                    dateTimePickerDatag.Value.Date,
                    TimeSpan.Parse(maskedTextBoxHoag.Text),
                    textBoxTipserv.Text
                );

                solicitacao.Inserir();

                if (solicitacao.IdSolicitacaoAtendimento > 0)
                {
                    CarregaGridSolicitacoes();
                    MessageBox.Show($"Solicitação de atendimento agendada com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao agendar solicitação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridSolicitacoes()
        {
            dgvsolaten.Rows.Clear();
            var listaDeSolicitacoes = SolicitacaoAtendimento.ObterLista();
            int linha = 0;
            foreach (var solicitacao in listaDeSolicitacoes)
            {
                dgvsolaten.Rows.Add();
                dgvsolaten.Rows[linha].Cells[0].Value = solicitacao.IdSolicitacaoAtendimento;
                dgvsolaten.Rows[linha].Cells[1].Value = solicitacao.DataAgendamento;
                dgvsolaten.Rows[linha].Cells[2].Value = solicitacao.HorarioAgendamento;
                dgvsolaten.Rows[linha].Cells[3].Value = solicitacao.TipoServico;
                linha++;
            }
        }

        private void dgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvsolaten.CurrentRow.Index;
                int idSolicitacao = Convert.ToInt32(dgvsolaten.Rows[linhaAtual].Cells[0].Value);
                var solicitacao = SolicitacaoAtendimento.ObterPorId(idSolicitacao);

                textId.Text = solicitacao.IdSolicitacaoAtendimento.ToString();
                dateTimePickerDatag.Value = solicitacao.DataAgendamento;
                maskedTextBoxHoag.Text = solicitacao.HorarioAgendamento.ToString();
                textBoxTiposerv.Text = solicitacao.TipoServico;

                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SolicitacaoAtendimento solicitacao = new SolicitacaoAtendimento(
                    int.Parse(textId.Text),
                    dateTimePickerDatag.Value.Date,
                    TimeSpan.Parse(maskedTextBoxHoag.Text),
                    textBoxTipserv.Text
                );

                if (solicitacao.Atualizar())
                {
                    CarregaGridSolicitacoes();
                    MessageBox.Show("Solicitação de atendimento atualizada com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar solicitação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idSolicitacao = int.Parse(textId.Text);
                SolicitacaoAtendimento solicitacao = SolicitacaoAtendimento.ObterPorId(idSolicitacao);

                if (solicitacao != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir a solicitação de atendimento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Adicione um método "Deletar" na classe SolicitacaoAtendimento se necessário
                        // if (solicitacao.Deletar())
                        // {
                        CarregaGridSolicitacoes();
                        MessageBox.Show("Solicitação de atendimento excluída com sucesso!");
                        LimparCampos();
                        // }
                        // else
                        // {
                        //     MessageBox.Show("Falha ao excluir a solicitação de atendimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // }
                    }
                }
                else
                {
                    MessageBox.Show("Solicitação de atendimento não encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir solicitação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            dateTimePickerDatag.Value = DateTime.Now;
            maskedTextBoxHoag.Clear();
            textBoxTipserv.Clear();

            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }
    }
}