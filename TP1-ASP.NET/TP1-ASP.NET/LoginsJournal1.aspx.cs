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
        protected void Page_Load(object sender, EventArgs e)
        {
            ListUsers();
            Session["Header"] = "Journal de connexion...";
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
    }
}