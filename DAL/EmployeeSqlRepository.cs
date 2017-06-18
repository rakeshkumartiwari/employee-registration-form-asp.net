using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class EmployeeSqlRepository
    {
        const string connectionString = @"Data Source=.\SqlExpress; Initial Catalog=RevalsysDb; Integrated Security=true";

        public void Insert(Employee employee)
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objCommand = new SqlCommand("sp_InsertEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("EmployeeName", employee.EmployeeName);
                objCommand.Parameters.AddWithValue("Designation", employee.Designation);
                objCommand.Parameters.AddWithValue("Salary", employee.Salary);
                objCommand.Parameters.AddWithValue("Email", employee.Email);
                objCommand.Parameters.AddWithValue("Mobile", employee.Mobile);
                objCommand.Parameters.AddWithValue("Qualification", employee.Qualification);
                objCommand.Parameters.AddWithValue("Manager", employee.Manager);
                objCommand.ExecuteNonQuery();

            }
        }

        public void Update(Employee employee)
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objCommand = new SqlCommand("sp_UpdateEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("EmployeeId", employee.EmployeeId);
                objCommand.Parameters.AddWithValue("EmployeeName", employee.EmployeeName);
                objCommand.Parameters.AddWithValue("Designation", employee.Designation);
                objCommand.Parameters.AddWithValue("Salary", employee.Salary);
                objCommand.Parameters.AddWithValue("Email", employee.Email);
                objCommand.Parameters.AddWithValue("Mobile", employee.Mobile);
                objCommand.Parameters.AddWithValue("Qualification", employee.Qualification);
                objCommand.Parameters.AddWithValue("Manager", employee.Manager);

                objCommand.ExecuteNonQuery();

            }
        }

        public DataSet GetEmployees()
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("sp_GetAllEmployees", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);

                return objDataSet;
            }
        }

        public Employee GetEmployee(int selectedId)
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("sp_GetEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("EmployeeId", selectedId);
                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);

                var employee = new Employee();

                employee.EmployeeId = Convert.ToInt32(objDataSet.Tables[0].Rows[0]["EmployeeId"].ToString());
                employee.EmployeeName = objDataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
                employee.Designation = objDataSet.Tables[0].Rows[0]["Designation"].ToString();
                employee.Salary = Convert.ToDecimal(objDataSet.Tables[0].Rows[0]["Salary"].ToString());
                employee.Email = objDataSet.Tables[0].Rows[0]["Email"].ToString();
                employee.Mobile = objDataSet.Tables[0].Rows[0]["Mobile"].ToString();
                employee.Qualification = objDataSet.Tables[0].Rows[0]["Qualification"].ToString();

                var managerId = 0;
                var manager = objDataSet.Tables[0].Rows[0]["Manager"].ToString();

                if (Int32.TryParse(manager, out managerId))
                {
                    employee.Manager = managerId;
                }
                return employee;
            }
        }
        public void Delete(int employeeId)
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objCommand = new SqlCommand("sp_DeleteEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("EmployeeId", employeeId);
                objCommand.ExecuteNonQuery();
            }
        }
    }
}
