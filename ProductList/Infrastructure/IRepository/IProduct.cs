using ProductList.Models;

namespace ProductList.Infrastructure.IRepository
{
    public interface IProduct
    {
        List<ProductInfo> GetProductData();
        ProductInfo GetProductId(int id);
        ProductInfo AddProduct(ProductInfo productInfo);
        ProductInfo UpdateProduct(ProductInfo productInfo);
        ProductInfo DeleteProduct(int id);
        ProductInfo GetProductIdData(int id);
    }
}
