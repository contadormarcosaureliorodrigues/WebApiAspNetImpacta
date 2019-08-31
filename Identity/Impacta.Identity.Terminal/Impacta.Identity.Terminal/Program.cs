using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//adicionando o identity
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Impacta.Identity.Terminal
{
	class Program
	{
		static void Main(string[] args)
		{

			// criar um usuario e senha 
			// que será armazenado no banco de dados
			// gerenciado pelo Identity
			var nomeUsuario = "contadormarcosaurelio@outlook.com";
			var senha = "senha123!";

			// vamos criar uma estrutura para receber o usuario 
			// e para gerenciar as informações de autenticação
			// para utilizar o identity e criar um novo usuario, precisamos 
			// receber uma instancia de UserStore que é tipado com a classe IdentityUser

			var usuarioArmazenado = new UserStore<IdentityUser>();

			// criar um objeto para fazer a gestão do usuario
			var usuarioGerenciador = new UserManager<IdentityUser>(usuarioArmazenado);

			var resultado = usuarioGerenciador.Create(new IdentityUser(nomeUsuario), senha);
			// verificar o status de retorno da criação do usuario


			// vamos consultar se o usuario foi gerado no BD

			//	var retorno 


			Console.WriteLine("Status Create {0}", resultado.Succeeded);
			//recupera informaçoes do usuario
			var IdentidadeUsuario = usuarioGerenciador.FindByName(nomeUsuario);

			// add claim
			//usuarioGerenciador.AddClaim(IdentidadeUsuario.Id, new Claim("Nome Usuario", "Marcos"));
			// esta forma usa uma constante do identity para colocar a descrição da claim
			// esta linha faz a mesma coisa 
			usuarioGerenciador.AddClaim(IdentidadeUsuario.Id, new Claim(ClaimTypes.GivenName, "Rodrigues"));

			//vamos verificar se o password existe ou esta correto
			var validasenha = usuarioGerenciador.CheckPassword(IdentidadeUsuario, senha);
			// vam,os escrever o resultado da comparação da senha

			Console.WriteLine("Senha Verificada: {0}", validasenha);


			Console.ReadLine();
		}
	}
}
