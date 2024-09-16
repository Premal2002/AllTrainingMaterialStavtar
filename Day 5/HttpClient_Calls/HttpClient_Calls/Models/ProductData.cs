namespace HttpClient_Calls.Models
{
    public class ProductData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public object rating { get; set; }



        List<ProductData> productList = new List<ProductData>();

        public List<ProductData> getProductData()
        {
            //4.set url in a variable
            string url = "https://fakestoreapi.com/products/category/electronics";

            //5.create a HttpClient object
            HttpClient client = new HttpClient();

            //6. clear the default data format from clients calling environment
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //7. make a call
            var result = client.GetAsync(url).Result;

            //8.check if call is success , if success read the data, else show error
            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<List<ProductData>>();
                data.Wait();
                productList = data.Result.ToList();
                return productList;
            }
            throw new Exception("something went wrong, please contact admin");
        }
    }
}
