using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace RevalsysTechSystemTest
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly EmployeeSqlRepository _repository;
        private readonly EmployeeSession _employeeSession;
        public Default()
        {
            _repository = new EmployeeSqlRepository();
            _employeeSession = new EmployeeSession();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LogCurrentSession();
            }
            if (!IsPostBack)
            {
                ClearErrorMessage();
                ClearLogInUi();
                RefreshEmployeesGrid();
                BindDdlCountry();
                BindDdlState();
                BindDdlCity();
                LogCurrentSession();
            }


        }

        #region BUTTON EVENT HANDLERS
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessAction();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void ProcessAction()
        {
            var actionName = _employeeSession.GetCurrentActionName();

            switch (actionName)
            {
                case EmployeeConstants.ACTION_UPDATE:
                    UpdateEmployee();
                    break;
                case EmployeeConstants.ACTION_DELETE:
                    DeleteEmployee();
                    break;
                case EmployeeConstants.ACTION_INSERT:
                    InsertEmployee();
                    break;
                default:
                    throw new Exception("No action define");

            }

            AfterActionProcessed();
        }

        private void AfterActionProcessed()
        {
            ClearEmployeeDetails();
            RefreshEmployeesGrid();
            ResetEmployeeSession();
            UpdateEmployeeButtons();
            ClearDdlCity();
            ClearDdlState();
            //do no clear country since it is needed for add action.
            LogCurrentSession();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SetUIFromEmployee();
        }
        protected void gridViewEmployees_OnRowSelect(object sender, CommandEventArgs e)
        {
            var selectedEmployeeId = int.Parse(e.CommandArgument.ToString());
            var actionName = e.CommandName;
            _employeeSession.SetSelectedEmployee(selectedEmployeeId);
            _employeeSession.SetCurrentAction(actionName);
            SetUIFromEmployee();
            UpdateEmployeeButtons();
            LogCurrentSession();

        }
        #endregion

        #region PRIVATE HELPER METHODS
        private void UpdateEmployeeButtons()
        {
            UpdateActionButtonText();
            UpdateResetButtonVisibility();
        }
        private void ResetEmployeeSession()
        {
            _employeeSession.Reset();
        }

        private Employee CreateEmployeeFromUI()
        {
            var employee = new Employee();
            employee.EmployeeId = _employeeSession.GetSelectedEmployee();
            employee.EmployeeName = txtEmployeeName.Text;
            employee.Designation = GetSelectedValue(ddlDesignation);
            employee.Salary = Convert.ToDecimal(txtSalary.Text);
            employee.Email = txtEmail.Text;
            employee.Mobile = txtMobile.Text;

            employee.Qualification = GetSelectedValue(ddlQualification);
            var managerId = 0;

            if (Int32.TryParse(txtManager.Text, out managerId))
            {
                employee.Manager = managerId;
            }
            employee.Country = ddlCountry.SelectedValue == " " ? 0 : Convert.ToInt32(ddlCountry.SelectedValue);
            employee.State = ddlState.SelectedValue == " " ? 0 : Convert.ToInt32(ddlState.SelectedValue);
            employee.City = ddlCity.SelectedValue == " " ? 0 : Convert.ToInt32(ddlCity.SelectedValue);
            return employee;
        }
        private void SetUIFromEmployee()
        {
            if (_employeeSession.IsEmployeeSelected())
            {
                int selectedId = _employeeSession.GetSelectedEmployee();
                var employee = _repository.GetEmployee(selectedId);
                txtEmployeeName.Text = employee.EmployeeName;
                ddlDesignation.SelectedValue = employee.Designation;
                txtSalary.Text = employee.Salary.ToString(CultureInfo.InvariantCulture);
                txtEmail.Text = employee.Email;
                txtMobile.Text = employee.Mobile;
                ddlQualification.SelectedValue = employee.Qualification;
                txtManager.Text = employee.Manager == 0 ? string.Empty : employee.Manager.ToString();

                BindDdlCountry();
                ddlCountry.SelectedValue = employee.Country.ToString();
                
                // load the drop down first before you select. Else it will throw error saying list does not has item to select.
                BindDdlState();
                ddlState.SelectedValue = employee.State.ToString();
                 
                BindDdlCity();
                ddlCity.SelectedValue = employee.City.ToString();
            }
        }

        private string GetSelectedValue(DropDownList ddl)
        {
            return IsOptionSelected(ddl.SelectedItem.Value) ? ddl.SelectedItem.Text : string.Empty;
        }
        private bool IsOptionSelected(string value)
        {
            return EmployeeConstants.NO_OPTION_SELECTED != value;
        }

        private void InsertEmployee()
        {
            _repository.Insert(CreateEmployeeFromUI());
        }

        private void DeleteEmployee()
        {
            _repository.Delete(_employeeSession.GetSelectedEmployee());

        }

        private void UpdateEmployee()
        {
            _repository.Update(CreateEmployeeFromUI());
        }

        private void HandleException(Exception exception)
        {
            lblError.Text = exception.Message;
        }
        private void RefreshEmployeesGrid()
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
            ddlCountry.SelectedIndex = -1;
            ddlCity.SelectedIndex = -1;
            ddlState.SelectedIndex = -1;

        }

        private void ClearErrorMessage()
        {
            lblError.Text = string.Empty;
        }

        private void UpdateActionButtonText()
        {
            var actionName = _employeeSession.GetCurrentActionName();
            switch (actionName)
            {
                case EmployeeConstants.ACTION_UPDATE:
                    btnSubmit.Text = EmployeeConstants.BUTTON_NAME_UPDATE;
                    break;
                case EmployeeConstants.ACTION_DELETE:
                    btnSubmit.Text = EmployeeConstants.BUTTON_NAME_DELETE;
                    break;
                case EmployeeConstants.ACTION_INSERT:
                    btnSubmit.Text = EmployeeConstants.BUTTON_NAME_SAVE;
                    break;
                default:
                    btnSubmit.Text = EmployeeConstants.BUTTON_NAME_SAVE;
                    break;

            }
        }

        private void UpdateResetButtonVisibility()
        {
            if (_employeeSession.IsDeleteAction())
            {
                btnReset.Visible = false;
            }
            else
            {
                btnReset.Visible = true;
            }
        }

        private void BindDdlCountry()
        {
            var ds = _repository.Country();
            ddlCountry.DataSource = ds;
            ddlCountry.Items.Clear();
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();

        }

        private void ClearDdlState()
        {
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));
            ddlState.DataBind();
        }

        private void BindDdlState()
        {
            int countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            var ds = _repository.State(countryId);
            ddlState.DataSource = ds;
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));
            ddlState.DataTextField = "select";
            ddlState.DataTextField = "StateNmae";
            ddlState.DataValueField = "StateId";


            ddlState.DataBind();
        }
        private void ClearDdlCity()
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
            ddlCity.DataBind();
        }

        private void BindDdlCity()
        {
            int stateId = Convert.ToInt32(ddlState.SelectedValue);
            ddlCity.DataSource = _repository.City(stateId);
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("Select City", "0"));

            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
        }
        #endregion

        #region LOGS
        private void LogCurrentSession()
        {
            LogInUi("currentEmployee", _employeeSession.GetSelectedEmployee().ToString());
            LogInUi("currentAction", _employeeSession.GetCurrentActionName());
        }

        private void LogInUi(string msg, string msg1)
        {
            lblLog.Text += msg + ": " + msg1;
        }

        private void ClearLogInUi()
        {
            lblLog.Text = "";
        }

        #endregion

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindDdlState();
            ClearDdlCity();

        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDdlCity();
        }


    }
}
