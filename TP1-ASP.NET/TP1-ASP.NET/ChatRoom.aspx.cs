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
        static string Selected_ThreadID = "";
        public static string MessageModifier = "";
        public static string Id_Modifier = "";

        // Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (MessageModifier != "")
                TB_Text.Text = MessageModifier;


            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }

            // Afficher les threads
            AfficherDiscussions();

            // S'il n'y a pas de discussions
            if (Selected_ThreadID == "")
            {
                Button btn = GetFirstButton();
                if (btn != null)
                    Selected_ThreadID = btn.ID.Substring(4);
            }

            if (!IsPostBack)
            {
                AfficherMessages();
                AfficherUsagers();
            }

        }

        private Button GetFirstButton()
        {
            foreach (Control c in PN_Threads.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.Table"))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType().ToString().Equals("System.Web.UI.WebControls.TableRow"))
                        {
                            foreach (Control c3 in c2.Controls)
                            {
                                if (c3.GetType().ToString().Equals("System.Web.UI.WebControls.TableCell"))
                                {
                                    foreach (Control c4 in c3.Controls)
                                    {
                                        if (c4.GetType().ToString().Equals("System.Web.UI.WebControls.Button"))
                                        {
                                            return (Button)c4;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            return null;
        }

        // Ajouter un message dans le thread
        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
            // Ajouter le message dans la BD
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            if (MessageModifier != "")
            {
                tm.Thread_ID = long.Parse(Selected_ThreadID);
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


        // Afficher les threads
        private void AfficherDiscussions()
        {
            PN_Threads.Controls.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            Table table = new Table();
            PN_Threads.Controls.Add(table);
            TableRow tr;
            TableCell td;

            List<String> threads = t.getThreadsById(Session["Selected_ID"].ToString());
            for (int i = 0; i < threads.Count; i++)
            {
                tr = new TableRow();
                td = new TableCell();
                td.CssClass = "ThreadButton";
                Button btn = new Button();

                btn.Text = threads[i];
                btn.ClientIDMode = ClientIDMode.Static;
                string thread_id = t.getIDThreads(btn.Text);
                btn.ID = "BTN_" + thread_id;
                if (thread_id == Selected_ThreadID)
                    btn.BackColor = System.Drawing.Color.LightBlue;
                else
                    btn.BackColor = System.Drawing.Color.LightGray;
                btn.Click += btn_Click;
                btn.CssClass = "ThreadButton";
                td.Controls.Add(btn);
                tr.Controls.Add(td);
                table.Controls.Add(tr);

                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = btn.ID;
                trigger.EventName = "Click";
                UPN_Threads.Triggers.Add(trigger);
                UPN_Users.Triggers.Add(trigger);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Selected_ThreadID = btn.ID.Substring(4);
            Titre.Text = btn.Text;
            AfficherDiscussions();
            AfficherUsagers();
            AfficherMessages();
        }

        // Afficher les messages du thread
        private void AfficherMessages()
        {
            Button btn = (Button)FindControl(Selected_ThreadID);
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
            tm.ShowMessages(Selected_ThreadID, Chat);
            ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
            //Titre.Text = ListBox1.SelectedItem.ToString(); *****************************************
            Createur.Text = tt.getCreatorFullName(Selected_ThreadID);
            Date.Text = tt.getThreadsDate(Selected_ThreadID);  
        }

        // Afficher les usagers du thread
        private void AfficherUsagers()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.GetUsers_thread(TableUsers, Selected_ThreadID);
        }

        // Updater pour recevoir les messages des autres users
        protected void TimerPanel_Tick(object sender, EventArgs e)
        {
            Chat.Controls.Clear();
            AfficherMessages();
            AfficherUsagers();
            if (MessageModifier != "")
                TB_Text.Text = MessageModifier;
        }
        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }
    }
}