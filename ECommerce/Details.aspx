<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ECommerce.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessaggioErrore" runat="server" CssClass="text-danger"></asp:Label>
 <div class="container-fluid">
     <div class="row">
         <div class="d-flex flex-column justify-content-between col-8">
             <h3 id="NomeProdotto" runat="server"></h3>
             <p id="DescrizioneProdotto" runat="server"></p>
             <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Aggiungi al carrello" OnClick="ButtonAggiungiCarrello_Click" />
         </div>
         <div class="col-4">
            <asp:Image ID="imgProdotto" runat="server" CssClass="img-fluid" />
             <h5 class="text-center mt-3" id="PrezzoProdotto" runat="server"></h5>
         </div>
     </div>
 </div>
</asp:Content>
