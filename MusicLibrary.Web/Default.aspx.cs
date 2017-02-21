using System;
using System.Web.UI;

namespace Project.Web
{
    public partial class _Default : Page
    {
        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string textToSearchFor = this.TextBoxSearchParam.Text;
            string queryParam = string.IsNullOrEmpty(textToSearchFor) ? string.Empty : string.Format("?q={0}", textToSearchFor);
            Response.Redirect("~/search" + queryParam);
        }
    }
}
