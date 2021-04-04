using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);

            if(product == null)
            {
                throw new ServiceException(HttpStatusCode.BadRequest, $"Product not exist with given id:{id}");
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var products = await _productsRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> CheckProductsAvailability(List<BasketItemDto> basketItems)
        {
            var productsInBasket = await _productsRepository.GetAllAsync(x => basketItems.Select(x => x.ProductId).Contains(x.Id));

            var output = new List<ProductDto>();

            foreach (var basketItem in basketItems)
            {
                //checking product id
                if(!productsInBasket.Any(x=> x.Id == basketItem.ProductId))
                {
                    throw new ServiceException(HttpStatusCode.BadRequest, $"Product not exist with given id:{basketItem.ProductId}");
                }

                var selectedProduct = productsInBasket.FirstOrDefault(x => x.Id == basketItem.ProductId);

                //checking stock
                if(basketItem.Quantity > selectedProduct.UnitInStock)
                {
                    throw new ServiceException(HttpStatusCode.BadRequest, $"Not enough stock with given id product:{basketItem.ProductId} - {selectedProduct.Name}");
                }


                output.Add(_mapper.Map<ProductDto>(selectedProduct));
            }

            return output;
        }
    }
}
