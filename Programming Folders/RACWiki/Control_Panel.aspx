<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" CodeFile="Control_Panel.aspx.vb" Inherits="TEST" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .test
        {
            color: White;
        }
        body
        {
            font-family: Arial;
            font-size: 12px;
        }
        a
        {
            color: Black;
            text-decoration: none;
            font: bold;
        }
        a:hover
        {
            color: #CCCCCC;
        }
        td.menu
        {
            background: #009999;
            font-size: larger;
            font-weight: bolder;
        }
        table.menu
        {
            font-size: 100%;
            position: absolute;
            visibility: hidden;
        }
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function showmenu(elmnt) {
            document.getElementById(elmnt).style.visibility = "visible";
        }
        function hidemenu(elmnt) {
            document.getElementById(elmnt).style.visibility = "hidden";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left">
    <br />Upload ERwin Data: <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="XML_File.aspx?id=DWBOE">ERWIN - DATA MART</asp:LinkButton> &nbsp &nbsp
        <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="XML_File.aspx?id=ZEUS">ERWIN - ZEUS</asp:LinkButton>
        <hr />
        <table width="50%">
            <tr class="test" bgcolor="#006666">
                <td onmouseover="showmenu('tutorials')" onmouseout="hidemenu('tutorials')">
                    Add New
                    <table class="menu" id="tutorials" width="120">
                        <tr>
                            <td class="menu">
                                <asp:LinkButton ID="LinkButton1" runat="server">Glossary</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="menu">
                                <asp:LinkButton ID="LinkButton3" runat="server">Data Warehouse</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td onmouseover="showmenu('scripting')" onmouseout="hidemenu('scripting')">
                    Edit/Update
                    <table class="menu" id="scripting" width="120">
                        <tr>
                            <td class="menu">
                                <asp:LinkButton ID="LinkButton4" runat="server">Glossary</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="menu">
                                <asp:LinkButton ID="LinkButton5" runat="server">Data Warehouse</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <hr />
        <br />
    </div>
    <asp:Panel ID="EDIT_Panel" runat="server" Visible="False">
        <table border="1" cellpadding="0" cellspacing="10" width="700px">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"
                        Text="*"></asp:Label>
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" CssClass="Dash">Attribute Descriptions</asp:HyperLink>
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"
                        Text="*"></asp:Label>
                </td>
                <td>
                    Publish:
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">ON</asp:ListItem>
                        <asp:ListItem Value="0">OFF</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:LinkButton ID="Data_Map_LinkButton" runat="server">Upload Map</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label" runat="server" CssClass="edit" Text="Schema:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Schema_DropDownList" runat="server" AutoPostBack="True" CssClass="edit">
                        <asp:ListItem Value="9997">-- Select Schema --</asp:ListItem>
                        <asp:ListItem Value="DWBOE">ORABO</asp:ListItem>
                        <asp:ListItem Value="DWZEU">ORAEDW</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="edit" Text="Table:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="TABLE_DropDownList" runat="server" AppendDataBoundItems="true"
                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ENTITY_NAME"
                        DataValueField="ENTITY_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"
                        ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <table border="1" cellpadding="0" cellspacing="10" width="700px">
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"
                        Text="*"></asp:Label>
                    <asp:Label ID="Label3" runat="server" CssClass="edit" Text="Keywords:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Keyword_TextBox" runat="server" CssClass="edit" Height="50px" TextMode="MultiLine"
                        Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"
                        Text="*"></asp:Label>
                    <asp:Label ID="Label4" runat="server" CssClass="edit" Text="Summary:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Summary_TextBox" runat="server" CssClass="edit" Height="70px" TextMode="MultiLine"
                        Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="edit" Text="ORIGINATION SOURCE:"
                        Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ORIGINATION_SOURCE_TextBox" runat="server" CssClass="edit" Height="70px"
                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="edit" Text="PRODUCTION SOURCE:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PRODUCTION_SOURCE_TextBox" runat="server" CssClass="edit" Height="70px"
                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="edit" Text="ETL PROCESS NAME:" Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ETL_PROCESS_NAME_TextBox" runat="server" CssClass="edit" Height="70px"
                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="edit" Text="Data MAP:"
                        Width="75px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Data_MAP_TextBox" runat="server" CssClass="edit" Width="100%"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
            <td></td>
            <td align="right">
                <asp:Label ID="Update_Label" runat="server" Text="Update completed." 
                    Visible="False"></asp:Label>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="Update_Button" runat="server" Text="Update" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    
    
    
    
    
    
    <asp:Panel ID="Glossary_EDIT_Panel" runat="server">
        <table border="1" cellpadding="0" cellspacing="10" width="700px">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Glossary Terms"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Glossary_DropDownList" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSource2" DataTextField="ENTITY_NAME" 
                        DataValueField="ENTITY_ID" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"
                        ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>Publish: 
                    <asp:RadioButtonList ID="Publish_RadioButtonList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">ON</asp:ListItem>
                        <asp:ListItem Value="0">OFF</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    Dictionary Type: 
                    <asp:DropDownList ID="DICT_TYPE_DropDownList" runat="server">
                        <asp:ListItem Selected="True">-- Select Type --</asp:ListItem>
                        <asp:ListItem Value="GENR">General</asp:ListItem>
                        <asp:ListItem Value="TECH">Technical</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Glossary Term:</td>
                    <td><asp:TextBox ID="Term_TextBox" Width="100%" runat="server"></asp:TextBox>
                </td>
           
            </tr>
            <tr>
                <td valign="top">
                Definition:
                </td>
                <td>
                
            <asp:TextBox ID="Definition_TB" runat="server" Height="100px" TextMode="MultiLine" 
                        Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>Keywords:</td>
            <td><asp:TextBox ID="Keywords_TB" runat="server" Height="100px" TextMode="MultiLine" 
                        Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
            <td></td>
            <td align="right">
            <asp:Label ID="Label9" runat="server" Text="Update completed." 
                    Visible="False"></asp:Label>
            <asp:Button ID="Add_Button1" Visible="false" runat="server" Text="Add Term" />
                <asp:Button ID="Update_Button0" runat="server" Text="Update" />
                </td>
            </tr>
        </table>
        
    </asp:Panel>
    </form>
</body>
</html>
