using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Post api/users
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
