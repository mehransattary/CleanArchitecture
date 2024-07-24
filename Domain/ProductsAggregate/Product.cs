using Domain.ProductsAggregate;
using Domain.Shared;

namespace Domain.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Money Price { get; private set; }
    public ICollection<ProductImage> ProductImages { get; set; }
    public Product(string title, Money price)
    {
        Guard(title);

        Title = title;
        Price = price;
        Id =  Guid.NewGuid();
    }
  

    public void Edit(string title, Money price)
    {
        Guard(title);

        Title = title;
        Price = price;
    }

    public void AddImage(string imageName)
    {
        ProductImages.Add(new ProductImage(Id, imageName));
    }
    public void RemoveImage(long id)
    {
        var image = ProductImages.FirstOrDefault(x => x.Id == id);

        if (image == null)
            throw new Exception("image is null");

        ProductImages.Remove(image);
    }
    private static void Guard(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("title");
     
    }
}
