
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_nivel_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsigla", Sigla);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdNivel = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static Nivel ObterPorId(int idNivel)
        {
            Nivel nivel = new Nivel();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from niveis where id_nivel = {idNivel}"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nivel = new Nivel(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2)
                );
            }
            return nivel;
        }

        public static List<Nivel> ObterLista()
        {
            List<Nivel> lista = new List<Nivel>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from niveis order by nome asc"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Nivel(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_nivel_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidnivel", IdNivel);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spsigla", Sigla);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_nivel_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidnivel", IdNivel);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}