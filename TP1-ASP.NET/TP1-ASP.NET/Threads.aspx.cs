using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Threads : System.Web.UI.Page
    {
        static string Selected_ThreadID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            AfficherThreads(); 

            if (Selected_ThreadID == "")
            {
                Button btn = GetFirstButton();
                if (btn != null)
                    Selected_ThreadID = btn.ID.Substring(4);
            }

            if(!IsPostBack)
            {
                AfficherUsagers();
                CheckUsagers();   
            }
        }

        private Button GetFirstButton()
        {
            foreach (Control c in PN_Threads.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.Table"))
                {
                    foreach(Control c2 in c.Controls)
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

        private void AfficherThreads()
        {
            PN_Threads.Controls.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            Table table = new Table();
            PN_Threads.Controls.Add(table);
            TableRow tr;
            TableCell td;

            List<String> threads = t.getThreads();
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
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Selected_ThreadID = btn.ID.Substring(4);
            AfficherThreads();
            AfficherUsagers();
            CheckUsagers();
        }

        private void AfficherUsagers()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.getUsers(Table_Usagers);
        }

        private void CheckUsagers()
        {
            Threads_Access ta = new Threads_Access((string)Application["MainDB"], this);
            foreach (Control c in Table_Usagers.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TableRow"))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType().ToString().Equals("System.Web.UI.WebControls.TableCell"))
                        {
                            foreach (Control c3 in c2.Controls)
                            {
                                if (c3.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                                {
                                    CheckBox cb = (CheckBox)c3;
                                    if (ta.isInvited(cb.ID, Selected_ThreadID))
                                    {
                                        cb.Checked = true;
                                    }
                                    else
                                    {
                                        cb.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void BTN_Nouveau_Click(object sender, EventArgs e)
        {
            if (TB_Titre.Text != "")
            {
                ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
                t.creator = int.Parse(Session["Selected_ID"].ToString());
                t.Title = TB_Titre.Text;
                t.Date_of_Creation = DateTime.Now;
                t.Insert();

                InsertionUsagers();


            }
            AfficherThreads();
        }

        private void InsertionUsagers()
        {
            Threads_Access ta = new Threads_Access((string)Application["MainDB"], this);
            string thread_id = ta.getIDThreads(TB_Titre.Text);
            foreach (Control c in Table_Usagers.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TableRow"))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType().ToString().Equals("System.Web.UI.WebControls.TableCell"))
                        {
                            foreach (Control c3 in c2.Controls)
                            {
                                if (c3.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                                {
                                    CheckBox cb = (CheckBox)c3;
                                    if (cb.Checked)
                                    {
                                        ta.User_ID = long.Parse(c3.ID);
                                        ta.Thread_ID = long.Parse(thread_id);
                                        ta.Insert();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void BTN_Modifier_Click(object sender, EventArgs e)
        {
            if (TB_Titre.Text != "" && Selected_ThreadID != "")
            {
                ThreadsTable threads = new ThreadsTable((String)Application["MainDB"], this);

                if (threads.SelectByID(Selected_ThreadID))
                {
                    threads.GetValues();
                    threads.Title = TB_Titre.Text;
                    threads.Update();
                }
            }
            AfficherThreads();
        }

        protected void BTN_Effacer_Click(object sender, EventArgs e)
        {
            if (Selected_ThreadID != "")
            {
                ThreadsTable threads = new ThreadsTable((String)Application["MainDB"], this);
                threads.DeleteRecordByID(Selected_ThreadID);
            }
            AfficherThreads();
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }

        protected void LB_Threads_SelectedIndexChanged(object sender, EventArgs e)
        {
            Threads_Access ta = new Threads_Access((string)Application["MainDB"], this);
            string thread_id = ta.getIDThreads(TB_Titre.Text);
            foreach (Control c in Table_Usagers.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TableRow"))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType().ToString().Equals("System.Web.UI.WebControls.TableCell"))
                        {
                            foreach (Control c3 in c2.Controls)
                            {
                                if (c3.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                                {
                                    CheckBox cb = (CheckBox)c3;
                                    cb.Checked = ta.isInvited(cb.ID, thread_id);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}