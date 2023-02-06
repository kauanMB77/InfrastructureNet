using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InfrastructureNet.DAO
{
    internal class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST; Database=InfraStags; integrated security=true"; //integrated security=true user=sa; password=123456
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }

    }
}