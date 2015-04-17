using System;
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

        public List<string> LoadFields(string ID)
        {
            List<string> Fields = new List<string>();
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID =" + ID);
            if (reader.Read())
            {
                Fields.Add(reader.GetString(1));
                Fields.Add(reader.GetString(2));
                Fields.Add(reader.GetString(3));
            }
            EndQuerySQL();
            return Fields;
        }

        public override void Insert()
        {
            InsertRecord(creator, Title, Date_of_Creation);
        }

        public override void Update()
        {
            UpdateRecord(id,creator, Title, Date_of_Creation);
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

        internal void getUsers(Table table)
        {
            QuerySQL("SELECT ID,UserName, Avatar FROM PERSONNES");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Insertion des données
                    TableRow tr = new TableRow();
                    InsertionCheckBox(tr, reader.GetInt64(0));
                    InsertionPhoto(tr, reader.GetString(2));
                    InsertionUserName(tr, reader.GetString(1));
                    
                    table.Rows.Add(tr);
                }
            }
            EndQuerySQL();
        }

        internal void GetUsers_thread(Table table, string Thread_id)
        {
            QuerySQL("SELECT User_Id FROM Threads_access WHERE THREAD_ID = " + Thread_id);
            if (reader.HasRows)
            {
                List<string> listUserId = new List<string>();
                while (reader.Read())
                {
                    listUserId.Add(reader.GetInt64(0).ToString());
                     
                }
                EndQuerySQL();
                for (int i = 0; i < listUserId.Count; i++ )
                {
                    QuerySQL("SELECT ID,UserName, Avatar, Connecte FROM PERSONNES WHERE id = " + listUserId[i]);
                    if(reader.HasRows)
                    {
                        if(reader.Read())
                        {
                            // Insertion des données
                            TableRow tr = new TableRow();
                            if (reader.GetInt32(3) == 1)
                                InsertionStatut(tr, "/Images/OnLine.png");
                            else
                                InsertionStatut(tr, "/Images/Busy.png");
                            InsertionPhoto(tr, reader.GetString(2));
                            InsertionUserName(tr, reader.GetString(1));

                            table.Rows.Add(tr);
                        }
                    }
                }
            }
            EndQuerySQL();
        }

        private void InsertionStatut(TableRow tr, string p)
        {
            TableCell td = new TableCell();
            Image img = new Image();
            img.CssClass = "ChatImage";
            img.ImageUrl = p;
            td.CssClass = "grid";
            td.Controls.Add(img);

            tr.Cells.Add(td);
        }

        internal string getCreatorFullName(string Thread_id)
        {
            QuerySQL("SELECT CREATOR FROM THREADS WHERE ID =" + Thread_id);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    long creator = reader.GetInt64(0); 
                    EndQuerySQL();

                    QuerySQL("SELECT FULLNAME FROM PERSONNES WHERE ID =" + creator);

                    if(reader.HasRows)
                    {
                        string FullName = "";
                        if(reader.Read())
                            FullName = reader.GetString(0);
                        EndQuerySQL(); 
                        return FullName;
                    }
                }
            }
            EndQuerySQL();
            return "";
        }

        internal string getThreadsDate(string thread_id)
        {
            QuerySQL("SELECT DATE_OF_CREATION FROM THREADS WHERE ID =" + thread_id);
            string date = "";
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    date = reader.GetDateTime(0).ToShortDateString();
                }
            }
            EndQuerySQL();
            return date;
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

        private void InsertionCheckBox(TableRow tr, long id)
        {
            TableCell td = new TableCell();
            CheckBox cb = new CheckBox();
            cb.ID = id.ToString();

            td.Controls.Add(cb);
            tr.Cells.Add(td);
        }


        internal void ShowThreads(ListBox lb)
        {
            lb.Height = 200;
            lb.Width = 100;
            QuerySQL("SELECT TITLE FROM THREADS");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lb.Items.Add(reader.GetString(0));
                }
            }
            EndQuerySQL();
        }

        internal bool Exist(string p)
        {
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE TITLE = '" + p + "'");
            if (reader.HasRows)
            {
                EndQuerySQL();
                return true;
            }
            else
            {
                EndQuerySQL();
                return false;
            }   
        }
    }
}