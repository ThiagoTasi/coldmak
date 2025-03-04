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
    public partial class FrmNiveis : Form
    {
        public FrmNiveis()
        {
            InitializeComponent();
        }

        private void FrmNiveis_Load(object sender, EventArgs e)
        {
            CarregaGridNiveis();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Nivel nivel = new Nivel(
                    textNome.Text,
                    textSigla.Text
                );

                nivel.Inserir();

                if (nivel.Id_Nivel > 0)
                {
                    CarregaGridNiveis();
                    MessageBox.Show($"Nível {nivel.Nome} inserido com sucesso");
                    btnInserir.Enabled = false;
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir nível: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaGridNiveis()
        {
            dgvNiveis.Rows.Clear();
            var listaDeNiveis = Nivel.ObterLista();
            int linha = 0;
            foreach (var nivel in listaDeNiveis)
            {
                dgvNiveis.Rows.Add();
                dgvNiveis.Rows[linha].Cells[0].Value = nivel.Id_Nivel;
                dgvNiveis.Rows[linha].Cells[1].Value = nivel.Nome;
                dgvNiveis.Rows[linha].Cells[2].Value = nivel.Sigla;
                linha++;
            }
        }

        private void dgvNiveis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int linhaAtual = dgvNiveis.CurrentRow.Index;
                int idNivel = Convert.ToInt32(dgvNiveis.Rows[linhaAtual].Cells[0].Value);
                var nivel = Nivel.ObterPorId(idNivel);

                textId.Text = nivel.Id_Nivel.ToString();
                textNome.Text = nivel.Nome;
                textSigla.Text = nivel.Sigla;

                btnAtualizar.Enabled = true;
                btnDeletar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Nivel nivel = new Nivel(
                    int.Parse(textId.Text),
                    textNome.Text,
                    textSigla.Text
                );

                if (nivel.Atualizar())
                {
                    CarregaGridNiveis();
                    MessageBox.Show("Nível atualizado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar nível: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int idNivel = int.Parse(textId.Text);
                Nivel nivel = Nivel.ObterPorId(idNivel);

                if (nivel != null)
                {
                    if (MessageBox.Show($"Deseja realmente excluir o nível {nivel.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (nivel.Deletar())
                        {
                            CarregaGridNiveis();
                            MessageBox.Show("Nível excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir o nível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nível não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir nível: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textId.Text = "";
            textNome.Text = "";
            textSigla.Text = "";

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