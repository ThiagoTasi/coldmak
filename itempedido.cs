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
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int IdOrdemdeServico { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeItem { get; set; }
        public decimal DescontoItem { get; set; }

        public ItemPedido()
        {
        }

        public ItemPedido(int idOrdemdeServico, int idProduto, decimal valorUnitario, int quantidadeItem, decimal descontoItem)
        {
            IdOrdemdeServico = idOrdemdeServico;
            IdProduto = idProduto;
            ValorUnitario = valorUnitario;
            QuantidadeItem = quantidadeItem;
            DescontoItem = descontoItem;
        }

        public ItemPedido(int idItemPedido, int idOrdemdeServico, int idProduto, decimal valorUnitario, int quantidadeItem, decimal descontoItem)
        {
            IdItemPedido = idItemPedido;
            IdOrdemdeServico = idOrdemdeServico;
            IdProduto = idProduto;
            ValorUnitario = valorUnitario;
            QuantidadeItem = quantidadeItem;
            DescontoItem = descontoItem;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itempedido_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spvalorunitario", ValorUnitario);
            cmd.Parameters.AddWithValue("spquantidadeitem", QuantidadeItem);
            cmd.Parameters.AddWithValue("spdescontoitem", DescontoItem);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdItemPedido = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static ItemPedido ObterPorId(int id)
        {
            ItemPedido itemPedido = new ItemPedido();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from itenspedido where iditempedido = {id}"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader(); 
            if (dr.Read())
            {
                itemPedido = new ItemPedido(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetDecimal(3),
                    dr.GetInt32(4),
                    dr.GetDecimal(5)
                );
            }
            return itemPedido;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itempedido_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spiditempedido", IdItemPedido);
            cmd.Parameters.AddWithValue("spidordemdeservico", IdOrdemdeServico);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spvalorunitario", ValorUnitario);
            cmd.Parameters.AddWithValue("spquantidadeitem", QuantidadeItem);
            cmd.Parameters.AddWithValue("spdescontoitem", DescontoItem);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }

        public static List<ItemPedido> ObterLista()
        {
            List<ItemPedido> lista = new List<ItemPedido>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from itenspedido"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ItemPedido(
                    dr.GetInt32(0),
                    dr.GetInt32(1),
                    dr.GetInt32(2),
                    dr.GetDecimal(3),
                    dr.GetInt32(4),
                    dr.GetDecimal(5)
                ));
            }
            return lista;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itempedido_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spiditempedido", IdItemPedido);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}