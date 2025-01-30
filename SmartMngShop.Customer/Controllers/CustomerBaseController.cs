using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartMngShop.Customer.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class CustomerBaseController : ControllerBase
    {
        protected IMediator mediator => HttpContext
            .RequestServices.GetRequiredService<IMediator> ();
    }
}
