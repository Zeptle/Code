<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MetaData_Update.aspx.vb"
    Inherits="MetaData_Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Update_Button" runat="server" Text="Update" />
        <table border="1" cellpadding="0" cellspacing="10" width="600px">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Name_Label" runat="server" Text="Label" CssClass="edit"></asp:Label>
                </td>
                <td><asp:Label ID="Label17" runat="server" Text="*" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                    <asp:CheckBox ID="Completed_CheckBox" runat="server" CssClass="edit2" />
                    <asp:Label ID="Label2" runat="server"
                        Text="Completed" CssClass="edit"></asp:Label>
                   

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label" runat="server" Text="Schema:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Schema_DropDownList" runat="server" AutoPostBack="True" 
                        CssClass="edit">
                        <asp:ListItem Value="9997">-- Select Schema --</asp:ListItem>
                        <asp:ListItem Value="DWBOE">BUSOBJ</asp:ListItem>
                        <asp:ListItem Value="DWZEU">ORAEDW</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Table:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>                   
                            <asp:DropDownList ID="Table_DropDownList" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Entity_Name" DataValueField="Entity_ID" 
                        AppendDataBoundItems="False" AutoPostBack="True" EnableTheming="False" 
                        CssClass="edit" Enabled="True">
                                <asp:ListItem Value="9997">-- Select Table/Mart --</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.OracleClient"
                        ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
                </td>
            </tr>
        </table><asp:Label ID="Label15" runat="server" Text="*" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#FF3300"></asp:Label><asp:Label ID="Label16" runat="server" Text="*" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                        
        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">Column Descriptions</asp:HyperLink>             
      
        <table border="1" cellpadding="0" cellspacing="10" width="600px">
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="*" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                
                    <asp:Label ID="Label3" runat="server" Text="Keywords:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Keyword_TextBox" runat="server" Height="50px" TextMode="MultiLine"
                        Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label14" runat="server" Text="*" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Summary:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Summary_TextBox" runat="server" Height="70px" TextMode="MultiLine"
                        Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Additional Comments:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="AddComments_TextBox" runat="server" Height="70px" TextMode="MultiLine"
                        Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Exclusions:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Exclusions_TextBox" runat="server" Height="70px" TextMode="MultiLine"
                        Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Inclusions:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Inclusions_TextBox" runat="server" Height="70px" TextMode="MultiLine"
                        Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Origination Source:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Source_TextBox" runat="server" Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Production Source:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Production_TextBox" runat="server" Height="70px" 
                        TextMode="MultiLine" Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Refresh Trigger:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Refresh_TextBox" runat="server" Width="485px" CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Refresh Number:" Width="75px" 
                        CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="RefreshNum_TextBox" runat="server"  Width="485px" 
                        CssClass="edit"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Dept Assigned/Used:" 
                        Width="75px" CssClass="edit"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Deptartment_TextBox" runat="server"  Width="485px" 
                        CssClass="edit"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
