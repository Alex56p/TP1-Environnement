<%@ Page Title="Chat Room..." Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_ASP.NET.ChatRoom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <table style="width: 849px">
            <tr>
                <td style="width: 176px">Liste des discussions</td>
                <td style="width: 327px"><asp:Label ID ="Titre" runat="server">... </asp:Label>
                    <asp:Label runat="server">Créateur: </asp:Label>
                    <asp:Label ID="Createur" runat="server">*créateur</asp:Label> 
                    <asp:Label ID="Date" runat="server">*date</asp:Label>
                </td>
                <td>Invités</td>
            </tr>
            <tr>
               <td>

                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                       <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                   </asp:Panel>

               </td>
                <td style="width: 327px">
                    <%-- <asp:UpdatePanel ID="Panel_Chat"  UpdateMode="Conditional" runat="server"> 
                        <ContentTemplate>--%>
                            <asp:Table ID="Chat" runat="server"></asp:Table>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BTN_Envoyer" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </td>
               
            </tr>
            <tr>
                <td></td>
                <td style="width: 327px">
                    <asp:TextBox ID="TB_Text" runat="server"></asp:TextBox>
                </td>
                <td>
                 <asp:Button ID="BTN_Envoyer" runat="server" Text="Envoyer..." OnClick="BTN_Envoyer_Click" />

                </td>
            </tr>
        </table>
    </div>
    
                
</asp:Content>
