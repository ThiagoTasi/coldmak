using coldmak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coldmak
{
    public partial class Frmusuario : Form
    {
        public Frmusuario()
        {
            InitializeComponent();
        }
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            // carregando o comboBox de níveis 
            cmbNivel.DataSource = Nivel.ObterLista();
            cmbNivel.DisplayMember = "Nome";
            cmbNivel.ValueMember = "Id";

            // carregando o datagrid de usuários
            CarregaGridUsuarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Usuario usuario = new(
                txtNome.Text,
                txtRg.Text,
                txtCpf.Text,
                txtEndereco.Text,
                txtCep.Text,
                txtEmail.Text,
                txtTelefone.Text,
                txtSenha.Text,
                txtData_Nascimento.Text,
                Nivel.ObterPorId(Convert.ToInt32(cmbNivel.SelectedValue))
                );

            usuario.Inserir();
            if (usuario.Id > 0)
            {
                // carrega grid
                CarregaGridUsuarios();
                MessageBox.Show($"Usuário {usuario.Nome} inserido com sucesso");
                btnInserir.Enabled = false;
            }
        }
        private void CarregaGridUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            var listaDeUsuarios = Usuario.ObterLista();
            int linha = 0;
            foreach (var usuario in listaDeUsuarios)
            {
                dgvUsuarios.Rows.Add();
                dgvUsuarios.Rows[linha].Cells[0].Value = usuario.Id;
                dgvUsuarios.Rows[linha].Cells[1].Value = usuario.Nome;
                dgvUsuarios.Rows[linha].Cells[2].Value = usuario.Rg;
                dgvUsuarios.Rows[linha].Cells[3].Value = usuario.Cpf;
                dgvUsuarios.Rows[linha].Cells[4].Value = usuario.Endereco;
                dgvUsuarios.Rows[linha].Cells[5].Value = usuario.Cep;
                dgvUsuarios.Rows[linha].Cells[6].Value = usuario.Email;
                dgvUsuarios.Rows[linha].Cells[7].Value = usuario.Telefone;
                dgvUsuarios.Rows[linha].Cells[8].Value = usuario.Senha;
                dgvUsuarios.Rows[linha].Cells[9].Value = usuario.Data_nascimento;
                dgvUsuarios.Rows[linha].Cells[10].Value = usuario.Nivel.Nome;
                dgvUsuarios.Rows[linha].Cells[11].Value = usuario.Ativo;
                linha++;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linhaAtual = dgvUsuarios.CurrentRow.Index;
            int idUser = Convert.ToInt32(dgvUsuarios.Rows[linhaAtual].Cells[0].Value);
            var usuario = Usuario.ObterPorId(idUser);
            txtId.Text = usuario.Id.ToString();
            txtNome.Text = usuario.Nome;
            txtRg.Text = usuario.Rg;
            txtCpf.Text = usuario.Cpf;
            txtEndereco.Text = usuario.Endereco;
            txtCep.Text = usuario.Cep;
            txtEmail.Text = usuario.Email;
            txtTelefone.Text = usuario.Telefone;
            txtSenha.Text = usuario.Senha;
            txtData_Nascimento.Text = usuario.Data_nascimento;
            cmbNivel.SelectedValue = usuario.Nivel.Id;
            chkAtivo.Checked = usuario.Ativo;
            btnAtualizar.Enabled = true;

            //MessageBox.Show(idUser.ToString());
        }
    } 

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new();
            usuario.Id = int.Parse(txtId.Text);
            usuario.Nome = txtNome.Text;
            usuario.Rg = txtRg.Text;
            usuario.Cpf = txtCpf.Text;
            usuario.Endereco = txtEndereco.Text;
            usuario.Cep = txtCep.Text;
            usuario.Email = txtEmail.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Data_nascimento = txtData_Nascimento.Text;
            cmbNivel.SelectedValue = usuario.Nivel.Id;
            usuario.Ativo = chkAtivo.Checked;

            usuario.Nivel = Nivel.ObterPorId(Convert.ToInt32(cmbNivel.SelectedValue));
            if (usuario.Atualizar())
            {
                CarregaGridUsuarios();
                MessageBox.Show("Usuário atualizado com sucesso!");
            }

        }
    }
}

    



