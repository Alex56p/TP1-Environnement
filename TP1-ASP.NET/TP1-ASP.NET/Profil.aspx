<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1_ASP.NET.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="ClientFormUtilities.js"></script>
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

        .thumbnail{
            width:64px;
            height:64px;
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
        div{
            display:block;
        }

        tbody {
          display: table-row-group;
          vertical-align: middle;
          border-color: inherit;
        }

        .header{
            width:99%;
        }
        .mainHeader{
                  width: 100%;
                  padding: 0px;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainHeader">
            <table>
                <tbody>
                     <tr>
                        <td class="header">
                            <h2>Votre profil...</h2>
                        </td>
                        <td >
                            <asp:Label ID="LB_HdrUserName" runat="server" Text="Anonymous"></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="Img_Username" CssClass="thumbnail" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
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
                        <asp:RequiredFieldValidator
                            ID="RFV_Nom"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="Le nom complet est vide!"
                            ControlToValidate="TB_Nom"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="label">Nom d'usager </td>
                    <td>
                        <asp:TextBox ID="TB_Username" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_UserName"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="Le nom d'usager est vide!"
                            ControlToValidate="TB_Username"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="label">Mot de passe </td>
                    <td>
                        <asp:TextBox ID="TB_Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_Password"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="Le mot de passe est vide!"
                            ControlToValidate="TB_Password"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="label">Adresse courriel</td>
                    <td>
                        <asp:TextBox ID="TB_Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_Email"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="L'adresse courriel est vide!"
                            ControlToValidate="TB_Email"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Update" runat="server" onClick="BTN_Update_Click" Text="Mettre à jour..." ValidationGroup="VG_Login" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Annuler" runat="server" Text="Annuler..." OnClick="BTN_Annuler_Click" />
                    </td>
                </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
