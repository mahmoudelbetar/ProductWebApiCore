namespace Day1Lab.Models.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int? id);
        Product GetByName(string? name);
        void Add(Product product);
        void Update(Product product);
        void Delete(int? id);
    }
}
