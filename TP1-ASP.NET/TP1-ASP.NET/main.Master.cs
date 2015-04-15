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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Header"] != null)
                LB_Header.Text = Session["Header"].ToString();
            PersonnesTable personnes = new PersonnesTable((string)Application["MainDB"],Page);
            if (Session["Selected_UserName"].ToString() != "Anonymous")
                LB_HdrUserName.Text = personnes.GetFullName(Session["Selected_UserName"].ToString());
            else
                LB_HdrUserName.Text = "Anonymous";
            if (Session["Selected_ID"] != null && personnes.GetAvatar(Session["Selected_ID"].ToString()) != "")
                Img_Username.ImageUrl = "Avatars/" + personnes.GetAvatar(Session["Selected_ID"].ToString());
            else
                Img_Username.ImageUrl = "Images/Anonymous.png";
        }
    }
}