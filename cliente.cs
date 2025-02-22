using coldmak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using SysTINSClass;

namespace coldmak
{
    public class cliente
    {
        public int Id { get; set; };
        public string Rg { get; set; };
        public string Cpf { get; set; };
        public string Cnpj { get; set; };
        public string Nome { get; set; };
        public string Email { get; set; };
        public string Telefone { get; set; };
        public cliente()
        {
            Id = 0;
        }

        
        public cliente( string rg, string cpf, string cnpj, string nome, string email)
        {
           
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Nome = nome;
            Email = email;
            
        }
        public cliente(string rg, string cpf, string cnpj, string nome, string email, string telefone)
        {
           
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public cliente(int id, string rg, string cpf, string cnpj, string nome, string email, string telefone)
        {
            Id = id;
            Rg = rg;
            Cpf = cpf;
            Cnpj = cnpj;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}

//inserir usuario
public void Inserir()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "sp_cliente_insert";
    cmd.Parameters.Add("sprg", MySql.Data.MySqlClient.MySqlDbType.Char).Value = Rg;
    cmd.Parameters.AddWithValue("spcpf", Cpf);
    cmd.Parameters.AddWithValue("spcpf", Cnpj);
    cmd.Parameters.AddWithValue("spnome", Nome);
    cmd.Parameters.AddWithValue("spemail", Email);
    cmd.Parameters.AddWithValue("sptelefone", Telefone);

    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        Id = dr.GetInt32(0);
    }
    cmd.Connection.Close();
}
//Obter por id
public static Cliente ObterPorId(int id)
{
    Cliente cliente = new Cliente();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from cliente where id = {id}";
    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        Cliente = new(
            dr.GetInt32(0),
            dr.GetString(1),
            dr.GetString(2),
            dr.GetString(3),
            dr.GetString(4),
            dr.GetString(5),
            dr.GetString(6)
           


            );
    }
    return cliente;
}
public static List<Cliente> ObterLista()
{
    List<Cliente> lista = new();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from cliente order by nome asc";
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
            dr.GetString(6)
         

            )
        );
    }

    return lista;
}
public bool Atualizar()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "sp_cliente_update";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.Parameters.AddWithValue("sprg", Rg);
    cmd.Parameters.AddWithValue("spcpf", Cpf);
    cmd.Parameters.AddWithValue("spcnpj", Cnpj);
    cmd.Parameters.AddWithValue("spnome", Nome);
    cmd.Parameters.AddWithValue("spemail", Email);
    cmd.Parameters.AddWithValue("sptelefone", Telefone);

}
public bool Excluir()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "sp_cliente_delete";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.ExecuteNonQuery();
    cmd.Connection.Close();
    return true;
}


    

