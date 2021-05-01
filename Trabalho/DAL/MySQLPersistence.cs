using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Importacao do Provider do MySQL

namespace Trabalho.DAL
{
   
    public class MySQLPersistence
    {
        string _strCon;

        MySqlConnection _conexao;
        MySqlCommand _comando;
        public MySQLPersistence()
        {
            _strCon = "Server=den1.mysql1.gear.host;Database=leofipp;Uid=leofipp;Pwd=Sg90DsB_~d93;";
            _conexao = new MySqlConnection(_strCon);
            _comando = _conexao.CreateCommand();
        }

        public void AbrirConexao()
        {
            if(_conexao.State != System.Data.ConnectionState.Open)
                _conexao.Open();
        }

        public void FecharConexao()
        {
            _conexao.Close();

            //_comando.CommandText = "SELECT , insert,delete,update";
           // _comando.ExecuteNonQuery();//i,d,u
            //_comando.ExecuteReader();//select
            //_comando.ExecuteScalar();//Retorna somente 1 valor, tipo count,max,avg
        }

        public void LimparParametros()
        {
            _comando.Parameters.Clear();
        }

        /// <summary>
        /// Executa Insert,Delete ou Update
        /// </summary>
        public int ExecutarNonQuery(string sql, Dictionary<string,object> parametros = null)
        {
            _comando.CommandText = sql;
            if(parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            int rows;
            try
            {
                rows = _comando.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                rows = 0;
            }
            return rows;
        }

        public void AdicionarParametro(string param, string valor)
        {
            _comando.Parameters.AddWithValue(param, valor);
        }

        public DataTable ExecutarSelect(string sql,Dictionary<string,object> parametros = null)
        {
            DataTable tabMemoria = new DataTable();
            _comando.CommandText = sql;
            if(parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            tabMemoria.Load(_comando.ExecuteReader());
            return tabMemoria;
        }

        public object ExecutarConsultaSimples(string sql)
        {
            object valor = null;
            _comando.CommandText = sql;
            valor = _comando.ExecuteScalar();
            return valor;
        }
    }
}
