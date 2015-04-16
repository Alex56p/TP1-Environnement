<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Profil1.aspx.cs" Inherits="TP1_ASP.NET.Profil1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Inscription">
        <div id="Avatar">
            <asp:Image ID="IMG_Avatar" runat="server" CssClass="Avatar" ImageUrl="~/Images/Anonymous.png" />
            <asp:FileUpload ID="FU_Avatar" runat="server" CssClass="Avatar" onchange="loadFile(event)" ClientIDMode="Static" />
            <script>
                 var loadFile = function (event) {
                     var output = document.getElementById('<%= IMG_Avatar.ClientID %>');
                     output.src = URL.createObjectURL(event.target.files[0]);
                 };
            </script>
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
                    <asp:CustomValidator
                        ID="CustomValidator1"
                        Display="None"
                        runat="server"
                        CssClass="label"
                        ErrorMessage="Ce nom d'usager existe déjà!"
                        ValidationGroup="VG_Login"
                        ControlToValidate="TB_UserName"
                        OnServerValidate="CV_TB_UserName_ServerValidate"
                        ForeColor="Red"> 
                    </asp:CustomValidator>
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
                <td class="label">Confirmation du mot de passe 

                        
                </td>
                <td>
                    <asp:TextBox ID="TB_Password_Confirm" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RFV_Password_Confirm"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Password_Confirm"
                        ValidationGroup="VG_Login"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Password"
                        Display="None"
                        runat="server"
                        CssClass="label"
                        ErrorMessage="Les mots de passe doivent être identiques!"
                        ValidationGroup="VG_Login"
                        OnServerValidate="CV_Password_ServerValidate"
                        ForeColor="Red"> 
                    </asp:CustomValidator>

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
                <td class="label">Confirmation de l'adresse courriel </td>
                <td>
                    <asp:TextBox ID="TB_Email_Confirm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RFV_Email_Confirm"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Email_Confirm"
                        ValidationGroup="VG_Login"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Email"
                        runat="server"
                        Display="None"
                        CssClass="label"
                        ErrorMessage="Les adresses courriels doivent être identique!"
                        ValidationGroup="VG_Login"
                        ControlToValidate="TB_UserName"
                        OnServerValidate="CV_Email_ServerValidate"
                        ForeColor="Red"> 
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_Update" runat="server" OnClick="BTN_Update_Click" Text="Mettre à jour..." ValidationGroup="VG_Login" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_Annuler" runat="server" Text="Annuler..." OnClick="BTN_Annuler_Click" />
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
