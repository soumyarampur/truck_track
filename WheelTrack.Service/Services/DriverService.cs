using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.DTO;
using WheelTrack.Core.Services;

namespace WheelTrack.Service.Services
{
    public class DriverService:IDriverService
    {
        public async Task<DriverResponse> CreateDriverAsync(DriverModel driverInfo)
        {
            //DriverResponse organizationResponse = new DriverResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(driverInfo.LastName) || string.IsNullOrWhiteSpace(driverInfo.FirstName))
                {
                    throw new ArgumentException("Organization Name and Code are required.");
                }

                //int addressId = await _orgRepository.InsertAddressAsync(orginfo.Address);


                //// Insert organization with the new addressId
                //int orgid = await _orgRepository.InsertOrganizationAsync(orginfo, addressId);

                DriverResponse organizationResponse = new DriverResponse
                {
                    Driver_Id = 1,
                    ErrorMessage = "Organization created successfully",
                    ErrorCode = "success"
                };

                return organizationResponse;

            }

            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine("An exception occurred while executing the validation tasks: " + ex.Message);
                // You can also throw the exception if you want to halt the execution here
                throw;
            }
        }

    }
}
