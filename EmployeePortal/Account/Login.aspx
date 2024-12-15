<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeePortal.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <form runat="server" id="form1">
        <div class="row mt-5">
            <div class="col-md-4 offset-4">
                <div class="card">
                    <div class="card-header">
                        <h3 class="text-center">User Details!</h3>
                    </div>
                    <div class="card-body">
                        <div class="row mt-3 mb-3">
                            <label>Emaild Address : </label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtEmail"
                                    CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <label>Password : </label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtpasswor"
                                    TextMode="Password"
                                    CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <asp:Button runat="server" ID="btnLogin"
                                Text="Login" CssClass="btn btn-primary"
                                OnClick="btnLogin_Click"/>
                        </div>
                    </div>
                    <div class="card-footer">
                        <span class="text-center text-danger">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
