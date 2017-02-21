<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="band.aspx.cs" Inherits="MusicLibrary.Web.add.band" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <legend>Register</legend>

            <asp:Label runat="server" ID="SuccessLabel" Visible="false" />

            <%--Band/Artist name--%>
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Label runat="server"
                        ID="LabelBandName"
                        Text="Band/Artist name :"
                        AssociatedControlID="TextBoxBandName"
                        CssClass="control-label" />
                </div>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="TextBoxBandName" CssClass="form-control input-md" />
                    <asp:RequiredFieldValidator runat="server"
                        ID="RequiredFieldBandName"
                        Text="*"
                        ErrorMessage="Band name is required!"
                        ControlToValidate="TextBoxBandName"
                        EnableClientScript="true"
                        SetFocusOnError="true"
                        ValidationGroup="AddNewBand">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server"
                        ID="RegularExpressionValidatorBandName"
                        Text="*"
                        ErrorMessage="A valid band/artist name has maximul length of 50 symbols and contains letters or digits or specific characters(-+,.=? )!"
                        ValidationExpression="[\w\d -+,.=?]{1,50}"
                        ControlToValidate="TextBoxBandName"
                        SetFocusOnError="true"
                        ValidationGroup="AddNewBand">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <%--Year of formation--%>
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Label runat="server"
                        ID="LabelYearOfFormation"
                        Text="Year of formation :"
                        AssociatedControlID="TextBoxYear"
                        CssClass="control-label" />
                </div>
                <div class="col-md-4">

                    <div class='input-group date'>
                        <asp:TextBox runat="server" ID="TextBoxYear" CssClass="form-control input-md" MaxLength="4"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                        <ajaxToolkit:CalendarExtender runat="server"
                            ID="TextBox1_CalendarExtender"
                            OnClientHidden="onCalendarHidden"
                            OnClientShown="onCalendarShown"
                            BehaviorID="calendar1"
                            Enabled="True"
                            TargetControlID="TextBoxYear"
                            Format="yyyy"></ajaxToolkit:CalendarExtender>
                    </div>
                    <asp:RequiredFieldValidator runat="server"
                        ID="RequiredFieldYear"
                        Text="*"
                        ErrorMessage="Year of formation is required!"
                        ControlToValidate="TextBoxYear"
                        EnableClientScript="true"
                        SetFocusOnError="true"
                        ValidationGroup="AddNewBand">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator runat="server"
                        ID="RangeValidatorYear"
                        Text="*"
                        ErrorMessage="Allowed years between 1800 and current year!"
                        ControlToValidate="TextBoxYear"
                        Type="Integer"
                        SetFocusOnError="true"
                        ValidationGroup="AddNewBand">
                    </asp:RangeValidator>
                </div>
            </div>

            <%--Country of origin--%>
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Label runat="server"
                        ID="LabelCountryOfOrigin"
                        Text="Country of origin :"
                        AssociatedControlID="ListBoxCountries"
                        OnDataBound="OnDataBound"
                        CssClass="control-label" />
                </div>
                <div class="col-md-4">
                    <asp:ListBox runat="server"
                        ID="ListBoxCountries"
                        Rows="8"
                        ItemType="Country"
                        DataTextField="CountryName"
                        DataValueField="Id"
                        AppendDataBoundItems="false"
                        CssClass="form-control">
                    </asp:ListBox>
                    <asp:RequiredFieldValidator runat="server"
                        ID="RequiredFieldCountries"
                        Text="*"
                        ErrorMessage="Please select a country!"
                        ControlToValidate="ListBoxCountries"
                        EnableClientScript="true"
                        InitialValue="Select a country"
                        SetFocusOnError="true"
                        ValidationGroup="AddNewBand">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <%--Genre of origin--%>
            <div class="form-group">
                <div class="col-md-4">
                    <asp:Label runat="server"
                        ID="LabelGenre"
                        Text="Genre :"
                        AssociatedControlID="DropDownListGenres"
                        CssClass="control-label" />
                </div>
                <div class="col-md-4" runat="server" id="GenreDropDownWrapper">
                    <asp:DropDownList runat="server"
                        ID="DropDownListGenres"
                        DataValueField="Id"
                        DataTextField="GenreName"
                        OnDataBound="OnDataBound"
                        CssClass="form-control">
                        <asp:ListItem Text="Select a genre" Selected="True" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server"
                        ID="RequiredFieldGenre"
                        Text="*"
                        ErrorMessage="Please select a genre!"
                        ControlToValidate="DropDownListGenres"
                        EnableClientScript="true"
                        InitialValue="Select a genre"
                        ValidationGroup="AddNewBand">
                    </asp:RequiredFieldValidator>
                    <asp:LinkButton runat="server"
                        ID="LinkButtonShowTextBox"
                        Text="You cant find the genre you want? Register new genre."
                        CommandName="ShowTextBox"
                        OnCommand="LinkButton_Command" />
                </div>
                <div class="col-md-4" runat="server" id="GenreTextBoxWrapper" visible="false">
                    <asp:TextBox runat="server" ID="TextBoxGenre" CssClass="form-control input-md" />
                    <asp:RequiredFieldValidator runat="server"
                        ID="RequiredFieldGenreTextBox"
                        Text="*"
                        ErrorMessage="Genre is required!"
                        ControlToValidate="TextBoxGenre"
                        EnableClientScript="true"
                        ValidationGroup="AddNewBand">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server"
                        ID="CustomValidatorGenreTextBox"
                        Text="Genre should have max 15 characters and should consist only of 15 letters and symbol (-)!"
                        ControlToValidate="TextBoxGenre"
                        ClientValidationFunction="validateGenreString" OnServerValidate="CustomValidatorGenreTextBox_ServerValidate">
                    </asp:CustomValidator>
                    <asp:LinkButton runat="server"
                        ID="LinkButtonShowDropDown"
                        Text="Bring back the list!"
                        CommandName="ShowDropDown"
                        OnCommand="LinkButton_Command" />
                </div>
            </div>

            <%--<asp:Panel runat="server" ID="PanelAlbums" Visible="false"></asp:Panel>--%>
        </fieldset>
    </div>

    <%--    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="ButtonAddAlbum" runat="server" Text="Add an album for this artist" CssClass="btn btn-default" CausesValidation="False" />
        </div>
    </div>--%>

    <div class="row">
        <div class="col-md-offset-3 col-md-4">
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn btn-success" ValidationGroup="AddNewBand" OnClick="ButtonSubmit_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CausesValidation="false" CssClass="btn btn-danger" OnClick="ButtonCancel_Click" />
        </div>
    </div>

    <asp:ValidationSummary runat="server"
        ID="ValidationSummary"
        HeaderText="You received the following errors:"
        ShowMessageBox="true"
        ShowSummary="false"
        ValidationGroup="AddNewBand"></asp:ValidationSummary>

</asp:Content>
