using HttpClient_Calls.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace HttpClient_Calls.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Post() 
        { 
            PostData pObj = new PostData();
            ViewBag.post = pObj.getPostsData();
            return View(pObj);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddEmployee(Employee en)
        {
           Employee employee = new Employee()
            {
                EmpName = "Raj" ,  EmpId=2001, EmpCity = "chennai", DeptId=20, EmpDesignation="Sales", EmpSalary=5000
                 
            };

            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Convert the object to JSON
            var jsonContent = JsonConvert.SerializeObject(employee);
            var content = new System.Net.Http.StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Post the data to the API endpoint
            var response = _httpClient.PostAsync("https://localhost:7186/api/Employees/api/Employees/add", content);

            if (response.Result.IsSuccessStatusCode)
            {
                // Process the response if needed
                var responseData = response.Result.Content.ReadAsStringAsync();
                ViewBag.Response = "Success: " + responseData;
            }
            else
            {
                ViewBag.Response = "Error: " + response.Result;
            }

            return View("AddEmployee");
        }

        public IActionResult ProductByCategory()
        {
            ProductData pObj = new ProductData();
            ViewBag.product = pObj.getProductData();
            return View(pObj);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
