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
    public partial class FrmItemFornecido : Form
    {
        public FrmItemFornecido()
        {
            InitializeComponent();
        }

        private void FrmItemFornecido_Load(object sender, EventArgs e)
        {
            CarregaGridItensFornecidos();
            LimparCampos();
        }

        // Funcionalidade: Inserir
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                ItemFornecido itemFornecido = new ItemFornecido(
                    int.Parse(textIdFornecedor.Text),
                    int.Parse(textIdProduto.Text),
                    decimal.Parse(textquant.Text),
                    textmod.Text,
                    textnome.Text
                );

                itemFornecido.Inserir();

                if (itemFornecido.IdItemFornecido > 0)
                {
                    CarregaGridItensFornecidos();
                    MessageBox.Show($"Item fornecido inserido com sucesso! ID: {itemFornecido.IdItemFornecido}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao inserir o item fornecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir item fornecido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Funcionalidade: Atualizar
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textIditemfor.Text))
                {
                    MessageBox.Show("Selecione um item para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                ItemFornecido itemFornecido = new ItemFornecido
                {
                    IdItemFornecido = int.Parse(textIditemfor.Text),
                    IdFornecedor = int.Parse(textIdFornecedor.Text),
                    IdProduto = int.Parse(textIdProduto.Text),
                    Quantidade = decimal.Parse(textquant.Text),
                    Modelo = textmod.Text,
                    Nome = textnome.Text
                };

                if (itemFornecido.Atualizar())
                {
                    CarregaGridItensFornecidos();
                    MessageBox.Show($"Item fornecido atualizado com sucesso! ID: {itemFornecido.IdItemFornecido}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o item fornecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar item fornecido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Funcionalidade: Deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textIditemfor.Text))
                {
                    MessageBox.Show("Selecione um item para deletar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idItemFornecido = int.Parse(textIditemfor.Text);
                ItemFornecido itemFornecido = ItemFornecido.ObterPorId(idItemFornecido);

                if (itemFornecido != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o item fornecido {itemFornecido.IdItemFornecido}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (itemFornecido.Deletar())
                        {
                            CarregaGridItensFornecidos();
                            MessageBox.Show($"Item fornecido excluído com sucesso! ID: {idItemFornecido}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o item fornecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item fornecido não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir item fornecido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Funcionalidade: Listar
        private void CarregaGridItensFornecidos()
        {
            dgvitfor.Rows.Clear();
            var listaDeItensFornecidos = ItemFornecido.ObterLista();
            int linha = 0;
            foreach (var itemFornecido in listaDeItensFornecidos)
            {
                dgvitfor.Rows.Add();
                dgvitfor.Rows[linha].Cells[0].Value = itemFornecido.IdItemFornecido;
                dgvitfor.Rows[linha].Cells[1].Value = itemFornecido.IdFornecedor;
                dgvitfor.Rows[linha].Cells[2].Value = itemFornecido.IdProduto;
                dgvitfor.Rows[linha].Cells[3].Value = itemFornecido.Quantidade;
                dgvitfor.Rows[linha].Cells[4].Value = itemFornecido.Modelo;
                dgvitfor.Rows[linha].Cells[5].Value = itemFornecido.Nome;
                linha++;
            }
        }

        // Evento de clique no DataGridView para preencher os campos
        private void dgvitfor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvitfor.CurrentRow.Index;
                int idItemFornecido = Convert.ToInt32(dgvitfor.Rows[linhaAtual].Cells[0].Value);
                var itemFornecido = ItemFornecido.ObterPorId(idItemFornecido);
                textIditemfor.Text = itemFornecido.IdItemFornecido.ToString();
                textIdFornecedor.Text = itemFornecido.IdFornecedor.ToString();
                textIdProduto.Text = itemFornecido.IdProduto.ToString();
                textquant.Text = itemFornecido.Quantidade.ToString();
                textmod.Text = itemFornecido.Modelo;
                textnome.Text = itemFornecido.Nome;
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            textIditemfor.Text = "";
            textIdFornecedor.Text = "";
            textIdProduto.Text = "";
            textquant.Text = "";
            textmod.Text = "";
            textnome.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        // Método para validar os campos
        private bool ValidarCampos()
        {
            if (!int.TryParse(textIdFornecedor.Text, out int idFornecedor) || idFornecedor <= 0)
            {
                MessageBox.Show("Informe um ID de fornecedor válido maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textIdFornecedor.Focus();
                return false;
            }

            if (!int.TryParse(textIdProduto.Text, out int idProduto) || idProduto <= 0)
            {
                MessageBox.Show("Informe um ID de produto válido maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textIdProduto.Focus();
                return false;
            }

            if (!decimal.TryParse(textquant.Text, out decimal quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textquant.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textmod.Text))
            {
                MessageBox.Show("Informe o modelo do item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textmod.Focus();
                return false;
            }

            if (textmod.Text.Length > 45)
            {
                MessageBox.Show("O modelo não pode exceder 45 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textmod.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textnome.Text))
            {
                MessageBox.Show("Informe o nome do item.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textnome.Focus();
                return false;
            }

            if (textnome.Text.Length > 60)
            {
                MessageBox.Show("O nome não pode exceder 60 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textnome.Focus();
                return false;
            }

            return true;
        }
    }
}