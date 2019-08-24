using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impacta.WebApi.Pessoas.Models;

namespace Impacta.WebApi.Pessoas.Controllers
{
    public class PessoasController : ApiController
    {
		//como não temos ainda o Bd, vamos simular usando uma lista statica
		static List<Pessoa> pessoas = new List<Pessoa>();

		public PessoasController()
		{
				
		}

		//SE o nome do metodo iniciar em Get não é necessário o atributo [HttpGet]
		[HttpGet]
		public List<Pessoa> RetornarNome()
		{
			return pessoas;
		}

		public void Post(string nomeDaPessoa)
		{
			if (!string.IsNullOrEmpty(nomeDaPessoa))
			{
				pessoas.Add(new Pessoa { Nome = nomeDaPessoa});
			}
		}

		public void Post(Pessoa pessoa)
		{
			if (pessoa != null)
			{
				pessoas.Add(pessoa);
				//asdffasfdçllkçnlçjowafjopn
			}
		}



	}
}
