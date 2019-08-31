﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Impacta.Autenticacao.Mvc.Startup1))]

namespace Impacta.Autenticacao.Mvc
{
	public class Startup1
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
			app.UseCookieAuthentication(
				new CookieAuthenticationOptions
				{
					AuthenticationType =
					DefaultAuthenticationTypes.ApplicationCookie,
					LoginPath = new PathString("/Home/LoginView")
				}
				);


		}
	}
}
