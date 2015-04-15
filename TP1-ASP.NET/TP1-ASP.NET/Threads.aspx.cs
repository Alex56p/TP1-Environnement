﻿using System;
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
            AfficherThreads();
            AfficherUsagers();
        }

        private void AfficherThreads()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            List<String> threads = t.getThreads();
            for(int i = 0; i < threads.Count;i++)
            {
                LB_Threads.Items.Add(threads[i]);
            }
        }

        private void AfficherUsagers()
        {
            ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
            t.getUsers(Panel_Usagers);
        }

        protected void BTN_Nouveau_Click(object sender, EventArgs e)
        {
            if(TB_Titre.Text != "")
            {
                ThreadsTable t = new ThreadsTable((string)Application["MainDB"], this);
                t.creator = int.Parse(Session["Selected_ID"].ToString());
                t.Title = TB_Titre.Text;
                t.Date_of_Creation = DateTime.Now;
                t.Insert();
            }
        }

        protected void BTN_Modifier_Click(object sender, EventArgs e)
        {
            if (TB_Titre.Text != "" && LB_Threads.SelectedItem != null)
            {
                ThreadsTable threads = new ThreadsTable((String)Application["MainDB"], this);

                if (threads.SelectByID(threads.getIDThreads(LB_Threads.SelectedItem.ToString())))
                {
                    threads.GetValues();
                    threads.Title = TB_Titre.Text;
                    threads.Update();
                }
            }
            LB_Threads.Items.Clear();
            AfficherThreads();
        }

        protected void BTN_Effacer_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index1.aspx");
        }
    }
}