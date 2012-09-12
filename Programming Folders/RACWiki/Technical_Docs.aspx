<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Technical_Docs.aspx.vb" Inherits="Technical_Docs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
    <tr> <td colspan="2"><asp:Label ID="Label1" runat="server"  CssClass="Warning" Text="Label">This Technical documents section provides information about 
    the data warehouse and MDM process to support the Field Support Centers teams who require this data.  Users who see information that requires updating 
    should please click on the <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="http://racwiki/images/Big_Question.png"  OnClientClick="window.open('http://racwiki/Comments.aspx', 'child', 'height=500,width=700,scrollbars=no'); return false" ImageAlign="Middle" Width="17" Height="17" />  to submit your comment to the admin.</asp:Label><br /><br /></td></tr>
    <tr><td align="center"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="DataWarehouse.aspx">Data Warehouse</asp:HyperLink> </td>
        <td align="center"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="MDM.aspx">Master Data Mgmt</asp:HyperLink> </td>
    </tr>
    </table>
    <br />
<br /><br /><br /><br />
<div class="IMPT_MSG2">
    <asp:HyperLink ID="HyperLink3" Target="_blank" runat="server" NavigateUrl="~/CP_Login.aspx">Admin Login</asp:HyperLink>
    </div>
</asp:Content>

