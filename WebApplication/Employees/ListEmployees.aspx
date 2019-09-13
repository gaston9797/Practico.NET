<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListEmployees.aspx.cs" Inherits="WebApplication.Employees.ListEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <br />
        <asp:Button 
            ID="NewEmployee" 
            runat="server" 
            CssClass="btn btn-primary"
            Text="New Employee" 
            OnClick="NewEmployee_Click" />
        <br />
        <br />
        <asp:GridView ID="EmployeeGV" runat="server" DataSourceID="EmployeesDS" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1107px" AutoGenerateSelectButton="True"
            OnSelectedIndexChanged="EmployeeGV_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <sortedascendingcellstyle backcolor="#F5F7FB" />
            <sortedascendingheaderstyle backcolor="#6D95E1" />
            <sorteddescendingcellstyle backcolor="#E9EBEF" />
            <sorteddescendingheaderstyle backcolor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource
        ID="EmployeesDS"
        TypeName="Controllers.EmployeeController"
        SelectMethod="GetDataEmployees"
        runat="server">
    </asp:ObjectDataSource>
    </p>
</asp:Content>
