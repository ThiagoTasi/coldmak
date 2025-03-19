using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public Nivel()
        {
        }

        public Nivel(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }

        public Nivel(int idNivel, string nome, string sigla)
        {
            IdNivel = idNivel;
            Nome = nome;
            Sigla = sigla;
        }

        public void Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nivel_insert";
                cmd.Parameters.AddWithValue("spnome", Nome ?? string.Empty);
                cmd.Parameters.AddWithValue("spsigla", Sigla ?? string.Empty);

                // Log para depuração
                System.IO.File.AppendAllText("insercao_log.txt", $"Inserir chamado: Nome={Nome}, Sigla={Sigla}, Data={DateTime.Now}\n");

                cmd.ExecuteNonQuery();

                // Captura o resultado retornado pela stored procedure
                var reader = cmd.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    IdNivel = reader.GetInt32("IdNivel");
                }
                else
                {
                    IdNivel = 0; // Caso a inserção não ocorra (ex.: duplicata evitada)
                }
                reader.Close();
                cmd.Connection.Close();

                // Log do resultado
                System.IO.File.AppendAllText("insercao_log.txt", $"Inserção concluída: IdNivel={IdNivel}, Data={DateTime.Now}\n");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir nível: {ex.Message}");
            }
        }

        public static Nivel ObterPorId(int idNivel)
        {
            Nivel nivel = null;
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "SELECT * FROM nivel WHERE IdNivel = @idNivel";
                cmd.Parameters.AddWithValue("@idNivel", idNivel);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nivel = new Nivel(
                        dr.GetInt32("IdNivel"),
                        dr.GetString("Nome"),
                        dr.GetString("Sigla")
                    );
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter nível por ID: {ex.Message}");
            }
            return nivel;
        }

        public static List<Nivel> ObterLista()
        {
            List<Nivel> lista = new List<Nivel>();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "SELECT * FROM nivel ORDER BY Nome ASC";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Nivel(
                        dr.GetInt32("IdNivel"),
                        dr.GetString("Nome"),
                        dr.GetString("Sigla")
                    ));
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter lista de níveis: {ex.Message}");
            }
            return lista;
        }

        public bool Atualizar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nivel_update";
                cmd.Parameters.AddWithValue("spidnivel", IdNivel);
                cmd.Parameters.AddWithValue("spnome", Nome ?? string.Empty);
                cmd.Parameters.AddWithValue("spsigla", Sigla ?? string.Empty);
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar nível: {ex.Message}");
            }
        }

        public bool Deletar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_nivel_delete";
                cmd.Parameters.AddWithValue("spidnivel", IdNivel);
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar nível: {ex.Message}");
            }
        }
    }
}