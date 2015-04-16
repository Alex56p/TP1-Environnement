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
            
            if(Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            //TEMPORAIRE
            Session["Selected_Thread"] = 1;
            AfficherDiscussions();
            if (ListBox1.SelectedItem == null)
                ListBox1.SelectedIndex = 0;
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

        private void AfficherDiscussions()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.ShowThreads(ListBox1);
        }
        private void AfficherMessages()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.ShowMessages(Session["Selected_Thread"].ToString(), Chat);
            ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
            Titre.Text = ListBox1.SelectedItem.ToString();
            Createur.Text = tt.getCreatorUserName(tt.getIDThreads(ListBox1.SelectedItem.ToString()));            
            Date.Text = tt.getThreadsDate(tt.getIDThreads(ListBox1.SelectedItem.ToString()));

            
        }

        private void AjouterMessage()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.AddMessage(Chat, TB_Text.Text, long.Parse(Session["Selected_ID"].ToString()));
        }
    }
}