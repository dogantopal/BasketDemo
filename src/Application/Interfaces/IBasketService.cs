using Application.Dtos;
using Core.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasketByIdAsync(string id);
        Task<Basket> UpdateBasketAsync(BasketDto basketDto);
        Task DeleteBasketAsync(string id);
    }
}
