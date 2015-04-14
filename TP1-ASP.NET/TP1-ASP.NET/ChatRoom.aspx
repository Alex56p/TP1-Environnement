<%@ Page Title="Chat Room..." Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_ASP.NET.ChatRoom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <table>
            <tr>
               
                <asp:UpdatePanel ID="Panel_Chat" runat="server"> 
                    <ContentTemplate>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Envoyer" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TB_Text" runat="server"></asp:TextBox>
                    <asp:Button ID="BTN_Envoyer" runat="server" Text="Envoyer..." OnClick="BTN_Envoyer_Click" />
                </td>
            </tr>
        </table>
    </div>
    
                
</asp:Content>
