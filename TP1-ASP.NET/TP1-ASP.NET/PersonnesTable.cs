using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public class PersonnesTable : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }

        public PersonnesTable(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "PERSONNES";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            FullName = FieldsValues[1];
            UserName = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];
            Avatar = FieldsValues[5];
        }

        public override void InitVisibility()
        {
            base.InitVisibility();
            SetVisibility(5, false);
        }

        public override void Insert()
        {
            InsertRecord(FullName, UserName, Password, Email, Avatar);
        }
        public override void Update()
        {
            UpdateRecord(ID, FullName, UserName, Password, Email, Avatar);
        }

        public bool Exist(String userName)
        {
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "'");
            if (reader.HasRows)
            {
                Next();
                GetValues();
                return true;
            }
            else
                return false;
        }

        public bool Valid(String userName, string Password)
        {
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "' AND PASSWORD = '" + Password + "'");
            if (reader.HasRows)
            {
                Next();
                GetValues();
                return true;
            }
            else
                return false;
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
                Fields.Add(reader.GetString(4));
                Fields.Add(reader.GetString(5));
            }

            return Fields;
        }
    }

}