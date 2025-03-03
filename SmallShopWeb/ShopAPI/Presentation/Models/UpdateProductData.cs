namespace SmallShopWeb.ShopAPI.Presentation.Models;

public record UpdateProductData(int Id, string Name, string? Description, decimal Price)
    : CreateProductData(Name, Description, Price);

