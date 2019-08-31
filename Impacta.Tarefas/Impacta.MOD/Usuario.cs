using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Impacta.MOD
{
	public class Usuario
	{
		[Required(ErrorMessage = "Nome do Usuário é obrigatório")]
		[Display(Name = "Usuário")]
		[StringLength(10, MinimumLength =5, ErrorMessage =("Usuário deve conter entre 5 e 10 caracteres"))]
		public string Username { get; set; }

		[Display(Name ="Senha")]
		[Required(ErrorMessage ="A Senha é Obrigatória")]
		public string Password { get; set; }


	}
}
