<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1_ASP.NET.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #Avatar {
            margin: auto;
            padding-left: 100px;
        }

        .Avatar{
            width:140px;
            display:block;
            margin-left:auto;
            margin-right:auto;
        }

        #Inscription {
            background-color: lightgrey;
            border: solid 1px;
            width: 500px;
            margin: auto;
        }

        .label {
            text-align: right;
        }

        #RegenarateCaptcha {
            width: 25px;
            height: 25px;
        }

        #IMGCaptcha {
            height: 40px;
            width: 100px;
        }

        .padding {
            width: 100px;
            padding-left: 30px;
        }

        #TB_Captcha {
            width: 100px;
        }

        .thumbnail {
            height: 100px;
            width: 100px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="MainHeader">
            <h2>Inscription...</h2>
            <hr />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="Inscription">
            <div id="Avatar">
                <asp:Image ID="IMG_Avatar" runat="server" CssClass="Avatar" ImageUrl="~/Images/Anonymous.png" />
                <asp:FileUpload ID="FU_Avatar" runat="server" CssClass="Avatar" onchange="PreLoadImage()" ClientIDMode="Static" />
            </div>

            <table>
                <tr>
                    <td class="label">Nom au complet </td>
                    <td>
                        <asp:TextBox ID="TB_Nom" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label">Nom d'usager </td>
                    <td>
                        <asp:TextBox ID="TB_Username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label">Mot de passe </td>
                    <td>
                        <asp:TextBox ID="TB_Password" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="label">Confirmation du mot de passe </td>
                    <td>
                        <asp:TextBox ID="TB_Password_Confirm" runat="server" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label">Adresse courriel</td>
                    <td>
                        <asp:TextBox ID="TB_Email" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label">Confirmation de l'adresse courriel </td>
                    <td>
                        <asp:TextBox ID="TB_Email_Confirm" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="RegenarateCaptcha" runat="server"
                                                ImageUrl="~/Images/RegenerateCaptcha.png"
                                                CausesValidation="False"
                                                OnClick="RegenarateCaptcha_Click"
                                                ValidationGroup="Subscribe_Validation"
                                                ToolTip="Regénérer le captcha..." />
                                        </td>
                                        <td>
                                            <asp:Image ID="IMGCaptcha" Class="Captcha" ImageUrl="~/captcha.png" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                </tr>
                <tr>
                    <td></td>
                    <td class="TB_Captcha">
                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5"></asp:TextBox>
                        <asp:CustomValidator ID="CV_Captcha" runat="server"
                            ErrorMessage="Code captcha incorrect!"
                            ValidationGroup="Subscribe_Validation"
                            Text="!"
                            OnServerValidate="CV_Captcha_ServerValidate"
                            ControlToValidate="TB_Captcha"
                            ValidateEmptyText="True">
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Inscrire" runat="server" Text="S'inscrire..." />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Annuler" runat="server" Text="Annuler..." />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
