using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_ASP.NET
{
    public class Threads_Messages : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID;
        public long Thread_ID;
        public long User_ID;
        public DateTime Date_of_Creation;
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
           Date_of_Creation = DateTime.Parse(FieldsValues[3]);
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
    }
}