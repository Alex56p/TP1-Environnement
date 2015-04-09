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

        public override void Insert()
        {
            id = int.Parse(getIDByCreator(creator));
            InsertRecord(id, creator, Title, Date_of_Creation);
        }

        public override void Update()
        {
            id = int.Parse(getIDByCreator(creator));
            UpdateRecord(id, creator, Title, Date_of_Creation);
        }



    }
}