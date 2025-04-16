using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTrack.Core.DTO
{
    public class DriverModel
    {
        public int OrgId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int AddressId { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public string Status { get; set; } = "active";
        public string LicenseNo { get; set; }
        public string Phone { get; set; }
        public int YearsOfExperience { get; set; } = 0;
        public string ImagePath { get; set; }
    }

    public class DriverResponse
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public int? Driver_Id { get; set; } // Nullable in case of errors
    }
}
