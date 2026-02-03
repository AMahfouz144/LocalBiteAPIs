using Application.Usecase.Products.DTOs;

namespace Application.Usecase.Menu.DTOs
{
    public class MenuDto
    {
        //public Guid CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }

}
