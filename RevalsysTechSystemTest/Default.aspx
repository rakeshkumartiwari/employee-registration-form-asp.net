<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RevalsysTechSystemTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Style/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
            <header>
                <h3>
                    Employee Registration
                </h3>
            </header>
            <div class="container">
                <div>
                    <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
                </div>
                <div class="tbl">
                      <table>
                    <tr>
                        <td>Emaployee Name :</td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Degignation :</td>
                        <td>
                            <asp:DropDownList ID="ddlDesignation" runat="server">
                                <asp:ListItem>Designation</asp:ListItem>
                                <asp:ListItem>CEO</asp:ListItem>
                                <asp:ListItem>Project Manager</asp:ListItem>
                                <asp:ListItem>Team Leader</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Salary :</td>
                        <td>
                            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email :</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Mobile :</td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Qualification :</td>
                        <td>
                            <asp:DropDownList ID="ddlQualification" runat="server">
                                <asp:ListItem>Qualification</asp:ListItem>
                                <asp:ListItem>MBA</asp:ListItem>
                                <asp:ListItem>M.Tech</asp:ListItem>
                                <asp:ListItem>B.Tech</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Manager :</td>
                        <td>
                            <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" />
                        </td>
                    </tr>
                </table>
                </div>
                
                
            </div>
            <footer>
                 <h4>
                     Register Employee
                </h4>
            </footer>
        <div>
            <asp:GridView ID="gridViewEmployees" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EmployeeId" ForeColor="#333333" GridLines="None"
                OnRowEditing="gridViewEmployees_OnRowEditing"
                OnRowDeleting="gridViewEmployees_OnRowDeleting"
               CssClass="grid"
                >
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="EmployeeName"/>
                    <asp:BoundField HeaderText="Designation" DataField="Designation"/>
                    <asp:BoundField HeaderText="Salary" DataField="Salary"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                    <asp:BoundField HeaderText="Mobile" DataField="Mobile"/>
                    <asp:BoundField HeaderText="Qualification" DataField="Qualification"/>
                    <asp:BoundField HeaderText="Manager" DataField="ManagerName"/>
                    
                    <asp:CommandField ShowEditButton="True"/>
                    <asp:CommandField ShowDeleteButton="True"/>
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
       
        <script src="Scripts/jquery-1.9.1.js"></script>
        <script src="Scripts/bootstrap.js"></script>
    </form>
</body>
</html>
