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
        public Nivel Nivel { get; set; }

        public Usuario()
        {
            Nivel = new Nivel();
        }

        public Usuario(string nome, string rg, string cpf, string endereco, string cep, string email,
                       string telefone, string senha, DateTime dataNascimento, int idNivel, bool ativo, Nivel nivel = null)
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
                       bool ativo, Nivel nivel = null)
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
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_usuario_insert";
                    cmd.Parameters.AddWithValue("spnome", Nome ?? string.Empty);
                    cmd.Parameters.AddWithValue("sprg", Rg ?? string.Empty);
                    cmd.Parameters.AddWithValue("spcpf", Cpf ?? string.Empty);
                    cmd.Parameters.AddWithValue("spendereco", Endereco ?? string.Empty);
                    cmd.Parameters.AddWithValue("spcep", Cep ?? string.Empty);
                    cmd.Parameters.AddWithValue("spemail", Email ?? string.Empty);
                    cmd.Parameters.AddWithValue("sptelefone", Telefone ?? string.Empty);
                    cmd.Parameters.AddWithValue("spsenha", Senha ?? string.Empty);
                    cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                    cmd.Parameters.AddWithValue("spidnivel", IdNivel);

                    // Captura o ID retornado por LAST_INSERT_ID()
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Falha ao obter o ID gerado pelo banco de dados.");
                    }
                    IdUsuario = Convert.ToInt32(result);
                }
                catch (MySqlException ex)
                {
                    // Captura erros específicos lançados pela procedure
                    if (ex.Message.Contains("CPF já cadastrado"))
                        throw new Exception("CPF já cadastrado.");
                    else if (ex.Message.Contains("Erro ao inserir usuário"))
                        throw new Exception("Erro ao inserir usuário no banco de dados.");
                    else
                        throw new Exception($"Erro de banco de dados ao inserir usuário: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao inserir usuário: {ex.Message}");
                }
            }
        }

        public static Usuario ObterPorId(int id)
        {
            Usuario usuario = null;
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandText = "SELECT u.*, n.nome AS nivel_nome, n.sigla " +
                                     "FROM usuario u " +
                                     "LEFT JOIN nivel n ON u.IdNivel = n.IdNivel " +
                                     "WHERE u.IdUsuario = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dr = cmd.ExecuteReader())
                    {
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
                                new Nivel(dr.GetInt32("IdNivel"), nivelNome, nivelSigla)
                            );
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Erro de banco de dados ao obter usuário por ID: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao obter usuário por ID: {ex.Message}");
                }
            }
            return usuario;
        }

        public static List<Usuario> ObterLista()
        {
            List<Usuario> lista = new List<Usuario>();
            using (var cmd = Banco.Abrir())
            {
                try
                {
                    cmd.CommandText = "SELECT u.*, n.nome AS nivel_nome, n.sigla " +
                                     "FROM usuario u " +
                                     "LEFT JOIN nivel n ON u.IdNivel = n.IdNivel " +
                                     "ORDER BY u.Nome ASC";
                    using (var dr = cmd.ExecuteReader())
                    {
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
                                new Nivel(dr.GetInt32("IdNivel"), nivelNome, nivelSigla)
                            );
                            lista.Add(usuario);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Erro de banco de dados ao obter lista de usuários: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao obter lista de usuários: {ex.Message}");
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
                    cmd.CommandText = "sp_usuario_update";
                    cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
                    cmd.Parameters.AddWithValue("spnome", Nome ?? string.Empty);
                    cmd.Parameters.AddWithValue("sprg", Rg ?? string.Empty);
                    cmd.Parameters.AddWithValue("spcpf", Cpf ?? string.Empty);
                    cmd.Parameters.AddWithValue("spendereco", Endereco ?? string.Empty);
                    cmd.Parameters.AddWithValue("spcep", Cep ?? string.Empty);
                    cmd.Parameters.AddWithValue("spemail", Email ?? string.Empty);
                    cmd.Parameters.AddWithValue("sptelefone", Telefone ?? string.Empty);
                    cmd.Parameters.AddWithValue("spsenha", Senha ?? string.Empty);
                    cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                    cmd.Parameters.AddWithValue("spidnivel", IdNivel);

                    // Executa a procedure e verifica linhas afetadas
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    // Captura erros específicos lançados pela procedure
                    if (ex.Message.Contains("Usuário não encontrado"))
                        throw new Exception("Usuário não encontrado.");
                    else if (ex.Message.Contains("CPF já cadastrado"))
                        throw new Exception("CPF já cadastrado por outro usuário.");
                    else if (ex.Message.Contains("Erro ao atualizar usuário"))
                        throw new Exception("Erro ao atualizar usuário no banco de dados.");
                    else
                        throw new Exception($"Erro de banco de dados ao atualizar usuário: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao atualizar usuário: {ex.Message}");
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
                    cmd.CommandText = "sp_delete_usuario";
                    cmd.Parameters.AddWithValue("spidusuario", IdUsuario);

                    // A procedure retorna uma mensagem via SELECT
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string mensagem = dr.GetString("Mensagem");
                            if (mensagem.Contains("Usuário não encontrado"))
                            {
                                return false;
                            }
                            return true; // "Usuário deletado com sucesso"
                        }
                        return false; // Caso não retorne nada (improvável)
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Erro de banco de dados ao deletar usuário: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao deletar usuário: {ex.Message}");
                }
            }
        }
    }
}