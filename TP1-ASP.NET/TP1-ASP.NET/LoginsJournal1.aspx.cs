using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class LoginsJournal1 : System.Web.UI.Page
    {
        static int Timer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Timer = Index1.SessionTime;
                ListUsers();
                Session["Header"] = "Journal de connexion...";
            }

        }

        public void ListUsers()
        {
            // Création d'une nouvelle instance de Users (reliée à la table MainDB.Users)
            Logins users = new Logins((String)Application["MainDB"], this);
            //users.SelectByUserID(Session["Selected_ID"].ToString());
            users.MakeGridView(PN_ListUsers, "LoginsJournal1.aspx", Session["Selected_ID"].ToString());
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }

        protected void SessionTimeOut_Tick(object sender, EventArgs e)
        {
            if (Timer == 0)
            {
                // Mettre connecter a true
                PersonnesTable user = new PersonnesTable((String)Application["MainDB"], this);
                Session["Users"] = user;

                if (user.SelectByID((String)Session["Selected_ID"]))
                {
                    List<string> Fields = user.LoadFields((String)Session["Selected_ID"]);

                    user.GetValues();

                    user.Deconnecter();
                }

                Index1.login.LogoutDate = DateTime.Now;
                Index1.login.Insert();

                Session["Selected_ID"] = null;
                Session["SelectedUserName"] = null;

                Response.Redirect("Login1.aspx");

            }
            else
            {
                Timer--;
            }
        }
    }
}