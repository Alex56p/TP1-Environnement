﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscription.aspx");
        }

        protected void BTN_PasswordLost_Click(object sender, EventArgs e)
        {
            
        }

    }
}