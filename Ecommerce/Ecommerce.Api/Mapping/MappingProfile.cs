using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Ecommerce.Api.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
         
        public MappingProfile()
        { 

            CreateMap<AppUser, RegisterUser>();
            CreateMap<Book, BooksDto>();

          
            //.AfterMap((src, dest) =>
            //     {
            //         dest.ThumbnailPath = 
            //         Path.Combine(_imageSettings.ThumbnailBasePath,
            //         dest.ThumbnailPath);

            //    });
        }
    }
}
