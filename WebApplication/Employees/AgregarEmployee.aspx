<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEmployee.aspx.cs" Inherits="WebApplication.Employees.AgregarEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 50px">

        <div class="form-row">
            <div class="form-group">
                <label for="Name">Name</label>
                <asp:TextBox
                    ID="Name"
                    CssClass="form-control"
                    PlaceHolder="Name"
                    runat="server">
                </asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label for="StartDate">StartDate</label>
                <asp:Calendar
                    ID="StartDate"
                    runat="server">
                </asp:Calendar>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label for="Type">Type</label><asp:RadioButtonList ID="RadioButtonType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" OnClick="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem>Full Time Employee</asp:ListItem>
                    <asp:ListItem>Part Time Employee</asp:ListItem>
                </asp:RadioButtonList>
&nbsp;</div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label for="Salary">Salary</label>
                <asp:TextBox
                    ID="Salary"
                    CssClass="form-control"
                    PlaceHolder="Salary"
                    runat="server">
                </asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label for="HourlyRate">Hourly Rate</label>
                <asp:TextBox
                    ID="HourlyRate"
                    CssClass="form-control"
                    PlaceHolder="Hourly Rate"
                    runat="server">
                </asp:TextBox>
            </div>
        </div>

        <asp:Button
            ID="Guardar"
            runat="server"
            CssClass="btn btn-primary"
            Text="Guardar" OnClick="Guardar_Click" />

        <asp:Button
            ID="Guardar0"
            runat="server"
            CssClass="btn btn-danger"
            Text="Borrar" OnClick="Borrar_Click" />

        <asp:Button
            ID="Cancelar"
            runat="server"
            CssClass="btn"
            Text="Cancelar" OnClick="Cancelar_Click" />
    </div>
</asp:Content>
