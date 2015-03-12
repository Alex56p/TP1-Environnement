using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Login : System.Web.UI.Page
    {
        public static string UserName = "Admin";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CurrentUser"] = new PersonnesTable((string)Application["MainDB"], this);
                Session["UserValid"] = false;
            }
        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Session["UserValid"] = true;
                Response.Redirect("Index.aspx");
            }
        }

        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscription.aspx");
        }

        protected void BTN_PasswordLost_Click(object sender, EventArgs e)
        {
            
        }

        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            args.IsValid = personnes.Exist(TB_UserName.Text);
            UserName = TB_UserName.Text;
        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            args.IsValid = personnes.Valid(TB_UserName.Text, TB_Password.Text);

        }


    }
}