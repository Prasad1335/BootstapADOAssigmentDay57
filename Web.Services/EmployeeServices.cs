using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web.Services.Models;
using Web.Services.Utilities;

namespace Web.Services
{
    public class EmployeeServices
    {
        public List<Employee> GetAll()
        {
            var emp = new List<Employee>();

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_GetAll";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                Id = (int)reader["Id"],
                                empNumber = reader["empNumber"].GetDataFromDb<int>(),
                                empName = reader["empName"].GetDataFromDb<string>(),
                                empGender = reader["empGender"].GetDataFromDb<string>(),
                                empAddress = reader["empAddress"].GetDataFromDb<string>(),
                                empDepartment = reader["empDepartment"].GetDataFromDb<string>(),
                                empPosition = reader["empPosition"].GetDataFromDb<string>(),
                                empDOJ = reader["empDOJ"].GetDataFromDb<DateTime>(),
                                empEmail = reader["empEmail"].GetDataFromDb<string>()
                               

                            };


                            emp.Add(employee);
                        }
                    }
                }
            }

            return emp;
        }


        public void Delete(int id)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Delete";

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

        public Employee GetById(int id)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "Employee_GetById";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var employees = new Employee();
                            employees.Id = (int)reader["Id"];
                            employees.empNumber = reader["empNumber"].GetDataFromDb<int>();
                            employees.empName = reader["empName"].GetDataFromDb<string>();
                            employees.empGender = reader["empGender"].GetDataFromDb<string>();
                            employees.empAddress = reader["empAddress"].GetDataFromDb<string>();
                            employees.empDepartment = reader["empDepartment"].GetDataFromDb<string>();
                            employees.empPosition = reader["empPosition"].GetDataFromDb<string>();
                            employees.empDOJ = reader["empDOJ"].GetDataFromDb<DateTime>();
                            employees.empEmail = reader["empEmail"].GetDataFromDb<string>();
                            return employees;
                        }
                    }
                    return null;
                }
            }
        }

        public void Update(Employee employees)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Update";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", employees.Id);
                    command.Parameters.AddWithValue("@empNumber", employees.empNumber.GetDataFromUi<int>());
                    command.Parameters.AddWithValue("@empName", employees.empName.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@empGender", employees.empGender.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@empAddress", employees.empAddress.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@empDepartment", employees.empDepartment.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@empPosition", employees.empPosition.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@empDOJ", employees.empDOJ.GetDataFromUi<DateTime>());
                    command.Parameters.AddWithValue("@empEmail", employees.empEmail.GetDataFromUi<string>());

                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

        public void Add(Employee employees)
        {

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Add";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@empNumber", employees.empNumber);
                    command.Parameters.AddWithValue("@empName", employees.empName);
                    command.Parameters.AddWithValue("@empGender", employees.empGender);
                    command.Parameters.AddWithValue("@empAddress", employees.empAddress);
                    command.Parameters.AddWithValue("@empDepartment", employees.empDepartment);
                    command.Parameters.AddWithValue("@empPosition", employees.empPosition);
                    command.Parameters.AddWithValue("@empDOJ", employees.empDOJ);
                    command.Parameters.AddWithValue("@empEmail", employees.empEmail);
                   


                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }
    }
}
