﻿using Impacta.Autenticacao.Mvc.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Impacta.Autenticacao.Mvc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Inicio()
		{
			return View();
		}

		public ActionResult AreaLivre()
		{
			ViewBag.Message = "Você está na área de acesso livre";

			return View();
		}

		[Authorize]
		public ActionResult AreaRestrita()
		{
			ViewBag.Message = "Você está na área Restrita";

			return View();
		}

		public ActionResult LoginView()
		{
			ViewBag.Message = "Você está na página de Login seja bem vindo!";
			return View();
		}

		public ActionResult CriarLogin()
		{
			Usuario usuario = null;

			return View(usuario);
		}

		[HttpPost]
		public ActionResult CriarLogin(Usuario usuario)
		{
			//Chamar metodo salvar Usuario
			bool resultado = SalvarUsuario(usuario);
			if (resultado)
			{
				return View("Inicio");
			}
			else
			{
				return View("CriarLogin");
			}

		}

		private bool SalvarUsuario(Usuario usuario)
		{
			bool retorno = false;
			//Obter a UserStore, UserManager
			var usuarioStore = new UserStore<IdentityUser>();
			var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);

			//Criar uma Identidade
			var usuarioInfo =
				new IdentityUser() { UserName = usuario.UserName };
			//Gravar
			IdentityResult resultado =
			usuarioGerenciador.Create(usuarioInfo , usuario.Password);

			if (resultado.Succeeded)
			{
				//Autentica e volta para a página inicial
				var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;
				
				var identidadeUsuario =
					usuarioGerenciador.CreateIdentity(usuarioInfo,
						DefaultAuthenticationTypes.ApplicationCookie);

				gerenciadorDeAutenticacao.SignIn( new AuthenticationProperties() { },
				identidadeUsuario);


				retorno = true;
			}
			else
			{
				retorno = false;
			}
			return retorno;
			;
		}

		[HttpPost]
		public ActionResult LoginView(Usuario usuario)
		{
			if (AutenticarUsuario(usuario))
			{
				return View("AreaRestrita");

			}
			else
			{
				return View("Inicio");
			}

		}

		private bool AutenticarUsuario(Usuario usuario)
		{
			bool retorno = false;
			var usuarioStore = new UserStore<IdentityUser>();
			var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);

			var usuarioIdentidade = usuarioGerenciador.Find(usuario.UserName, usuario.Password);

			if (usuarioIdentidade !=null)
			{
				var gerenciadorDeAutenticacao = HttpContext.GetOwinContext().Authentication;

				var identidade = usuarioGerenciador.CreateIdentity(usuarioIdentidade,
				DefaultAuthenticationTypes.ApplicationCookie);
				gerenciadorDeAutenticacao.SignIn(
					new AuthenticationProperties()
					{ IsPersistent = false },
					identidade);
				retorno = true;
			}
			else
			{
				ViewBag.MensagemErro = "Usuario ou senha Invalida.";

				retorno = false;
			}
			return retorno;

		}
	}
}