using Application.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<BasketDto, Basket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
