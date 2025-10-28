
namespace CodeFirstApproach_EFCORE.Models
{
    public class ProductServiceOperations : IProductOperations
    {
        ShoppingDbContext _context;
        public ProductServiceOperations(ShoppingDbContext context)
        {
                _context = context; 
        }
        public void DeleteProduct(int id)
        {
            Product p=_context.Products.FirstOrDefault(x => x.Prodid == id);

            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public List<Product> GetAllProductByCategoryID(int categoryID)
        {
            List<Product> products=(from p in _context.Products
                                   where p.CategoryID   ==categoryID
                                   select   p).ToList();
            return products;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductByID(int id)
        {
         return _context.Products.FirstOrDefault(x => x.Prodid == id);    
        }

        public void InsertProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges(); 
        }

        public void UpdateProduct(int id, Product p)
        {
           Product existingProduct= _context.Products.FirstOrDefault(x => x.Prodid == id);
            existingProduct.ProdName = p.ProdName;
            existingProduct.Price = p.Price;    
            existingProduct.CategoryID = p.CategoryID;
            _context.SaveChanges();
        }
    }
}
