using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OrderController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var products = await _httpClient.GetStringAsync("https://localhost:7243/api/Product");
            return Ok(new
            {
                Message = "Order created.",
                ProductData=products
            });
        }
    }
}
