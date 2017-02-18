using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicLibrary.Web.add
{
    public partial class band : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string myScript = "add-band.js";
            Page.ClientScript.RegisterClientScriptInclude("addBandJs", myScript);


            RangeValidatorYear.MaximumValue = DateTime.Now.Year.ToString();
            RangeValidatorYear.MinimumValue = DateTime.Now.AddYears(-50).Year.ToString();

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.Page.Validate("AddNewBand");
            if (this.Page.IsValid)
            {
                var bandName = this.TextBoxBandName.Text;
                var yearOfFormation = int.Parse(this.TextBoxYear.Text);
                var countryOfOrigin = this.ListBoxCountries.SelectedValue;
                var genre = this.DropDownListGenres.SelectedIndex != -1 ?
                    this.DropDownListGenres.SelectedValue : this.TextBoxGenre.Text;

                
            }
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ShowTextBox")
            {
                this.GenreDropDownWrapper.Visible = false;
                this.GenreTextBoxWrapper.Visible = true;
                this.DropDownListGenres.SelectedIndex = -1;
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

                if (genre.Length < 2 && genre.Length > 15)
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
    }
}