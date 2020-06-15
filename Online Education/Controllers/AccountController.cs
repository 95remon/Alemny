using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Online_Education.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Online_Education.Controllers
{
    public class AccountController : ApiController
    {

        [HttpPost]
        public async Task<IHttpActionResult> postregistration()
        {

           
                UserStore<IdentityUser> store =
                    new UserStore<IdentityUser>(new LearningContext());

                UserManager<IdentityUser> manager =
                    new UserManager<IdentityUser>(store);
                User user = new User();


            string pathImage;
            var httpRequest = HttpContext.Current.Request;



            //Upload Image
            var postedFile = httpRequest.Files["Image"];


            user.Type = httpRequest["Type"];
            user.Name = httpRequest["Name"];
            user.UserName = httpRequest["Name"];
            if (user.Type == "Student")
            {
                user.Level = httpRequest["Level"];
            }
            user.Email = httpRequest["Email"];
            
            user.PasswordHash = httpRequest["Password"];
            user.Address = httpRequest["Address"];
            user.PhoneNumber = httpRequest["PhoneNumber"];
            user.Gender = httpRequest["Gender"];

            if (user.Type == "Instructor")
            {
                pathImage = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                pathImage += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                string filePath = "";
                filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + pathImage);
                pathImage = "http://localhost:51851/Content/Images/" + pathImage;

                user.Image = pathImage;
                postedFile.SaveAs(filePath);

            }
            IdentityResult result = await manager.CreateAsync(user, user.PasswordHash);
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
        [Route("api/account/GetUserInfo/{username}/{password}")]

        public async Task<IHttpActionResult> GetUserInfo(string username, string password) 
        {
            UserStore<User> store =
                      new UserStore<User>(new LearningContext());

            UserManager<User> manager =
                new UserManager<User>(store);

            IdentityUser user = await manager.FindAsync(username, password);
          
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);


        }



    }
}
