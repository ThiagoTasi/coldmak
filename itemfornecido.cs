using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coldmakClass
{
    public class ItemFornecido
    {
        public int IdItemFornecido { get; set; }
        public int IdFornecedor { get; set; } // Chave estrangeira para a tabela Fornecedor
        public int IdProduto { get; set; }    // Chave estrangeira para a tabela Produto
        public decimal Quantidade { get; set; }
        public string Modelo { get; set; }
        public string Nome { get; set; }

        // Construtor padrão
        public ItemFornecido()
        {
        }

        // Construtor sem ID (para inserção)
        public ItemFornecido(int idFornecedor, int idProduto, decimal quantidade, string modelo, string nome)
        {
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
            Quantidade = quantidade;
            Modelo = modelo;
            Nome = nome;
        }

        // Construtor com ID (para recuperação de dados)
        public ItemFornecido(int idItemFornecido, int idFornecedor, int idProduto, decimal quantidade, string modelo, string nome)
        {
            IdItemFornecido = idItemFornecido;
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
            Quantidade = quantidade;
            Modelo = modelo;
            Nome = nome;
        }

        // Método para inserir um novo item fornecido
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itemfornecido_insert"; // Nome da stored procedure para inserção
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spquantidade", Quantidade);
            cmd.Parameters.AddWithValue("spmodelo", Modelo);
            cmd.Parameters.AddWithValue("spnome", Nome);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdItemFornecido = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // Método para obter um item fornecido por ID
        public static ItemFornecido ObterPorId(int id)
        {
            ItemFornecido itemFornecido = new ItemFornecido();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from itemfornecido where iditem_fornecido = {id}"; // Nome da tabela
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                itemFornecido = new ItemFornecido(
                    dr.GetInt32(0), // iditem_fornecido
                    dr.GetInt32(1), // idfornecedor
                    dr.GetInt32(2), // idproduto
                    dr.GetDecimal(3), // quantidade
                    dr.GetString(4), // modelo
                    dr.GetString(5)  // nome
                );
            }
            cmd.Connection.Close();
            return itemFornecido;
        }

        // Método para atualizar um item fornecido
        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itemfornecido_altera"; // Nome da stored procedure para atualização
            cmd.Parameters.AddWithValue("spiditemfornecido", IdItemFornecido);
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spquantidade", Quantidade);
            cmd.Parameters.AddWithValue("spmodelo", Modelo);
            cmd.Parameters.AddWithValue("spnome", Nome);

            cmd.ExecuteNonQuery();
            bool sucesso = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return sucesso;
        }

        // Método para obter a lista de itens fornecidos
        public static List<ItemFornecido> ObterLista()
        {
            List<ItemFornecido> lista = new List<ItemFornecido>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from itemfornecido"; // Nome da tabela
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ItemFornecido(
                    dr.GetInt32(0), // iditem_fornecido
                    dr.GetInt32(1), // idfornecedor
                    dr.GetInt32(2), // idproduto
                    dr.GetDecimal(3), // quantidade
                    dr.GetString(4), // modelo
                    dr.GetString(5)  // nome
                ));
            }
            cmd.Connection.Close();
            return lista;
        }

        // Método para deletar um item fornecido
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_itemfornecido_delete"; // Nome da stored procedure para deleção
            cmd.Parameters.AddWithValue("spiditemfornecido", IdItemFornecido);
            cmd.ExecuteNonQuery();
            bool sucesso = cmd.ExecuteNonQuery() > 0;
            cmd.Connection.Close();
            return sucesso;
        }
    }
}