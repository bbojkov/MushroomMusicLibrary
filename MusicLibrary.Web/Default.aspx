<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.Web._Default" %>

<%--<%@ Register Src="UserControls/BandList.ascx" TagName="BandList" TagPrefix="bl" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>This is home</h1>
    <asp:Repeater ID="RepeaterAlphabet" runat="server"
        ItemType="System.Char"
        OnItemCommand="RepeaterAlphabet_ItemCommand">
        <ItemTemplate>
            <asp:Button runat="server" Text="<%#: Item %>" CommandName="<%#: Item %>" />
        </ItemTemplate>
        <FooterTemplate>
            <hr />
        </FooterTemplate>
    </asp:Repeater>

    <asp:GridView runat="server" ID="BandGridView" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="BandName" HeaderText="Band Name" />
            <asp:BoundField DataField="Country.CountryName" HeaderText="Country" />
            <asp:BoundField DataField="Genre.GenreName" HeaderText="Genre" />
        </Columns>
    </asp:GridView>

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
