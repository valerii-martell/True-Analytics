using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace True_Analytics
{
    public partial class _Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wrong.Visible = false;
        }

        protected void LogIn(object sender, EventArgs e)
        {
            
            if (Email.Text!="wrongemail@gmail.com"&&Email.Text!=""&&Email.Text.Contains("@")&&Password.Text.Trim()!="")
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