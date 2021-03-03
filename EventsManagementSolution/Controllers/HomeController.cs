using EventsManagementSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EventsManagementSolution.Controllers
{
    public class HomeController : Controller
    {



        // GET: Home


        public ActionResult Index()
        {
            IEnumerable<EventModel> Events = null;
            
            

            if (!Request.IsAuthenticated || Session["user"] == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.API_BASE_URL);
                    var respnseTask = client.GetAsync("events/public");
                    respnseTask.Wait();

                    var result = respnseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EventModel>>();
                        readTask.Wait();

                        Events = readTask.Result;
                    }

                    else //web api sent error response 
                    {
                        //log response status here..

                        Events = Enumerable.Empty<EventModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                }

            }

            else
            {
                var LoggedUserID = (int)Session["user"] as object;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.API_BASE_URL);
                    var respnseTask = client.GetAsync(string.Format("events/all/{0}", LoggedUserID));
                    respnseTask.Wait();

                    var result = respnseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EventModel>>();
                        readTask.Wait();

                        Events = readTask.Result;
                    }

                    else //web api sent error response 
                    {
                        //log response status here..

                        Events = Enumerable.Empty<EventModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                }



            }

            return View(Events);
        }
    }
}