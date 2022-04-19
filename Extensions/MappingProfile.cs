using AutoMapper;
using CSharpAngular.Api.DataTransferObjects.Articles;
using CSharpAngular.Api.Entities;

namespace CSharpAngular.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<CreateArticleDto, Article>();
        }
    }
}
