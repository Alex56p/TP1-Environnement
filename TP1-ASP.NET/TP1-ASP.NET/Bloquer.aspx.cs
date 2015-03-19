using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
   public partial class Bloquer : System.Web.UI.Page
   {
       static TimeSpan chrono;
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!Page.IsPostBack)
              chrono = new TimeSpan(00, 00, 05);
      }

      protected void OnTick(object sender, EventArgs e)
      {
          if (chrono.Hours == 0 && chrono.Minutes == 0 && chrono.Seconds == 0)
          {
              Session.Abandon();
              Response.Redirect("Login.aspx");
          }
          else
          {
              if (chrono.Minutes <= 2)
              {
                  chrono = chrono.Subtract(new TimeSpan(0, 0, 1));
              }
              else
              {
                  chrono = chrono.Subtract(new TimeSpan(0, 1, 0));
              }
          }
      }
   }
}