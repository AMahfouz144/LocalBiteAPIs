namespace Application.Usecase.Order.DTOs
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        // Guest info
        public string? GuestName { get; set; }
        public string? GuestPhone { get; set; }
        public string? GuestEmail { get; set; }
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
