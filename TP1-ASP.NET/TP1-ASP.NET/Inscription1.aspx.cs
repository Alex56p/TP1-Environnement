using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace TP1_ASP.NET
{
    public partial class Inscription1 : System.Web.UI.Page
    {
        PersonnesTable Personnes;
        bool valid = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Session["captcha"] = BuildCaptcha();

            if (TB_Username.Text != null)
                Session["Username"] = TB_Username.Text;
            Session["Header"] = "Inscription...";
        }

        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PersonnesTable personne = new PersonnesTable((string)Application["MainDB"], this);
            args.IsValid = !personne.Exist(TB_Username.Text);
            if (valid)
                valid = args.IsValid;
        }

        protected void AddUser()
        {
            if ((Session["Username"] != null) && Session["Username"].ToString() != "")
            {

                Personnes = new PersonnesTable((String)Application["MainDB"], this);
                Personnes.FullName = TB_Nom.Text;
                Personnes.UserName = TB_Username.Text;
                Personnes.Password = TB_Password.Text;
                Personnes.Email = TB_Password.Text;

                string Avatar_Path;
                string avatar_ID;
                if (FU_Avatar.FileName != "")
                {
                    avatar_ID = FU_Avatar.FileName;
                    Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID;
                    FU_Avatar.SaveAs(Avatar_Path);
                    Personnes.Avatar = avatar_ID;
                }
                else
                {
                    Personnes.Avatar = Personnes.GetAvatar(Session["Selected_ID"].ToString());
                }
                Personnes.Insert();
            }
        }

        protected void BTN_Inscrire_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                Personnes = new PersonnesTable((String)Application["MainDB"], this);

                AddUser();
                Session["Selected_ID"] = Personnes.getID(TB_Username.Text);
                Session["Selected_UserName"] = TB_Username.Text;
                Response.Redirect("Index1.aspx");
            }
        }

        protected void BTN_Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login1.aspx");
        }

        protected void CV_Email_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Email.Text != TB_Email_Confirm.Text)
            {
                valid = false;
                args.IsValid = false;
            }

        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TB_Password.Text != TB_Password_Confirm.Text)
            {
                valid = false;
                args.IsValid = false;
            }
        }

        /// <summary>
        /// CAPTCHA
        /// </summary>
        #region Captcha
        Random random = new Random();
        char RandomChar()
        {
            // les lettres comportant des ambiguïtées ne sont pas dans la liste
            // exmple: 0 et O ont été retirés
            string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
            return chars[random.Next(0, chars.Length)];
        }

        Color RandomColor(int min, int max)
        {
            return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
        }

        string Captcha()
        {
            string captcha = "";

            for (int i = 0; i < 5; i++)
                captcha += RandomChar();
            return captcha;//.ToLower();
        }

        string BuildCaptcha()
        {
            int width = 200;
            int height = 70;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics DC = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(RandomColor(0, 127));
            SolidBrush pen = new SolidBrush(RandomColor(172, 255));
            DC.FillRectangle(brush, 0, 0, 200, 100);
            Font font = new Font("Snap ITC", 32, FontStyle.Regular);
            PointF location = new PointF(5f, 5f);
            DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            string captcha = Captcha();
            DC.DrawString(captcha, font, pen, location);

            // noise generation
            for (int i = 0; i < 5000; i++)
            {
                bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
            }
            bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
            return captcha;
        }

        protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
        {
            Session["captcha"] = BuildCaptcha();
            // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
            IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
            PN_Captcha.Update();
        }

        protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
            if (valid)
                valid = args.IsValid;
        }
        #endregion
    }
}