using Microsoft.AspNetCore.Mvc;

namespace SmartMngShop.Customer.Controllers
{
    public class CreateCustomerController : CustomerBaseController
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateCustomer()
    }
}
