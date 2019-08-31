using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.MOD;

using System.Web.Security;

namespace Impacta.Tarefas.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Autenticacao()
        {
			Usuario usuario = null;
			
            return View(usuario);

        }
		//[Authorize]
		[HttpPost]
		public ActionResult AutenticarLogin(Usuario usuario)
		{
			//segundo parametro é relatiovo ao cookie,
			//é para persistir o usuario, caso seja true,
			//ele sempre irá considerar que o usuario ja esta autenticado
			FormsAuthentication.SetAuthCookie(usuario.Username, false);
			return RedirectToAction("Index", "RealBooks");
		}

		public ActionResult Logout()
		{
			//Remove FormeAutentication do Browser
			FormsAuthentication.SignOut();

			//retorna para a View Login
			return View("Autenticacao");
		}
    }
}