namespace CodeFirstApproach_EFCORE.Models
{
    public interface IProductOperations
    {
        void InsertProduct(Product p);
        void UpdateProduct(int id,Product p);
        void DeleteProduct(int id);
        Product GetProductByID(int id);
        List<Product> GetAllProducts();
        List<Product> GetAllProductByCategoryID(int categoryID);    
    }
}
