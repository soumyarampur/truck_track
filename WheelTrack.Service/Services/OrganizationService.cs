using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.Common;
using WheelTrack.Core.DTO;
using WheelTrack.Core.Factories;
using WheelTrack.Core.Repositories;
using WheelTrack.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WheelTrack.Service.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IOrganizationRepository _orgRepository;


        public OrganizationService(IOrganizationRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }
        public async Task<OrganizationResponse> AddOrganization(organizationModel orginfo)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(orginfo.OrgName) || string.IsNullOrWhiteSpace(orginfo.OrgCode))
                {
                    throw new ArgumentException("Organization Name and Code are required.");
                }

                int addressId = await _orgRepository.InsertAddressAsync(orginfo.Address);


                // Insert organization with the new addressId
                int orgid = await _orgRepository.InsertOrganizationAsync(orginfo, addressId);

                OrganizationResponse organizationResponse  = new OrganizationResponse
                {
                    OrgId = orgid,
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
