<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1_ASP.NET.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
         #Avatar {
            padding-left: 45px;
        }

        .Avatar{
            width:140px;
            display:block;
            margin-left:auto;
            margin-right:auto;
        }

        #Profil {
            background-color: lightgrey;
            border: solid 1px;
            width: 500px;
            margin: auto;
        }

        .label {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="MainHeader">
            <h2>Votre profil...</h2>
            <hr />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="Profil">
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
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Update" runat="server" Text="Mettre à jour..." />
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
