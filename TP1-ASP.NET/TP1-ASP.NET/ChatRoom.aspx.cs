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
            //TEMPORAIRE
            Session["Selected_Thread"] = 1;
            AfficherMessages();
        }

        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
            //TB_Text.Text = "";
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);  
            tm.Thread_ID = long.Parse(Session["Selected_Thread"].ToString());
            tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
            tm.Date_of_Creation = DateTime.Now.ToShortDateString();
            tm.Message = TB_Text.Text;
            tm.Insert();

            AjouterMessage();
        }

        private void AfficherMessages()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.ShowMessages(Session["Selected_Thread"].ToString(), Chat);
        }

        private void AjouterMessage()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.AddMessage(Chat, TB_Text.Text, long.Parse(Session["Selected_ID"].ToString()));
        }
    }
}