using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelTrack.Core.Common;
using WheelTrack.Core.DTO;
using WheelTrack.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WheelTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        public readonly IOrganizationService _IOrganizationService;

        public OrganizationController(IOrganizationService OrganizationService)
        {
            this._IOrganizationService = OrganizationService;
           
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrganizationResponse), 201)]
        [ProducesResponseType(typeof(Error), 400)]
        [Route("/v1/api/organizations")]
      

        public async Task<IActionResult> AddOrganization([FromBody] organizationModel orgInfo)
        {
            if (orgInfo == null)
            {
                return BadRequest(new OrganizationResponse
                {
                    ErrorMessage = "Organization information is required",
                    ErrorCode = "failed"
                   
                });
            }

            try
            {
                var response = await _IOrganizationService.AddOrganization(orgInfo);

                if (response?.OrgId > 0)
                {
                    return CreatedAtAction(nameof(AddOrganization), new { id = response.OrgId }, response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OrganizationResponse
                {
                    
                    ErrorCode = "failed",
                    ErrorMessage = $"An error occurred: {ex.Message}"
                });
            }
        }
    }

}

