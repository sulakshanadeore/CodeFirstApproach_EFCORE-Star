namespace CodeFirstApproach_EFCORE.Models
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(int id,Category category); 
        void Delete(int id);

        Category Find(int id);

        List<Category> GetAll();
    }
}
