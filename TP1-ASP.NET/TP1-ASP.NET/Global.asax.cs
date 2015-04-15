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

        void Session_End(Object sender, EventArgs E)
        {
            PersonnesTable user = new PersonnesTable((String)Application["MainDB"], HttpContext.Current.CurrentHandler as System.Web.UI.Page);
            Session["Users"] = user;

            if (user.SelectByID((String)Session["Selected_ID"]))
            {
                List<string> Fields = user.LoadFields((String)Session["Selected_ID"]);
                user.GetValues();
                user.Deconnecter();
            }
            Logins login = new Logins((String)Application["MainDB"], HttpContext.Current.CurrentHandler as System.Web.UI.Page);
            login.LogoutDate = DateTime.Now;
            login.Insert();
            Session["Selected_ID"] = null;
            Session["SelectedUserName"] = null;

            Response.Redirect("Login1.aspx");
        }
    }
}