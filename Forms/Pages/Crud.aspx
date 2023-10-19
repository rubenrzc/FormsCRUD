<%@ Page Title="" Language="C#" MasterPageFile="~/resources/mpages/MP.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="Forms.Pages.Crud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>

    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre" MaxLength="10"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEdad"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEmail"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="tbDate"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Ciudades</label>
                <asp:DropDownList ID="ddlCiudades" runat="server" CssClass="form-control selectpicker"></asp:DropDownList>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_ClickEntity" />
            <asp:Button runat="server" CssClass="btn btn-info" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_ClickEntity" />
            <asp:Button runat="server" CssClass="btn btn-warning" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_ClickEntity" />
            <asp:Button runat="server" CssClass="btn btn-secondary btn-dark" ID="BtnVolver" Text="Volver" Visible="true" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>
