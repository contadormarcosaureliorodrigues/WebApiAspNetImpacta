using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impacta.WebApi.Pessoas.Models;

namespace Impacta.WebApi.Pessoas.Controllers
{
    public class CursoController : ApiController
    {
		static List<Curso> cursos = new List<Curso>();

		public CursoController()
		{

		}

		[HttpGet]
		public List<Curso> RetornaCurso()
		{
			return cursos;
		}

		public  Curso getcurso (int Id)
		{
			// LINQ para percorrer a lista e encontrar o curso
			var consultaCurso = from c in cursos
								where c.Id.Equals(Id)
								select c;
			// Busca o curso dentro da lista de curso com LAMBDA Expression
			var res = cursos.Where(x => x.Id.Equals(Id)).FirstOrDefault();
		if(consultaCurso.Count() <= 0)
			{
				return null;
			}
			else
			{
				return consultaCurso.First();
			}


		}

		public void PostCurso(Curso curso)
		{
			if (curso != null)
			{
				cursos.Add(curso);
			}
		}

		public void PutCurso(int id, Curso curso)
		{
			if (curso != null && id >0)
			{
				var result = cursos.Where(x => x.Id.Equals(id)).FirstOrDefault();
				result.Nome = curso.Nome;
				result.CargaHoraria = curso.CargaHoraria;

				int posicao = cursos.IndexOf(result);
				cursos.RemoveAt(posicao);
				cursos.Insert(posicao, curso);
				
			}
		}
	
		public List<Curso> DeleteCurso(int id)
		{
			if (id > 0)
			{

				cursos.RemoveAt(cursos.IndexOf(cursos.Where(x => x.Id.Equals(id)).FirstOrDefault()));
			}
			return cursos;
		}


	}
}
