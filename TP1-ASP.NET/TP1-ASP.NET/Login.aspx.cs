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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CurrentUser"] = new PersonnesTable((string)Application["MainDB"], this);
                Session["UserValid"] = false;
                Session["Selected_UserName"] = "Anonymous";
            }
            LoadConnexionHeader();
        }

        private void LoadConnexionHeader()
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            LB_HdrUserName.Text = Session["Selected_UserName"].ToString();
            if (Session["Selected_ID"] != null && personnes.GetAvatar(Session["Selected_ID"].ToString()) != "")
                Img_Username.ImageUrl = "Avatars/" + personnes.GetAvatar(Session["Selected_ID"].ToString());
            else
                Img_Username.ImageUrl = "Images/Anonymous.png";
        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
                Session["Selected_ID"] = personnes.getID(TB_UserName.Text);
                Session["Selected_UserName"] = TB_UserName.Text;
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
        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            args.IsValid = personnes.Valid(TB_UserName.Text, TB_Password.Text);

        }


    }
}