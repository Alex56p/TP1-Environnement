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
        public static string Id_Modifier = "";


        // Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);            

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

            if (Session["Message_Modifier_id"] == null)
               Session["Message_Modifier_id"] = "";

            AfficherMessages();
            AfficherUsagers();
        }

        public void AddMessage(string Id_Message, string thread_id, string User_id, string Date, string Message)
        {

            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);


            TableRow tr = new TableRow();
            tr.CssClass = "grid";

            //Image
            TableCell picture = new TableCell();
            picture.CssClass = "ChatImage";
            Image img = new Image();
            img.CssClass = "ChatImage";
            img.ImageUrl = "Avatars/" + tm.GetAvatar(User_id);
            picture.Controls.Add(img);

            //UserName
            TableCell UserName = new TableCell();
            UserName.Text = tm.GetFullName(User_id);

            //Date
            TableCell dateMessage = new TableCell();
            dateMessage.Text = Date;

            //Text
            TableCell TextMessage = new TableCell();
            TextMessage.Text = Message;


            if (tm.GetUserName(long.Parse(Session["Selected_ID"].ToString())) == "Admin" || User_id == Session["Selected_ID"].ToString())
            {
                //Modifier
                TableCell Modifier = new TableCell();
                ImageButton BTN_Modifier = new ImageButton();
                BTN_Modifier.CssClass = "ChatImage";
                BTN_Modifier.ImageUrl = "Images/edit.png";
                BTN_Modifier.Click += BTN_Modifier_Click;
                Modifier.Controls.Add(BTN_Modifier);
                BTN_Modifier.ID = "M" + Id_Message.ToString();

                //Effacer
                TableCell Supprimer = new TableCell();
                ImageButton BTN_Supprimer = new ImageButton();
                BTN_Supprimer.CssClass = "ChatImage";
                BTN_Supprimer.ImageUrl = "Images/delete.png";
                BTN_Supprimer.Click += BTN_Supprimer_Click;
                Supprimer.Controls.Add(BTN_Supprimer);
                BTN_Supprimer.ID = "S" + Id_Message.ToString();



                tr.Cells.Add(Modifier);
                tr.Cells.Add(Supprimer);
            }

            tr.Cells.Add(picture);
            tr.Cells.Add(UserName);
            tr.Cells.Add(dateMessage);
            tr.Cells.Add(TextMessage);
            Chat.Rows.Add(tr);

        }

        public void BTN_Modifier_Click(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string buttonId = button.ID;

            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);

            string Message = tm.RechercherMessage(buttonId.Remove(0, 1));
            Session["Message_Modifier_id"] = buttonId.Remove(0,1);
            TB_Text.Text = Message;
            LB_Modifier.Visible = true;
        }

        public void BTN_Supprimer_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string Id = button.ID.Remove(0, 1);

            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);

            tm.DeleteRecordByID(Id);
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
           if(!string.IsNullOrWhiteSpace(TB_Text.Text) && TB_Text.Text.Length != 0)
           {
               if (Session["Message_Modifier_id"].ToString() == ""  )
               {
                   tm.Thread_ID = long.Parse(Selected_ThreadID);
                   tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
                   tm.Date_of_Creation = DateTime.Now.ToShortDateString();
                   tm.Message = TB_Text.Text;
                   tm.Insert();
               }
               else
               {
                   tm.UpdateMessage(Session["Message_Modifier_id"].ToString(), TB_Text.Text);
                   Session["Message_Modifier_id"] = "";
                   LB_Modifier.Visible = false;
               }
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
            Panel_Chat.Controls.Clear();
            AfficherDiscussions();
            AfficherUsagers();
            AfficherMessages();
        }

        // Afficher les messages du thread
        private void AfficherMessages()
        {
            if(Selected_ThreadID != "")
            {
                Button btn = (Button)FindControl(Selected_ThreadID);
                Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
                tm.User_ID = long.Parse(Session["Selected_ID"].ToString());
                List<String> threads = tm.ShowMessages(Selected_ThreadID, Chat, UPN_Chat);

                // Afficher les messages
                for(int i = 0; i < threads.Count; i += 5)
                {
                    AddMessage(threads[i], threads[i + 1], threads[i + 2], threads[i + 3], threads[i + 4]);
                }

                ThreadsTable tt = new ThreadsTable((string)Application["MainDB"], this);
                //Titre.Text = ListBox1.SelectedItem.ToString(); *****************************************
                Createur.Text = tt.getCreatorFullName(Selected_ThreadID);
                Date.Text = tt.getThreadsDate(Selected_ThreadID);
            }
             
        }

        // Afficher les usagers du thread
        private void AfficherUsagers()
        {
           TableUsers.Controls.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.GetUsers_thread(TableUsers, Selected_ThreadID);
        }

        // Updater pour recevoir les messages des autres users
        protected void TimerPanel_Tick(object sender, EventArgs e)
        {
            Threads_Messages tm = new Threads_Messages((string)Application["MainDB"], this);
            Chat.Controls.Clear();
            AfficherMessages();
            AfficherUsagers();

            if (Session["Message_Modifier_id"].ToString() != null)
            {
               if(TB_Text.Text != tm.RechercherMessage(Session["Message_Modifier_id"].ToString()))
                   TB_Text.Text = tm.RechercherMessage(Session["Message_Modifier_id"].ToString());
            }
        }
        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }
    }
}