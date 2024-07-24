using Application.Products.DTOs;
using Domain.Products;
using Domain.Shared;

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
        var product = new Product(productDto.Title, new Money(productDto.Price) );
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
            Price = product.Price.Value,
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
                        Price = x.Price.Value,
                        Title = x.Title,
                        Id = x.Id
                    })
                    .ToList();

        return products;
    }
}
