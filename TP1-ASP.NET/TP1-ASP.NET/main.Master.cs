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
       TimeSpan chrono;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session.Timeout = 1;
               chrono = new TimeSpan(0, 0, 10);
            }

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

        protected void Chrono_Tick(object sender, EventArgs e)
        {
           chrono.Subtract(new TimeSpan(0, 0, 1));
           if (chrono == new TimeSpan(0, 0, 0))
              Session.Abandon();
        }
    }
}