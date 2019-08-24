using Impacta.MOD;
using Impacta.Tarefas.DAL;
using Impacta.Tarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Tarefas.Controllers
{
    public class TarefaController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}
        // GET: Tarefa
        public ActionResult NovaTarefa()
        {
            return View();
        }

		[HttpPost]
		public ActionResult NovaTarefa(TarefaViewModel tarefaView)
		{
			// Usando as boas práticas de programação
			//vamos fazer uso do modelstate
			if (ModelState.IsValid)
			{

				Data ObjData = new Data();
				TarefaMOD tarefaMOD = new TarefaMOD();

				tarefaMOD.Nome = tarefaView.Nome;
				tarefaMOD.Prioridade = tarefaView.Prioridade;
				tarefaMOD.Concluida = tarefaView.Concluida;
				tarefaMOD.Observacao = tarefaView.Observacao;

				var resultado = ObjData.CriarTarefa(tarefaMOD);
				//retornar para o inicio
				//return View("Index");
				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{

				ViewBag.Alerta = "Por favor verifique os dados do formulário";
			}
			return View();

		}
		
		public ActionResult ListarNovasTArefas()
		{
			List<TarefaMOD> tarefas = null;

			try
			{
				Data data = new Data();
				tarefas = data.ListarTarefas();
			}
			catch (Exception ex)
			{
				ViewBag.Alerta = "Ops! Verifique: " + ex.Message;
			}
			return View(tarefas);
		}


        // GET: Tarefa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tarefa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int id)
        {
			Data data = new Data();
			var tarefa = data.ConsultarTarefa(id);

			if (tarefa == null)
			{
				ViewBag.Alerta = "Não foi encontrado o registro Desejado";
				return View("ListaNovasTarefas");
			}
			return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TarefaMOD collection)
        {
            try
            {
				// TODO: Add update logic here

				Data data = new Data();
				var res = data.AtualizarTarefa(id, collection);


				return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int Id, FormCollection collection)
        {
			try
			{
				// TODO: Add delete logic here
				Data data = new Data();
				var res = data.ExcluirTarefa(Id);

				return RedirectToAction("ListarNovasTArefas");
			}
			catch
			{
				return RedirectToAction("ListarNovasTArefas");
			}
		}

        // POST: Tarefa/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {
			return View();
        }
    }
}
