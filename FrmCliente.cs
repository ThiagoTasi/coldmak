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
                int idade = int.Parse(textIdade.Text);

                Cliente cliente = new Cliente(
                    textNome.Text,
                    textRg.Text,
                    textCpf.Text,
                    textCnpj.Text,
                    textEmail.Text,
                    textTelefone.Text,
                    dataNascimento,
                    idade
                );

                cliente.Inserir();

                if (cliente.Id > 0)
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
                dgvCliente.Rows[linha].Cells[0].Value = cliente.Id;
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
                textId.Text = cliente.Id.ToString();
                textRg.Text = cliente.Rg;
                textCpf.Text = cliente.Cpf;
                textCnpj.Text = cliente.Cnpj;
                textNome.Text = cliente.Nome;
                textEmail.Text = cliente.Email;
                textTelefone.Text = cliente.Telefone;
                textDataNasc.Text = cliente.DataNascimento.ToString("yyyy-MM-dd");
                textIdade.Text = cliente.IdadeCliente.ToString();
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(textId.Text);
                cliente.Nome = textNome.Text;
                cliente.Rg = textRg.Text;
                cliente.Cpf = textCpf.Text;
                cliente.Cnpj = textCnpj.Text;
                cliente.Email = textEmail.Text;
                cliente.Telefone = textTelefone.Text;
                cliente.DataNascimento = DateTime.ParseExact(textDataNasc.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                cliente.IdadeCliente = int.Parse(textIdade.Text);

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
            // ... (código do método btnDeletar_Click)
        }

        private void LimparCampos()
        {
            // ... (código do método LimparCampos)
        }
    }
}