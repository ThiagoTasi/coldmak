using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public class Caixa
    {
        public int IdCaixa { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Status { get; set; }

        public Caixa()
        {
        }

        public Caixa(int idUsuario, DateTime dataAbertura, decimal saldoInicial, string status)
        {
            IdUsuario = idUsuario;
            DataAbertura = dataAbertura;
            SaldoInicial = saldoInicial;
            Status = status;
        }

        public Caixa(int idCaixa, int idUsuario, DateTime dataAbertura, decimal saldoInicial, string status)
        {
            IdCaixa = idCaixa;
            IdUsuario = idUsuario;
            DataAbertura = dataAbertura;
            SaldoInicial = saldoInicial;
            Status = status;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_caixa_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
            cmd.Parameters.AddWithValue("spdataabertura", DataAbertura);
            cmd.Parameters.AddWithValue("spsaldoinicial", SaldoInicial);
            cmd.Parameters.AddWithValue("spstatus", Status);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "select last_insert_id()";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdCaixa = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static Caixa ObterPorId(int id)
        {
            Caixa caixa = null;
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from caixa where id_caixa = {id}"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                caixa = new Caixa(
                    dr.GetInt32(0), // id_caixa
                    dr.GetInt32(1), // id_usuario
                    dr.GetDateTime(2), // data_abertura
                    dr.GetDecimal(3), // saldo_inicial
                    dr.GetString(4) // status
                );
            }
            cmd.Connection.Close();
            return caixa;
        }

        public static List<Caixa> ObterTodos()
        {
            List<Caixa> caixas = new List<Caixa>();
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from caixa"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                caixas.Add(new Caixa(
                    dr.GetInt32(0), // id_caixa
                    dr.GetInt32(1), // id_usuario
                    dr.GetDateTime(2), // data_abertura
                    dr.GetDecimal(3), // saldo_inicial
                    dr.GetString(4) // status
                ));
            }
            cmd.Connection.Close();
            return caixas;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_caixa_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidcaixa", IdCaixa);
            cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
            cmd.Parameters.AddWithValue("spdataabertura", DataAbertura);
            cmd.Parameters.AddWithValue("spsaldoinicial", SaldoInicial);
            cmd.Parameters.AddWithValue("spstatus", Status);
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rowsAffected > 0;
        }

        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_caixa_delete"; // Substitua pelo nome da sua stored procedure de deleção
            cmd.Parameters.AddWithValue("spidcaixa", IdCaixa);
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rowsAffected > 0;
        }
    }
}