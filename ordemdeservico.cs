
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class OrdemdeServico
    {
        public int IdOrdemdeServico { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }

        public OrdemdeServico()
        {
        }

        public OrdemdeServico(int idUsuario, int idCliente, DateTime data, string status, decimal desconto, decimal valorTotal)
        {
            IdUsuario = idUsuario;
            IdCliente = idCliente;
            Data = data;
            Status = status;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public OrdemdeServico(int idOrdemDeServico, int idUsuario, int idCliente, DateTime data, string status, decimal desconto, decimal valorTotal)
        {
            IdOrdemdeServico = idOrdemDeServico;
            IdUsuario = idUsuario;
            IdCliente = idCliente;
            Data = data;
            Status = status;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ordem_servico_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
            cmd.Parameters.AddWithValue("spidcliente", IdCliente);
            cmd.Parameters.AddWithValue("spdata", Data);
            cmd.Parameters.AddWithValue("spstatus", Status);
            cmd.Parameters.AddWithValue("spdesconto", Desconto);
            cmd.Parameters.AddWithValue("spvalortotal", ValorTotal);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdOrdemdeServico = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static OrdemdeServico ObterPorId(int idOrdemDeServico)
        {
            OrdemdeServico ordemDeServico = new OrdemdeServico();
            var cmd = Banco.Abrir(); 
            cmd.CommandText = $"select * from ordem_de_servico where idordem_de_servico = {idOrdemDeServico}"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ordemDeServico = new OrdemdeServico(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetDateTime(3),
                    dr.GetString(4),
                    dr.GetDecimal(5),
                    dr.GetDecimal(6)
                );
            }
            return ordemDeServico;
        }

        public static List<OrdemdeServico> ObterLista()
        {
            List<OrdemdeServico> lista = new List<OrdemdeServico>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from ordem_de_servico order by data desc"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new OrdemdeServico(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetDateTime(3),
                    dr.GetString(4),
                    dr.GetDecimal(5),
                    dr.GetDecimal(6)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ordem_servico_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);
            cmd.Parameters.AddWithValue("spidusuario", IdUsuario);
            cmd.Parameters.AddWithValue("spidcliente", IdCliente);
            cmd.Parameters.AddWithValue("spdata", Data);
            cmd.Parameters.AddWithValue("spstatus", Status);
            cmd.Parameters.AddWithValue("spdesconto", Desconto);
            cmd.Parameters.AddWithValue("spvalortotal", ValorTotal);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ordem_servico_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}