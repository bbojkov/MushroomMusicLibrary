<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="letter.aspx.cs" Inherits="MusicLibrary.Web.browse.letter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="RepeaterAlphabet" runat="server"
        ItemType="System.Char">
        <ItemTemplate>
            <asp:LinkButton
                ID="LinkLetterButton" 
                runat="server" 
                Text="<%#: Item %>" 
                CommandName="<%#: Item %>" 
                OnCommand="LinkLetterButton_Command"
                CssClass="btn btn-info navbar-btn custom-alphabet">
            </asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate>
            <hr />
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
