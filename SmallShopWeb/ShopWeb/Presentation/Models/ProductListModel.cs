using SmallShopWeb.ShopCommon.Dto;

namespace SmallShopWeb.ShopWeb.Presentation.Models;

public class ProductListModel
{
    public IEnumerable<ProductInfo> Produts { get; set; } = Array.Empty<ProductInfo>(); 

}
