using System;
using System.Collections.Generic;
using System.Data;
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
        public Nivel Nivel { get; set; } // Assumindo que Nivel é uma classe relacionada

        // Construtor padrão
        public Usuario()
        {
            Nivel = new Nivel();
        }

        // Construtor para inserção
        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email,
                       string telefone, string senha, DateTime dataNascimento, int idNivel, bool ativo)
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
            Nivel = new Nivel();
        }

        // Construtor completo
        public Usuario(int idUsuario, string nome, string rg, string cpf, string endereco, string cep,
                       string email, string telefone, string senha, DateTime dataNascimento, int idNivel,
                       bool ativo)
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
            Nivel = new Nivel();
        }

        // Método para inserir um usuário (sem parâmetro de saída p_idUsuario)
        public void Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_insert";
                cmd.Parameters.AddWithValue("p_nome", Nome ?? string.Empty);
                cmd.Parameters.AddWithValue("p_rg", Rg ?? string.Empty);
                cmd.Parameters.AddWithValue("p_cpf", Cpf ?? string.Empty);
                cmd.Parameters.AddWithValue("p_endereco", Endereco ?? string.Empty);
                cmd.Parameters.AddWithValue("p_cep", Cep ?? string.Empty);
                cmd.Parameters.AddWithValue("p_email", Email ?? string.Empty);
                cmd.Parameters.AddWithValue("p_telefone", Telefone ?? string.Empty);
                cmd.Parameters.AddWithValue("p_senha", Senha ?? string.Empty);
                cmd.Parameters.AddWithValue("p_dataNascimento", DataNascimento);
                cmd.Parameters.AddWithValue("p_idNivel", IdNivel);
                cmd.Parameters.AddWithValue("p_ativo", Ativo ? 1 : 0);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir usuário: {ex.Message}");
                throw;
            }
        }

        // Método para obter um usuário por ID
        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = null;
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "SELECT * FROM usuario WHERE IdUsuario = @id";
                cmd.Parameters.AddWithValue("@id", id);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
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
                        dr.GetBoolean("Ativo")
                    );
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter usuário por ID: {ex.Message}");
                throw;
            }
            return usuario;
        }

        // Método para obter a lista de usuários
        public static List<Usuario> ObterLista()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = "SELECT * FROM usuario ORDER BY Nome ASC";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Usuario(
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
                        dr.GetBoolean("Ativo")
                    ));
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter lista de usuários: {ex.Message}");
                throw;
            }
            return lista;
        }

        // Método para atualizar um usuário
        public bool Atualizar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_usuario_update";
                cmd.Parameters.AddWithValue("p_idusuario", IdUsuario);
                cmd.Parameters.AddWithValue("p_nome", Nome ?? string.Empty);
                cmd.Parameters.AddWithValue("p_rg", Rg ?? string.Empty);
                cmd.Parameters.AddWithValue("p_cpf", Cpf ?? string.Empty);
                cmd.Parameters.AddWithValue("p_endereco", Endereco ?? string.Empty);
                cmd.Parameters.AddWithValue("p_cep", Cep ?? string.Empty);
                cmd.Parameters.AddWithValue("p_email", Email ?? string.Empty);
                cmd.Parameters.AddWithValue("p_telefone", Telefone ?? string.Empty);
                cmd.Parameters.AddWithValue("p_senha", Senha ?? string.Empty);
                cmd.Parameters.AddWithValue("p_dataNascimento", DataNascimento);
                cmd.Parameters.AddWithValue("p_idNivel", IdNivel);
                cmd.Parameters.AddWithValue("p_ativo", Ativo ? 1 : 0);

                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                throw;
            }
        }

        // Método para deletar um usuário
        public bool Deletar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_delete_usuario";
                cmd.Parameters.AddWithValue("p_idusuario", IdUsuario);

                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
                throw;
            }
        }
    }
}