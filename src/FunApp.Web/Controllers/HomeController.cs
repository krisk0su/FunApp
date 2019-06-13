using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services.DataServices;
using FunApp.Services.Models.Home;
using Microsoft.AspNetCore.Mvc;
using FunApp.Web.Models;


namespace FunApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IJokesService jokesService;


        public HomeController(IJokesService service)
        {
            this.jokesService = service;
        }
        public IActionResult Index()
        {


            var viewModel = new IndexJokesViewModel()
            {
                Jokes = this.jokesService.GerRandomJokes(10)
            };
            return this.View(viewModel);

        }

           
        

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
