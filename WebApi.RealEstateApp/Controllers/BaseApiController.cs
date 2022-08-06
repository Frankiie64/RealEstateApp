using Microsoft.AspNetCore.Mvc;

namespace WebAPI.RealEstateApp.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
       
    }
}
