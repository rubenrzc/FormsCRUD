<%@ Page Title="" Language="C#" MasterPageFile="~/resources/mpages/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Forms.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    INICIO
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 300px">
            <h2>Lista de registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-lg-6 text-start">
                    <asp:ScriptManager ID="smId" runat="server"></asp:ScriptManager>
                    <asp:Label ID="lblId" runat="server" Text="ID"></asp:Label>
                    <asp:TextBox ID="TxtId" runat="server" MaxLength="2" TextMode="number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvId" runat="server" ErrorMessage="Campo requerido" ControlToValidate="TxtId" BorderColor="Red" BorderStyle="Double"></asp:RequiredFieldValidator>  
                    <asp:Button ID="BtnId" runat="server" Text="Id" OnClick="BtnId_Click"/>
                </div>
                <div class="col-lg-6 text-start">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Create" OnClick="BtnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn form-control-sm btn-info" ID="BtnRead" OnClick="BtnRead_Click" />
                                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="ButtonUpdate" OnClick="ButtonUpdate_Click" />
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="ButtonDelete" OnClick="ButtonDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
