using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Login1 : System.Web.UI.Page
    {
        private static int Times { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Times = 0;
                Session["Bloquer"] = false;
                Session["CurrentUser"] = new PersonnesTable((string)Application["MainDB"], this);
                Session["UserValid"] = false;
                Session["Selected_UserName"] = "Anonymous";
                Session["Selected_ID"] = null;
                Session["Header"] = "Login...";
            }
            else
            {
                Session["Selected_UserName"] = "Anonymous";
                Session["Selected_ID"] = null;
                if (Session["Bloquer"] != null && bool.Parse(Session["Bloquer"].ToString()))
                {
                    Response.Redirect("Bloquer1.aspx");
                }
            }

        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            Times++;
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            if (!personnes.isOnline(personnes.getIDPersonnes(TB_UserName.Text)))
            {
               if (Page.IsValid && !personnes.isOnline(personnes.getIDPersonnes(TB_UserName.Text)))
               {
                  Session["Selected_ID"] = personnes.getIDPersonnes(TB_UserName.Text);
                  Session["Selected_UserName"] = TB_UserName.Text;
                  Session["UserValid"] = true;
                  Session["Bloquer"] = false;
                  Response.Redirect("Index1.aspx");
               }
               else if (Times >= 3)
               {
                  Session["Bloquer"] = true;
               }
            }
            else
            {

            }

        }

        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscription1.aspx");
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

                eMail.To = personnes.GetEmail(personnes.getIDPersonnes(TB_UserName.Text));
                eMail.Subject = "Mot de passe oublié";
                eMail.Body = "Votre mot de passe est : " + personnes.GetPassword(personnes.getIDPersonnes(TB_UserName.Text));

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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
           PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
           args.IsValid = !personnes.isOnline(personnes.getIDPersonnes(TB_UserName.Text));
        }
    }
}