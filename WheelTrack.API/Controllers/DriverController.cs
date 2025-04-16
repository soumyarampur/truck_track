using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelTrack.Core.DTO;
using WheelTrack.Core.Services;

namespace WheelTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public readonly IDriverService _IDriverService;

        public DriverController(IDriverService DriverService)
        {
            this._IDriverService = DriverService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] DriverModel driver)
        {
            if (driver == null || driver.OrgId == 0)
            {
                return BadRequest("Invalid driver data.");
            }

            var response = await _IDriverService.CreateDriverAsync(driver);
            return CreatedAtAction(nameof(CreateDriver), new { id = response.Driver_Id }, driver);
        }

    }
}
