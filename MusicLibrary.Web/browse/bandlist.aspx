<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bandlist.aspx.cs" Inherits="MusicLibrary.Web.browse.bandlist" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView SelectMethod="BandGridView_GetData" runat="server" ID="BandGridView" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="BandName" HeaderText="Band Name" />
            <asp:BoundField DataField="Country.CountryName" HeaderText="Country" />
            <asp:BoundField DataField="Genre.GenreName" HeaderText="Genre" />
        </Columns>
    </asp:GridView>

    <div class="back-link">
        <a href="/browse/letter" class="btn btn-info">BACK</a>
    </div>
</asp:Content>
