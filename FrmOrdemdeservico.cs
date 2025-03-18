using System;
using System.Windows.Forms;
using coldmakClass; // Namespace da classe OrdemdeServico

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
                // Validação de campos obrigatórios (excluindo textIdusu e textIdcli)
                if (string.IsNullOrWhiteSpace(textData.Text) || string.IsNullOrWhiteSpace(textStatus.Text) ||
                    string.IsNullOrWhiteSpace(textDesc.Text) || string.IsNullOrWhiteSpace(textVato.Text))
                {
                    MessageBox.Show("Os campos Data, Status, Desconto e Valor Total devem ser preenchidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Conversão segura dos valores obrigatórios
                if (!DateTime.TryParse(textData.Text, out DateTime data))
                {
                    MessageBox.Show("O campo Data deve conter uma data válida no formato (ex.: yyyy-MM-dd HH:mm:ss)!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textDesc.Text, out decimal desconto) || !decimal.TryParse(textVato.Text, out decimal valorTotal))
                {
                    MessageBox.Show("Os campos Desconto e Valor Total devem conter números decimais válidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Conversão segura dos IDs (usa valores padrão 2 e 3, que devem existir quando as tabelas estiverem prontas)
                int idUsuario = string.IsNullOrWhiteSpace(textIdusu.Text) ? 2 : (int.TryParse(textIdusu.Text, out int tempIdUsuario) ? tempIdUsuario : 2);
                int idCliente = string.IsNullOrWhiteSpace(textIdcli.Text) ? 3 : (int.TryParse(textIdcli.Text, out int tempIdCliente) ? tempIdCliente : 3);

                // Depuração: Exibe os IDs que serão usados
                MessageBox.Show($"ID Usuário: {idUsuario}, ID Cliente: {idCliente}", "Depuração");

                // Criação do objeto com valores validados
                OrdemdeServico ordemDeServico = new OrdemdeServico(
                    idUsuario,
                    idCliente,
                    data,
                    textStatus.Text,
                    desconto,
                    valorTotal
                );

                ordemDeServico.Inserir();

                if (ordemDeServico.IdOrdemdeServico > 0)
                {
                    CarregaGridOrdemDeServico();
                    MessageBox.Show("Ordem de serviço inserida com sucesso!");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao inserir a ordem de serviço. Verifique se os IDs de Usuário e Cliente existem nas tabelas correspondentes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir ordem de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textId.Text))
                {
                    MessageBox.Show("Selecione uma ordem de serviço para atualizar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                else
                {
                    MessageBox.Show("Falha ao atualizar a ordem de serviço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrWhiteSpace(textId.Text))
                {
                    MessageBox.Show("Selecione uma ordem de serviço para deletar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idOrdemDeServico = int.Parse(textId.Text);
                OrdemdeServico ordemDeServico = OrdemdeServico.ObterPorId(idOrdemDeServico);

                if (ordemDeServico != null)
                {
                    if (MessageBox.Show("Deseja realmente excluir a ordem de serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaGridOrdemDeServico();
                MessageBox.Show("Lista de ordens de serviço atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar ordens de serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridOrdemDeServico()
        {
            try
            {
                dgvords.Rows.Clear();
                var listaDeOrdemDeServico = OrdemdeServico.ObterLista();
                if (listaDeOrdemDeServico != null && listaDeOrdemDeServico.Count > 0)
                {
                    int linha = 0;
                    foreach (var ordem in listaDeOrdemDeServico)
                    {
                        dgvords.Rows.Add();
                        dgvords.Rows[linha].Cells[0].Value = ordem.IdOrdemdeServico;
                        dgvords.Rows[linha].Cells[1].Value = ordem.IdUsuario;
                        dgvords.Rows[linha].Cells[2].Value = ordem.IdCliente;
                        dgvords.Rows[linha].Cells[3].Value = ordem.Data.ToString("yyyy-MM-dd HH:mm:ss");
                        dgvords.Rows[linha].Cells[4].Value = ordem.Status;
                        dgvords.Rows[linha].Cells[5].Value = ordem.Desconto;
                        dgvords.Rows[linha].Cells[6].Value = ordem.ValorTotal;
                        linha++;
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma ordem de serviço encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a grid: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrdemDeServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = e.RowIndex;
                int idOrdemDeServico = Convert.ToInt32(dgvords.Rows[linhaAtual].Cells[0].Value);
                var ordemDeServico = OrdemdeServico.ObterPorId(idOrdemDeServico);

                if (ordemDeServico != null)
                {
                    textId.Text = ordemDeServico.IdOrdemdeServico.ToString();
                    textIdusu.Text = ordemDeServico.IdUsuario.ToString();
                    textIdcli.Text = ordemDeServico.IdCliente.ToString();
                    textData.Text = ordemDeServico.Data.ToString("yyyy-MM-dd HH:mm:ss");
                    textStatus.Text = ordemDeServico.Status;
                    textDesc.Text = ordemDeServico.Desconto.ToString();
                    textVato.Text = ordemDeServico.ValorTotal.ToString();

                    btnAtualizar.Enabled = true;
                    btnDeletar.Enabled = true;
                    btnInserir.Enabled = false;
                }
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
    }
}