using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdCaixa = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static Caixa ObterPorId(int id)
        {
            Caixa caixa = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from caixas where idcaixa = {id}"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                caixa = new Caixa(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetDateTime(2),
                    dr.GetDecimal(3),
                    dr.GetString(4)
                );
            }
            return caixa;
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
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}