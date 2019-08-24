using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.MOD;
using Impacta.Tarefas.Business;


namespace Impacta.Tarefas.Controllers
{
    public class RealBooksController : Controller
    {
        // GET: RealBooks
        public ActionResult Index()
        {
			////Criar um objeto do tipo Business
			//EditoraBUS editoraBUS = new EditoraBUS();
			//var listaEditora = editoraBUS.ListarEditoras();

			//Retornamos a variável lista editoras para a VIEW
			//que estará tipada para receber uma lista de Editoras
			return View();
        }

		public ActionResult ListarEditoras()
		{
			EditoraBUS editoraBUS = new EditoraBUS();
			var listaEditora = editoraBUS.ListarEditoras();

			//Retornamos a variável lista editoras para a VIEW
			//que estará tipada para receber uma lista de Editoras
			return View(listaEditora);
		}


        // GET: RealBooks/Details/5
        public ActionResult Details(int id)
        {
			EditoraBUS objEditora = new EditoraBUS();
			var lst = objEditora.BuscarEditora(id);
			return View(lst);
        }

        // GET: RealBooks/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RealBooks/Create
        [HttpPost]
        public ActionResult Create(Editora collection)
        {
            try
            {
				// TODO: Add insert logic here
				// Invocando na camada de negócio o método para salvar os dados da Editora
				EditoraBUS editoraBUS = new EditoraBUS();

				// enviamos para a camada de negócio os dados da editora
				editoraBUS.Salvar(collection);
				//se for bem sucedido retornamos para a página principal
                return RedirectToAction("ListarEditoras");
            }
            catch
            {
                return View();
            }
        }

		// GET: RealBooks/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError("Editora", "Editora inválida.");
				}
				EditoraBUS objEditora = new EditoraBUS();
				var lst = objEditora.BuscarEditora(id);
				return View(lst);
			}
			catch (Exception)
			{

				return View();
			}
			return View();
		}

		// POST: RealBooks/Edit/5
		[HttpPost]
        public ActionResult Edit(int id, Editora collection)
        {
            try
            {
				// TODO: Add update logic here
				EditoraBUS objEditora = new EditoraBUS();

				objEditora.Salvar(collection);
				return RedirectToAction("ListarEditoras");
            }
            catch
            {
                return View();
            }
        }

        // GET: RealBooks/Delete/5
        public ActionResult Delete(int id)
        {
			EditoraBUS objEditora = new EditoraBUS();
			var lst = objEditora.BuscarEditora(id);
			

			//EditoraBUS objEditora = new EditoraBUS();
			objEditora.Excluir(id);

			return View(lst);
		}

        // POST: RealBooks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListarEditoras");
            }
            catch
            {
                return View();
            }
        }
    }
}
