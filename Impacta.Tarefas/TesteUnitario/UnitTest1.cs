using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Impacta.Tarefas.DAL;
using Impacta.Tarefas.EF;
using Impacta.MOD;

namespace TesteUnitario
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Data dataDAL = new Data();


		}



	[TestMethod]
	public void Test_ContextoCodeFirst()
	{
			RealBooksContexto contexto = new RealBooksContexto();
			Editora editora = new Editora();
			editora.Nome = "Rodrigues";
			editora.Email = "teste@teste.com.br";
			contexto.Editoras.Add(editora);
			contexto.SaveChanges();
			
	}

	}
}
