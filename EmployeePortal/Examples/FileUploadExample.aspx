<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="FileUploadExample.aspx.cs"
    Inherits="EmployeePortal.Examples.FileUploadExample"
    MasterPageFile="~/Layouts/Main.Master" %>
<asp:Content runat="server" ContentPlaceHolderID ="Contenthead">
    <title>Fileupload - Example</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPage">
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="fileControl" />
            <asp:Button runat="server" ID="btnUpload" Text="Upload"
                OnClick="btnUpload_Click" />
        </div>
    </form>
</asp:Content>
