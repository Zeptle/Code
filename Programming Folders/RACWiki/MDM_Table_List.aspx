<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MDM_Table_List.aspx.vb" Inherits="MDM_Table_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <br />
                             <!-- Dept Dropdown -->
                            <asp:DropDownList ID="Dept_DropDownList" runat="server" AppendDataBoundItems="True" CssClass="dropdown_Marts"
                                DataSourceID="Dept_SqlDataSource" DataTextField="Type" 
                                DataValueField="Column_ID" AutoPostBack="True" >
                                
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="Dept_SqlDataSource" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
                            
                            <!-- SubType Dropdown -->
                            <asp:DropDownList ID="Type_DropDownList" runat="server" AppendDataBoundItems="false" 
                                CssClass="dropdown_Marts" DataSourceID="Type_SqlDataSource" DataTextField="Type" 
                                DataValueField="Type_ID" AutoPostBack="True">
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="Type_SqlDataSource" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource> 
                            
                            
                             <!-- Table Dropdown -->
                            <asp:DropDownList ID="Table_DropdownList" runat="server" DataSourceID="Table_SqlDataSource"
                              CssClass="dropdown_Marts"  DataTextField="ENTITY_NAME" DataValueField="ENTITY_ID" AutoPostBack="True" AppendDataBoundItems="False">
                                <asp:ListItem Text="--- Select Table/Mart ---" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:SqlDataSource ID="Table_SqlDataSource" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;" 
                                SelectCommand=""></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr class="Header_View">
            <td>
                <h3>
                    Customer</h3>
            </td>
            <td>
                <h3>
                    Location</h3>
            </td>
            <td>
                <h3>
                    Product</h3>
            </td>
        </tr>
        <tr class="Table_View">
            <td>
                <asp:Label ID="Customer_Label" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="Location_Label" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="Product_Label" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="Header_View">
                <hr />
                <br />
                <h3>
                    Views</h3>
            </td>
        </tr>
        <tr>
            <td class="Table_View" colspan="3">
                <div class="twocolumn">
                    <asp:Label ID="View_Label" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
