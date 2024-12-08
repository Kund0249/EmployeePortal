<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="DropdownBinding.aspx.cs"
    Inherits="EmployeePortal.Examples.DropdownBinding"
    MasterPageFile="~/Layouts/Main.Master" %>

<asp:Content runat="server" ContentPlaceHolderID ="Contenthead">
    <title>Dropdown-Example</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPage">
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="ddlCategory"
                DataTextField="Name" DataValueField="Id">
                <%--  <asp:ListItem Value="HR">Humar Resources</asp:ListItem>
            <asp:ListItem Value="FA" Text="Finance & Account"></asp:ListItem>--%>
            </asp:DropDownList>

            <asp:Button runat="server" Text="Save" OnClick="Unnamed_Click" />
        </div>
    </form>
</asp:Content>


