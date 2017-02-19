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
                <p class="navbar-btn">
                    <asp:HyperLink CssClass="btn btn-info"
                        ID="HyperLink1"
                        runat="server"
                        NavigateUrl='<%# string.Format("~/browse/band.aspx?id={0}", Item.Id) %>'>
                    See Additional Information
                    </asp:HyperLink>
                </p>
                <hr />
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
