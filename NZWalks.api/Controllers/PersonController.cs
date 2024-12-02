using Microsoft.AspNetCore.Mvc;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public string ReturnWilliam()
        {
            return "William!!!!!!";
        }
    }
}