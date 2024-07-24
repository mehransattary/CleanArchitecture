namespace Domain.ProductsAggregate;

public class ProductImage
{
    public ProductImage(Guid productId, string imageName )
    {
        if (string.IsNullOrEmpty(imageName))
            throw new Exception("imagename is null or empty");

        ProductId = productId;
        ImageName = imageName;
    }

    public long Id { get; set; }

    public Guid ProductId { get; set; }
    public string ImageName { get; set; }

}
