using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public class Logins : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public String IPAdress { get; set; }
       
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="connexionString"></param>
        /// <param name="Page"></param>
        public Logins (String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "LOGINS";
        }

        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            UserID = long.Parse(FieldsValues[1]);
            LoginDate = DateTime.Parse(FieldsValues[2]);
            LogoutDate = DateTime.Parse(FieldsValues[3]);
            IPAdress = FieldsValues[4];
        }

        public override void Insert()
        {
              InsertRecord(UserID, LoginDate, LogoutDate, IPAdress);
        }

        public override void Update()
        {
            UpdateRecord(UserID, LoginDate, LogoutDate, IPAdress);
        }

        private Panel PN_GridView = null;
        public void MakeGridView(Panel PN_GridView, String EditPage, String UserSelected)
        {
            SqlDataReader reader = FillReader(UserSelected.ToString());
            // Conserver le panneau parent (utilisé dans certaines méthodes de cette classe
            this.PN_GridView = PN_GridView;
            Table Grid = null;

            if(reader.HasRows)
            {
                // Création de l'entête
                Grid = new Table();
                Grid.CssClass = "grid";
                TableRow tr = new TableRow();
                tr.CssClass = "grid";
                AjouterElementHeader(tr, "UserName");
                AjouterElementHeader(tr, "Date_Login");
                AjouterElementHeader(tr, "Durée_Session");
                Grid.Rows.Add(tr);

                while(reader.Read())
                {
                    // Insertion des données
                    tr = new TableRow();
                    tr.CssClass = "grid";
                    InsertionUserName(tr, UserSelected);
                    InsertionDateLogin(tr, reader.GetDateTime(2));
                    InsertionDuree(tr, reader.GetDateTime(2), reader.GetDateTime(3));
                    Grid.Rows.Add(tr);
                }
            }            
                PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
        }

        private void AjouterElementHeader(TableRow tr, String Titre)
        {
            TableCell td = new TableCell();
            td.CssClass = "grid";
            tr.Cells.Add(td);
            Label LBL_Header = new Label();
            LBL_Header.Text = "<b>" + Titre + "</b>";
            ImageButton BTN_Sort = new ImageButton();
            // assignation du delegate du clic (voir sa définition plus bas dans le code)
            BTN_Sort.Click += new ImageClickEventHandler(SortField_Click);
            // IMPORTANT!!!
            // il faut placer dans le répertoire Images du projet l'icône qui représente un tri
            BTN_Sort.ImageUrl = @"~/Images/Sort.png";
            // afin de bien reconnaitre quel champ il faudra trier on construit ici un ID
            // pour le bouton
            BTN_Sort.ID = "Sort_" + Titre;
            td.Controls.Add(BTN_Sort);
            td.Controls.Add(LBL_Header);
        }

        private void InsertionUserName(TableRow tr, String UserSelected)
        {
            TableCell td = new TableCell();
            td.CssClass = "grid";
            td.Text = SelectByUserID(UserSelected);

            tr.Cells.Add(td);
        }

        private void InsertionDateLogin(TableRow tr, DateTime LoginDate)
        {
            TableCell td = new TableCell();
            td.Text = LoginDate.ToShortDateString();
            td.CssClass = "grid";

            tr.Cells.Add(td);
        }

        private void InsertionDuree(TableRow tr, DateTime LoginDate, DateTime LogoutDate)
        {
            TableCell td = new TableCell();
            td.Text = LogoutDate.Subtract(LoginDate).ToString();
            td.CssClass = "grid";

            tr.Cells.Add(td);
        }

    }
}