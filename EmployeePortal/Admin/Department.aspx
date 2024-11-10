<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="EmployeePortal.Admin.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/AppStyle.css" rel="stylesheet" />
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
                            </td>
                        </tr>
                        <tr>
                            <th>Department Name</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDepartmentName"
                                    CssClass="form-control"></asp:TextBox>
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
                                <asp:Button runat="server" Text="Save" CssClass="btn btn-success" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
