using Microsoft.AspNetCore.Mvc;

namespace TweetBook.Controllers
{
    public class TweetbookController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Nick" });
        }
    }
}
