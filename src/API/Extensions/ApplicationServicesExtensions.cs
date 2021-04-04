using Application.Concrete;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Core.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();

            services.AddTransient<IValidator<BasketDto>, BasketValidator>();
            services.AddTransient<IValidator<BasketItemDto>, BasketItemValidator>();

            return services;
        }
    }
}
