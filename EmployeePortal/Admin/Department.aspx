<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="EmployeePortal.Admin.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%-- <link href="../Content/css/AppStyle.css" rel="stylesheet" />--%>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row mt-10">
                <div class="col-md-6 col-sm-12 offset-md-3">
                    <table class="table">
                        <tr>
                            <th>Department Code</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDepartmentCode"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtDepartmentCode"
                                    ErrorMessage="Code can not be blank"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server"
                                    ValidationExpression="[a-zA-Z]{2,4}"
                                    ControlToValidate="txtDepartmentCode"
                                    ErrorMessage="Invalid code,Minimum 2 and Maximum 4 characte is allowed"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>Department Name</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDepartmentName"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtDepartmentName"
                                    ErrorMessage="Name can not be blank"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server"
                                    ValidationExpression="[a-zA-Z\s]{1,20}"
                                    ControlToValidate="txtDepartmentName"
                                    ErrorMessage="Invalid Name,Maximum 20 characte is allowed"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>Description</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDescription"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" Text="ReSet" CssClass="btn btn-danger" />
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-10 col-sm-12 offset-md-1">
                    <asp:GridView runat="server"
                        CssClass="table table-hover"
                        ID="DepartmentGrid"
                        AutoGenerateColumns="false"
                        OnRowDeleting="DepartmentGrid_RowDeleting"
                        DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField HeaderText="Dept Code" DataField="Code" />
                            <asp:BoundField HeaderText="Dept Name" DataField="Name" />
                            <asp:BoundField HeaderText="Description" DataField="Descriptions" />
                            <asp:CommandField HeaderText="Action" ShowDeleteButton="true"
                                ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-danger" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
