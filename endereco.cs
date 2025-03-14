﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coldmakClass
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroResidencial { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public Endereco()
        {
        }

        public Endereco(string cep, string logradouro, string numeroResidencial, string complemento, string bairro, string cidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            NumeroResidencial = numeroResidencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public Endereco(int idEndereco, string cep, string logradouro, string numeroResidencial, string complemento, string bairro, string cidade, string uf)
        {
            IdEndereco = idEndereco;
            Cep = cep;
            Logradouro = logradouro;
            NumeroResidencial = numeroResidencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        public void Inserir()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_endereco_insert";
                cmd.Parameters.Add("spcep", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Cep;
                cmd.Parameters.AddWithValue("splogradouro", Logradouro);
                cmd.Parameters.AddWithValue("spnumeroresidencial", NumeroResidencial);
                cmd.Parameters.AddWithValue("spcomplemento", Complemento);
                cmd.Parameters.AddWithValue("spbairro", Bairro);
                cmd.Parameters.AddWithValue("spcidade", Cidade);
                cmd.Parameters.AddWithValue("spuf", UF);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select last_insert_id()";
                cmd.ExecuteNonQuery();

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    IdEndereco = dr.GetInt32(0);
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao inserir endereço: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir endereço: " + ex.Message);
                throw;
            }
        }

        public static Endereco ObterPorId(int id)
        {
            Endereco endereco = new Endereco();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from enderecos where id = {id}";
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    endereco = new Endereco(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7)
                    );
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao obter endereço por ID: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter endereço por ID: " + ex.Message);
                throw;
            }
            return endereco;
        }

        public static List<Endereco> ObterLista()
        {
            List<Endereco> lista = new List<Endereco>();
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from enderecos order by logradouro asc";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Endereco(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetString(6),
                        dr.GetString(7)
                    ));
                }
                dr.Close();
                cmd.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao obter lista de endereços: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter lista de endereços: " + ex.Message);
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
                cmd.CommandText = "sp_endereco_altera";
                cmd.Parameters.AddWithValue("spid", IdEndereco);
                cmd.Parameters.AddWithValue("spcep", Cep);
                cmd.Parameters.AddWithValue("splogradouro", Logradouro);
                cmd.Parameters.AddWithValue("spnumeroresidencial", NumeroResidencial);
                cmd.Parameters.AddWithValue("spcomplemento", Complemento);
                cmd.Parameters.AddWithValue("spbairro", Bairro);
                cmd.Parameters.AddWithValue("spcidade", Cidade);
                cmd.Parameters.AddWithValue("spuf", UF);
                cmd.ExecuteNonQuery();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao atualizar endereço: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar endereço: " + ex.Message);
                throw;
            }
        }

        public bool Deletar()
        {
            try
            {
                var cmd = Banco.Abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_endereco_delete";
                cmd.Parameters.AddWithValue("spid", IdEndereco);
                cmd.ExecuteNonQuery();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro de banco de dados ao deletar endereço: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar endereço: " + ex.Message);
                throw;
            }
        }
    }
}