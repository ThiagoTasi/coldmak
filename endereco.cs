using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroResidencial { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        private const string ConnectionString = "Server=localhost;Database=coldmak;User=root;Password=;";

        public Endereco(string cep, string logradouro, string numeroResidencial, string complemento,
                       string bairro, string cidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            NumeroResidencial = numeroResidencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public Endereco()
        {
        }

        public bool Inserir(out string erro)
        {
            erro = string.Empty;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("sp_endereco_insert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@spcep", Cep);
                        cmd.Parameters.AddWithValue("@splogradouro", Logradouro);
                        cmd.Parameters.AddWithValue("@spnumeroresidencial", NumeroResidencial ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@spcomplemento", Complemento ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@spbairro", Bairro ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@spcidade", Cidade ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@spuf", UF);

                        var idParam = new MySqlParameter("p_IdEndereco", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(idParam);

                        cmd.ExecuteNonQuery();

                        if (idParam.Value != DBNull.Value)
                        {
                            IdEndereco = Convert.ToInt32(idParam.Value);
                        }
                        else
                        {
                            erro = "Parâmetro de saída p_IdEndereco não foi retornado.";
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }

        public bool Atualizar(out string erro)
        {
            erro = string.Empty;
            try
            {
                // Validações iniciais
                if (IdEndereco <= 0)
                {
                    erro = "ID do endereço inválido.";
                    MessageBox.Show(erro, "Depuração - Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexão com o banco de dados bem-sucedida para atualização!", "Depuração - Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (var cmd = new MySqlCommand("sp_endereco_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Adiciona os parâmetros com os nomes exatos esperados pela stored procedure
                        cmd.Parameters.AddWithValue("@p_IdEndereco", IdEndereco);
                        cmd.Parameters.AddWithValue("@p_Logradouro", Logradouro ?? (object)DBNull.Value);

                        // Parâmetro de saída
                        var rowsAffectedParam = new MySqlParameter("@p_rowsAffected", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(rowsAffectedParam);

                        // Depuração: Mostrar os valores dos parâmetros antes da execução
                        MessageBox.Show($"Parâmetros: p_IdEndereco = {IdEndereco}, p_Logradouro = {Logradouro ?? "null"}", "Depuração - Parâmetros", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmd.ExecuteNonQuery();

                        // Depuração: Verificar o valor retornado pelo parâmetro de saída
                        object rowsAffectedValue = rowsAffectedParam.Value;
                        MessageBox.Show($"Valor retornado para p_rowsAffected: {rowsAffectedValue ?? "null"}", "Depuração - Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        int rowsAffected;
                        if (rowsAffectedValue == null || rowsAffectedValue == DBNull.Value)
                        {
                            rowsAffected = 0;
                            erro = "Parâmetro p_rowsAffected retornou valor nulo ou inválido.";
                            MessageBox.Show(erro, "Depuração - Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            rowsAffected = Convert.ToInt32(rowsAffectedValue);
                        }

                        MessageBox.Show($"Linhas afetadas pela atualização: {rowsAffected}", "Depuração - Linhas Afetadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            erro = $"Nenhuma linha foi atualizada. Verifique se o ID {IdEndereco} existe na tabela endereco.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro na atualização: {ex.Message}";
                MessageBox.Show($"{erro}\nDetalhes: {ex.StackTrace}", "Erro Crítico - Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Deletar(out string erro)
        {
            erro = string.Empty;
            try
            {
                if (IdEndereco <= 0)
                {
                    erro = "ID do endereço inválido.";
                    return false;
                }

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexão com o banco de dados bem-sucedida para limpar o logradouro!", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (var cmd = new MySqlCommand("sp_delete_endereco", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_IdEndereco", IdEndereco);

                        cmd.Parameters.Add("@p_rowsAffected", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                        MessageBox.Show($"Parâmetro: p_IdEndereco = {IdEndereco}", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmd.ExecuteNonQuery();

                        int rowsAffected = Convert.ToInt32(cmd.Parameters["@p_rowsAffected"].Value);
                        MessageBox.Show($"Linhas afetadas pela atualização do logradouro: {rowsAffected}", "Depuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            erro = "Nenhuma linha foi atualizada. Verifique se o ID existe.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao limpar o logradouro: {ex.Message}";
                return false;
            }
        }

        public static List<Endereco> ObterLista(out string erro)
        {
            erro = string.Empty;
            var lista = new List<Endereco>();
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM endereco", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Endereco
                                {
                                    IdEndereco = reader.GetInt32("IdEndereco"),
                                    Cep = reader.GetString("Cep"),
                                    Logradouro = reader.GetString("Logradouro"),
                                    NumeroResidencial = reader.IsDBNull(reader.GetOrdinal("NumeroResidencial")) ? null : reader.GetString("NumeroResidencial"),
                                    Complemento = reader.IsDBNull(reader.GetOrdinal("Complemento")) ? null : reader.GetString("Complemento"),
                                    Bairro = reader.IsDBNull(reader.GetOrdinal("Bairro")) ? null : reader.GetString("Bairro"),
                                    Cidade = reader.IsDBNull(reader.GetOrdinal("Cidade")) ? null : reader.GetString("Cidade"),
                                    UF = reader.GetString("UF")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return lista;
        }

        public static Endereco ObterPorId(int id, out string erro)
        {
            erro = string.Empty;
            Endereco endereco = null;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM endereco WHERE IdEndereco = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                endereco = new Endereco
                                {
                                    IdEndereco = reader.GetInt32("IdEndereco"),
                                    Cep = reader.GetString("Cep"),
                                    Logradouro = reader.GetString("Logradouro"),
                                    NumeroResidencial = reader.IsDBNull(reader.GetOrdinal("NumeroResidencial")) ? null : reader.GetString("NumeroResidencial"),
                                    Complemento = reader.IsDBNull(reader.GetOrdinal("Complemento")) ? null : reader.GetString("Complemento"),
                                    Bairro = reader.IsDBNull(reader.GetOrdinal("Bairro")) ? null : reader.GetString("Bairro"),
                                    Cidade = reader.IsDBNull(reader.GetOrdinal("Cidade")) ? null : reader.GetString("Cidade"),
                                    UF = reader.GetString("UF")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return endereco;
        }
    }
}