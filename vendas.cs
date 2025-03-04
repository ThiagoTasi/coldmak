
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class Vendas
    {
        public int IdVendas { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Desconto { get; set; }
        public decimal VendaTotal { get; set; }

        public Vendas()
        {
        }

        public Vendas(DateTime dataVenda, decimal precoVenda, decimal desconto, decimal vendaTotal)
        {
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            Desconto = desconto;
            VendaTotal = vendaTotal;
        }

        public Vendas(int idVendas, DateTime dataVenda, decimal precoVenda, decimal desconto, decimal vendaTotal)
        {
            IdVendas = idVendas;
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            Desconto = desconto;
            VendaTotal = vendaTotal;
        }

        // Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_vendas_insert"; // Assumindo que você tem uma stored procedure chamada sp_vendas_insert
            cmd.Parameters.AddWithValue("spdatavenda", DataVenda);
            cmd.Parameters.AddWithValue("spprecovenda", PrecoVenda);
            cmd.Parameters.AddWithValue("spdesconto", Desconto);
            cmd.Parameters.AddWithValue("spvendatotal", VendaTotal);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdVendas = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // ObterPorId
        public static Vendas ObterPorId(int id)
        {
            Vendas venda = new Vendas();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from vendas where idvendas = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                venda = new Vendas(
                    dr.GetInt32(0),
                    dr.GetDateTime(1),
                    dr.GetDecimal(2),
                    dr.GetDecimal(3),
                    dr.GetDecimal(4)
                );
            }
            return venda;
        }

        public static List<Vendas> ObterLista()
        {
            List<Vendas> lista = new List<Vendas>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from vendas order by datavenda desc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Vendas(
                    dr.GetInt32(0),
                    dr.GetDateTime(1),
                    dr.GetDecimal(2),
                    dr.GetDecimal(3),
                    dr.GetDecimal(4)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_vendas_altera"; // Assumindo que você tem uma stored procedure chamada sp_vendas_altera
            cmd.Parameters.AddWithValue("spidvendas", IdVendas);
            cmd.Parameters.AddWithValue("spdatavenda", DataVenda);
            cmd.Parameters.AddWithValue("spprecovenda", PrecoVenda);
            cmd.Parameters.AddWithValue("spdesconto", Desconto);
            cmd.Parameters.AddWithValue("spvendatotal", VendaTotal);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_vendas_delete"; // Assumindo que você tem uma stored procedure chamada sp_vendas_delete
            cmd.Parameters.AddWithValue("spidvendas", IdVendas);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
 