using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.DTO;

namespace WheelTrack.Core.Repositories
{
    public interface IOrganizationRepository
    {
        public  Task<int> InsertAddressAsync(addressModel address);
        public  Task<int> InsertOrganizationAsync(organizationModel org,int addressId);
    }
}
