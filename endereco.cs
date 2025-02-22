using coldmak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace coldmak
{
    public class endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero_residencial { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        
        {
        public endereco()
        {
            Id = 0;
        }

        public endereco(string numero_residencial, string complemento, string bairro, string cidade, string uf)
        {
          
            Numero_residencial = numero_residencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
        public endereco( string logradouro, string numero_residencial, string complemento, string bairro, string cidade, string uf)
        {
           
            Logradouro = logradouro;
            Numero_residencial = numero_residencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
        public endereco( string cep, string logradouro, string numero_residencial, string complemento, string bairro, string cidade, string uf)
        {
           
            Cep = cep;
            Logradouro = logradouro;
            Numero_residencial = numero_residencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
        public endereco(int id, string cep, string logradouro, string numero_residencial, string complemento, string bairro, string cidade, string uf)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Numero_residencial = numero_residencial;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
    }
}

//inserir endereco
public void Inserir()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "sp_endereco_insert";
    cmd.Parameters.Add("spcep", MySql.Data.MySqlClient.MySqlDbType.Char).Value = Cep;
    cmd.Parameters.AddWithValue("splogradouro", Logradouro);
    cmd.Parameters.AddWithValue("spnumero_residencial", Numero_residencial);
    cmd.Parameters.AddWithValue("spcomplemento", Complemento);
    cmd.Parameters.AddWithValue("spbairro", Bairro);
    cmd.Parameters.AddWithValue("spcidade", Cidade);
    cmd.Parameters.AddWithValue("spuf", Uf);
    cmd.ExecuteNonQuery();
    cmd.Connection.Close();

    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        Id = dr.GetInt32(0);
    }
    cmd.Connection.Close();
}
//Obter por id
public static Endereco ObterPorId(int id)
{
    Endereco endereco = new Endereco();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from endereco where id = {id}";
    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        Endereco = new(
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
    return endereco;
}
public static List<Endereco> ObterLista()
{
    List<Endereco> lista = new();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from endereco order by nome asc";
    var dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        lista.Add(new(
            dr.GetInt32(0),
            dr.GetString(1),
            dr.GetString(2),
            dr.GetString(3),
            dr.GetString(4),
            dr.GetString(5),
            dr.GetString(6),
            dr.GetString(7)


            )
        );
    }

    return lista;
}
public bool Atualizar()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "sp_endereco_update";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.Parameters.AddWithValue("spcep", Cep);
    cmd.Parameters.AddWithValue("splogradouro", Logradouro);
    cmd.Parameters.AddWithValue("spnumero_residencial", Numero_residencial);
    cmd.Parameters.AddWithValue("spcomplemento", Complemento);
    cmd.Parameters.AddWithValue("spbairro", Bairro);
    cmd.Parameters.AddWithValue("spcidade", Cidade);
    cmd.Parameters.AddWithValue("spuf", Uf);
    if (cmd.ExecuteNonQuery() > 0)
    {
        return true;
    }
    cmd.Connection.Close();
    return resposta;
}
public void Excluir()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "sp_endereco_delete";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.ExecuteNonQuery();
    cmd.Connection.Close();
}
        }
    }
}
