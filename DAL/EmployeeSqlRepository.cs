﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class EmployeeSqlRepository
    {
        private const string ConnectionString =
            @"Data Source=.\SqlExpress; Initial Catalog=RevalsysDb; Integrated Security=true";

        public void Insert(Employee employee)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
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
                objCommand.Parameters.AddWithValue("Country", employee.Country);
                objCommand.Parameters.AddWithValue("State", employee.State);
                objCommand.Parameters.AddWithValue("City", employee.City);
                objCommand.ExecuteNonQuery();
                //change stored proc 
            }
        }

        public void Update(Employee employee)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
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
                objCommand.Parameters.AddWithValue("Country", employee.Country);
                objCommand.Parameters.AddWithValue("State", employee.State);
                objCommand.Parameters.AddWithValue("City", employee.City);
                objCommand.ExecuteNonQuery();
            }
        }

        public DataSet GetEmployees()
        {
            using (var objConnection = new SqlConnection(ConnectionString))
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
            using (var objConnection = new SqlConnection(ConnectionString))
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
                employee.Designation = objDataSet.Tables[0].Rows[0]["Designation"] != DBNull.Value ? Convert.ToInt32(objDataSet.Tables[0].Rows[0]["Designation"].ToString()) : 0; ;
                employee.Salary = Convert.ToDecimal(objDataSet.Tables[0].Rows[0]["Salary"].ToString());
                employee.Email = objDataSet.Tables[0].Rows[0]["Email"].ToString();
                employee.Mobile = objDataSet.Tables[0].Rows[0]["Mobile"].ToString();
                employee.Qualification = objDataSet.Tables[0].Rows[0]["Qualification"] != DBNull.Value ? Convert.ToInt32(objDataSet.Tables[0].Rows[0]["Qualification"].ToString()) : 0; ;

                var managerNull = 0;
                var manager = objDataSet.Tables[0].Rows[0]["ManagerId"].ToString();

                if (Int32.TryParse(manager, out managerNull))
                {
                    employee.Manager = managerNull;
                }

                employee.Country = objDataSet.Tables[0].Rows[0]["Country"] != DBNull.Value ? Convert.ToInt32(objDataSet.Tables[0].Rows[0]["Country"].ToString()) : 0;
                employee.State = objDataSet.Tables[0].Rows[0]["State"] != DBNull.Value ? Convert.ToInt32(objDataSet.Tables[0].Rows[0]["State"].ToString()) : 0;
                employee.City = objDataSet.Tables[0].Rows[0]["City"] != DBNull.Value ? Convert.ToInt32(objDataSet.Tables[0].Rows[0]["City"].ToString()) : 0;
                return employee;
            }
        }

       

        public void Delete(int employeeId)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                var objCommand = new SqlCommand("sp_DeleteEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("EmployeeId", employeeId);
                objCommand.ExecuteNonQuery();
            }
        }
        public DataSet Designation()
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();

                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("select * from tbl_Rakesh_Designation", objConnection);

                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                return objDataSet;

            }
        }
        public DataSet Qualification()
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();

                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("select * from tbl_Rakesh_Qualification", objConnection);

                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                return objDataSet;

            }
        }
        public DataSet Country()
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();

                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("select * from tbl_Rakesh_Country", objConnection);

                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                return objDataSet;

            }
        }
        public DataSet State(int countryId)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();

                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("select * from tbl_Rakesh_State where CountryId=" + countryId + "", objConnection);

                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                return objDataSet;

            }
        }
        public DataSet City(int stateId)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();

                var objDataSet = new DataSet();
                var objCommand = new SqlCommand("select * from tbl_Rakesh_City where stateId='" + stateId + "'", objConnection);

                var objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                return objDataSet;

            }
        }
    }
}
