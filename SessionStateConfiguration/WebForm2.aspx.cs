using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionStateConfiguration
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session value is assign on the text box  
            if (Session["UserName"] != null)
            {
                tbUserName.Text = Session["UserName"].ToString();
            }
            if (Session["Pwd"] != null)
            {
                tbpwd.Text = Session["Pwd"].ToString();
            }
        }
    }
}