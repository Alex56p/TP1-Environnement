using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class main : System.Web.UI.MasterPage
    {
        static public int Timer;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //{
            //    Session.Timeout = 1;
            //    Timer = 1 * 60;
            //}
            //if(Page.IsAsync)
            //{
            //    Session.Timeout = 1;
            //    Timer = 1 * 60;
            //}
            
            if (Session["Header"] != null)
                LB_Header.Text = Session["Header"].ToString();
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"],Page);
            if (Session["Selected_UserName"] != null && Session["Selected_UserName"].ToString() != "Anonymous")
                LB_HdrUserName.Text = personnes.GetFullName(Session["Selected_UserName"].ToString());
            else
                LB_HdrUserName.Text = "Anonymous";
            if (Session["Selected_ID"] != null && personnes.GetAvatar(Session["Selected_ID"].ToString()) != "")
                Img_Username.ImageUrl = "Avatars/" + personnes.GetAvatar(Session["Selected_ID"].ToString());
            else
                Img_Username.ImageUrl = "Images/Anonymous.png";
        }

        //protected void SessionTimeOut_Tick(object sender, EventArgs e)
        //{
        //    if (Timer == 0)
        //    {
        //        // Mettre connecter a true
        //        Session["Users"] = Index1.userOnline;

        //        if (Session["Selected_ID"] != null && Index1.userOnline.SelectByID((String)Session["Selected_ID"]))
        //        {
        //            List<string> Fields = Index1.userOnline.LoadFields((String)Session["Selected_ID"]);

        //            Index1.userOnline.GetValues();

        //            Index1.userOnline.Deconnecter();
        //        }

        //        Index1.login.LogoutDate = DateTime.Now;
        //        Index1.login.Insert();

        //        Session["Selected_ID"] = null;
        //        Session["SelectedUserName"] = null;

        //        Response.Redirect("Login1.aspx");
        //        Response.Write("Chrono fini.");
        //    }
        //    else
        //    {
        //        Timer--;
        //    }
        //}
    }
}