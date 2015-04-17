using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public class Threads_Messages : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID;
        public long Thread_ID;
        public long User_ID;
        public string Date_of_Creation;
        public String Message;


        public Threads_Messages(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_MESSAGES";
        }

        public override void GetValues()
        {
           ID = long.Parse(FieldsValues[0]);
           Thread_ID = long.Parse(FieldsValues[1]);
           User_ID = long.Parse(FieldsValues[2]);
           Date_of_Creation = FieldsValues[3];
           Message = FieldsValues[4];
        }

        public override void Insert()
        {
            InsertRecord(Thread_ID, User_ID, Date_of_Creation, Message);
        }

        public override void Update()
        {
           UpdateRecord(Thread_ID, User_ID, Date_of_Creation, Message);
        }

        public void ShowMessages(String Thread, Table t)
        {
            SqlDataReader reader = FillReaderChat(Thread.ToString());

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    AddMessage(t, 
                        reader.GetString(4), 
                        reader.GetInt64(2).ToString(), 
                        reader.GetDateTime(3).ToString(), 
                        GetAvatar1(reader.GetInt64(2).ToString()), 
                        GetFullName1(reader.GetInt64(2).ToString()), 
                        reader.GetInt64(0));
                }
            }
            EndQuerySQL();
        }

        public string GetAvatar1(string ID)
        {
            QuerySQL("Select Avatar FROM PERSONNES Where ID = " + ID);
            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                return read;
            }
            EndQuerySQL();
            return "";
        }

        internal string GetFullName1(string p)
        {
            QuerySQL("Select FullName FROM PERSONNES Where ID = " + p);
            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                return read;
            }
            EndQuerySQL();
            return "";
        }


        public static void AddMessage(Table t, string Message, string user_id, string Date, string imageurl, string fullname, long Id_Message)
        {
            TableRow tr = new TableRow();
            tr.CssClass = "grid";

            //Image
            TableCell picture = new TableCell();
            picture.CssClass = "ChatImage";
            Image img = new Image();
            img.CssClass = "ChatImage";
            img.ImageUrl = "Avatars/" + imageurl;
            picture.Controls.Add(img);

            //UserName
            TableCell UserName = new TableCell();
            UserName.Text = fullname;

            //Date
            TableCell dateMessage = new TableCell();
            dateMessage.Text = Date;

            //Text
            TableCell TextMessage = new TableCell();
            TextMessage.Text = Message;

            //Modifier
            TableCell Modifier = new TableCell();
            ImageButton BTN_Modifier = new ImageButton();
            BTN_Modifier.CssClass = "ChatImage";
            BTN_Modifier.ImageUrl = "Images/edit.png";
            BTN_Modifier.Click += ChatRoom.BTN_Modifier_Click;
            Modifier.Controls.Add(BTN_Modifier);
            BTN_Modifier.ID = "M" + Id_Message.ToString();

            //Effacer
            TableCell Supprimer = new TableCell();
            ImageButton BTN_Supprimer = new ImageButton();
            BTN_Supprimer.CssClass = "ChatImage";
            BTN_Supprimer.ImageUrl = "Images/delete.png";
            BTN_Supprimer.Click += ChatRoom.BTN_Supprimer_Click;
            Supprimer.Controls.Add(BTN_Supprimer);
            BTN_Supprimer.ID = "S" + Id_Message.ToString();

            tr.Cells.Add(picture);
            tr.Cells.Add(UserName);
            tr.Cells.Add(dateMessage);
            tr.Cells.Add(TextMessage);
            tr.Cells.Add(Modifier);
            tr.Cells.Add(Supprimer);
            t.Rows.Add(tr);
        }

        internal string GetFullName(string id)
        {
            QuerySQL("Select FullName FROM PERSONNES Where ID = " + id );
            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                return read;
            }
            EndQuerySQL();
            return "";
        }
        public string GetAvatar(string ID)
        {
            QuerySQL("Select Avatar FROM PERSONNES Where ID = " + ID);
            
            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                return read;
            }
            EndQuerySQL();
            return "";
        }

        public string RechercherMessage(string id)
        {
            QuerySQL("Select Message from THREADS_MESSAGES where Id = " + id);

            if(reader.Read())
            {
                string Message = reader.GetString(0);
                EndQuerySQL();
                return Message;
            }
            EndQuerySQL();

            return "";
        }

        public void UpdateMessage(string id_Message, string Message)
        {
            NonQuerySQL("UPDATE THREADS_MESSAGES SET Message = '" + Message + "' WHERE Id = " + id_Message);
            EndQuerySQL();
        }

        public long GetLastIdMessage()
        {
            QuerySQL("SELECT Id FROM THREADS_MESSAGES ORDER BY Id DESC");
            if(reader.Read())
            {
                EndQuerySQL();
                return reader.GetInt64(0);
            }
            EndQuerySQL();
            return 0;
        }

    }
}