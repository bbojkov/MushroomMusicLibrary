using MusicLibrary.MVP.Models;
using MusicLibrary.MVP.Presenters;
using MusicLibrary.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using MusicLibrary.MVP.EventArguments;
using System.Text.RegularExpressions;

namespace MusicLibrary.Web.add
{
    [PresenterBinding(typeof(AddBandPresenter))]
    public partial class band : MvpPage<AddBandModel>, IAddBandView
    {
        public event EventHandler NeedGenres;
        public event EventHandler NeedCountries;
        public event EventHandler<AddBandEventArgs> RegisterBand;

        protected void Page_Load(object sender, EventArgs e)
        {
            string myScript = "add-band.js";
            Page.ClientScript.RegisterClientScriptInclude("addBandJs", myScript);

            RangeValidatorYear.MaximumValue = DateTime.Now.Year.ToString();
            RangeValidatorYear.MinimumValue = DateTime.Now.AddYears(-100).Year.ToString();

            if (!IsPostBack)
            {
                this.NeedCountries(null, null);
                this.NeedGenres(null, null);

                this.ListBoxCountries.DataSource = this.Model.Countries;
                this.ListBoxCountries.DataBind();
                this.DropDownListGenres.DataSource = this.Model.Genres;
                this.DropDownListGenres.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.Page.Validate("AddNewBand");
            if (this.Page.IsValid)
            {
                string bandName = this.TextBoxBandName.Text;
                string formationYearAsString = this.TextBoxYear.Text;
                string originCountryIdAsString = this.ListBoxCountries.SelectedValue;
                string genreName = this.TextBoxGenre.Text;
                string genreIdAsString = this.DropDownListGenres.SelectedValue;

                this.RegisterBand(sender, new AddBandEventArgs()
                {
                    BandNameString = bandName,
                    YearString = formationYearAsString,
                    CountryIdString = originCountryIdAsString,
                    GenreIdString = genreIdAsString,
                    GenreNameString = genreName
                });

                if (this.Model.IsSuccessful)
                {
                    this.SuccessLabel.Text = "Bravo, tiger! You just registered that band!";

                    this.Response.Redirect("../browse/all");
                }
            }
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ShowTextBox")
            {
                this.GenreDropDownWrapper.Visible = false;
                this.GenreTextBoxWrapper.Visible = true;
                this.DropDownListGenres.SelectedIndex = 0;
                Page.ClientScript.RegisterClientScriptInclude("customValidations", "client-custom-validations.js");
            }
            else
            {
                this.GenreDropDownWrapper.Visible = true;
                this.GenreTextBoxWrapper.Visible = false;
                this.TextBoxGenre.Text = string.Empty;
            }
        }

        protected void CustomValidatorGenreTextBox_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Put this out so can be tested !
            try
            {
                var genre = args.Value;

                if (genre.Length < 2 && genre.Length > 30)
                {
                    args.IsValid = false;
                    return;
                }

                Regex rgx = new Regex(@"^[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$/i");
                if (rgx.IsMatch(genre))
                {
                    args.IsValid = false;
                    return;
                }

                args.IsValid = true;

            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListBoxCountries.Items.Insert(0, new ListItem("Select a country", ""));
                this.DropDownListGenres.Items.Insert(0, new ListItem("Select a genre", ""));
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.TextBoxBandName.Text = string.Empty;
            this.TextBoxYear.Text = string.Empty;
            this.TextBoxGenre.Text = string.Empty;
            this.DropDownListGenres.SelectedIndex = 0;
            this.ListBoxCountries.SelectedIndex = 0;
        }
    }
}