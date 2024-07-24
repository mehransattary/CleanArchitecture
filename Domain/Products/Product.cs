using Domain.Shared;

namespace Domain.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Money Price { get; private set; }

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

    private static void Guard(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("title");
     
    }
}
