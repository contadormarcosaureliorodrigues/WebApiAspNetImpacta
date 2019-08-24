using Impacta.MOD;
using Impacta.Tarefas.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.Business
{
	public class EditoraBUS
	{
		public List<Editora> ListarEditoras()
		{
			try
			{
				///instanciamos o objeto que se comunica com o banco de dados
				EditoraEF editoraEF = new EditoraEF();
				//executa o metodo listar editoras(Faz o select)
				var ed = editoraEF.ListarEditoras();

				return ed;
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao tentar Validar a busca das Editoras. Erro: \n" + ex.Message);
			}

		}

		public void Salvar(Editora editora)
		{
			try
			{
				if (string.IsNullOrEmpty(editora.Nome))
				{
					throw new Exception("Nome Invalido");
				}
				if (string.IsNullOrEmpty(editora.Email))
				{
					throw new Exception("Email Invalido");
				}
				EditoraEF editoraEF = new EditoraEF();
				editoraEF.Salvar(editora);
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public void Excluir(int id)
		{
				EditoraEF editoraEF = new EditoraEF();
				editoraEF.Excluir(id);

		}

		public Editora BuscarEditora(int id)
		{
			//Instanciando o objeto que se comunica com o banco de dados
			EditoraEF editoraEF = new EditoraEF();

			Editora ed;

			try
			{
				// Executa o metodo listar Editoras (Faz Select)
				ed = editoraEF.BuscarEditora(id);
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao tentar validar a busca de editoras" + ex.Message);
			}

			return ed;
		}

	}
}
