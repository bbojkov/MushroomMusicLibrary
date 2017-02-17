<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="genres.aspx.cs" Inherits="MusicLibrary.Web.browse.genres" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-5">
            <asp:ListBox
                runat="server"
                ID="ListGenre"
                DataTextField="GenreName"
                OnSelectedIndexChanged="ListGenre_SelectedIndexChanged"
                AutoPostBack="True"></asp:ListBox>
        </div>
        <div class="col-md-7">
            <asp:GridView runat="server" ID="BandGridView" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataTextField="BandName" HeaderText="Band By Selected Genre" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>

