using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Profil : System.Web.UI.Page
    {
        public string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                LoadForm();
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

        private void UpdateCurrent()
        {
            if ((Session["Selected_ID"] != null) && (Session["Users"] != null))
            {

                PersonnesTable personnes = (PersonnesTable)Session["Users"];
                personnes.FullName = TB_Nom.Text;
                Session["Selected_UserName"] = TB_Username.Text;
                personnes.UserName = TB_Username.Text;
                personnes.Password = TB_Password.Text;
                personnes.Email = TB_Email.Text;


                String Avatar_Path = "";
                String avatar_ID = "";
                if (FU_Avatar.FileName != "")
                {
                    DeleteImage(personnes.Avatar);
                    avatar_ID = Guid.NewGuid().ToString();
                    Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
                    FU_Avatar.SaveAs(Avatar_Path);
                    personnes.Avatar = avatar_ID;
                }
                else
                {
                    personnes.Avatar = personnes.GetAvatar(Session["Selected_ID"].ToString());
                }

                personnes.Update();
            }
            Response.Redirect("Index.aspx");
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
                    IMG_Avatar.ImageUrl = "Avatars/" + Fields.ElementAt(4) + ".png";
                }
                else
                    IMG_Avatar.ImageUrl = "Images/Anonymous.png";
            }
        }

        protected void BTN_Update_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
                UpdateCurrent();
        }

        protected void BTN_Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}