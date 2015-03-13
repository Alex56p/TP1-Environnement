using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Index : System.Web.UI.Page
    {
        static Logins login;

        protected void Page_Load(object sender, EventArgs e)
        {                
            if(!Page.IsPostBack)
            {
                login = new Logins((string)Application["MainDB"], this);
                LoadConnexionHeader();
                login.LoginDate = DateTime.Now;
                login.UserID = long.Parse(Session["Selected_ID"].ToString());
                login.IPAdress = GetUserIP();
            }
        }

        private void LoadConnexionHeader()
        {
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"], this);
            LB_HdrUserName.Text = Session["Selected_UserName"].ToString();
            if (Session["Selected_ID"] != null && personnes.GetAvatar(Session["Selected_ID"].ToString()) != "")
                Img_Username.ImageUrl = "Avatars/" + personnes.GetAvatar(Session["Selected_ID"].ToString()) + ".png";
            else
                Img_Username.ImageUrl = "Images/Anonymous.png";
        }

        protected void BTN_Profil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void BTN_Online_Click(object sender, EventArgs e)
        {
            Response.Redirect("Room.aspx");
        }

        protected void BTN_Journal_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginsJournal.aspx");
        }

        protected void BTN_Deconnexion_Click(object sender, EventArgs e)
        {
            login.LogoutDate = DateTime.Now;
            login.Insert();
        }

        public string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
                return ipList.Split(',')[0];
            string ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            if (ipAddress == "::1") // local host
                ipAddress = "127.0.0.1";
            return ipAddress;
        }

        protected void Page_UnLoad(Object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                login.LogoutDate = DateTime.Now;
                login.Insert();
            }
            
        }
    }
}