<%@ Page Title="Chat Room..." Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_ASP.NET.ChatRoom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" DefaultButton ="BTN_Envoyer">
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
                     <asp:UpdatePanel ID="UpdatePanel_Chat"  UpdateMode="Conditional" runat="server"> 
                        <ContentTemplate>
                            <%--<asp:Timer ID="TimerPanel" runat="server" OnTick="TimerPanel_Tick" Interval="1000"></asp:Timer>--%>
                            <asp:Panel ID="Panel_Chat" runat="server">
                                <asp:Table ID="Chat" runat="server"></asp:Table>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BTN_Envoyer" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Panel ID="Panel_Users" runat="server" ScrollBars="Auto">
                        <asp:table id="TableUsers" runat="server"></asp:table>
                    </asp:Panel>
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
    </asp:Panel>
                
</asp:Content>
