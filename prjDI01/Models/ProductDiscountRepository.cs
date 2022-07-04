namespace prjDI01.Models
{
    public class ProductDiscountRepository : IProductRepository
    {
        public IList<Product> GetAll()
        {
            var products = new ProductDataSource().GetProducts().
                Select(x=>new Product { Id=x.Id, Classification=x.Classification,Name=x.Name,Price=(int)(x.Price*0.9)}).ToList();
            return products;
        }
    }
}
