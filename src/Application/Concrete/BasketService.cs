using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public BasketService(
            IBasketRepository basketRepository, 
            IProductService productService,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }

        public async Task<Basket> GetBasketByIdAsync(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return basket ?? new Basket(id);
        }

        public async Task<Basket> UpdateBasketAsync(BasketDto basketDto)
        {
            //check producst id and stock, and if there are error(s), throws it.
            var productsInBasket = await _productService.CheckProductsAvailability(basketDto.Items);

            var basket = _mapper.Map<Basket>(basketDto);

            basket.Items = new List<BasketItem>();

            //for add product properties to basket
            productsInBasket.ForEach(product => basket.Items.Add(new BasketItem
            {
                Id = product.Id,
                Price = product.Price,
                ProductName = product.Name,
                Quantity = basketDto.Items.FirstOrDefault(item => item.ProductId == product.Id).Quantity
            }));

            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

            return updatedBasket;
        }
    }
}
