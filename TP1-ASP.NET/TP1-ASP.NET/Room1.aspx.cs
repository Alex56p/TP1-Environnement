using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Room1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }

            Session["Header"] = "Room...";
            ListUsers();
        }
        public void ListUsers()
        {
           PN_ListUsers.Controls.Clear();
            // Création d'une nouvelle instance de Users (reliée à la table MainDB.Users)
            PersonnesTable users = new PersonnesTable((String)Application["MainDB"], this);
            //users.SelectByUserID(Session["Selected_ID"].ToString());
            users.MakeDGVOnline(PN_ListUsers, "LoginsJournal1.aspx");
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }
    }
}