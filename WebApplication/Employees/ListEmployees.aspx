<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListEmployees.aspx.cs" Inherits="WebApplication.Employees.ListEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="EmployeesDS" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource
        ID="EmployeesDS"
        TypeName="Controllers.EmployeeController"
        SelectMethod="GetEmployees"
        runat="server">
    </asp:ObjectDataSource>
    </p>
</asp:Content>
