using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunApp.Data.Common;
using FunApp.Models;
using FunApp.Services.Models.Categories;

namespace FunApp.Services.DataServices
{
    public class CategoryService:ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            return this.categories.All()
                .Select(x => new IdAndNameViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categories.All().Any(x => x.Id == categoryId);
        }
    }
}
