using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            PersonnesTable user = new PersonnesTable((String)Application["MainDB"], this);
            Session["Users"] = user;
           

            if(user.Equals((String)Session["CurrentUser"]))
                 InsertSetValueScript(user);
        }

        private void InsertSetValueScript(PersonnesTable personne)
        {
            String script = "<script>";

            script += BuildSetValueScript("TB_Nom", personne.FullName);
            script += BuildSetValueScript("TB_Username", personne.UserName);
            script += BuildSetValueScript("TB_Password", personne.Password);
            script += BuildSetValueScript("TB_Password_Confirm", personne.Password);
            script += BuildSetValueScript("TB_Email", personne.Email);
            script += "</script>";
        }

        private string BuildSetValueScript(String input, String value)
        {
            return "SetValue('" + input + "', '" + value + "'); ";
        }
    }
}