namespace HttpClient_Calls.Models
{
    public class PostData
    {
        //1.create properties
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }


        //2.create a variable to store the data
        List<PostData> postsList = new List<PostData>();

        //3.create a method to make the call
        public List<PostData> getPostsData() 
        {
            //4.set url in a variable
            string url = "https://jsonplaceholder.typicode.com/posts";

            //5.create a HttpClient object
            HttpClient client = new HttpClient();

            //6. clear the default data format from clients calling environment
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //7. make a call
            var result = client.GetAsync(url).Result;
           

            //8.check if call is success , if success read the data, else show error
            if(result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsAsync<List<PostData>>();
                data.Wait();
                postsList = data.Result.ToList();
                return postsList;
            }
            throw new Exception("something went wrong, please contact admin");
        }

        


    }
}
