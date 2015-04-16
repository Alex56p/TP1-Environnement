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
        string Thread_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            AfficherDiscussions();
            if (ListBox1.Items.Count == 0)
                BTN_Envoyer.Enabled = false;
            else
            {
                if (ListBox1.SelectedItem == null)
                {
                    ListBox1.SelectedIndex = 0;
                    ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
                    Thread_ID = tt.getIDThreads(ListBox1.SelectedItem.ToString());
                    AfficherMessages();
                }
            }
            
        }

        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);  
            tm.Thread_ID = long.Parse(Thread_ID);
            tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
            tm.Date_of_Creation = DateTime.Now.ToShortDateString();
            tm.Message = TB_Text.Text;
            tm.Insert();

            AjouterMessage();
            TB_Text.Text = "";
        }

        private void AfficherDiscussions()
        {
            ListBox1.Items.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.ShowThreads(ListBox1);
        }
        private void AfficherMessages()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.ShowMessages(Thread_ID, Chat);
            ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
            Titre.Text = ListBox1.SelectedItem.ToString();
            Createur.Text = tt.getCreatorFullName(Thread_ID);
            Date.Text = tt.getThreadsDate(Thread_ID);        
        }

        private void AjouterMessage()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.AddMessage(Chat, TB_Text.Text, Session["Selected_ID"].ToString(), DateTime.Now.ToString());
        }

        public static void BTN_Modifier_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public static void BTN_Supprimer_Click(object sender, ImageClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}