<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="ECommerce.Carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridView1" CssClass="table table-bordered" AutoGenerateColumns="false" runat="server" ItemType="ECommerce.Prodotto">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <strong>Prodotto</strong>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Item.Nome %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <strong>Descrizione</strong>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Item.DescrizioneHome %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <strong>Prezzo</strong>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#Item.Prezzo %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="Remove" runat="server" Text="Rimuovi dal Carrello" CssClass="btn btn-danger" CommandArgument="<%# Item.ID %>" OnClick="Remove_Click" />
                            <a class="text-decoration-none btn btn-success ms-2" href="Default.aspx">Aggiungi altri prodotti</a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between">
        <asp:Button ID="btnSvuotaCarrello" runat="server" Text="Svuota Carrello" OnClick="btnSvuotaCarrello_Click" CssClass="btn btn-warning" />
        <p class="me-2">
            <asp:Label ID="lblTotale" runat="server" CssClass="fw-bold" Text=""></asp:Label></p>
    </div>
    <p id="carrelloVuoto" class="fw-bold" runat="server"></p>
</asp:Content>
