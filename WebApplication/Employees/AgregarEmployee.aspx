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
                    runat="server">
                </asp:Calendar>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group">
                <label for="Type">Type</label>
                <asp:TextBox
                    ID="Type"
                    CssClass="form-control"
                    PlaceHolder="Type"
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
    </div>
</asp:Content>
