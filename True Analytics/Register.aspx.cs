using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace True_Analytics
{
    public partial class _Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wrong.Visible = false;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {

            if (Email.Text != "" 
                && Email.Text.Contains("@") 
                && Password.Text.Trim() != ""
                && ConfirmPassword.Text.Trim() != ""
                && Password.Text.Trim() == ConfirmPassword.Text.Trim()
                && ServiceAccountEmail.Text != ""
                && ServiceAccountEmail.Text.Contains("@")
                && ServiceAccoutSecret.Text.Trim() != ""
                && AnalyticsID.Text.Trim() != ""
                && SpreadsheetID.Text.Trim() != "")
            {
                Response.Redirect("~/Summary.aspx");
            }
            else
            {
                Wrong.Visible = true;
            }
        }
    }
}