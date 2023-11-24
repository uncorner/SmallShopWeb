using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopWeb.Presentation.Models;

public class ProductListModel
{
    public IEnumerable<ProductInfo> Products { get; set; } = Array.Empty<ProductInfo>(); 

}
