﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}