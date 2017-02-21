<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="MusicLibrary.Web.search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal>
        </h1>
    </div>

    <asp:Repeater runat="server" ID="Repeater" ItemType="MusicLibrary.Models.Band" SelectMethod="Repeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#: Item.BandName %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div>
        <a href="Default.aspx" class="btn btn-info">Back to Home</a>
    </div>
</asp:Content>
