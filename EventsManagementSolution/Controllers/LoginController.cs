using EventsManagementSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventsManagementSolution.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Username  == "admin@vit.com" && model.Password == "123")
                {
                    using(var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Constants.API_BASE_URL);
                        var postTask = client.PostAsJsonAsync<LoginModel>("users/login", model);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            // set a cookie for authenticated login
                            var readTask = result.Content.ReadAsAsync<LoginResponse>();
                            readTask.Wait();
                            int userID = readTask.Result.LoggedInUserId;
                            FormsAuthentication.SetAuthCookie(userID.ToString(), false); // cookie distroies after user closes the bowser
                            Session["user"] = userID;
                            return RedirectToAction("Index", "home");
                            
                        }


                    }

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

      



                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                }
            }
            return View();
        }


    }
}