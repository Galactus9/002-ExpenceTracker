using Application.DTOs.ExpenseCategoryDTO;
using Application.DTOs.ExpenseDTO;
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
                // Map Expense
                mc.CreateMap<ExpenseGetDTO, Expense>().ReverseMap();
                mc.CreateMap<ExpenseCreateDTO, Expense>().ReverseMap();
                mc.CreateMap<ExpenseUpdateDTO, Expense>().ReverseMap();

                // Map ExpenseCategory
                mc.CreateMap<ExpenseCategoryGetDTO, ExpenseCategory>().ReverseMap();
                mc.CreateMap<ExpenseCategoryCreateDTO, ExpenseCategory>().ReverseMap();
                mc.CreateMap<ExpenseCategoryUpdateDTO, ExpenseCategory>().ReverseMap();

            });

            IMapper Automapper = mapperConfig.CreateMapper();
            services.AddSingleton(Automapper);
        }
    }
}
