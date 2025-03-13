using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace coldmakClass
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; } // Tipo corrigido
        public int IdadeCliente { get; set; } // Tipo corrigido

        public Cliente()
        {
        }

        public Cliente(string nome, string rg, string cpf, string cnpj, string email, string telefone, DateTime dataNascimento, int idadeCliente)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            IdadeCliente = idadeCliente;
        }

        public Cliente(int id, string nome, string rg, string cpf, string cnpj, string email, string telefone, DateTime dataNascimento, int idadeCliente)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            IdadeCliente = idadeCliente;
        }

        // Inserir
        public void Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_cliente_insert";
                cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spcnpj", Cnpj);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanasc", DataNascimento);
                cmd.Parameters.AddWithValue("spidade", IdadeCliente);
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir cliente: {ex.Message}");
                throw; // Re-lança a exceção para ser tratada em camadas superiores
            }
        }

        // ObterPorId
        public static Cliente ObterPorId(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from clientes where id = {id}";
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente = new Cliente(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetDateTime(7), // Correção aqui
                        dr.GetInt32(8) // Correção aqui
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter cliente por ID: {ex.Message}");
                throw;
            }
            return cliente;
        }

        public static List<Cliente> ObterLista()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from clientes order by nome asc";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetDateTime(7), // Correção aqui
                        dr.GetInt32(8) // Correção aqui
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter lista de clientes: {ex.Message}");
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
                cmd.CommandText = "sp_cliente_altera";
                cmd.Parameters.AddWithValue("spid", Id);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spcnpj", Cnpj);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanasc", DataNascimento);
                cmd.Parameters.AddWithValue("spidade", IdadeCliente);
                cmd.ExecuteNonQuery();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
                throw;
            }
        }
        public bool Deletar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_cliente_delete";
                cmd.Parameters.AddWithValue("spid", Id);
                cmd.ExecuteNonQuery();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                throw;
            }
        }
    }
}
