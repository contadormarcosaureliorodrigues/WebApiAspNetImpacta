using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// vamos adicionar o Entity Framework
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Impacta.MOD;

namespace Impacta.Tarefas.EF
{
	public class RealBooksContexto : DbContext
	{
		//private string conn;

		public RealBooksContexto() : base(@"RealBooksContext")
		//@"RealBooksContext"
		//@"Data Source=(LocalDB)\MSSQLLocalDB;
		//			Initial Catalog=Pessoal;
		//			Integrated Security=True;Pooling=False"
		{

		}

		// Para trabalharr com EF você precisa de uma classe para representar o seu BD
		// que é nossa classe contexto que deve herdar de DBContext
		//Todas as tabelas que vocÊ desejar trabalhar no Banco de Dados devem ser mapeadas 
		//aqui com os DBSet<>
		public DbSet<Editora> Editoras { get; set; }
		public DbSet <Livro> Livros { get; set; }
		
		
		//Por padrão do EF as entidades geradas no banco de dados
		//utilizam o plural do ingles : Ex: Livros -> Livroes
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			//base.OnModelCreating(modelBuilder);
		}

		public System.Data.Entity.DbSet<Impacta.MOD.Endereco> Enderecoes { get; set; }
	}
}
