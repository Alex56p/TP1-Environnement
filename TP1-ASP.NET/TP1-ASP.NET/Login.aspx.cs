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
        private static int Times { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                Session["Bloquer"] = false;
                Session["CurrentUser"] = new PersonnesTable((string)Application["MainDB"], this);
                Session["UserValid"] = false;
                Session["Selected_UserName"] = "Anonymous";
            }
            else
            {
               if(bool.Parse(Session["Bloquer"].ToString()))
               {
                  Response.Redirect("Bloquer.aspx");
               }
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
            Times++;
            if(Page.IsValid)
            {
                PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
                Session["Selected_ID"] = personnes.getID(TB_UserName.Text);
                Session["Selected_UserName"] = TB_UserName.Text;
                Session["UserValid"] = true;
                Response.Redirect("Index.aspx");
            }
            else if(Times >= 3)
            {
               Session["Bloquer"] = true;
            }
        }

        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscription.aspx");
        }

        protected void BTN_PasswordLost_Click(object sender, EventArgs e)
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            if (TB_UserName.Text == "")
                Response.Write("Le nom d'usager est vide.");
            else if (!personnes.Exist(TB_UserName.Text))
                Response.Write("Le nom d'usager n'existe pas.");
            else
            {
                EMail eMail = new EMail();

                // Vous devez avoir un compte gmail
                eMail.From = "devoirasp@gmail.com";
                eMail.Password = "Sunshine_1234";
                eMail.SenderName = "Administrateur";

                eMail.Host = "smtp.gmail.com";
                eMail.HostPort = 587;
                eMail.SSLSecurity = true;

                eMail.To = personnes.GetEmail(personnes.getID(TB_UserName.Text));
                eMail.Subject = "Mot de passe oublié";
                eMail.Body = "Votre mot de passe est : " + personnes.GetPassword(personnes.getID(TB_UserName.Text));

                if (eMail.Send())
                {
                    Response.Write("This eMail has been sent with success.");
                }
                else
                    Response.Write("An error occured while sendind this eMail.");
            }
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