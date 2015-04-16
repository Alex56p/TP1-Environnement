using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TP1_ASP.NET
{
    public partial class Profil1 : System.Web.UI.Page
    {
        public string path;
        bool valid = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            if (!Page.IsPostBack)
            {
                LoadForm();
                Session["Header"] = "Profil...";
            }
        }


        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PersonnesTable personne = new PersonnesTable((string)Application["MainDB"], this);
            if (TB_Username.Text.ToUpper() != Session["Selected_UserName"].ToString().ToUpper())
            {
                args.IsValid = !personne.Exist(TB_Username.Text);
                if (valid)
                    valid = args.IsValid;
            }

        }

        private void UpdateCurrent()
        {
            if ((Session["Selected_ID"] != null) && (Session["Users"] != null))
            {

                PersonnesTable personnes = (PersonnesTable)Session["Users"];
                personnes.GetValues();
                personnes.FullName = TB_Nom.Text;
                Session["Selected_UserName"] = TB_Username.Text;
                personnes.UserName = TB_Username.Text;
                personnes.Password = TB_Password.Text;
                personnes.Email = TB_Email.Text;

                string Avatar_Path;
                string avatar_ID;
                if (FU_Avatar.FileName != "")
                {
                   avatar_ID = FU_Avatar.FileName;
                   Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID;
                   FU_Avatar.SaveAs(Avatar_Path);
                   personnes.Avatar = avatar_ID;
                }
                else
                {
                   personnes.Avatar = "Anonymous.png";
                }

                personnes.Update();
            }
            Response.Redirect("Index1.aspx");
        }

        private void DeleteImage(String ID)
        {
            if (File.Exists(Server.MapPath(@"~\Avatars\") + ID + ".png"))
                File.Delete(Server.MapPath(@"~\Avatars\") + ID + ".png");
        }

        private void LoadForm()
        {
            PersonnesTable user = new PersonnesTable((String)Application["MainDB"], this);
            Session["Users"] = user;

            if (user.SelectByID((String)Session["Selected_ID"]))
            {
                List<string> Fields = user.LoadFields((String)Session["Selected_ID"]);
                TB_Nom.Text = Fields.ElementAt(0);
                TB_Username.Text = Fields.ElementAt(1);
                TB_Password.Text = Fields.ElementAt(2);
                TB_Email.Text = Fields.ElementAt(3);
                if (Fields.ElementAt(4) != "")
                {
                    path = Fields.ElementAt(4);
                    IMG_Avatar.ImageUrl = "Avatars/" + Fields.ElementAt(4);
                }
                else
                    IMG_Avatar.ImageUrl = "Images/Anonymous.png";
            }
        }

        protected void BTN_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && valid)
                UpdateCurrent();
        }

        protected void BTN_Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }

        protected void CV_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Email.Text != TB_Email_Confirm.Text)
            {
                valid = false;
                args.IsValid = false;
            }

        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Password.Text != TB_Password_Confirm.Text)
            {
                valid = false;
                args.IsValid = false;
            }
        }
    }
}