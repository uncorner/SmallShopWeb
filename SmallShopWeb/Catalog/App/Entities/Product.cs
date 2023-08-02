using System.ComponentModel.DataAnnotations;

namespace SmallShopWeb.Catalog.App.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Product(string name)
        {
            Name = name;
        } 

    }
}
