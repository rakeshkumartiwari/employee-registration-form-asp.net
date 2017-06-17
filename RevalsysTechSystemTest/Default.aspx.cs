using System;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace RevalsysTechSystemTest
{
    public partial class Default : System.Web.UI.Page
    {
        private const string SELECTED_EMPLOYEE = "SELECTED_EMPLOYEE";

        private const string ACTION_INSERT = "ACTION_INSERT";
        private const string ACTION_UPDATE = "ACTION_UPDATE";
        private const string ACTION_DELETE = "ACTION_DELETE";

        private const string ACTION_NAME = "ACTION_NAME";
        private EmployeeSqlRepository _repository;
        public Default()
        {
            _repository = new EmployeeSqlRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                UpdateActionButtonText();
            }
            if (!IsPostBack)
            {
                ClearErrorMessage();
            }
            RefrashEmployeesGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var actionName = GetCurrentActionName();
                switch (actionName)
                {
                    case ACTION_UPDATE:
                        UpdateEmployee();
                        break;
                    case ACTION_DELETE:
                        DeleteEmployee();
                        break;
                    case ACTION_INSERT:
                        InsertEmployee();
                        break;
                    default:
                        throw new Exception("No action define");

                }
                ClearEmployeeDetails();
                RefrashEmployeesGrid();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void HandleException(Exception exception)
        {
            lblError.Text = exception.Message;
        }

        private void InsertEmployee()
        {
            _repository.Insert(GetEmployeeFromUI());
        }

        private void DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        private void UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        protected void gridViewEmployees_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var fetchedEmployeeId = gridViewEmployees.DataKeys[e.NewEditIndex];
            if (fetchedEmployeeId != null)
            {
                Session[SELECTED_EMPLOYEE] = fetchedEmployeeId.Value;
                Session[ACTION_NAME] = ACTION_UPDATE;
                UpdateActionButtonText();
            }

        }

        protected void gridViewEmployees_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        private void RefrashEmployeesGrid()
        {
            gridViewEmployees.DataSource = null;
            gridViewEmployees.DataSource = _repository.GetEmployees();
            gridViewEmployees.DataBind();
        }

        private void ClearEmployeeDetails()
        {
            txtEmployeeName.Text = string.Empty;
            ddlDesignation.SelectedIndex = -1;
            txtSalary.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            ddlQualification.SelectedIndex = -1;
            txtManager.Text = string.Empty;
        }

        private void ClearErrorMessage()
        {
            lblError.Text = string.Empty;
        }

        private void UpdateActionButtonText()
        {
            var actionName = GetCurrentActionName();
            switch (actionName)
            {
                case ACTION_UPDATE:
                    btnSubmit.Text = "Update";
                    break;
                case ACTION_DELETE:
                    btnSubmit.Text = "Delete";
                    break;
                case ACTION_INSERT:
                    btnSubmit.Text = "Submit";
                    break;
                default:
                    btnSubmit.Text = "Submit";
                    break;

            }
        }

        private string GetCurrentActionName()
        {
            return Session[ACTION_NAME] == null ? ACTION_INSERT : Session[ACTION_NAME].ToString();
        }
        private Employee GetEmployeeFromUI()
        {
            var employee = new Employee();
            employee.EmployeeName = txtEmployeeName.Text;
            employee.Designation = ddlDesignation.SelectedItem.Text;
            employee.Salary = Convert.ToDecimal(txtSalary.Text);
            employee.Email = txtEmail.Text;
            employee.Mobile = txtMobile.Text;
            employee.Qualification = ddlQualification.SelectedItem.Text;
            var managerId = 0;
            if (Int32.TryParse(txtManager.Text, out managerId))
            {
                employee.Manager = managerId;
            }
            return employee;
        }



    }
}