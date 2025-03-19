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
using Microsoft.SqlServer.Server;
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
                // Validar se os campos obrigatórios estão preenchidos
                if (string.IsNullOrWhiteSpace(textNome.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de nome do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textDataNasc.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de data de nascimento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textIdadeCliente.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de idade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar o formato da data
                if (!DateTime.TryParse(textDataNasc.Text, out DateTime dataNascimento))
                {
                    MessageBox.Show("Formato de data inválido. Use yyyy-MM-dd para data.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar se a idade é um número inteiro válido
                if (!int.TryParse(textIdadeCliente.Text, out int idadeCliente))
                {
                    MessageBox.Show("A idade deve ser um número inteiro válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar o objeto Cliente e inserir
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
                // Verificar se uma linha foi selecionada no DataGridView
                if (dgvCliente.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecione um cliente no DataGridView para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obter o IdCliente diretamente do DataGridView
                int idCliente = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);

                // Validar se o campo de Nome não está vazio
                if (string.IsNullOrWhiteSpace(textNome.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de nome do cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Criar o objeto Cliente com os dados necessários
                Cliente cliente = new Cliente();
                cliente.IdCliente = idCliente;
                cliente.Nome = textNome.Text;

                // Executar a atualização
                if (cliente.Atualizar())
                {
                    CarregaGridClientes();
                    MessageBox.Show("Nome do cliente atualizado com sucesso!");
                    btnAtualizar.Enabled = false;
                    LimparCampos();
                }
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
                // Validar se o campo de email não está vazio
                if (string.IsNullOrWhiteSpace(textEmail.Text))
                {
                    MessageBox.Show("Por favor, preencha o campo de email.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validação básica de formato de email
                if (!textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
                {
                    MessageBox.Show("Por favor, insira um email válido (deve conter @ e .).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Se chegou até aqui, o email é válido
                Cliente cliente = new Cliente();
                cliente.Email = textEmail.Text;

                if (MessageBox.Show($"Deseja realmente excluir clientes com email {cliente.Email}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cliente.Deletar())
                    {
                        CarregaGridClientes();
                        MessageBox.Show("Cliente(s) excluído(s) com sucesso!");
                        btnDeletar.Enabled = false;
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao excluir o cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            btnInserir.Enabled = true;
            btnAtualizar.Enabled = false; // Desativar ao limpar
            btnDeletar.Enabled = false;   // Desativar ao limpar
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CarregaGridClientes();
        }

        private void FrmClientes_Load_1(object sender, EventArgs e)
        {

        }
    }
}