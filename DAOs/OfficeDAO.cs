using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;
using Microsoft.Data.SqlClient;

namespace Task.DAOs
{
    public class OfficeDAO : IOfficeDAO

    {
        private readonly SqlConnection _sqlConnection;
        private static readonly String GetAllOfficesQuery = "SELECT * FROM General.Office";
        private static readonly String GetOfficeByIdQuery = "SELECT * FROM General.Office WHERE office_id = @officeId";

        public OfficeDAO(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OfficeDB") ?? throw new ArgumentNullException("connection string `OfficeDB` cannot be null");
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
        }

        public IEnumerable<Office> GetAllOffices()
        {
            List<Office> offices = [];

            using (SqlCommand command = new SqlCommand(GetAllOfficesQuery, _sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Office office = new Office
                        {
                            OfficeId = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Address1 = reader.GetString(2),
                            Address2 = reader.GetString(3),
                            City = reader.GetString(4),
                            State = reader.GetString(5),
                            ZipCode = reader.GetString(6),
                            PhoneNumber = reader.GetString(7),
                            BillTo = reader.GetString(8),
                            PayToName = reader.GetString(9),
                            PayToAddress1 = reader.GetString(10),
                            PayToAddress2 = reader.GetString(11),
                            PayToCity = reader.GetString(12),
                            PayToState = reader.GetString(13),
                            PayToZipCode = reader.GetString(14),
                            PlaceOfServiceCode = reader.GetString(15),
                            IsDefault = reader.GetBoolean(16)
                        };

                        offices.Add(office);
                    }
                }
            }
            return offices;
        }

        public Office? GetOfficeById(Guid officeId)
        {
            using (SqlCommand command = new SqlCommand(GetOfficeByIdQuery, _sqlConnection))
            {
                command.Parameters.AddWithValue("@officeId", officeId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Office office = new Office
                        {
                            OfficeId = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Address1 = reader.GetString(2),
                            Address2 = reader.GetString(3),
                            City = reader.GetString(4),
                            State = reader.GetString(5),
                            ZipCode = reader.GetString(6),
                            PhoneNumber = reader.GetString(7),
                            BillTo = reader.GetString(8),
                            PayToName = reader.GetString(9),
                            PayToAddress1 = reader.GetString(10),
                            PayToAddress2 = reader.GetString(11),
                            PayToCity = reader.GetString(12),
                            PayToState = reader.GetString(13),
                            PayToZipCode = reader.GetString(14),
                            PlaceOfServiceCode = reader.GetString(15),
                            IsDefault = reader.GetBoolean(16)
                        };

                        return office;
                    }
                }
            }

            return null;
        }

        ~OfficeDAO()
        {
            _sqlConnection.Close();
        }
    }
}