<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Data_Map.aspx.vb" Inherits="Data_Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
            <td background="http://racwiki/images/Border_Main.jpg" width="300">
                <table width="300" bgcolor="#FFFFFF" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="11" height="22px" valign="top">
                            <img src="http://racwiki/images/Web_Design_13.gif" width="300" height="22" alt="">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11" valign="top">
                            <%'Insert Data Here %>
                           
                            <p class="Thanks">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <br /><br />
                            </p>
                            <%-- END-bound content. --%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11">
                            <img src="http://racwiki/images/Web_Design_15.gif" width="300" height="26" alt="">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>