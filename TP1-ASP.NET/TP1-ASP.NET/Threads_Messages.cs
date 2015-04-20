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

        public List<String> ShowMessages(String Thread, Table t, UpdatePanel p)
        {
            SqlDataReader reader = FillReaderChat(Thread.ToString());
            List<String> list = new List<string>();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    list.Add(reader.GetInt64(0).ToString());
                    list.Add(reader.GetInt64(1).ToString());
                    list.Add(reader.GetInt64(2).ToString());
                    list.Add(reader.GetDateTime(3).ToShortDateString());
                    list.Add(reader.GetString(4));
                }
            }
            EndQuerySQL();

            return list;
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


        public string GetUserName(long user_id)
        {
            QuerySQL("Select UserName FROM PERSONNES Where ID = " + user_id);

            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                return read;
            }
            EndQuerySQL();
            return "";
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

        internal List<string> getIdByThreads(string Selected_ThreadID)
        {
            List<string> Messages = new List<string>();

            QuerySQL("SELECT ID FROM Threads_Messages WHERE Thread_Id =" + Selected_ThreadID);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Messages.Add(reader.GetInt64(0).ToString());
                }
            }
            EndQuerySQL();
            return Messages;
        }
    }
}