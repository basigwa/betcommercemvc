using BetCommerceMVC.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BetCommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<ProductsViewModel> members = null;
            IEnumerable<ProductCategoryVM> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/api/v1/bet/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("product/get-products");
                var responseTask2 = client.GetAsync("product/get-product-categories");
                responseTask.Wait();
                responseTask2.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                //If success received   
                if (result.IsSuccessStatusCode&result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductsViewModel>>();
                    var readCategories = result2.Content.ReadAsAsync<IList<ProductCategoryVM>>();
                    readTask.Wait();
                    readCategories.Wait();

                    members = readTask.Result;
                    categories = readCategories.Result;
                    ViewBag.Products = members;
                    ViewBag.Categories = categories;

                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<ProductsViewModel>();
                    ViewBag.Products = members;
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View();
        }
        public ActionResult Products()
        {
            IEnumerable<ProductsViewModel> members = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44373/api/v1/bet/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("product/get-products");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductsViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                    ViewBag.Products = members;

                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<ProductsViewModel>();
                    ViewBag.Products = members;
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}