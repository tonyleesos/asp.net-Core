namespace prjDI01.Models
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
    }
}
