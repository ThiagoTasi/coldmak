
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string CodBarras { get; set; }
        public string Categoria { get; set; }
        public int IdFornecedor { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public string UnidadeVenda { get; set; }
        public int EstoqueMinimo { get; set; }
        public string ClasseDesconto { get; set; }
        public byte[] Imagem { get; set; } // Usando byte[] para armazenar a imagem
        public DateTime DataCadastro { get; set; }

        public Produto()
        {
        }

        public Produto(string codBarras, string Categoria, int idFornecedor, string descricao, decimal valorUnitario, string unidadeVenda, int estoqueMinimo, string classeDesconto, byte[] imagem, DateTime dataCadastro)
        {
            CodBarras = codBarras;
            Categoria = Categoria;
            IdFornecedor = idFornecedor;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            UnidadeVenda = unidadeVenda;
            EstoqueMinimo = estoqueMinimo;
            ClasseDesconto = classeDesconto;
            Imagem = imagem;
            DataCadastro = dataCadastro;
        }

        public Produto(int idProduto, string codBarras, string Categoria, int idFornecedor, string descricao, decimal valorUnitario, string unidadeVenda, int estoqueMinimo, string classeDesconto, byte[] imagem, DateTime dataCadastro)
        {
            IdProduto = idProduto;
            CodBarras = codBarras;
            Categoria = Categoria;
            IdFornecedor = idFornecedor;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            UnidadeVenda = unidadeVenda;
            EstoqueMinimo = estoqueMinimo;
            ClasseDesconto = classeDesconto;
            Imagem = imagem;
            DataCadastro = dataCadastro;
        }

        // Inserir
        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.Add("spcodbarras", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = CodBarras;
            cmd.Parameters.AddWithValue("spcategoria", Categoria);
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spdescricao", Descricao);
            cmd.Parameters.AddWithValue("spvalorunitario", ValorUnitario);
            cmd.Parameters.AddWithValue("spunidadevenda", UnidadeVenda);
            cmd.Parameters.AddWithValue("spestoqueminimo", EstoqueMinimo);
            cmd.Parameters.AddWithValue("spclasseddesconto", ClasseDesconto);
            cmd.Parameters.AddWithValue("spimagem", Imagem);
            cmd.Parameters.AddWithValue("spdatacadastro", DataCadastro);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdProduto = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        // ObterPorId
        public static Produto ObterPorId(int id)
        {
            Produto produto = new Produto();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from produtos where idproduto = {id}"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                produto = new Produto(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetInt32(3),
                    dr.GetString(4),
                    dr.GetDecimal(5),
                    dr.GetString(6),
                    dr.GetInt32(7),
                    dr.GetString(8),
                    (byte[])dr["imagem"], // Obtendo a imagem como byte[]
                    dr.GetDateTime(10)
                );
            }
            return produto;
        }

        public static List<Produto> ObterLista()
        {
            List<Produto> lista = new List<Produto>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from produtos order by descricao asc"; // Substitua pelo nome da sua tabela
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Produto(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetInt32(3),
                    dr.GetString(4),
                    dr.GetDecimal(5),
                    dr.GetString(6),
                    dr.GetInt32(7),
                    dr.GetString(8),
                    (byte[])dr["imagem"], // Obtendo a imagem como byte[]
                    dr.GetDateTime(10)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.Parameters.AddWithValue("spcodbarras", CodBarras);
            cmd.Parameters.AddWithValue("spidcategoria", Categoria);
            cmd.Parameters.AddWithValue("spidfornecedor", IdFornecedor);
            cmd.Parameters.AddWithValue("spdescricao", Descricao);
            cmd.Parameters.AddWithValue("spvalorunitario", ValorUnitario);
            cmd.Parameters.AddWithValue("spunidadevenda", UnidadeVenda);
            cmd.Parameters.AddWithValue("spestoqueminimo", EstoqueMinimo);
            cmd.Parameters.AddWithValue("spclasseddesconto", ClasseDesconto);
            cmd.Parameters.AddWithValue("spimagem", Imagem);
            cmd.Parameters.AddWithValue("spdatacadastro", DataCadastro);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0 ? true : false;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_produto_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidproduto", IdProduto);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}