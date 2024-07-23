using Application.Orders.DTOs;
using Application.Products.DTOs;

namespace Application.Products;

public interface IProductService
{
    void AddProduct(AddProductDto productDto);
    void EditProduct(EditProductDto productDto);
    ProductDto GetProductById(Guid id);
    List<ProductDto> GetProducts();
}
