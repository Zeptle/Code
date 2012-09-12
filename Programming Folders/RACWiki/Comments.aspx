<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Comments.aspx.vb" Inherits="Comments" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RaciPedia - v1.0</title>
    <link href="StyleSheet/StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td background="http://racwiki/images/Border_Main.jpg" width="600">
                <table width="550" bgcolor="#FFFFFF" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr><td colspan="11" height="22px" valign="top"><img src="http://racwiki/images/Web_Design_13.gif" width="600" height="22" alt=""></td></tr>
                   <tr>
                        <td colspan="11" valign="top">
                            <%'Insert Data Here %><asp:Panel ID="Panel1" runat="server">
                           
                           <table border=0 cellpadding=0 align="center" width="550px" class="Comments2">
                           <tr>
                                <td valign="middle" align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Your Email:" /></td>
                                    <td>
                                    <asp:TextBox ID="TextBox1" CssClass="Comments3" runat="server" Width="300px" />
                                        <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"  
                                        ControlToValidate="TextBox1" CssClass="Error" Font-Size="Medium"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="server" 
                                        ErrorMessage="Invalid Email." ControlToValidate="TextBox1" CssClass="Error" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                           </tr>
                           <tr>
                                <td valign="middle" align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Subject:"/></td><td>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="Comments3" TextMode="SingleLine" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" 
                                        ControlToValidate="TextBox3" CssClass="Error" Font-Size="Medium"></asp:RequiredFieldValidator></td>
                           </tr>
                           <tr>
                                <td valign="top" align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Comment:"/></td><td>
                                    <cc1:Editor ID="Editor1" CssClass="Comments3" runat="server" Width="475px" Height="300px" 
                                        BorderColor="Silver" DesignPanelCssPath="Comments3" 
                                        DocumentCssPath="Comments3" BackColor="#DFDFDF" BorderStyle="Solid" 
                                        BorderWidth="1px" />
                                </td>
                           </tr>
                           <tr>
                                <td colspan=2 height="50px"  valign="middle" >
                                    <asp:Button ID="Button1" runat="server" Text="Submit" />
                                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                    </asp:ToolkitScriptManager>

                                </td>
                           </tr>
                           </table>  </asp:Panel>
                            <asp:Panel ID="Panel2" CssClass="Thanks" Visible="false" runat="server">
                            
                                    <asp:Image ID="Thank_You_PIC" runat="server" ImageUrl="http://racwiki/images/vision.png" /><br /><br />
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                            <%-- Data-bound content. --%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11">
                            <img src="http://racwiki/images/Web_Design_15.gif" width="600" height="26" alt="">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
