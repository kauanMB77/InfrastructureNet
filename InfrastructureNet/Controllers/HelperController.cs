using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Runtime.Intrinsics.Arm;

namespace InfrastructureNet.Controllers
{
    public class HelperControllers
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null || false)
                return false;
            else
                return true;
        }

        public static Boolean VerificaUserADM(ISession session)
        {
            string adm = session.GetString("ADM");
            if (adm == null || false)
                return false;
            else
                return true;
        }

        public static Boolean VerificaUserMestre(ISession session)
        {
            string mestre = session.GetString("master");
            if (mestre == null || false)
                return false;
            else
                return true;
        }
    }
}
