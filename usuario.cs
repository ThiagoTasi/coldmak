
using coldmak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using SysTINSClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace coldmak
{
    public class usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public usuario()
        {
            Id = 0;
        }

        public usuario(string nome, string rg, string cpf, string endereco, string cep, string email)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;

        }
        public usuario(string nome, string rg, string cpf, string endereco, string cep, string email, string telefone)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
            Email = email;
            Telefone = telefone;
        }
        public usuario(int id, string nome, string rg, string cpf, string endereco, string cep, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Endereco = endereco;
            Cep = cep;
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
    cmd.CommandText = "sp_usuario_insert";
    cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
    cmd.Parameters.AddWithValue("sprg", Rg);
    cmd.Parameters.AddWithValue("spcpf", Cpf);
    cmd.Parameters.AddWithValue("spendereco", Endereco);
    cmd.Parameters.AddWithValue("spcep", Cep);
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
public static Usuario ObterPorId(int id)
{
    Usuario usuario = new Usuario();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from usuarios where id = {id}";
    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        usuario = new(
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
    return usuario;
}
public static List<Usuario> ObterLista()
{
    List<Usuario> lista = new();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from usuarios order by nome asc";
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
    cmd.CommandText = "sp_usuario_update";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.Parameters.AddWithValue("spnome", Nome);
    cmd.Parameters.AddWithValue("sprg", Rg);
    cmd.Parameters.AddWithValue("spcpf", Cpf);
    cmd.Parameters.AddWithValue("spendereco", Endereco);
    cmd.Parameters.AddWithValue("spcep", Cep);
    cmd.Parameters.AddWithValue("spemail", Email);
    cmd.Parameters.AddWithValue("sptelefone", Telefone);

}
//efetuar login
public static Usuario EfetuarLogin(string email, string senha)
{
    Usuario usuario = new();
    var cmd = Banco.Abrir();
    cmd.CommandText = $"select * from usuarios where email = '{email}' and senha = md5('{senha}') and ativo = 1";
    var dr = cmd.ExecuteReader();
    if (dr.Read())
    {
        usuario = new(
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
    return usuario;
}
public void Excluir()
{
    var cmd = Banco.Abrir();
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "sp_usuario_delete";
    cmd.Parameters.AddWithValue("spid", Id);
    cmd.ExecuteNonQuery();
    cmd.Connection.Close();
}
