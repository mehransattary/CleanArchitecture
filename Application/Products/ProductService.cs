using Application.Products.DTOs;
using Domain.Products;

namespace Application.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public void AddProduct(AddProductDto productDto)
    {
        var product = new Product(productDto.Title, productDto.Price);
        productRepository.Add(product);
        productRepository.SaveChange();
    }

    public void EditProduct(EditProductDto productDto)
    {
        var product = productRepository.GetById(productDto.Id);
        product.Edit(product.Title, product.Price);
        productRepository.Update(product);
        productRepository.SaveChange(); 
    }

    public ProductDto GetProductById(Guid id)
    {
        var product = productRepository.GetById(id);

        var productDto = new ProductDto()
        {
            Price =product.Price,
            Title = product.Title,            
        };

        return productDto;
    }

    public List<ProductDto> GetProducts()
    {
       var products =productRepository
                    .GetList()
                    .Select(x=>new ProductDto()
                    {
                        Price = x.Price,
                        Title = x.Title,
                        Id = x.Id
                    })
                    .ToList();

        return products;
    }
}
