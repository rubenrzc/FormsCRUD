<%@ Page Title="" Language="C#" MasterPageFile="~/resources/mpages/MP.Master" AutoEventWireup="true" CodeBehind="InicioId.aspx.cs" Inherits="Forms.Pages.EntityTuto.InicioId" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    InicioSeSSion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="clo-lg-6">
                <h1>
                    <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                </h1>
            </div>
            <form runat="server">
                <div class="clo-lg-6">
                    <asp:LinkButton ID="lnkCerrar" runat="server" OnClick="lnkCerrar_Click">Cerrar</asp:LinkButton>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
