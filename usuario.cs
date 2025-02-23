using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace coldmak
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
        public string Senha { get; set; } // Adicionado para manter a compatibilidade com o código existente

        public Nivel Nivel { get; set; } // Adicionado para manter a compatibilidade com o código existente

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

        public Usuario(string nome, string email, string senha, Nível nivel)
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

        // inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_usuario_insert";
            cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nivel.Id);
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
                    Nivel.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
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
                    Nivel.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
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
            cmd.Parameters.AddWithValue("spsenha", Senha);
            cmd.Parameters.AddWithValue("spnivel", Nivel.Id);
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }

        // efetuar login
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
                    Nivel.ObterPorId(dr.GetInt32(4)),
                    dr.GetBoolean(5)
                );
            }
            return usuario;
        }
    }
}