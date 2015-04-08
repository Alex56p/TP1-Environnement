using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_ASP.NET
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Envoyer_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = TB_Text.Text;
            Panel_Chat.ContentTemplateContainer.Controls.Add(lbl);
            Panel_Chat.ContentTemplateContainer.Controls.Add(new LiteralControl("<br/>"));
        }
    }
}