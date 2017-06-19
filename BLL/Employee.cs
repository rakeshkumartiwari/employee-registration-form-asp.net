namespace BLL
{
   public class Employee
    {
       public int EmployeeId { get; set; }
       public string EmployeeName { get; set; }
       public string Designation { get; set; }
       public decimal Salary { get; set; }
       public string Email { get; set; }
       public string Mobile { get; set; }
       public string Qualification { get; set; }
       public int? Manager { get; set; }
       public int Country { get; set; }
       public int  State { get; set; }
       public int City { get; set; }
    }
}
