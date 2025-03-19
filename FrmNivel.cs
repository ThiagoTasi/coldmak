using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coldmakApp

{
    public partial class FrmNiveis : Form
    {
        public FrmNiveis()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=127.0.0.1;database=coldmak;user=root;password=";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdNivel, Nome, Sigla FROM nivel";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Limpa e configura as colunas manualmente
                        dgvNiveis.Columns.Clear();
                        dgvNiveis.AutoGenerateColumns = false;

                        dgvNiveis.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "colIdNivel",
                            HeaderText = "IdNivel",
                            DataPropertyName = "IdNivel",
                            Visible = true
                        });
                        dgvNiveis.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "colNome",
                            HeaderText = "Nome",
                            DataPropertyName = "Nome",
                            Visible = true
                        });
                        dgvNiveis.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            Name = "colSigla",
                            HeaderText = "Sigla",
                            DataPropertyName = "Sigla",
                            Visible = true
                        });

                        // Define o DataSource apenas se houver dados
                        if (dt.Rows.Count > 0)
                        {
                            dgvNiveis.DataSource = dt;
                            MessageBox.Show("Dados carregados com sucesso! " + dt.Rows.Count + " registros.");
                        }
                        else
                        {
                            dgvNiveis.DataSource = null;
                            MessageBox.Show("Nenhum registro encontrado na tabela 'nivel'.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNiveis.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvNiveis.SelectedRows[0].Cells[0].Value);
                    string novoValor = textNome.Text.Trim();

                    if (string.IsNullOrEmpty(novoValor))
                    {
                        MessageBox.Show("Por favor, insira um valor para o campo Nome!");
                        return;
                    }

                    string connectionString = "server=127.0.0.1;database=coldmak;user=root;password=";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE nivel SET Nome = @valor WHERE IdNivel = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@valor", novoValor);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    btnListar_Click(sender, e);
                    MessageBox.Show("Registro atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para atualizar!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNiveis.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvNiveis.SelectedRows[0].Cells[0].Value);

                    DialogResult result = MessageBox.Show("Tem certeza de que deseja deletar este registro?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string connectionString = "server=127.0.0.1;database=coldmak;user=root;password=";
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM nivel WHERE IdNivel = @id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        btnListar_Click(sender, e);
                        MessageBox.Show("Registro deletado com sucesso!");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para deletar!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar: " + ex.Message);
            }
        }
    }
}