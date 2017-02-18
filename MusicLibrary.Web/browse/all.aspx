<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="all.aspx.cs" Inherits="MusicLibrary.Web.browse.all" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server"
        ID="ListViewCategories"
        ItemType="MusicLibrary.Models.Band"
        SelectMethod="ListViewCategories_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <div class="col-md-4">
                <h4><%#: Item.BandName %></h4>
                <itemtemplate>
                    <h4>
                        Country: <%#: Item.Country.CountryName %>
                    </h4>
                </itemtemplate>
                <itemtemplate>
                    <h4>
                       Genre: <%#: Item.Genre.GenreName %>
                    </h4>
                </itemtemplate>
                <asp:Button ID="AddToFavorites" runat="server" Text="Add to favorites" OnClick="AddToFavorites_Click" CssClass="btn btn-success"/>
                <hr />
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
