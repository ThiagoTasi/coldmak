using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class OrdemdeServico
    {
        public int IdOrdemdeServico { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }

        public OrdemdeServico()
        {
        }

        public OrdemdeServico(int idUsuario, int idCliente, DateTime data, string status, decimal desconto, decimal valorTotal)
        {
            IdUsuario = idUsuario;
            IdCliente = idCliente;
            Data = data;
            Status = status;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public OrdemdeServico(int idOrdemDeServico, int idUsuario, int idCliente, DateTime data, string status, decimal desconto, decimal valorTotal)
        {
            IdOrdemdeServico = idOrdemDeServico;
            IdUsuario = idUsuario;
            IdCliente = idCliente;
            Data = data;
            Status = status;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public void Inserir()
        {
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ordemdeservico_insert";
                    cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("spidcliente", IdCliente);
                    cmd.Parameters.AddWithValue("spdata", Data);
                    cmd.Parameters.AddWithValue("spstatus", Status);
                    cmd.Parameters.AddWithValue("spdesconto", Desconto);
                    cmd.Parameters.AddWithValue("spvalortotal", ValorTotal);
                    cmd.Parameters.Add("spidordem", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Recupera o ID gerado
                    IdOrdemdeServico = cmd.Parameters["spidordem"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["spidordem"].Value) : -1;

                    if (IdOrdemdeServico == -1)
                    {
                        throw new Exception("Falha na inserção. Verifique se os IDs de Usuário e Cliente existem.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao inserir ordem de serviço: " + ex.Message);
                }
            }
        }

        public static OrdemdeServico ObterPorId(int idOrdemDeServico)
        {
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM ordemdeservico WHERE IdOrdemDeServico = @id";
                    cmd.Parameters.AddWithValue("@id", idOrdemDeServico);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new OrdemdeServico(
                                dr.GetInt32("IdOrdemDeServico"),
                                dr.GetInt32("IdUsuario"),
                                dr.GetInt32("IdCliente"),
                                dr.GetDateTime("Data"),
                                dr.GetString("Status"),
                                dr.GetDecimal("Desconto"),
                                dr.GetDecimal("ValorTotal")
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter ordem de serviço por ID: " + ex.Message);
                }
            }
            return null;
        }

        public static List<OrdemdeServico> ObterLista()
        {
            var lista = new List<OrdemdeServico>();
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM ordemdeservico ORDER BY Data DESC";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new OrdemdeServico(
                                dr.GetInt32("IdOrdemDeServico"),
                                dr.GetInt32("IdUsuario"),
                                dr.GetInt32("IdCliente"),
                                dr.GetDateTime("Data"),
                                dr.GetString("Status"),
                                dr.GetDecimal("Desconto"),
                                dr.GetDecimal("ValorTotal")
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter lista de ordens de serviço: " + ex.Message);
                }
            }
            return lista;
        }

        public bool Atualizar()
        {
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ordemdeservico_update";
                    cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);
                    cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("spidcliente", IdCliente);
                    cmd.Parameters.AddWithValue("spdata", Data);
                    cmd.Parameters.AddWithValue("spstatus", Status);
                    cmd.Parameters.AddWithValue("spdesconto", Desconto);
                    cmd.Parameters.AddWithValue("spvalortotal", ValorTotal);

                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar ordem de serviço: " + ex.Message);
                }
            }
        }

        public bool Deletar()
        {
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_delete_ordemdeservico";
                    cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);

                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    return linhasAfetadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao deletar ordem de serviço: " + ex.Message);
                }
            }
        }
    }
}