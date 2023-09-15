<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server" ItemType="ECommerce.Prodotto">
                <ItemTemplate>
                    <div class="col-3 d-flex">
                    <div class="card mx-3 my-3" style="width:300px;">
                        <img src="/Content/Img/<%# Item.Immagine %>" class="card-img-top w-100" alt="...">
                        <div class="card-body d-flex flex-column justify-content-between">
                            <h5 class="card-title"><%# Item.Nome %></h5>
                            <p><%# Item.DescrizioneHome %></p>
                            <a href="<%# "Details.aspx?ID=" + Item.ID %>" class="btn btn-warning mb-2">Dettagli prodotto</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
