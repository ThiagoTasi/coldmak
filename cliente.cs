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
        public int IdCliente { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdadeCliente { get; set; }

        public Cliente()
        {
        }

        public Cliente(string rg, string cpf, string cnpj, string nome, string email, string telefone, DateTime dataNascimento, int idadeCliente)
        {
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            IdadeCliente = idadeCliente;
        }

        public Cliente(int idcliente, string nome, string rg, string cpf, string cnpj, string email, string telefone, DateTime dataNascimento, int idadeCliente)
        {
            IdCliente = idcliente;
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Nome = nome;
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
                cmd.Parameters.AddWithValue("spidcliente", IdCliente);
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spcnpj", Cnpj);
                cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spidadecliente", IdadeCliente);

                // Adicionar parâmetro de saída para p_IdCliente
                var pIdCliente = new MySqlParameter("p_IdCliente", MySqlDbType.Int32);
                pIdCliente.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pIdCliente);

                cmd.ExecuteNonQuery();

                // Obter o valor do parâmetro de saída
                IdCliente = Convert.ToInt32(pIdCliente.Value);

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir cliente: {ex.Message}");
                throw;
            }
        }

        // ObterPorId
        public static Cliente ObterPorId(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from cliente where IdCliente = {id}"; // Corrigido para 'cliente' e 'IdCliente'
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente = new Cliente(
                        dr.GetInt32("IdCliente"),
                        dr.GetString("Nome"),
                        dr.GetString("Rg"),
                        dr.GetString("Cpf"),
                        dr.GetString("Cnpj"),
                        dr.GetString("Email"),
                        dr.GetString("Telefone"),
                        dr.GetDateTime("DataNascimento"),
                        dr.GetInt32("IdadeCliente")
                    );
                }
                dr.Close();
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
                cmd.CommandText = "select * from cliente order by Nome asc"; // Corrigido para 'cliente'
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente(
                        dr.GetInt32("IdCliente"),
                        dr.GetString("Nome"),
                        dr.GetString("Rg"),
                        dr.GetString("Cpf"),
                        dr.GetString("Cnpj"),
                        dr.GetString("Email"),
                        dr.GetString("Telefone"),
                        dr.GetDateTime("DataNascimento"),
                        dr.GetInt32("IdadeCliente")
                    ));
                }
                dr.Close();
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
                cmd.CommandText = "sp_cliente_update"; // Corrigido de sp_cliente_altera
                cmd.Parameters.AddWithValue("spidcliente", IdCliente);
                cmd.Parameters.AddWithValue("sprg", Rg);
                cmd.Parameters.AddWithValue("spcpf", Cpf);
                cmd.Parameters.AddWithValue("spcnpj", Cnpj);
                cmd.Parameters.AddWithValue("spnome", Nome);
                cmd.Parameters.AddWithValue("spemail", Email);
                cmd.Parameters.AddWithValue("sptelefone", Telefone);
                cmd.Parameters.AddWithValue("spdatanascimento", DataNascimento);
                cmd.Parameters.AddWithValue("spidadecliente", IdadeCliente);
                cmd.ExecuteNonQuery();
                return true; // Simplificado, pois ExecuteNonQuery() já foi chamado
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
                cmd.CommandText = "sp_delete_cliente"; // Corrigido de sp_cliente_delete
                cmd.Parameters.AddWithValue("spidcliente", IdCliente);
                cmd.ExecuteNonQuery();
                return true; // Simplificado, pois ExecuteNonQuery() já foi chamado
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                throw;
            }
        }
    }
}
