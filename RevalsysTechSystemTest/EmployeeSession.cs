using System;
using System.Web;
using System.Web.SessionState;

namespace RevalsysTechSystemTest
{
    public class EmployeeSession
    {
        public HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        public void SetSelectedEmployee(int fetchedEmployeeId)
        {
            Session[EmployeeConstants.SELECTED_EMPLOYEE] = fetchedEmployeeId;
        }
        public int GetSelectedEmployee()
        {
            return  Session[EmployeeConstants.SELECTED_EMPLOYEE] == null ? EmployeeConstants.NO_SELECTED_EMPLOYEE : Convert.ToInt32( Session[EmployeeConstants.SELECTED_EMPLOYEE].ToString());

        }

        public void SetCurrentAction(string actionName)
        {
            Session[EmployeeConstants.ACTION_NAME] = actionName;
        }

        public string GetCurrentActionName()
        {
            return Session[EmployeeConstants.ACTION_NAME] == null ? EmployeeConstants.ACTION_INSERT : Session[EmployeeConstants.ACTION_NAME].ToString();
        }

        public bool IsEmployeeSelected()
        {
            return GetSelectedEmployee() > 0;
        }

        public void Reset()
        {
           SetCurrentAction(EmployeeConstants.ACTION_INSERT);
            SetSelectedEmployee(EmployeeConstants.NO_SELECTED_EMPLOYEE);
        }

        public bool IsDeleteAction()
        {
            return GetCurrentActionName() == EmployeeConstants.ACTION_DELETE;
        }
    }
}