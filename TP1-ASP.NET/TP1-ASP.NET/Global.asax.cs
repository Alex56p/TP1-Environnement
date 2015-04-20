using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace TP1_ASP.NET
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string DB_Path = Server.MapPath(@"~\App_Data\MainDB.mdf");
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MaindDB"]
            Application["MainDB"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=True";

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
    new ScriptResourceDefinition
    {
        Path = "~/scripts/jquery-1.7.2.min.js",
        DebugPath = "~/scripts/jquery-1.7.2.min.js",
        CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
        CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
    });
        }

        public void Session_End()
        {
            Application.Lock();
            if(Index1.login != null)
            {
                // Mettre connecter a true
                Session["Users"] = Index1.userOnline;

                if (Session["Selected_ID"] != null && Index1.userOnline.SelectByID((String)Session["Selected_ID"]))
                {
                    List<string> Fields = Index1.userOnline.LoadFields((String)Session["Selected_ID"]);

                    Index1.userOnline.GetValues();

                    Index1.userOnline.Deconnecter();

                    Session["Selected_ID"] = null;
                    Session["SelectedUserName"] = null;
                }

                Index1.login.LogoutDate = DateTime.Now;
                Index1.login.Insert();
            }
            
            
            Application.UnLock();
        }
    }
}