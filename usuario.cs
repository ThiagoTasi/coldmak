using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NivelId { get; set; }
        public Nivel Nivel { get; set; }
        public bool Ativo { get; set; }

        public Usuario()
        {
            Nivel = new Nivel();
        }

        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email, string telefone, DateTime dataNascimento, int nivelId, bool ativo, string senha)
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
            Senha = Senha;
        }

        public Usuario(int id, string nome, string rg, string cpf, string endereco, string cep, string email, string telefone, DateTime dataNascimento, int nivelId, bool ativo, string senha)
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
            Senha = Senha;
        }

        public void Inserir()
        {
            try
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
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao inserir usuário: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir usuário: " + ex.Message);
                throw;
            }
        }

        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
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
                        dr.GetBoolean(10),
                        dr.GetString(11)
                    );
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao obter usuário por ID: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter usuário por ID: " + ex.Message);
                throw;
            }
            return usuario;
        }

        public static List<Usuario> ObterLista()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
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
                        dr.GetBoolean(10),
                        dr.GetString(11)
                    ));
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao obter lista de usuários: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter lista de usuários: " + ex.Message);
                throw;
            }
            return lista;
        }

        public bool Atualizar()
        {
            try
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
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao atualizar usuário: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar usuário: " + ex.Message);
                throw;
            }
        }

        public bool Deletar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_delete";
                cmd.Parameters.AddWithValue("spid", Id);
                cmd.ExecuteNonQuery();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao deletar usuário: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar usuário: " + ex.Message);
                throw;
            }
        }
    }
}
        