using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTrack.Core.DTO
{
    public class organizationModel
    {
        public string OrgName { get; set; }
        public string OrgCode { get; set; }
        public string Status { get; set; }
        public addressModel Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Domain { get; set; }
    }

    public class addressModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string EntityName { get; set; }
    }

    public class OrganizationResponse
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public int? OrgId { get; set; } // Nullable in case of errors
    }
}
