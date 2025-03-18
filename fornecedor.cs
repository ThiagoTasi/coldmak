using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        private const string ConnectionString = "Server=localhost;Database=coldmak;User=root;Password=;";

        public Fornecedor()
        {
        }

        public Fornecedor(string razaoSocial, string fantasia, string cnpj, string telefone, string email)
        {
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public Fornecedor(int idFornecedor, string razaoSocial, string fantasia, string cnpj, string telefone, string email)
        {
            IdFornecedor = idFornecedor;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public bool Inserir(out string erro, out int idFornecedor)
        {
            erro = string.Empty;
            idFornecedor = 0;
            try
            {
                // Validações básicas
                if (string.IsNullOrWhiteSpace(RazaoSocial))
                {
                    erro = "Razão Social é obrigatória.";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Cnpj))
                {
                    erro = "CNPJ é obrigatório.";
                    return false;
                }

                // Verificar se o CNPJ já existe
                if (CnpjExiste(Cnpj, out string erroVerificacao))
                {
                    erro = "CNPJ já cadastrado. Por favor, use um CNPJ diferente.";
                    return false;
                }
                if (!string.IsNullOrEmpty(erroVerificacao))
                {
                    erro = $"Erro ao verificar CNPJ: {erroVerificacao}";
                    return false;
                }

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("sp_fornecedor_insert", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_RazaoSocial", RazaoSocial);
                        cmd.Parameters.AddWithValue("@p_Fantasia", Fantasia);
                        cmd.Parameters.AddWithValue("@p_Cnpj", Cnpj);
                        cmd.Parameters.AddWithValue("@p_Telefone", Telefone);
                        cmd.Parameters.AddWithValue("@p_Email", Email);

                        var idParam = new MySqlParameter("@p_IdFornecedor", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(idParam);

                        cmd.ExecuteNonQuery();

                        idFornecedor = Convert.ToInt32(idParam.Value);
                        IdFornecedor = idFornecedor;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao inserir fornecedor: {ex.Message}";
                return false;
            }
        }

        public static bool CnpjExiste(string cnpj, out string erro)
        {
            erro = string.Empty;
            try
            {
                // Padronizar o CNPJ: remover pontos, barras, hífens e espaços
                string cnpjLimpo = cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM fornecedor WHERE TRIM(REPLACE(REPLACE(REPLACE(Cnpj, '.', ''), '/', ''), '-', '')) = @Cnpj", conn))
                    {
                        cmd.Parameters.AddWithValue("@Cnpj", cnpjLimpo);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        // Adicionar depuração
                        Console.WriteLine($"CNPJ verificado: {cnpjLimpo}, Count: {count}");
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao verificar CNPJ: {ex.Message}";
                return false;
            }
        }
        public static Fornecedor ObterPorId(int idFornecedor, out string erro)
        {
            erro = string.Empty;
            Fornecedor fornecedor = null;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM fornecedor WHERE IdFornecedor = @IdFornecedor", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdFornecedor", idFornecedor);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                fornecedor = new Fornecedor(
                                    dr.GetInt32("IdFornecedor"),
                                    dr.GetString("RazaoSocial"),
                                    dr.GetString("Fantasia"),
                                    dr.GetString("Cnpj"),
                                    dr.GetString("Telefone"),
                                    dr.GetString("Email")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao obter fornecedor por ID: {ex.Message}";
            }
            return fornecedor;
        }

        public static List<Fornecedor> ObterLista(out string erro)
        {
            erro = string.Empty;
            List<Fornecedor> lista = new List<Fornecedor>();
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT * FROM fornecedor ORDER BY RazaoSocial ASC", conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Fornecedor(
                                    dr.GetInt32("IdFornecedor"),
                                    dr.GetString("RazaoSocial"),
                                    dr.GetString("Fantasia"),
                                    dr.GetString("Cnpj"),
                                    dr.GetString("Telefone"),
                                    dr.GetString("Email")
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao obter lista de fornecedores: {ex.Message}";
            }
            return lista;
        }

        public bool Atualizar(out string erro)
        {
            erro = string.Empty;
            try
            {
                if (IdFornecedor <= 0)
                {
                    erro = "ID do fornecedor inválido.";
                    return false;
                }

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("sp_fornecedor_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_IdFornecedor", IdFornecedor);
                        cmd.Parameters.AddWithValue("@p_RazaoSocial", RazaoSocial);
                        cmd.Parameters.AddWithValue("@p_Fantasia", Fantasia);
                        cmd.Parameters.AddWithValue("@p_Cnpj", Cnpj);
                        cmd.Parameters.AddWithValue("@p_Telefone", Telefone);
                        cmd.Parameters.AddWithValue("@p_Email", Email);

                        var rowsAffectedParam = new MySqlParameter("@p_RowsAffected", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(rowsAffectedParam);

                        cmd.ExecuteNonQuery();

                        int rowsAffected = Convert.ToInt32(rowsAffectedParam.Value);
                        Console.WriteLine($"Atualizar - ID: {IdFornecedor}, Rows Affected: {rowsAffected}"); // Depuração
                        if (rowsAffected == 0)
                        {
                            erro = "Nenhuma linha foi atualizada. Verifique se o ID do fornecedor existe.";
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao atualizar fornecedor: {ex.Message}";
                return false;
            }
        }
        public bool Deletar(out string erro)
        {
            erro = string.Empty;
            try
            {
                if (IdFornecedor <= 0)
                {
                    erro = "ID do fornecedor inválido.";
                    return false;
                }

                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("sp_delete_fornecedor", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@p_IdFornecedor", IdFornecedor);

                        var rowsAffectedParam = new MySqlParameter("@p_RowsAffected", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(rowsAffectedParam);

                        cmd.ExecuteNonQuery();

                        int rowsAffected = Convert.ToInt32(rowsAffectedParam.Value);
                        Console.WriteLine($"Deletar - ID: {IdFornecedor}, Rows Affected: {rowsAffected}"); // Depuração
                        if (rowsAffected == 0)
                        {
                            erro = "Nenhuma linha foi excluída. Verifique se o ID do fornecedor existe.";
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = $"Erro ao deletar fornecedor: {ex.Message}";
                return false;
            }
        }
    }
}