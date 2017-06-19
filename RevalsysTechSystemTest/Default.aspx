<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RevalsysTechSystemTest.Default" EnableViewState="true" Culture="hi-IN"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Style/StyleSheet.css" rel="stylesheet" />
    <style type="text/css">
        table {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <h3>Employee Registration
            </h3>
        </header>
        <div class="container">
            <div>
                <asp:Label ID="lblLog" runat="server" ForeColor="#FF0066" Visible="False"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
            </div>
            <div class="tbl">
                <table>
                    <tr>
                        <td>Emaployee Name<asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label>
                            :</td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Degignation :</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlDesignation" runat="server">
                                <asp:ListItem Selected="True" Value="-1">Designation</asp:ListItem>
                                <asp:ListItem>CEO</asp:ListItem>
                                <asp:ListItem>Project Manager</asp:ListItem>
                                <asp:ListItem>Team Leader</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td>Salary<asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label>:</td>
                        <td>
                            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Salary is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSalary" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Enter only digit." ForeColor="Red" ValidationExpression="^[0-9.]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Email<asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label>:</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email id is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email id." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Mobile<asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label>:</td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Mobile number is required." ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Invalid mobile number." ForeColor="Red" ValidationExpression="^[7-9]{1}[0-9]{9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Qualification :</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlQualification" runat="server">
                                <asp:ListItem Selected="True" Value="-1">Qualification</asp:ListItem>
                                <asp:ListItem>MBA</asp:ListItem>
                                <asp:ListItem>M.Tech</asp:ListItem>
                                <asp:ListItem>B.Tech</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td>Manager :</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtManager" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                           Country : 
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                           
                        </td>

                    </tr>
                    <tr>
                        <td>
                           State : 
                        </td>
                        <td colspan="2">
                           <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                               
                           </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td>
                           City : 
                        </td>
                        <td colspan="2">
                           <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="false" AppendDataBoundItems="true">
                               
                           </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="False" ValidateRequestMode="Disabled" ValidationGroup="reset" />
                        </td>

                    </tr>
                </table>
            </div>


        </div>
        <footer>
            <h4>Register Employee
            </h4>
        </footer>
        <div class="grid-container">
            <asp:GridView ID="gridViewEmployees"  runat="server" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="EmployeeId" ForeColor="#333333" GridLines="None"
                OnRowCommand="gridViewEmployees_OnRowSelect"
                CssClass="grid"
                ShowHeaderWhenEmpty="True" EmptyDataText="No records Found">
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="EmployeeName" />
                    <asp:BoundField HeaderText="Designation" DataField="Designation" />
                    <asp:BoundField HeaderText="Salary" DataField="Salary" DataFormatString="{0:C}" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                    <asp:BoundField HeaderText="Qualification" DataField="Qualification" />
                    <asp:BoundField HeaderText="Manager" DataField="ManagerName" />
                    <asp:BoundField HeaderText="Country" DataField="CountryName" />
                    <asp:BoundField HeaderText="State" DataField="StateName" />
                    <asp:BoundField HeaderText="City" DataField="CityName" />
                    <asp:TemplateField>
                        <ItemTemplate>
                               <asp:LinkButton  runat="server" CommandName="ACTION_UPDATE"
                                    Text="Edit"
                                    CommandArgument='<%# Eval("EmployeeId") %>' OnCommand="gridViewEmployees_OnRowSelect" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                               <asp:LinkButton runat="server" CommandName="ACTION_DELETE"
                                    Text="Delete"
                                    CommandArgument='<%# Eval("EmployeeId") %>' OnCommand="gridViewEmployees_OnRowSelect" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="30px" />
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
