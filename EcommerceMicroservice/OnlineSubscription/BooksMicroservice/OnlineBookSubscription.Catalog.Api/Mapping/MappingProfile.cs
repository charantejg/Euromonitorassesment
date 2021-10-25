using System.IO;
using Microsoft.AspNetCore.Hosting;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Api.Mapping
{
    public class MappingProfile: AutoMapper.Profile
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public MappingProfile()
        {
            CreateMap<Book, BooksDto>();
        }

        public MappingProfile(Microsoft.Extensions.Configuration.IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;

            CreateMap<Book, BooksDto>()
            .AfterMap((src, dest) =>
                 {
                     dest.Thumbnail =
                     Path.Combine(_env.WebRootPath ,_configuration["ImagePath"], dest.Thumbnail);

                 });

            CreateMap<Subscription, SubscribeDto>().ReverseMap();
         

        }

    }
}
