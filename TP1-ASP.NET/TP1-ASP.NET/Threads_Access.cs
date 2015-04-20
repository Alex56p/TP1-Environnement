using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_ASP.NET
{
    public class Threads_Access : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID;
        public long Thread_ID;
        public long User_ID;


        public Threads_Access(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_ACCESS";
        }

        public override void GetValues()
        {
           ID = long.Parse(FieldsValues[0]);
           Thread_ID = long.Parse(FieldsValues[1]);
           User_ID = long.Parse(FieldsValues[2]);
        }

        public override void Insert()
        {
            InsertRecord(Thread_ID, User_ID);
        }

        public override void Update()
        {
           UpdateRecord(Thread_ID, User_ID);
        }

        internal bool isInvited(string User_ID, string thread_id)
        {
            QuerySQL("SELECT USER_ID FROM THREADS_ACCESS WHERE THREAD_ID =" + thread_id);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if(reader.GetInt64(0) == long.Parse(User_ID))
                    {
                        EndQuerySQL();
                        return true;
                    }
                }
            }
            EndQuerySQL();
            return false;
        }

        internal List<string> getIDByThread(string Selected_ThreadID)
        {
            List<string> Messages = new List<string>();

            QuerySQL("SELECT ID FROM THREADS_ACCESS WHERE Thread_Id =" + Selected_ThreadID);
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