using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(INNOVAMED.Startup1))]

namespace INNOVAMED
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Login/Login"), // Ruta de inicio de sesión
                });
            
        }
    }
}
