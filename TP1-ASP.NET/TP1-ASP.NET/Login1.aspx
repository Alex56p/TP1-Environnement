﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="TP1_ASP.NET.Login1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    
    <div style="margin: auto; width: 350px; background-color: lightgray; padding-left: 10px; padding-top: 10px; border: 1px solid black;">
        <table>
            <tr>
                <td>
                    <asp:Label for="TB_UserName" runat="server" Text="Nom d'usager"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="TB_UserName" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RFV_TB_UserName"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le nom d'usager est vide!"
                        ControlToValidate="TB_UserName"
                        ValidationGroup="VG_Login"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Username"
                        runat="server"
                        ErrorMessage="Ce nom d'usager n'existe pas!"
                        Display="None"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CV_TB_UserName_ServerValidate"> 
                    </asp:CustomValidator>
                    <asp:CustomValidator
                        ID="CustomValidator1"
                        runat="server"
                        ErrorMessage="Cet usager est déjà en ligne"
                        Display="None"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CustomValidator1_ServerValidate"> 
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label for="TB_Password" runat="server" Text="Mot de passe"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Password" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RFV_TB_Password"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le mot de passe est vide!"
                        ControlToValidate="TB_Password"
                        ValidationGroup="VG_Login"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Password"
                        runat="server"
                        ErrorMessage="Le mot de passe n'est pas valide."
                        Display="None"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CV_Password_ServerValidate"> 
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_Login" runat="server" Text="Soumettre..." class="submitBTN" ValidationGroup="VG_Login" OnClick="BTN_Login_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_Inscription" class="submitBTN" runat="server" Text="Inscription..." OnClick="BTN_Inscription_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_PasswordLost" class="submitBTN" runat="server" Text="Mot de passe oublié..." OnClick="BTN_PasswordLost_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left;">
                    <asp:ValidationSummary
                        ID="VGS_Logi"
                        runat="server"
                        ValidationGroup="VG_Login"
                        HeaderText="Résumé des erreurs: &lt;hr/&gt;" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
