using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdNivel { get; set; }
        public bool Ativo { get; set; }
        public Nivel Nivel { get; set; }

        public Usuario()
        {
            Nivel = new Nivel();
        }

        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email,
                       string telefone, string senha, DateTime dataNascimento, int idNivel, bool ativo, Nivel nivel)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            DataNascimento = dataNascimento;
            IdNivel = idNivel;
            Ativo = ativo;
            Nivel = nivel ?? new Nivel();
        }

        public Usuario(int idUsuario, string nome, string rg, string cpf, string endereco, string cep,
                       string email, string telefone, string senha, DateTime dataNascimento, int idNivel,
                       bool ativo, Nivel nivel)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            DataNascimento = dataNascimento;
            IdNivel = idNivel;
            Ativo = ativo;
            Nivel = nivel ?? new Nivel();
        }

        public void Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_insert";
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spendereco", Endereco);
                cmd.Parameters.AddWithValue("spcep", Cep);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spsenha", Senha);
                cmd.Parameters.AddWithValue("spdata_nascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spid_nivel", IdNivel);
                cmd.Parameters.AddWithValue("spativo", Ativo ? 1 : 0);

                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
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
            Usuario usuario = null;
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "SELECT u.*, n.nome AS nivel_nome, n.sigla " +
                                 "FROM usuario u " +
                                 "LEFT JOIN nivel n ON u.IdNivel = n.IdNivel " +
                                 "WHERE u.IdUsuario = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string nivelNome = dr.IsDBNull(dr.GetOrdinal("nivel_nome")) ? null : dr.GetString("nivel_nome");
                    string nivelSigla = dr.IsDBNull(dr.GetOrdinal("sigla")) ? null : dr.GetString("sigla");
                    usuario = new Usuario(
                        dr.GetInt32("IdUsuario"),
                        dr.GetString("Nome"),
                        dr.GetString("Rg"),
                        dr.GetString("Cpf"),
                        dr.GetString("Endereco"),
                        dr.GetString("Cep"),
                        dr.GetString("Email"),
                        dr.GetString("Telefone"),
                        dr.GetString("Senha"),
                        dr.GetDateTime("DataNascimento"),
                        dr.GetInt32("IdNivel"),
                        dr.GetBoolean("Ativo"),
                        new Nivel(
                            dr.GetInt32("IdNivel"),
                            nivelNome,
                            nivelSigla
                        )
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
                cmd.CommandText = "SELECT u.*, n.nome AS nivel_nome, n.sigla " +
                                 "FROM usuario u " +
                                 "LEFT JOIN nivel n ON u.IdNivel = n.IdNivel " +
                                 "ORDER BY u.Nome ASC";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string nivelNome = dr.IsDBNull(dr.GetOrdinal("nivel_nome")) ? null : dr.GetString("nivel_nome");
                    string nivelSigla = dr.IsDBNull(dr.GetOrdinal("sigla")) ? null : dr.GetString("sigla");
                    var usuario = new Usuario(
                        dr.GetInt32("IdUsuario"),
                        dr.GetString("Nome"),
                        dr.GetString("Rg"),
                        dr.GetString("Cpf"),
                        dr.GetString("Endereco"),
                        dr.GetString("Cep"),
                        dr.GetString("Email"),
                        dr.GetString("Telefone"),
                        dr.GetString("Senha"),
                        dr.GetDateTime("DataNascimento"),
                        dr.GetInt32("IdNivel"),
                        dr.GetBoolean("Ativo"),
                        new Nivel(
                            dr.GetInt32("IdNivel"),
                            nivelNome,
                            nivelSigla
                        )
                    );
                    lista.Add(usuario);
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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_altera";
                cmd.Parameters.AddWithValue("spid_usuario", IdUsuario);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spendereco", Endereco);
                cmd.Parameters.AddWithValue("spcep", Cep);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spsenha", Senha);
                cmd.Parameters.AddWithValue("spdata_nascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spid_nivel", IdNivel);
                cmd.Parameters.AddWithValue("spativo", Ativo ? 1 : 0);
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowsAffected > 0;
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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_delete";
                cmd.Parameters.AddWithValue("spid_usuario", IdUsuario);
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowsAffected > 0;
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