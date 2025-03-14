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
using static System.Net.Mime.MediaTypeNames;

namespace coldmakApp
{
    public partial class FrmEnderecos : Form
    {
        public FrmEnderecos()
        {
            InitializeComponent();
        }

        private void FrmEnderecos_Load(object sender, EventArgs e)
        {
            CarregaGridEnderecos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco(
                    textCep.Text,
                    textLogra.Text,
                    textNumRes.Text,
                    textComple.Text,
                    textBairro.Text,
                    textCidade.Text,
                    textUf.Text
                );

                endereco.Inserir();

                if (endereco.IdEndereco > 0)
                {
                    CarregaGridEnderecos();
                    MessageBox.Show($"Endereço inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridEnderecos()
        {
            dgvEndereco.Rows.Clear();
            var listaDeEnderecos = Endereco.ObterLista();
            int linha = 0;
            foreach (var endereco in listaDeEnderecos)
            {
                dgvEndereco.Rows.Add();
                dgvEndereco.Rows[linha].Cells[0].Value = endereco.IdEndereco;
                dgvEndereco.Rows[linha].Cells[1].Value = endereco.Cep;
                dgvEndereco.Rows[linha].Cells[2].Value = endereco.Logradouro;
                dgvEndereco.Rows[linha].Cells[3].Value = endereco.NumeroResidencial;
                dgvEndereco.Rows[linha].Cells[4].Value = endereco.Complemento;
                dgvEndereco.Rows[linha].Cells[5].Value = endereco.Bairro;
                dgvEndereco.Rows[linha].Cells[6].Value = endereco.Cidade;
                dgvEndereco.Rows[linha].Cells[7].Value = endereco.UF;
                linha++;
            }
        }

        private void dgvEnderecos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvEndereco.CurrentRow.Index;
                int idEndereco = Convert.ToInt32(dgvEndereco.Rows[linhaAtual].Cells[0].Value);
                var endereco = Endereco.ObterPorId(idEndereco);
                textId.Text = endereco.IdEndereco.ToString();
                textCep.Text = endereco.Cep;
                textLogra.Text = endereco.Logradouro;
                textNumRes.Text = endereco.NumeroResidencial;
                textComple.Text = endereco.Complemento;
                textBairro.Text = endereco.Bairro;
                textCidade.Text = endereco.Cidade;
                textUf.Text = endereco.UF;
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco();
                endereco.IdEndereco = int.Parse(textId.Text);
                endereco.Cep = textCep.Text;
                endereco.Logradouro = textLogra.Text;
                endereco.NumeroResidencial = textNumRes.Text;
                endereco.Complemento = textComple.Text;
                endereco.Bairro = textBairro.Text;
                endereco.Cidade = textCidade.Text;
                endereco.UF = textUf.Text;

                if (endereco.Atualizar())
                {
                    CarregaGridEnderecos();
                    MessageBox.Show("Endereço atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idEndereco = int.Parse(textId.Text);
                Endereco endereco = Endereco.ObterPorId(idEndereco);

                if (endereco != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o endereço {endereco.Logradouro}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (endereco.Deletar())
                        {
                            CarregaGridEnderecos();
                            MessageBox.Show("Endereço excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o endereço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Endereço não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir endereço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textCep.Text = "";
            textLogra.Text = "";
            textNumRes.Text = "";
            textComple.Text = "";
            textBairro.Text = "";
            textCidade.Text = "";
            textUf.Text = "";
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
            btnInserir.Enabled = true;
        }

        private void btnDeletar_Click_1(object sender, EventArgs e)
        {

        }
    }
}