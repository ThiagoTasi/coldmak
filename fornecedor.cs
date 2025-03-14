﻿
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Fornecedor()
        {
        }

        public Fornecedor(string razaoSocial, string fantasia, string cnpj, string telefone, string email)
        {
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public Fornecedor(int idFornecedor, string razaoSocial, string fantasia, string cnpj, string telefone, string email)
        {
            IdFornecedor = idFornecedor;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_fornecedor_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("sprazaosocial", RazaoSocial);
            cmd.Parameters.AddWithValue("spfantasia", Fantasia);
            cmd.Parameters.AddWithValue("spcnpj", Cnpj);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdFornecedor = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static Fornecedor ObterPorId(int idFornecedor)
        {
            Fornecedor fornecedor = new Fornecedor();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from fornecedores where id_fornecedor = {idFornecedor}"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                fornecedor = new Fornecedor(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5)
                );
            }
            return fornecedor;
        }

        public static List<Fornecedor> ObterLista()
        {
            List<Fornecedor> lista = new List<Fornecedor>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from fornecedores order by razao_social asc"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Fornecedor(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4),
                    dr.GetString(5)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_fornecedor_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("sprazaosocial", RazaoSocial);
            cmd.Parameters.AddWithValue("spfantasia", Fantasia);
            cmd.Parameters.AddWithValue("spcnpj", Cnpj);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_fornecedor_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}