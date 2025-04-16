using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.Common;
using WheelTrack.Core.DTO;

namespace WheelTrack.Core.Services
{
    public interface IOrganizationService
    {
        public Task<OrganizationResponse> AddOrganization(organizationModel orginfo);
    }
}
