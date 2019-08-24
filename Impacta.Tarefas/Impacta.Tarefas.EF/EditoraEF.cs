using Impacta.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.EF
{
	public class EditoraEF
	{
		public List<Editora> ListarEditoras()
		{
			List<Editora> listaDeEditora = null;

			using (RealBooksContexto realDB = new RealBooksContexto())
			{
				//uma vez instanciado o contexto precisamos retornar os dados do Banco via Select
				listaDeEditora = realDB.Editoras.ToList();

			}
			return listaDeEditora;

		}

		public void Salvar(Editora editora)
		{
			using (RealBooksContexto db = new RealBooksContexto())
			{
				//verifica se o ID já Existe, se existe é porque não é um cadastro novo
				//então é uma alteração
				if (editora.EditoraId > 0)
				{
					//busca no banco de dados o registro por ID
					var result = db.Editoras.Where(x => x.EditoraId == editora.EditoraId).FirstOrDefault();
					result.Nome = editora.Nome;
					result.Email = editora.Email;
					result.Cnpj = editora.Cnpj;
					result.Telefone = editora.Telefone;
					//	Faz o update no registro alterado
					db.SaveChanges();
				}

				else
				{
					db.Editoras.Add(editora);
					//faz um insert no banco
					db.SaveChanges();
				}

			}
		}

		public Editora BuscarEditora(int id)
		{
			Editora editora = null;
			//conectando no banco
			using (RealBooksContexto realDB = new RealBooksContexto())
			{

				//uma vez instanciado o contexto precisamos retornar os dados do Banco via select
				using (var db = new RealBooksContexto())
				{
					editora = db.Editoras.Where(p => p.EditoraId == id).FirstOrDefault();
				}
			}
			return editora;
		}
		public void Excluir(int id)
		{
			using (var realDB = new RealBooksContexto())
			{
				//Busca a editora pelo ID
				var editora = realDB.Editoras.Where(i => i.EditoraId == id).FirstOrDefault();
				realDB.Editoras.Remove(editora);
				realDB.SaveChanges();
			}
		}

	}




}
