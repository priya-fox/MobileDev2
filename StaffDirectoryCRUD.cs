using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace StaffDirectory
{
    internal class StaffContactDirectory
    {
        private readonly string _connectionString;

        public StaffContactDirectory()
        {
            _connectionString = @"Data Source=TABLET-LP023O4F\SQLEXPRESS;Initial Catalog=StaffContactDirectory;Integrated Security=True;Encrypt=False";
        }

        public List<Staff> GetStaff()
        {
            List<Staff> staffList = new List<Staff>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM People";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Staff staff = new Staff
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Phone = reader.GetString(2),
                                Department = reader.GetString(3),
                                AddressStreet = reader.GetString(4),
                                AddressCity = reader.GetString(5),
                                AddressState = reader.GetString(6),
                                AddressZip = reader.GetString(7),
                                AddressCountry = reader.GetString(8),
                            };

                            staffList.Add(staff);
                        }
                    }
                }
            }

            return staffList;
        }

        public void AddStaff(Staff staff)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Staff (Name, Phone, Department, AddressStreet, AddressCity, AddressState, AddressZip, AddressCountry) " +
                               "VALUES (@Name, @Phone, @Department, @AddressStreet, @AddressCity, @AddressState, @AddressZip, @AddressCountry)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", staff.Name);
                    command.Parameters.AddWithValue("@Phone", staff.Phone);
                    command.Parameters.AddWithValue("@Department", staff.Department);
                    command.Parameters.AddWithValue("@AddressStreet", staff.AddressStreet);
                    command.Parameters.AddWithValue("@AddressCity", staff.AddressCity);
                    command.Parameters.AddWithValue("@AddressState", staff.AddressState);
                    command.Parameters.AddWithValue("@AddressZip", staff.AddressZip);
                    command.Parameters.AddWithValue("@AddressCountry", staff.AddressCountry);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStaff(int staffId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Staff WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", staffId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}



