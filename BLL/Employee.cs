﻿namespace BLL
{
   public class Employee
    {
       public Employee()
       {
           //always put the default values on the manager country state city as not selected.
           //therefore no need to check for null 
           Manager = 0;
           Country = 0;
           State = 0;
           City = 0;
       }
       public int EmployeeId { get; set; }
       public string EmployeeName { get; set; }
       public string Designation { get; set; }
       public decimal Salary { get; set; }
       public string Email { get; set; }
       public string Mobile { get; set; }
       public string Qualification { get; set; }
       public int Manager { get; set; }
       public int Country { get; set; }
       public int  State { get; set; }
       public int City { get; set; }
    
    }
}
