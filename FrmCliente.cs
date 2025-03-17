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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CarregaGridClientes();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataNascimento = DateTime.ParseExact(textDataNasc.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                int idadeCliente = int.Parse(textIdadeCliente.Text);

                Cliente cliente = new Cliente(
                    textRg.Text,
                    textCpf.Text,
                    textCnpj.Text,
                    textNome.Text,
                    textEmail.Text,
                    textTelefone.Text,
                    dataNascimento,
                    idadeCliente
                );

                cliente.Inserir();

                if (cliente.IdCliente > 0)
                {
                    CarregaGridClientes();
                    MessageBox.Show($"Cliente {cliente.Nome} inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data ou idade inválido. Use AAAA-MM-DD para data.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridClientes()
        {
            dgvCliente.Rows.Clear();
            var listaDeClientes = Cliente.ObterLista();
            int linha = 0;
            foreach (var cliente in listaDeClientes)
            {
                dgvCliente.Rows.Add();
                dgvCliente.Rows[linha].Cells[0].Value = cliente.IdCliente;
                dgvCliente.Rows[linha].Cells[1].Value = cliente.Rg;
                dgvCliente.Rows[linha].Cells[2].Value = cliente.Cpf;
                dgvCliente.Rows[linha].Cells[3].Value = cliente.Cnpj;
                dgvCliente.Rows[linha].Cells[4].Value = cliente.Nome;
                dgvCliente.Rows[linha].Cells[5].Value = cliente.Email;
                dgvCliente.Rows[linha].Cells[6].Value = cliente.Telefone;
                dgvCliente.Rows[linha].Cells[7].Value = cliente.DataNascimento.ToString("yyyy-MM-dd");
                dgvCliente.Rows[linha].Cells[8].Value = cliente.IdadeCliente;
                linha++;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvCliente.CurrentRow.Index;
                int idCliente = Convert.ToInt32(dgvCliente.Rows[linhaAtual].Cells[0].Value);
                var cliente = Cliente.ObterPorId(idCliente);
                textIdCliente.Text = cliente.IdCliente.ToString();
                textRg.Text = cliente.Rg;
                textCpf.Text = cliente.Cpf;
                textCnpj.Text = cliente.Cnpj;
                textNome.Text = cliente.Nome;
                textEmail.Text = cliente.Email;
                textTelefone.Text = cliente.Telefone;
                textDataNasc.Text = cliente.DataNascimento.ToString("yyyy-MM-dd");
                textIdadeCliente.Text = cliente.IdadeCliente.ToString();
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = int.Parse(textIdCliente.Text);
                cliente.Rg = textRg.Text;
                cliente.Cpf = textCpf.Text;
                cliente.Cnpj = textCnpj.Text;
                cliente.Nome = textNome.Text;
                cliente.Email = textEmail.Text;
                cliente.Telefone = textTelefone.Text;
                cliente.DataNascimento = DateTime.ParseExact(textDataNasc.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                cliente.IdadeCliente = int.Parse(textIdadeCliente.Text);

                if (cliente.Atualizar())
                {
                    CarregaGridClientes();
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data ou idade inválido. Use AAAA-MM-DD para data.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(textIdCliente.Text);
                Cliente cliente = Cliente.ObterPorId(idCliente);

                if (cliente != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o cliente {cliente.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cliente.Deletar())
                        {
                            CarregaGridClientes();
                            MessageBox.Show("Cliente excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textIdCliente.Text = "";
            textRg.Text = "";
            textCpf.Text = "";
            textCnpj.Text = "";
            textNome.Text = "";
            textEmail.Text = "";
            textTelefone.Text = "";
            textDataNasc.Text = "";
            textIdadeCliente.Text = "";
            btnAtualizar.Enabled = true;
            btnDeletar.Enabled = true;
            btnInserir.Enabled = true;
        }

        
    }
}
