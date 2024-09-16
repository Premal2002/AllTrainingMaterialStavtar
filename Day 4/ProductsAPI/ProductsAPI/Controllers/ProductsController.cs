using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Products pObj = new Products(); //this is bad code , old fashion
                                        //instead we use DI - Dependency Onjection

        //We will have to specify what this method does for client
        [HttpGet] //2.what the method is doing
        [Route("/products/list")]//3.How will thet access this method
        public IActionResult GetAllProducts()
        {
            //1.this will always return HttpStatusCode and Data(JSON)
            var data = pObj.AllProducts();
            return Ok(data);
        }
        
        [HttpGet]
        [Route("/products/id/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var p = pObj.ProductById(id);
                return Ok(p);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/products/category/{Category}")]
        public IActionResult GetProductsByCategory(string Category)
        {
            try
            {
                var p = pObj.ProductsByCategory(Category);
                return Ok(p);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/products/instock/{trueorfalse}")]
        public IActionResult GetProductsInStock(bool trueorfalse)
        {
            try
            {
                var p = pObj.ProductByAvailablity(trueorfalse);
                return Ok(p);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("/products/count")]
        public IActionResult GteProductCount()
        {
            var total = pObj.ProductsCount();
            return Ok(total);
        }

        [HttpPost]
        [Route("/products/add")]
        public IActionResult AddProduct([FromBody] Products newProduct)
        {
            try
            {
                string add = pObj.AddNewProduct(newProduct);
                return Created("", add);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/products/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var delete = pObj.RemoveProduct(id);
                return Accepted(delete);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/products/update")]
        public IActionResult ModifyProduct([FromBody] Products updatedProductInfo)
        {
            try
            {
                var edit = pObj.EditProduct(updatedProductInfo);
                return Accepted(edit);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
