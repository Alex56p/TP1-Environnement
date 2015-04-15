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
                    AddMessage(t, reader.GetString(4), reader.GetInt64(2));
                }
            }
            EndQuerySQL();
        }

        public void AddMessage(Table t, string Message, long user)
        {
            TableRow tr = new TableRow();
            tr.CssClass = "grid";

            //Image
            TableCell picture = new TableCell();
            picture.CssClass = "ChatImage";
            Image img = new Image();
            img.ImageUrl = "Avatars/" + GetAvatar(user.ToString()) + ".png";
            picture.Controls.Add(img);

            //Text
            TableCell TextMessage = new TableCell();
            TextMessage.Text = Message;

            tr.Cells.Add(picture);
            tr.Cells.Add(TextMessage);
            t.Rows.Add(tr);
        }
        public string GetAvatar(string ID)
        {
            QuerySQL("Select Avatar FROM PERSONNES Where ID = " + ID);
            
            if (reader.Read())
            {
                string read = reader.GetString(0);
                EndQuerySQL();
                QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID = " + ID);
                EndQuerySQL();
                return read;
            }
            return "";
        }

    }
}