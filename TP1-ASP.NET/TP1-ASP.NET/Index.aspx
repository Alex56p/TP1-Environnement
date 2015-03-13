<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1_ASP.NET.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Accueil</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script src="ClientFormUtilities.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <style>

        .Connexion{
            float:right;
        }

        .submitBTN {
            display: block;
            width: 173px;
            text-align: center;
        }
    </style>
</head>
    
<body>
    <div>
        <h2>Accueil...</h2>
        <asp:Label ID="LB_HdrUserName" CssClass="Connexion" runat="server" Text="Anonymous"></asp:Label>
        <asp:Image ID="Img_Username" CssClass="Connexion" runat="server" />
    </div>
    <hr />
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." class="submitBTN" OnClick="BTN_Profil_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Online" runat="server" Text="Usagers en ligne..." class="submitBTN" OnClick="BTN_Online_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Journal" runat="server" Text="Journal des visites..." class="submitBTN" OnClick="BTN_Journal_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Deconnexion" runat="server" Text="Déconnexion..." class="submitBTN" OnClick="BTN_Deconnexion_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
