using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Online_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Online_Education.Controllers
{
    public class AccountController : ApiController
    {

        [HttpPost]
        public async Task<IHttpActionResult> postregistration(Account account)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserStore<IdentityUser> store =
                    new UserStore<IdentityUser>(new LearningContext());

                UserManager<IdentityUser> manager =
                    new UserManager<IdentityUser>(store);
                User user = new User();

                user.UserName = account.UserName;
                user.PasswordHash = account.Password;

                IdentityResult result = await manager.CreateAsync(user , user.PasswordHash);
                if (result.Succeeded)
                {
                    return Created("", "register Sucess " + user.UserName);
                }
                else
                {
                    string error = "";
                    foreach (var err in result.Errors)
                    {
                        error += err + "\n";
                    }
                    return BadRequest(error);

                    
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
