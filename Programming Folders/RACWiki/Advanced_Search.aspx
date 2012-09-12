<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Advanced_Search.aspx.vb" Inherits="Advanced_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Welcome_MSG">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label">Find Attributes with...</asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
            AutoPostBack="True">
            <asp:ListItem Value="0" Selected="True">all of these words</asp:ListItem>
            <asp:ListItem Value="1">exact word or phrase</asp:ListItem>
            <asp:ListItem Value="2">any of these words</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="Search_TextBox" class="text_search" runat="server" Width="417px"
            AutoCompleteType="Search"></asp:TextBox>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="Search_textBox"
            ServiceMethod="GetCompletionList" UseContextKey="True" MinimumPrefixLength="1"
            CompletionSetCount="15" CompletionInterval="0" EnableViewState="True">
        </asp:AutoCompleteExtender>
        &nbsp&nbsp
        <asp:Button ID="Button1" runat="server" Text="Search" />&nbsp View:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True" Value="16">Top 15</asp:ListItem>
            <asp:ListItem Value="26">Top 25</asp:ListItem>
            <asp:ListItem Value="51">Top 50</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Error_Label" runat="server" CssClass="Error" Visible="False"></asp:Label><br />
        Data Source:
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Selected="True">Data Marts (BOE_STAGE)</asp:ListItem>
            <asp:ListItem Value="3">MDM</asp:ListItem>
            <asp:ListItem Value="5">Production Tables (Zeus)</asp:ListItem>
             <asp:ListItem Value="7">Glossary ONLY</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        
        <br />
        <asp:Label ID="Label2" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    
    
  
        
   <!-- Provide Search Results -->
    <asp:ListView runat="server" ID="ListView3" DataSourceID="SqlDataSource3" DataKeyNames="Entity_ID">
        <LayoutTemplate>
            <table id="Table1" border="0" width="500px" cellpadding="0" cellspacing="0" align="center"
                runat="server">
                <tr id="Tr2" runat="server">
                    <td colspan="3" valign="bottom" class="Results_01" align="center">
                        <asp:Label ID="Label4" runat="server" Text="Search Results" CssClass="header"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="itemPlaceholder">
                </tr>
                <tr id="Tr5" runat="server">
                    <td colspan="3" align="left">
                        <asp:Image ID="Image2" runat="server" Width="500px" ImageUrl="http://racwiki/images/Results/Results_Frame_05.gif" />
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink ID="HyperLink1" Width="400px" class="Search_display" Text='<%#Eval("Entity_Name") %>'
                        NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID"))+ "#" + cstr(Eval("Entity_ID")) %>'
                        runat="server"></asp:HyperLink>
                    <br />
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" width="500px" runat="server" class="Summary_display">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Attribute Name: <b><asp:Label ID="Label1" CssClass="Glossary" runat="server" Text='<%#Eval("COLUMN_NAME") %>' /></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server" class="Search_display2">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink Width="400px" ID="HyperLink1" Text='<%#Eval("Entity_Name") %>' NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID"))%>'
                        runat="server"></asp:HyperLink>
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" runat="server" class="Summary_display2">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                Attribute Name: <b><asp:Label ID="Label1" CssClass="Glossary" runat="server" Text='<%#Eval("COLUMN_NAME") %>' /></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID"))+ "#" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_ContentPlaceHolder" runat="Server">
</asp:Content>
