
namespace CodeFirstApproach_EFCORE.Models
{
    public class CategoryService : ICategoryService
    {
        ShoppingDbContext _context;

        public CategoryService(ShoppingDbContext context)
        {
            _context = context;
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           Category c= _context.Categories.FirstOrDefault(p => p.CategoryID ==id);
            _context.Categories.Remove(c);
            _context.SaveChanges();
        }

        public Category Find(int id)
        {
            // throw new NotImplementedException();
            Category c = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            return c;
        }

        public List<Category> GetAll()
        {
            // throw new NotImplementedException();
            return _context.Categories.ToList();
        }

        public void Update(int id, Category category)
        {
            //throw new NotImplementedException();
            Category c = _context.Categories.FirstOrDefault(p => p.CategoryID == id);
            c.CategroyName = category.CategroyName;
            c.Description = category.Description;   
            _context.SaveChanges();
        }
    }
}
