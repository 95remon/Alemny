using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Online_Education.Models;
using Owin;

[assembly: OwinStartup(typeof(Online_Education.Startup1))]

namespace Online_Education
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            

            //use middle creat token cookie oauth
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                //URl http how expirestion
                TokenEndpointPath = new PathString("/login"),  //http-https

                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),

                AllowInsecureHttp = true,

                //how to create token (fields)==>
                Provider = new TokenCreate()

            }); ;
            //Check token valid 
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());



            HttpConfiguration config = new HttpConfiguration();

            
            
            


            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            app.UseWebApi(config);
        }
    }
    //inherit class ==>override
    internal class TokenCreate : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            context.Validated();
        }
        //Check User Password ==>login {"":,""} ==>create Token
        public override async Task GrantResourceOwnerCredentials
            (OAuthGrantResourceOwnerCredentialsContext context)//Method//Request Body /login
        {
            //OWin Cors
            context.OwinContext.Response.Headers.Add(" Access - Control - Allow - Origin ", new[] { "*" });
            //Check
            UserStore<User> store =
                    new UserStore<User>(new LearningContext());

            UserManager<User> manager =
                new UserManager<User>(store);

            IdentityUser user = await manager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("grant_error", "username & password Not Valid");  //Invalid
            }
            else
            {
                //Create token
                ClaimsIdentity claims = new ClaimsIdentity(context.Options.AuthenticationType); //Token beare -jwt cookie

                //Fields 
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                if (manager.IsInRole(user.Id, "Admin"))
                    claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
              
                context.Validated(claims);
            }

        }
    }
}
