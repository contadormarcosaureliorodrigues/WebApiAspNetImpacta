using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Impacta.MOD;

namespace Impacta.Tarefas.ClientAPI
{
	class Program
	{
		
		static void Main(string[] args)
		{
			
			//executa o metodo assincrono para chamada da API
			RunAsync().Wait();
		}

		static async Task RunAsync()
		{
			var formato = new MediaTypeWithQualityHeaderValue("application/json");

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:53584/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(formato);

				//HttpResponseMessage httpRes = new HttpResponseMessage();
				// o metodo GETASSYNC() Vai solicitar a aexecução da sua API 
				//e obter um valor de resposta, armazenado na variavel resposta
				var resposta = await client.GetAsync("api/WebApiEditora");
//				string conteudo = await resposta.Content.ReadAsAsync<string>();


				//nós precisamos definir qual o tipo de retorno iremos obter
				//neste caso podemos definir de duas maneiras
				// 1) definimos um objeto de retorno similar ao da assinatura da API
				// 2) definimos uma modelagem de classe igual a retornada pela API
				//var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<object>>();
				// Na segunda forma seria assim
				var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<Editora>>();
				foreach (var item in conteudo)
				{
					Console.WriteLine(string.Format(
						"EditoraID: {0}, Nome: {1}", item.EditoraId, item.Nome));

				}


				Console.WriteLine(conteudo);
				Console.ReadLine();
			}
		

		}

	}
}
