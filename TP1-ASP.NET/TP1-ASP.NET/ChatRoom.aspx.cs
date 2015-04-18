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
        public static string MessageModifier = "";
        public static string Id_Modifier = "";

        // Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (MessageModifier != "")
                TB_Text.Text = MessageModifier;


            if(Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            
            // Afficher les threads
            AfficherDiscussions();

            // S'il n'y a pas de discussions
            if (ListBox1.Items.Count == 0)
                BTN_Envoyer.Enabled = false;
            else
            {
                // S'il n'y a pas de discussion sélectionné
                if (ListBox1.SelectedItem == null)
                {
                    ListBox1.SelectedIndex = 0;
                    ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
                    Thread_ID = tt.getIDThreads(ListBox1.SelectedItem.ToString());
                    AfficherMessages();
                    AfficherUsagers();
                }
            }
            
        }

        // Ajouter un message dans le thread
        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
            // Ajouter le message dans la BD
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);  
            if(MessageModifier != "")
            {
                tm.Thread_ID = long.Parse(Thread_ID);
                tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
                tm.Date_of_Creation = DateTime.Now.ToShortDateString();
                tm.Message = TB_Text.Text;
                tm.Insert();
            }
            else
            {
                tm.UpdateMessage(Id_Modifier, TB_Text.Text);
                MessageModifier = "";
                Id_Modifier = "";
            }
            
            Chat.Controls.Clear();
            AfficherMessages();
            TB_Text.Text = "";
        }


        // SUCE MON POIL

        // Afficher les threads
        private void AfficherDiscussions()
        {
            ListBox1.Items.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.ShowThreads(ListBox1);
        }

        // Afficher les messages du thread
        private void AfficherMessages()
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
            tm.ShowMessages(Thread_ID, Chat);
            ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
            Titre.Text = ListBox1.SelectedItem.ToString();
            Createur.Text = tt.getCreatorFullName(Thread_ID);
            Date.Text = tt.getThreadsDate(Thread_ID);        
        }
        
        // Afficher les usagers du thread
        private void AfficherUsagers()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.GetUsers_thread(TableUsers, Thread_ID);
        }

        // Updater pour recevoir les messages des autres users
        protected void TimerPanel_Tick(object sender, EventArgs e)
        {
            Chat.Controls.Clear();
            AfficherMessages();
            if (MessageModifier != "")
                TB_Text.Text = MessageModifier;
        }
    }
}