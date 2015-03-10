<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Labo_2.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="FormStyles.css"/>
</head>
<body>
    <h2>Login...</h2> <hr />
    <form id="form1" runat="server">
    <div style="margin:auto; width:350px; background-color:lightgray; padding:20px; border:1px solid black;">
        <table>
            <tr>
                <td> <asp:Label for="TB_UserName" runat="server" Text="Nom d'usager"></asp:Label>   </td>
                <td> <asp:TextBox ID="TB_UserName" runat="server" CssClass="TextBox"></asp:TextBox> </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_UserName" runat="server" 
                        Text="!vide" 
                        ErrorMessage="Le nom d'usager est vide!"
                        ControlToValidate="TB_UserName"
                        ValidationGroup="VG_Login">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td> <asp:Label for="TB_Password" runat="server" Text="Mot de passe"></asp:Label>   </td>
                <td> <asp:TextBox ID="TB_Password" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox> </td>
                 <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_Password" runat="server" 
                        Text="!vide" 
                        ErrorMessage="Le mot de passe est vide!"
                        ControlToValidate="TB_Password"
                        ValidationGroup="VG_Login">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td> <asp:Button ID="BTN_Login" runat="server" Text="Soumettre..." class="submitBTN" ValidationGroup="VG_Login"/> </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:left;">
                    <asp:ValidationSummary ID="VGS_Logi" runat="server"  
                        ValidationGroup="VG_Login" 
                        HeaderText="Résumé des erreurs: &lt;hr/&gt;"
                    />
                </td>
            </tr>
        </table>
    </div>
        <asp:CustomValidator ID="CV_TB_UserName" runat="server" 
            ErrorMessage="Ce nom d'usager n'existe pas!" 
            Display="None" 
            ValidationGroup="VG_Login" 
            OnServerValidate="CV_TB_UserName_ServerValidate">
        </asp:CustomValidator>
    </form>
</body>
</html>
