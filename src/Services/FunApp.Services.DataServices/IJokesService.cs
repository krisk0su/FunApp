using System.Collections.Generic;
using System.Threading.Tasks;
using FunApp.Services.Models.Home;


namespace FunApp.Services.DataServices
{
    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GerRandomJokes(int count);
        Task<int> Create(int categoryId, string content);
        IndexJokeViewModel GetById(int id);
    }
}