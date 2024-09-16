namespace ProductsAPI
{
    public class Products
    {
        #region Properties
        public int productID { get; set; }
        public  string productName { get; set; }
        public string productCategory { get; set; }
        public double productPrice { get; set; }
        public bool productIsInStock { get; set; }
        #endregion

        #region Private Data
        private static List<Products> productList = new List<Products>()
        {
            new Products() { productID = 100, productName = "Pepsi", productCategory = "Cold-Drink", productPrice = 50, productIsInStock = true },
            new Products() { productID = 105, productName = "Dr Pepper", productCategory = "Cold-Drink", productPrice = 65, productIsInStock = false },
            new Products() { productID = 106, productName = "7 Up", productCategory = "Cold-Drink", productPrice = 58, productIsInStock = true },
            new Products() { productID = 107, productName = "Red Bull", productCategory = "Energy-Drink", productPrice = 120, productIsInStock = true },
            new Products() { productID = 108, productName = "Monster Energy", productCategory = "Energy-Drink", productPrice = 130, productIsInStock = true },
            new Products() { productID = 109, productName = "Gatorade", productCategory = "Sports-Drink", productPrice = 75, productIsInStock = false },
            new Products() { productID = 110, productName = "Vitamin Water", productCategory = "Sports-Drink", productPrice = 85, productIsInStock = true },
            new Products() { productID = 113, productName = "Sony WH-1000XM5", productCategory = "Electronics", productPrice = 350, productIsInStock = false },
            new Products() { productID = 114, productName = "Nike Air Max", productCategory = "Footwear", productPrice = 120, productIsInStock = true },
            new Products() { productID = 115, productName = "Adidas Ultraboost", productCategory = "Footwear", productPrice = 140, productIsInStock = true },
            new Products() { productID = 116, productName = "Levi's 501 Jeans", productCategory = "Apparel", productPrice = 80, productIsInStock = true },
            new Products() { productID = 117, productName = "North Face Jacket", productCategory = "Apparel", productPrice = 200, productIsInStock = false },
            new Products() { productID = 118, productName = "Sony 4K TV", productCategory = "Electronics", productPrice = 1500, productIsInStock = true },
            new Products() { productID = 119, productName = "Kindle Paperwhite", productCategory = "Electronics", productPrice = 130, productIsInStock = true }
        };
        #endregion

        #region Methods

        #region Get Methods
        #region List of Products
        public List<Products> AllProducts()
        {
            return productList;
        }
        #endregion

        #region Products By Id
        public Products ProductById(int id)
        {
            var product = (from p in productList
                     where p.productID == id
                     select p).Single();
            if(product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product with id +" + id + " not found");
            }
        }
        #endregion

        #region Products By Category
        public List<Products> ProductsByCategory(string pCategory)
        {
            var products = (from p in productList
                            where p.productCategory == pCategory
                            select p).ToList();
            if(products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new Exception("Products with category +" + pCategory + " not found in the product list");
            }
        }
        #endregion

        #region Products By Avaialability
        public List<Products> ProductByAvailablity(bool trueorfalse)
        {
            var products = (from p in productList
                            where p.productIsInStock == trueorfalse
                            select p).ToList();

            if (products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new Exception("No Products Found!!!");
            }
        }
        #endregion

        #region Total Product Count
        public int ProductsCount()
        {
            return productList.Count;
        }
        #endregion
        #endregion

        #region Add update Delete
        public string AddNewProduct(Products p)
        {
            //validations formating and calculations
            if(p.productName.Length < 3)
            {
                throw new Exception("Please enter valid produtc name(Atleast more that 3 characters)");
            }
            productList.Add(p);
            return "Product Added successfully";
        }

        public string RemoveProduct(int id)
        {
            var pr = (from p in productList
                      where p.productID == id
                      select p).Single();

            if (pr != null) 
            {
                productList.Remove(pr);
                return "Product removed successfully";
            }
            else
            {
                throw new Exception("Product with id +" + id + " not found");
            }
        }

        public string EditProduct(Products products) 
        { 
            var pr =(from p in productList
                     where p.productID == products.productID
                     select p).Single();

            if (pr != null) 
            {
                pr.productName = products.productName;
                pr.productCategory = products.productCategory;
                pr.productPrice = products.productPrice;
                pr.productIsInStock = products.productIsInStock;

                return "Product details updated";
            }
            else
            {
                throw new Exception("Product with id +" + products.ProductById + " not found");
            }
        }
        #endregion

        #endregion
    }
}
