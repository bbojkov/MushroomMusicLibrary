<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="band.aspx.cs" Inherits="MusicLibrary.Web.browse.band" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewBandDetails" ItemType="MusicLibrary.Models.Band" SelectMethod="FormViewBandDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1>
                    <%: Title %>
                </h1>
                <div class="container">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-info">Band Name: <%#: Item.BandName %></li>
                        <li class="list-group-item list-group-item-info">Country of Origin: <%#: Item.Country.CountryName %></li>
                        <li class="list-group-item list-group-item-info">Genre: <%#: Item.Genre.GenreName %></li>
                        <li class="list-group-item list-group-item-success">Description: </li>
                        <asp:Button
                            ID="AddToFavorites"
                            runat="server"
                            Text="Add to favorites"
                            OnClick="AddToFavorites_Click"
                            CssClass="btn btn-success" />
                    </ul>
            </header>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
