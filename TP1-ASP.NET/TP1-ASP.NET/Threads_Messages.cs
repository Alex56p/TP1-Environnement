using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_ASP.NET
{
    public class Threads_Messages : SqlExpressUtilities.SqlExpressWrapper
    {
        public int id;
        public int Thread_ID;
        public int User_ID;
        public DateTime Date_of_Creation;
        public String Message;


        public Threads_Messages(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_MESSAGES";
        }
    }
}