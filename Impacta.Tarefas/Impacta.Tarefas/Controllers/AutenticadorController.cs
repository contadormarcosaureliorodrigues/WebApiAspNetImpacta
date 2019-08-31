using Impacta.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.Tarefas.Business;


namespace Impacta.Tarefas.Controllers
{
    public class AutenticadorController : Controller
    {
		public ActionResult  Formulario()
		{
			return View();
		}

		public  ActionResult Entrar(Usuario usuario)
		{
			if (usuario.Username != null && usuario.Password != null &&
				usuario.Username.Equals("Realbooks") && usuario.Password.Equals("Realbooks"))
			{
				Session["Usuario"] = usuario;
				return RedirectToAction("Index", "RealBooks");
			}
			else
			{
				ViewBag.Mensagem = " Usuário ou senha Incorretos";
				return View("Formulario");
			}
		}

		public ActionResult Sair()
		{
			Session.Abandon();
			return RedirectToAction("Formulario", "Autenticador");

		}
	
    }
}