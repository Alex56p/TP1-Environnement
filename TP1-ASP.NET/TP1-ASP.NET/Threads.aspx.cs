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
        protected void Page_Load(object sender, EventArgs e)
       {
            if (Session["Selected_ID"] == null)
            {
                Response.Redirect("Login1.aspx");
            }
            if (Session["Selected_ThreadID"] == null)
                Session["Selected_ThreadID"] = "";
            AfficherThreads(); 
            AfficherUsagers();
            CheckUsagers();   
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

            List<String> threads = t.getThreadsByCreator(Session["Selected_ID"].ToString());
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
                if (thread_id == Session["Selected_ThreadID"].ToString())
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

                UPN_Titre.Triggers.Add(trigger);
                UPN_Bouton.Triggers.Add(trigger);
                UPN_Threads.Triggers.Add(trigger);
                UPN_Usagers.Triggers.Add(trigger);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["Selected_ThreadID"] = btn.ID.Substring(4);
            TB_Titre.Text = btn.Text;            
            btn.BackColor = System.Drawing.Color.LightBlue;

            if (Session["Selected_ThreadID"] == "")
            {
                BTN_Creer.Text = "Créer";
            }
            else
            {
                BTN_Creer.Text = "Modifier";
            }

            AfficherThreads();
            AfficherUsagers();
            CheckUsagers();           

        }

        private void AfficherUsagers()
        {
            Table_Usagers.Controls.Clear();
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.getUsers(Table_Usagers,Session["Selected_ID"].ToString());
        }

        private void CheckUsagers()
        {
            if(Session["Selected_ThreadID"].ToString() != "")
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
                                        if (ta.isInvited(cb.ID, Session["Selected_ThreadID"].ToString()))
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
            
        }

        protected void BTN_Nouveau_Click(object sender, EventArgs e)
        {
            TB_Titre.Text = "";
            Session["Selected_ThreadID"] = "";
            BTN_Creer.Text = "Créer";
            CB_Tous.Checked = false;
           LB_Titre_Check.Text ="";
            LB_Usagers_Check.Text = "";
            AfficherThreads();
            AfficherUsagers();
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

            ta.User_ID = long.Parse(Session["Selected_ID"].ToString());
            ta.Thread_ID = long.Parse(thread_id);
            ta.Insert();
        }

        protected void BTN_Modifier_Click(object sender, EventArgs e)
        {
            //CRÉER
           IsPageValid();
            if (TB_Titre.Text != "" && Session["Selected_ThreadID"] == "")
            {
                ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
                if (!t.Exist(TB_Titre.Text) && AtLeastOne())
                {
                    t.creator = int.Parse(Session["Selected_ID"].ToString());
                    t.Title = TB_Titre.Text;
                    t.Date_of_Creation = DateTime.Now;
                    t.Insert();
                    Session["Selected_ThreadID"] = t.getIDThreads(TB_Titre.Text);
                    BTN_Creer.Text = "Modifier";
                    InsertionUsagers();
                    AfficherThreads();
                    AfficherUsagers();
                    CheckUsagers();
                }
            }
            //MODIFIER
            else if (TB_Titre.Text != "" && Session["Selected_ThreadID"] != "")
            {
                ThreadsTable threads = new ThreadsTable((String)Application["MainDB"], this);

                if (threads.SelectByID(Session["Selected_ThreadID"].ToString()) && AtLeastOne())
                {
                    //Modifier Thread
                    threads.GetValues();
                    threads.Title = TB_Titre.Text;
                    threads.Update();

                    //Modifier Thread_Access
                    Threads_Access ta = new Threads_Access((String)Application["MainDB"], this);
                    List<string> T_Access = ta.getIDByThread(Session["Selected_ThreadID"].ToString());
                    for (int i = 0; i < T_Access.Count; i++)
                    {
                        ta.DeleteRecordByID(T_Access[i]);
                    }
                    InsertionUsagers();

                    AfficherThreads();
                    AfficherUsagers();
                    CheckUsagers();
                }
            }
        }

        private void IsPageValid()
        {

           if (TB_Titre.Text == "")
           {
              LB_Titre_Check.Text = "Le titre est vide.";
              LB_Titre_Check.ForeColor = System.Drawing.Color.Red;
           }
           else
           {
              LB_Titre_Check.Text = "";
           }

           ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
           if (t.Exist(TB_Titre.Text))
           {
              LB_Empty_Check.Text = "Le titre existe déjà.";
             LB_Empty_Check.ForeColor =System.Drawing.Color.Red;
           }
           else
           {
              LB_Empty_Check.Text = "";
           }

           if(!AtLeastOne())
           {
              LB_Usagers_Check.Text = "Il faut au moins un usager.";
              LB_Usagers_Check.ForeColor = System.Drawing.Color.Red;
           }
           else
           {
              LB_Usagers_Check.Text = "";
           }

           UPN_Erreur.Update();
        }

        private bool AtLeastOne()
        {
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
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected void BTN_Effacer_Click(object sender, EventArgs e)
        {
           
            if (Session["Selected_ThreadID"] != "")
            {
                //DELETE THREADS
                ThreadsTable threads = new ThreadsTable((String)Application["MainDB"], this);
                threads.DeleteRecordByID(Session["Selected_ThreadID"].ToString());
                //DELETE THREADS_ACCESS
                Threads_Access ta = new Threads_Access((String)Application["MainDB"], this);
                
                List<string> T_Access = ta.getIDByThread(Session["Selected_ThreadID"].ToString());
                for (int i = 0; i < T_Access.Count; i++)
                {
                    ta.DeleteRecordByID(T_Access[i]);
                }
                //DELETE THREADS_MESSAGES
                Threads_Messages tm = new Threads_Messages((String)Application["MainDB"], this);
                List<string> Messages = tm.getIdByThreads(Session["Selected_ThreadID"].ToString());
                for (int i = 0; i < Messages.Count; i++)
                {
                    ta.DeleteRecordByID(Messages[i]);
                }
                TB_Titre.Text = "";
                Session["Selected_ThreadID"] = "";
                BTN_Creer.Text = "Creer";
                AfficherThreads();
                AfficherUsagers();
                CheckUsagers();
            }
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }

        protected void CB_Tous_CheckedChanged(object sender, EventArgs e)
        {
            bool Check;
            if(CB_Tous.Checked)
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

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
                                    cb.Checked = Check;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}