using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Impacta.MOD
{
	public class Editora
	{
		[Display(Name = "Código da Editora")]
		public int EditoraId { get; set; }
		
		[Display(Name = "Razão Social")]
		[Required(ErrorMessage = "Razão Social deve ser informada" )]
		public string Nome { get; set; }

		[EmailAddress]// Se formato não for email emitira uma mensagem
		[Required(ErrorMessage = "E-mail de Contato não esta sendo informado")]
		public string Email { get; set; }

		[Required]
		public string Cnpj { get; set; }

		[Phone]
		public string Telefone { get; set; }

		public Endereco Endereco { get; set; }

		public string NumeroCelular { get; set; }

	}
}
