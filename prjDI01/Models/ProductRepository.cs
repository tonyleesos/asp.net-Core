namespace prjDI01.Models
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> GetAll()
        {
            var products = new ProductDataSource().GetProducts();
            return products;
        }
    }
}
