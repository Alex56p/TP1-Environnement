<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Inscription1.aspx.cs" Inherits="TP1_ASP.NET.Inscription1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                        ID="RFV_TB_Nom"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Nom"
                        ValidationGroup="VG_Create"> 
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="label">Nom d'usager </td>
                <td>
                    <asp:TextBox ID="TB_Username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RFV_TB_Username"
                        runat="server"
                        Text="Vide!"
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Username"
                        ValidationGroup="VG_Create"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CustomValidator1"
                        Display="None"
                        runat="server"
                        CssClass="label"
                        ErrorMessage="Ce nom d'usager existe déjà!"
                        ValidationGroup="VG_Create"
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
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Password"
                        ValidationGroup="VG_Create"> 
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
                        ValidationGroup="VG_Create"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Password"
                        Display="None"
                        runat="server"
                        CssClass="label"
                        ErrorMessage="Les mots de passe doivent être identiques!"
                        ValidationGroup="VG_Create"
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
                        ErrorMessage="Le champ est vide!"
                        ControlToValidate="TB_Email"
                        ValidationGroup="VG_Create"> 
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
                        ValidationGroup="VG_Create"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator
                        ID="CV_Email"
                        runat="server"
                        Display="None"
                        CssClass="label"
                        ErrorMessage="Les adresses courriels doivent être identique!"
                        ValidationGroup="VG_Create"
                        ControlToValidate="TB_UserName"
                        OnServerValidate="CV_Email_ServerValidate"
                        ForeColor="Red"> 
                    </asp:CustomValidator>
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
                                            ValidationGroup="VG_Create"
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
                        Text="!"
                        OnServerValidate="CV_Captcha_ServerValidate"
                        ControlToValidate="TB_Captcha"
                        ValidateEmptyText="True"
                        ValidationGroup="VG_Create"
                        ForeColor="Red">
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BTN_Inscrire" runat="server" ValidationGroup="VG_Create" OnClick="BTN_Inscrire_Click" Text="S'inscrire..." />
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
                        ValidationGroup="VG_Create"
                        HeaderText="Résumé des erreurs: &lt;hr/&gt;" />
                </td>
            </tr>

        </table>
    </div>
</asp:Content>
