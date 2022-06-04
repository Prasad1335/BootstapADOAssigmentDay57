using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web.Services.Models;
using Web.Services.Utilities;

namespace Web.Services
{
    public class JobServices
    {
        public List<Job> GetAll()
        {
            var jobs = new List<Job>();

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "job_GetAll";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var jobss = new Job
                            {
                                Id = (int)reader["Id"],
                                jobTitle = reader["jobTitle"].GetDataFromDb<string>(),
                                numberOfJobPosition = reader["numberOfJobPosition"].GetDataFromDb<string>(),
                                locationAddress = reader["locationAddress"].GetDataFromDb<string>(),
                                expectedSalaryRange = reader["expectedSalaryRange"].GetDataFromDb<string>()
                            };
                            jobs.Add(jobss);
                        }
                    }
                }
            }

            return jobs;
        }


        public void Delete(int id)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "job_Delete";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

        public Job GetById(int id)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "job_GetById";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var jobs = new Job();
                            jobs.Id = (int)reader["Id"];
                            jobs. jobTitle= reader["jobTitle"].GetDataFromDb<string>();
                            jobs.numberOfJobPosition = reader["numberOfJobPosition"].GetDataFromDb<string>();
                            jobs.locationAddress = reader["locationAddress"].GetDataFromDb<string>();
                            jobs.expectedSalaryRange = reader["expectedSalaryRange"].GetDataFromDb<string>();
                            return jobs;
                        }
                    }
                    return null;
                }
            }
        }

        public void Update(Job jobs)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "job_Update";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", jobs.Id);
                    command.Parameters.AddWithValue("@jobTitle", jobs.jobTitle.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@numberOfJobPosition", jobs.numberOfJobPosition.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@locationAddress", jobs.locationAddress.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@expectedSalaryRange", jobs.expectedSalaryRange.GetDataFromUi<string>());

                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

        public void Add(Job jobs)
        {

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "[job_Add]";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@jobTitle", jobs.jobTitle);
                    command.Parameters.AddWithValue("@numberOfJobPosition", jobs.numberOfJobPosition);
                    command.Parameters.AddWithValue("@locationAddress", jobs.locationAddress);
                    command.Parameters.AddWithValue("@expectedSalaryRange", jobs.expectedSalaryRange);
                  
                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }
    }
}
