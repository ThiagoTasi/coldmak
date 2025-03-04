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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataNascimento;
                if (DateTime.TryParse(textDataNascimento.Text, out dataNascimento))
                {
                    Usuario usuario = new Usuario(
                        textNome.Text,
                        textRg.Text,
                        textCpf.Text,
                        textEndereco.Text,
                        textCep.Text,
                        textEmail.Text,
                        textTelefone.Text,
                        dataNascimento,
                        Convert.ToInt32(cmbNivel.SelectedValue),
                        chkAtivo.Checked,
                        textSenha.Text
                    );

                    usuario.Inserir();

                    if (usuario.Id > 0)
                    {
                        CarregaGridUsuarios();
                        MessageBox.Show($"Usuário {usuario.Nome} inserido com sucesso");
                        btnInserir.Enabled = false;
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Formato de data inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvUsuarios.Rows[linha].Cells[8].Value = usuario.DataNascimento;
                dgvUsuarios.Rows[linha].Cells[9].Value = usuario.Nivel.Nome;
                dgvUsuarios.Rows[linha].Cells[10].Value = usuario.Ativo;
                linha++;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvUsuarios.CurrentRow.Index;
                int idUser = Convert.ToInt32(dgvUsuarios.Rows[linhaAtual].Cells[0].Value);
                var usuario = Usuario.ObterPorId(idUser);
                textId.Text = usuario.Id.ToString();
                textNome.Text = usuario.Nome;
                textRg.Text = usuario.Rg;
                textCpf.Text = usuario.Cpf;
                textEndereco.Text = usuario.Endereco;
                textCep.Text = usuario.Cep;
                textEmail.Text = usuario.Email;
                textTelefone.Text = usuario.Telefone;
                textDataNascimento.Text = usuario.DataNascimento.ToString("dd/MM/yyyy");
                chkAtivo.Checked = usuario.Ativo;
                cmbNivel.SelectedValue = usuario.NivelId;
                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id = int.Parse(textId.Text);
                usuario.Nome = textNome.Text;
                usuario.Rg = textRg.Text;
                usuario.Cpf = textCpf.Text;
                usuario.Endereco = textEndereco.Text;
                usuario.Cep = textCep.Text;
                usuario.Email = textEmail.Text;
                usuario.Telefone = textTelefone.Text;

                DateTime dataNascimento;
                if (DateTime.TryParse(textDataNascimento.Text, out dataNascimento))
                {
                    usuario.DataNascimento = dataNascimento;
                }
                else
                {
                    MessageBox.Show("Formato de data inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                usuario.NivelId = Convert.ToInt32(cmbNivel.SelectedValue);
                usuario.Ativo = chkAtivo.Checked;
                usuario.Senha = textSenha.Text;

                if (usuario.Atualizar())
                {
                    CarregaGridUsuarios();
                    MessageBox.Show("Usuário atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = int.Parse(textId.Text);
                Usuario usuario = Usuario.ObterPorId(idUsuario);

                if (usuario != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o usuário {usuario.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (usuario.Deletar())
                        {
                            CarregaGridUsuarios();
                            MessageBox.Show("Usuário excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textNome.Text = "";
            textRg.Text = "";
            textCpf.Text = "";
            textEndereco.Text = "";
            textCep.Text = "";
            textEmail.Text = "";
            textTelefone.Text = "";
            textDataNascimento.Text = "";
            chkAtivo.Checked = false;
            cmbNivel.SelectedIndex = 0;
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