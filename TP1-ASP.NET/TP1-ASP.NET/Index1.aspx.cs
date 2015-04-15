using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Index1 : System.Web.UI.Page
    {
        static public int SessionTime = 1 * 60;
        static public Logins login;
        static public PersonnesTable userOnline;
        static public bool Connecte = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            if (!Connecte)
            {
                login = new Logins((string)Application["MainDB"], this);
                login.LoginDate = DateTime.Now;
                login.UserID = long.Parse(Session["Selected_ID"].ToString());
                login.IPAdress = GetUserIP();
                Session["Header"] = "Index...";

                // Mettre connecter a true
                userOnline = new PersonnesTable((String)Application["MainDB"], this);

                if (userOnline.SelectByID((String)Session["Selected_ID"]))
                {
                    List<string> Fields = userOnline.LoadFields((String)Session["Selected_ID"]);

                    userOnline.GetValues();

                    userOnline.Connecter();
                }

                Connecte = true;
            }
        }


        protected void BTN_Profil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil1.aspx");
        }

        protected void BTN_Online_Click(object sender, EventArgs e)
        {
            Response.Redirect("Room1.aspx");
        }

        protected void BTN_Journal_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginsJournal1.aspx");
        }

        protected void BTN_Deconnexion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login1.aspx");
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

        protected void BTN_ChatRoom_Click(object sender, EventArgs e)
        {
            Session["Header"] = "Chat Room...";
            Response.Redirect("ChatRoom.aspx");
        }

        protected void BTN_Gerer_Click(object sender, EventArgs e)
        {
            Session["Header"] = "Gérer mes discussions...";
            Response.Redirect("Threads.aspx");
        }
    }
}