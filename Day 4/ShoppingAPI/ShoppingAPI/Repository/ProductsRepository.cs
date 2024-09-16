using ShoppingAPI.Model;

namespace ShoppingAPI.Repository
{
    public class ProductsRepository
    {
        ShoppingDb2Context db = new ShoppingDb2Context(); //use DI instead

        public List<Product> ProductsByCategory(string category)
        {
            var pr = (from p in db.Products
                      where p.ProductCategory == category
                      select p).ToList();

            return pr;
        }

        public int ProductCount()
        {
            return db.Products.Count();
        }

        public List<Product> GetProductsmatchingName(string startsWith)
        {
            var pr = (from p in db.Products
                      where p.ProductName.StartsWith(startsWith)
                      select p).ToList();

            return pr;
        }
    }
}
