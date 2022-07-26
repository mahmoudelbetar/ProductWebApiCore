namespace Day1Lab.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Product product)
        {
            if(product != null)
            {
                db.Add(product);
                db.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            if(id != null || id != 0)
            {
                Product? product = db.Products.FirstOrDefault(p => p.Id == id);
                db.Remove(product);
                db.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public Product GetById(int? id)
        {
            if (id != null || id != 0)
            {
                Product? product = db.Products.FirstOrDefault(p => p.Id == id);
                return product;
            }
            else
            {
                return default;
            }
        }

        public Product GetByName(string? name)
        {
            if(name != null || name != "")
            {
                return db.Products.FirstOrDefault(p => p.Name == name);
            }
            else
            {
                return null;
            }
        }

        public void Update(Product product)
        {
            if(product != null)
            {
                db.Update(product);
                db.SaveChanges();
            }
        }
    }
}
