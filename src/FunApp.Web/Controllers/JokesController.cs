using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunApp.Services.DataServices;
using FunApp.Web.Models.Jokes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace FunApp.Web.Controllers
{
    public class JokesController : Controller
    {
        private IJokesService jokesService;
        private ICategoryService categoryService;

        public JokesController(IJokesService jokesService, ICategoryService categoryService)
        {
            this.jokesService = jokesService;
            this.categoryService = categoryService;
        }
        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = categoryService.GetAll().Select(x=> new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var id =  this.jokesService.Create(model.CategoryId, model.Content);
            return this.RedirectToAction("Details", id);
        }

        public IActionResult Details(int id)
        {
            var vm = this.jokesService.GetById(id);
            return this.View(vm);
        }
    }
}