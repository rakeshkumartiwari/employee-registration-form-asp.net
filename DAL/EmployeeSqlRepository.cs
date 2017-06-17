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

        public void Delete(string employeeId)
        {
            using (var objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();
                var objCommand = new SqlCommand("sp_Employee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("Action", "Delete");
                objCommand.Parameters.AddWithValue("Action", employeeId);
                objCommand.ExecuteNonQuery();
            }
        }
    }
}
