using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using coldmakClass;

namespace coldmakClass
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NivelId { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }

        public Nivel Nivel { get; set; }

        public Usuario()
        {
            Nivel = new();
        }

        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email, string telefone, DateTime dataNascimento, int nivelId, bool ativo)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            NivelId = nivelId;
            Ativo = ativo;
        }

        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email, string telefone, Nivel nivel)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
            Nivel = nivel;
        }

        public Usuario(string nome, string email, string senha, Nivel nivel)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }

        public Usuario(string nome, string email, string senha, Nivel nivel, bool ativo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }

        public Usuario(int id, string nome, string email, string senha, Nivel nivel, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
            Ativo = ativo;
        }

        public Usuario(int id, string nome, string rg, string cpf, string endereco, string cep, string email, string telefone, DateTime dataNascimento, int nivelId, bool ativo)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            NivelId = nivelId;
            Ativo = ativo;
        }

        // Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_insert";
            cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("sprg", Rg);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("spendereco", Endereco);
            cmd.Parameters.AddWithValue("spcep", Cep);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spdata_nascimento", DataNascimento);
            cmd.Parameters.AddWithValue("spnivelid", NivelId);
            cmd.Parameters.AddWithValue("spativo", Ativo);
            cmd.Parameters.AddWithValue("spsenha", Senha);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Id = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // ObterPorId
        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usuarios where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new Usuario(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetString(6),
                    dr.GetString(7),
                    dr.GetDateTime(8),
                    dr.GetInt32(9),
                    dr.GetBoolean(10)

                );
            }
            return usuario;
        }

        public static List<Usuario> ObterLista()
        {
            List<Usuario> lista = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usuarios order by nome asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Usuario(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetString(6),
                    dr.GetString(7),
                    dr.GetDateTime(8),
                    dr.GetInt32(9),
                    dr.GetBoolean(10)

                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_altera";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("sprg", Rg);
            cmd.Parameters.AddWithValue("spcpf", Cpf);
            cmd.Parameters.AddWithValue("spendereco", Endereco);
            cmd.Parameters.AddWithValue("spcep", Cep);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spdata_nascimento", DataNascimento);
            cmd.Parameters.AddWithValue("spnivelid", NivelId);
            cmd.Parameters.AddWithValue("spativo", Ativo);
            cmd.Parameters.AddWithValue("spsenha", Senha);

            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Efetuar login
        public static Usuario EfetuarLogin(string email, string senha)
        {
            Usuario usuario = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from usuarios where email = '{email}' and senha = md5('{senha}') and ativo = 1";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usuario = new Usuario(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetString(6),
                    dr.GetString(7),
                    dr.GetDateTime(8),
                    dr.GetInt32(9),
                    dr.GetBoolean(10)

                );
            }
            return usuario;
        }
    }
}