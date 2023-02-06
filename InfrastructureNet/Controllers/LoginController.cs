using InfrastructureNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using InfrastructureNet.DAO;

namespace InfrastructureNet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult FazLogin(string usuario, string senha)
        {
            LoginViewModel user = new LoginViewModel();
            LoginDAO a = new LoginDAO();
            user = a.ConsultaLogin(usuario);

            if(senha == user.senha)
            {
                this.HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        public IActionResult CadastraLogin(int id, string usuario, string senha)
        {
            LoginViewModel user = new LoginViewModel();
            LoginDAO a = new LoginDAO();
            try
            {
                a.CadastraLogin(id, usuario, senha);
                return View("Index");
            }
            catch
            {
                ViewBag.Erro = "Cadastro não realizado, erro encontrado!";
                return View("Index");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        public IActionResult Cadastro()
        {
            try
            {
                LoginViewModel login = new LoginViewModel();
                LoginDAO dao = new LoginDAO();
                login.Id = dao.ProximoId();


                return View("Form", login);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
