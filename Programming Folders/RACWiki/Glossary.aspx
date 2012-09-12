<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Glossary.aspx.vb" Inherits="Glossary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<SCRIPT TYPE="text/javascript">
<!--
function popup(mylink, windowname)
{
if (! window.focus)return true;
var href;
if (typeof(mylink) == 'string')
   href=mylink;
else
   href=mylink.href;
window.open(href, windowname, 'width=700,height=500,scrollbars=yes');
return false;
}
//-->
</SCRIPT>

<asp:Label  ID="Label1" CssClass="Glossary_URL" runat="server" Text=""></asp:Label>
&nbsp;&nbsp&nbsp&nbsp&nbsp

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
    <div class="Glossary">Select Glossary:
    <asp:DropDownList CssClass="dropdown_Marts" ID="DropDownList1" runat="server" AutoPostBack="True">
    <asp:ListItem Value="0" Enabled="true">-- View All Terms --</asp:ListItem>
    <asp:ListItem Value="1">General Terms</asp:ListItem>
    <asp:ListItem Value="2">Technical Terms</asp:ListItem>
    </asp:DropDownList></div>
    <asp:Label ID="Label2" Width="750px" runat="server" CssClass="Glossary"></asp:Label>
                            <br /><br />
                            <%-- Data-bound content. --%>
                            <asp:Label ID="Label3"  CssClass="Glossary_URL" runat="server" Text="" Visible="False"></asp:Label>
                        
</asp:Content>

