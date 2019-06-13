using AutoMapper;
using FunApp.Models;
using FunApp.Services.Mapping;

namespace FunApp.Services.Models.Home
{
    public class IndexJokeViewModel: IMapFrom<IndexJokeViewModel>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Joke, IndexJokeViewModel>()
                .ForMember(x=> x.CategoryName, 
                   x=> x.MapFrom(j => j.Category.Name))
                .ForMember( x=> x.Id, 
                    x=> x.MapFrom(j => j.Id))
                .ForMember(x=> x.Content, 
                    x=> x.MapFrom(j => j.Content
                    ));
        }
    }

   
}
