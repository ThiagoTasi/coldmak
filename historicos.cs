using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coldmakClass
{
    public class Historicos
    {
        public int IdHistoricos { get; set; }
        public int IdCliente { get; set; }
        public int IdOrdemServico { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public DateTime DataVenda { get; set; }

        public Historicos()
        {
        }

        public Historicos(int idCliente, int idOrdemServico, int idFornecedor, int idProduto, DateTime dataVenda)
        {
            IdCliente = idCliente;
            IdOrdemServico = idOrdemServico;
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
            DataVenda = dataVenda;
        }

        public Historicos(int idHistoricos, int idCliente, int idOrdemServico, int idFornecedor, int idProduto, DateTime dataVenda)
        {
            IdHistoricos = idHistoricos;
            IdCliente = idCliente;
            IdOrdemServico = idOrdemServico;
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
            DataVenda = dataVenda;
        }

        // Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_historicos_insert"; // Assumindo que você tem uma stored procedure chamada sp_historicos_insert
            cmd.Parameters.AddWithValue("spidcliente", IdCliente);
            cmd.Parameters.AddWithValue("spidordemservico", IdOrdemServico);
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spdatavenda", DataVenda);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdHistoricos = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // ObterPorId
        public static Historicos ObterPorId(int id)
        {
            Historicos historico = new Historicos();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from historicos where id_historicos = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                historico = new Historicos(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetInt32(3),
                    dr.GetInt32(4),
                    dr.GetDateTime(5)
                );
            }
            return historico;
        }

        public static List<Historicos> ObterLista()
        {
            List<Historicos> lista = new List<Historicos>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from historicos order by data_venda desc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Historicos(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetInt32(3),
                    dr.GetInt32(4),
                    dr.GetDateTime(5)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_historicos_altera"; // Assumindo que você tem uma stored procedure chamada sp_historicos_altera
            cmd.Parameters.AddWithValue("spidhistoricos", IdHistoricos);
            cmd.Parameters.AddWithValue("spidcliente", IdCliente);
            cmd.Parameters.AddWithValue("spidordemservico", IdOrdemServico);
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spdatavenda", DataVenda);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_historicos_delete"; // Assumindo que você tem uma stored procedure chamada sp_historicos_delete
            cmd.Parameters.AddWithValue("spidhistoricos", IdHistoricos);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}