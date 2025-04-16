using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.DTO;
using WheelTrack.Core.Factories;
using WheelTrack.Core.Repositories;
using Dapper;

namespace WheelTrack.DAL.Repositories
{
    public class OrganizationRepository: IOrganizationRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public OrganizationRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> InsertAddressAsync(addressModel address)
        {
            try
            {
                using (var uow = _dbConnectionFactory.MariaDBInstance())
                {
                    string sql = @"
                        INSERT INTO address (city, state, pincode, address1, address2, country, entity_name) 
                        VALUES (@City, @State, @Pincode, @Address1, @Address2, @Country, @EntityName);
                        SELECT LAST_INSERT_ID();";

                    return await uow.Connection.ExecuteScalarAsync<int>(sql, address, transaction: uow.Transaction);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown here)
                throw new Exception("An error occurred while inserting the address.", ex);
            }
        }

        public async Task<int> InsertOrganizationAsync(organizationModel organization, int AddressId)
        {
            try
            {
                using (var uow = _dbConnectionFactory.MariaDBInstance())
                {
                    string sql = @"
                        INSERT INTO organizations (org_name, org_code, status, address_id, contact_email, contact_phone, domain)
                        VALUES (@OrgName, @OrgCode, @Status, @AddressId, @ContactEmail, @ContactPhone, @Domain);
                        SELECT LAST_INSERT_ID();";

                    var parameters = new
                    {
                        organization.OrgName,
                        organization.OrgCode,
                        organization.Status,
                        AddressId,
                        organization.ContactEmail,
                        organization.ContactPhone,
                        organization.Domain
                    };

                    return await uow.Connection.ExecuteScalarAsync<int>(sql, parameters, transaction: uow.Transaction);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown here)
                throw new Exception("An error occurred while inserting the organization.", ex);
            }
        }
    }
}

