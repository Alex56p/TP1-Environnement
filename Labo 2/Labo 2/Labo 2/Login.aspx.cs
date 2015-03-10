using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labo_2
{
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if(!Page.IsPostBack)
         {
            Session["CurrentUser"] = new USERS((string)Application["MainDB"], this);
            Session["UserValid"] = false;
         }
      }
      protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
      {
         USERS users = new USERS((string)Application["MainDB"], this); 
         args.IsValid = users.Exist(TB_UserName.Text);

      }

      protected void BTN_Login_Click(object sender, EventArgs e)
      {
         if(Page.IsValid)
         {
            Session["UserValid"] = true;
            Response.Redirect("Accueil.aspx");
         }
      }
   }
}