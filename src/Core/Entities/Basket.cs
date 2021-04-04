using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Basket
    {
        public Basket()
        {

        }
        public Basket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public int ProductCount
        {
            get
            {
                return Items.Sum(x => x.Quantity);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(x => x.Price);
            }
        }
    }
}
