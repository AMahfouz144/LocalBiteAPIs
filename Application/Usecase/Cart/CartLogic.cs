using Application.Usecase.Cart.Models;
using Domain.Products;

namespace Application.Usecase.Cart
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public List<CartItem> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(i => i.Total);

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
                Items.Remove(item);
        }

        public void UpdateQuantity(Guid productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
                item.Quantity = quantity;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
