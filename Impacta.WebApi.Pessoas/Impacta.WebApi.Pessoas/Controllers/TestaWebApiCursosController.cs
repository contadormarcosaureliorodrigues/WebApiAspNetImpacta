using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Impacta.WebApi.Pessoas.Controllers
{
    public class TestaWebApiCursosController : Controller
    {
        // GET: TestaWebApiCursos
        public ActionResult Formulario()
        {
            return View();
        }
    }
}