﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public class ThreadsTable : SqlExpressUtilities.SqlExpressWrapper
    {
        public int id;
        public int creator;
        public String Title;
        public DateTime Date_of_Creation;


        public ThreadsTable(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS";
        }

        public override void GetValues()
        {
            id = int.Parse(FieldsValues[0]);
            creator = int.Parse(FieldsValues[1]);
            Title = FieldsValues[2].ToString();
            Date_of_Creation = DateTime.Parse(FieldsValues[3]);
        }

        public override void Insert()
        {
            InsertRecord(creator, Title, Date_of_Creation);
        }

        public override void Update()
        {
            UpdateRecord(creator, Title, Date_of_Creation);
        }

        internal List<string> getThreads()
        {
            List<string> threads = new List<string>();

            QuerySQL("SELECT TITLE FROM THREADS");
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    threads.Add(reader.GetString(0));
                }
            }
            EndQuerySQL();
            return threads;
        }

        internal Table getUsers()
        {
            Table table = new Table();

            QuerySQL("SELECT UserName, Avatar FROM PERSONNES");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Insertion des données
                    TableRow tr = new TableRow();
                    InsertionUserName(tr, reader.GetString(0));
                    InsertionPhoto(tr, reader.GetString(1));
                    InsertionCheckBox(tr);
                    table.Rows.Add(tr);
                }
            }
            EndQuerySQL();

           return table;
        }

        private void InsertionPhoto(TableRow tr, String Avatar)
        {
            TableCell td = new TableCell();
            Image img = new Image();
            img.CssClass = "ChatImage";
            img.ImageUrl = "/Avatars/" + Avatar;
            td.Controls.Add(img);
            tr.Cells.Add(td);
        }

        private void InsertionUserName(TableRow tr, String User)
        {
            TableCell td = new TableCell();
            td.Text = User;

            tr.Cells.Add(td);
        }

        private void InsertionCheckBox(TableRow tr)
        {
            TableCell td = new TableCell();
            CheckBox cb = new CheckBox();

            td.Controls.Add(cb);
            tr.Cells.Add(td);
        }
    }
}