<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EmployeePortal.Admin.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenthead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
    <form runat="server" id="form1">
            <div class="row mt-5">
        <div class="col-md-8 offset-2">
            <asp:GridView runat="server"
                CssClass="table table-hover"
                ID="EmployeeGrid"
                ShowHeaderWhenEmpty="true"
                EmptyDataText="No record found!"
                EmptyDataRowStyle-CssClass="text-center text-danger"
                AutoGenerateColumns="false"
                OnRowDeleting="EmployeeGrid_RowDeleting"
                OnSelectedIndexChanged="EmployeeGrid_SelectedIndexChanged"
                >
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="Name" />
                    <asp:BoundField HeaderText="Gender" DataField="Gender" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Mobile" DataField="Name" />
                    <asp:BoundField HeaderText="Address" DataField="Address" />
                    <asp:BoundField HeaderText="Department" DataField="Department" />
                    <asp:CommandField HeaderText="Action"
                        ShowDeleteButton="true"
                        DeleteImageUrl="~/Content/App-Icons/trans.png"
                        ShowSelectButton="true"
                        SelectImageUrl="~/Content/App-Icons/Pencil.png"
                        ButtonType="Image"
                        ControlStyle-Width="20"
                        ControlStyle-Height="20" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</asp:Content>
