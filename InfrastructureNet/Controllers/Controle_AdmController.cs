using Microsoft.AspNetCore.Mvc;
using InfrastructureNet.DAO;
using System.ComponentModel;
using InfrastructureNet.Models;

namespace InfrastructureNet.Controllers
{
    public class Controle_AdmController : Controller
    {
        public IActionResult Index()
        {
            LoginDAO dao = new LoginDAO();
            List<LoginViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult concedeAdm(string usuario)
        {
            LoginDAO dao = new LoginDAO();
            dao.concedeAdm(usuario);
            return View();
        }
    }
}
