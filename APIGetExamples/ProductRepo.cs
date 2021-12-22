public static class ProductRepo
{
	public static List<Product> Products { get; set; } = new List<Product>();
	public static void Init(IConfiguration configuration)
	{
		var products = configuration.GetSection("products").Get<List<Product>>();
		Products = products;

	}
	public static void addProduct(Product product)
	{
		Products.Add(product);
	}

	public static Product? getProduct(string code)
	{
		return Products?.First(product => product.Code == code);
	}

	public static void removeProduct(Product product)
	{
		Products?.Remove(product);
	}
}
