using System;
using System.Collections.Generic;
using FunApp.Data.Common;
using FunApp.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FunApp.Services.Mapping;
using FunApp.Services.Models.Home;

namespace FunApp.Services.DataServices
{
    public class JokesService : IJokesService
    {
        private IRepository<Joke> jokesRepository;
        private IRepository<Category> categoriesRepository;

        public JokesService(IRepository<Joke> jokeRepository, IRepository<Category> categoriesRepo)
        {
            this.jokesRepository = jokeRepository;
            this.categoriesRepository = categoriesRepo;
        }

        public IEnumerable<IndexJokeViewModel> GerRandomJokes(int count)
        {

            var jokes = this.jokesRepository
                .All()
                .To<IndexJokeViewModel>()
                .Take(count)
                .ToList();

            return jokes;
        }



        public async Task<int> Create(int categoryId, string content)
        {
            //TODO:VALIDATE

            var joke = new Joke()
            {
                CategoryId = categoryId,
                Content = content
            };
            await this.jokesRepository.Add(joke);
            await jokesRepository.SaveChangesAsync();
            var idRet = joke.Id;
            return idRet;
        }

        public IndexJokeViewModel GetById(int id)
        {
            var model = this.jokesRepository
                .All()
                .Where(x => x.Id == id)
                .To<IndexJokeViewModel>()
                .FirstOrDefault();
            return model;

        }
    }


}
