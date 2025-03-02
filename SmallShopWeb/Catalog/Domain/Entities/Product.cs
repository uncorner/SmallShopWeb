using System.ComponentModel.DataAnnotations;

namespace SmallShopWeb.Catalog.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Product(string name)
        {
            Name = name;
        } 

    }
}
