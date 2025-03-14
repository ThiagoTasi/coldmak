
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class SolicitacaodeAtendimento
    {
        public int IdSolicitacaodeAtendimento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HorarioAgendamento { get; set; }
        public string TipoServico { get; set; }

        public SolicitacaodeAtendimento()
        {
        }

        public SolicitacaodeAtendimento(DateTime dataAgendamento, DateTime horarioAgendamento, string tipoServico)
        {
            DataAgendamento = dataAgendamento;
            HorarioAgendamento = horarioAgendamento;
            TipoServico = tipoServico;
        }

        public SolicitacaodeAtendimento(int idSolicitacaodeAtendimento, DateTime dataAgendamento, DateTime horarioAgendamento, string tipoServico)
        {
            IdSolicitacaodeAtendimento = idSolicitacaodeAtendimento;
            DataAgendamento = dataAgendamento;
            HorarioAgendamento = horarioAgendamento;
            TipoServico = tipoServico;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_solicitacao_atendimento_insert"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spdataagendamento", DataAgendamento);
            cmd.Parameters.AddWithValue("sphorarioagendamento", HorarioAgendamento);
            cmd.Parameters.AddWithValue("sptiposervico", TipoServico);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select last_insert_id()";
            cmd.ExecuteNonQuery();

            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                IdSolicitacaodeAtendimento = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static SolicitacaodeAtendimento ObterPorId(int idSolicitacaodeAtendimento)
        {
            SolicitacaodeAtendimento solicitacaodeAtendimento = new SolicitacaodeAtendimento();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from solicitacao_atendimento where idsolicitacao_atendimento = {idSolicitacaodeAtendimento}"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                solicitacaodeAtendimento = new SolicitacaodeAtendimento(
                    dr.GetInt32(0),
                    dr.GetDateTime(1),
                    (DateTime)dr.GetValue(2),
                    dr.GetString(3)
                );
            }
            return solicitacaodeAtendimento;
        }

        public static List<SolicitacaodeAtendimento> ObterLista()
        {
            List<SolicitacaodeAtendimento> lista = new List<SolicitacaodeAtendimento>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from solicitacao_atendimento order by data_agendamento desc"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new SolicitacaodeAtendimento(
                    dr.GetInt32(0),
                    dr.GetDateTime(1),
                    (DateTime)dr.GetValue(2),
                    dr.GetString(3)
                ));
            }
            return lista;
        }

        public bool Atualizar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_solicitacao_atendimento_altera"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidsolicitacaoatendimento", IdSolicitacaodeAtendimento);
            cmd.Parameters.AddWithValue("spdataagendamento", DataAgendamento);
            cmd.Parameters.AddWithValue("sphorarioagendamento", HorarioAgendamento);
            cmd.Parameters.AddWithValue("sptiposervico", TipoServico);
            cmd.ExecuteNonQuery();
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Deletar()
        {
            var cmd = Banco.Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_solicitacao_atendimento_delete"; // Substitua pelo nome da sua stored procedure
            cmd.Parameters.AddWithValue("spidsolicitacaoatendimento", IdSolicitacaodeAtendimento);
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rowsAffected > 0;
        }
    }
}