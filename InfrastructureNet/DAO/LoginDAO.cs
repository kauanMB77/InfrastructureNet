using InfrastructureNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace InfrastructureNet.DAO
{
    public class LoginDAO : PadraoDAO<LoginViewModel>
    {

        protected override SqlParameter[] CriaParametros(LoginViewModel model)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("id", model.Id),
                new SqlParameter("usuario", model.usuario),
                new SqlParameter("senha", model.senha),
                new SqlParameter("isADM", model.isADM),
                new SqlParameter("isMaster", model.isMaster)
            };

            return parametros;
        }

        protected override LoginViewModel MontaModel(DataRow registro)
        {
            LoginViewModel model = new LoginViewModel();

            model.Id = Convert.ToInt32(registro["id"]);
            model.usuario = registro["usuario"].ToString();
            model.senha = registro["senha"].ToString();
            /*if (registro["isADM"].ToString() == "true")
                model.isADM = true;
            else
                model.isADM = false;
            if (registro["isMaster"].ToString() == "true")
                model.isMaster = true;
            else
                model.isMaster = false;*/

            model.isADM = (bool)registro["isADM"];
            model.isMaster = (bool)registro["isMaster"];

            return model;
        }

        protected override void SetTabela()
        {
            Tabela = "Users";
        }

        public virtual LoginViewModel ConsultaLogin(string usuario)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("usuario", usuario),
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaLogin", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public virtual LoginViewModel CadastraLogin(int id, string usuario, string senha)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("usuario", usuario),
                new SqlParameter("senha", senha),
            };
            HelperDAO.ExecutaProc("spInsert_Users", p);

            return null;
        }

        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from Users";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

        public void concedeAdm(string usuario)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("usuario", usuario),
            };
            HelperDAO.ExecutaProc("spConcedeAdm", p);
        }
    }
}
