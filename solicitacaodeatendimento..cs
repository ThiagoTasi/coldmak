
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    public class SolicitacaoAtendimento
    {
        public int IdSolicitacaoAtendimento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HorarioAgendamento { get; set; }
        public string TipoServico { get; set; }

        public SolicitacaoAtendimento()
        {
        }

        public SolicitacaoAtendimento(DateTime dataAgendamento, DateTime horarioAgendamento, string tipoServico)
        {
            DataAgendamento = dataAgendamento;
            HorarioAgendamento = horarioAgendamento;
            TipoServico = tipoServico;
        }

        public SolicitacaoAtendimento(int idSolicitacaoAtendimento, DateTime dataAgendamento, DateTime horarioAgendamento, string tipoServico)
        {
            IdSolicitacaoAtendimento = idSolicitacaoAtendimento;
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
                IdSolicitacaoAtendimento = dr.GetInt32(0);
            }
            cmd.Connection.Close();
        }

        public static SolicitacaoAtendimento ObterPorId(int idSolicitacaoAtendimento)
        {
            SolicitacaoAtendimento solicitacaoAtendimento = new SolicitacaoAtendimento();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from solicitacao_atendimento where idsolicitacao_atendimento = {idSolicitacaoAtendimento}"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                solicitacaoAtendimento = new SolicitacaoAtendimento(
                    dr.GetInt32(0),
                    dr.GetDateTime(1),
                    (DateTime)dr.GetValue(2),
                    dr.GetString(3)
                );
            }
            return solicitacaoAtendimento;
        }

        public static List<SolicitacaoAtendimento> ObterLista()
        {
            List<SolicitacaoAtendimento> lista = new List<SolicitacaoAtendimento>();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select * from solicitacao_atendimento order by data_agendamento desc"; // Substitua pelo nome da sua tabela e coluna
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new SolicitacaoAtendimento(
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
            cmd.Parameters.AddWithValue("spidsolicitacaoatendimento", IdSolicitacaoAtendimento);
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
            cmd.Parameters.AddWithValue("spidsolicitacaoatendimento", IdSolicitacaoAtendimento);
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rowsAffected > 0;
        }
    }
}