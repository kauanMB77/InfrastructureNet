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
            HttpContext.Session.Clear();
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
            if(usuario == null || senha == null)
            {
                ViewBag.Erro = "Usuário ou senha em branco!";
                return View("Index");
            }
            LoginViewModel user = new LoginViewModel();
            LoginDAO a = new LoginDAO();
            user = a.ConsultaLogin(usuario);

            if(senha == user.senha)
            {
                if(user.isMaster == true)
                {
                    this.HttpContext.Session.SetString("master", "true");
                }
                else if(user.isADM == true)
                {
                    this.HttpContext.Session.SetString("ADM", "true");
                }
                else
                {
                    this.HttpContext.Session.SetString("Logado", "true");
                }
                /*
                this.HttpContext.Session.SetString("Logado", "true");
                if(user.isADM) { this.HttpContext.Session.SetString("IsADM", "true"); }
                if(user.isMaster) { this.HttpContext.Session.SetString("IsMaster", "true"); }*/
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
