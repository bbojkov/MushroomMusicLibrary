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
                        <%#: Item.Country.CountryName %>
                    </h4>
                </itemtemplate>
                <itemtemplate>
                    <h5>
                        <%#: Item.Genre.GenreName %>
                    </h5>
                </itemtemplate>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
