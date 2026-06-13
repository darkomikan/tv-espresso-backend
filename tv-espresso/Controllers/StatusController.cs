using Microsoft.AspNetCore.Mvc;
using tv_espresso.Services;

namespace tv_espresso.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StatusController : ControllerBase
    {
        private readonly StatusService statusService;

        public StatusController(StatusService statusService) => this.statusService = statusService;

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetLatest()
        {
            string latest = statusService.GetLatestVersion();
            return Ok(new
            {
                version = latest.Substring(latest.IndexOf("tv-espresso_") + 12, 5),
                uri = latest
            });
        }
    }
}
