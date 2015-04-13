using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
           Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
           tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
           tm.Thread_ID = long.Parse(Session["Selected_Thread"].ToString());
           tm.Date_of_Creation = DateTime.Now;
           tm.Message = TB_Text.Text;

           tm.Insert();
        }
    }
}