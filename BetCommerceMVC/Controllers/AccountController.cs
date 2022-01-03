using BetCommerceMVC.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BetCommerceMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       [HttpGet]
        public ActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            model.Title = "Ms.";
            model.acceptTerms = true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.PostAsJsonAsync("Account/Register", model);
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Redirect("/Login");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult VerifyEmail(VerifyRequest model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.PostAsJsonAsync("Account/verify-email", model);
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Redirect("~/");
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(RegisterVM model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.PostAsJsonAsync("Account/Authenticate", model);
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Redirect("~/");
                }

            }
            return View();
        }
    }
}