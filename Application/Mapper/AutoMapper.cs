using Application.DTOs.ExpenceCategoryDTO;
using Application.DTOs.ExpenceDTO;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public static class AutoMapper
    {
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                // Map Expence
                mc.CreateMap<ExpenceGetDTO, Expence>().ReverseMap();
                mc.CreateMap<ExpenceCreateDTO, Expence>().ReverseMap();
                mc.CreateMap<ExpenceUpdateDTO, Expence>().ReverseMap();
                
                // Map ExpenceCategory
                mc.CreateMap<ExpenceCategoryGetDTO, ExpenceCategory>().ReverseMap();
                mc.CreateMap<ExpenceCategoryCreateDTO, ExpenceCategory>().ReverseMap();
                mc.CreateMap<ExpenceCategoryUpdateDTO, ExpenceCategory>().ReverseMap();
            });

            IMapper Automapper = mapperConfig.CreateMapper();
            services.AddSingleton(Automapper);
        }
    }
}
