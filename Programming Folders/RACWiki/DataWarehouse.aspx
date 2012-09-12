<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="DataWarehouse.aspx.vb" Inherits="DataWarehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <% 'Insert Search Box Here %>
                                                         <!-- Dept Dropdown -->
                            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" CssClass="dropdown_Marts"
                                DataSourceID="SqlDataSource1" DataTextField="Type" 
                                DataValueField="Column_ID" AutoPostBack="True" >
                                
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
                            <!-- SubType Dropdown -->
                            <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="false" 
                                CssClass="dropdown_Marts" DataSourceID="SqlDataSource2" DataTextField="Type" 
                                DataValueField="Type_ID" AutoPostBack="True">
                                
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource> 
                            <!-- Table Dropdown -->
                            
                            <asp:DropDownList ID="Table_DropdownList" runat="server" DataSourceID="SqlDataSource3"
                                DataTextField="ENTITY_NAME" DataValueField="ENTITY_ID" AutoPostBack="True" 
                                AppendDataBoundItems="False" CssClass="dropdown_Marts">
                                <asp:ListItem Selected="True">--- Select Table/Mart ---</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
                            &nbsp&nbsp&nbsp&nbsp

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <asp:HyperLink ID="HyperLink6" runat="server" Target="_blank" NavigateUrl="http://racwiki/documents/BI_Data_Warehouse.pdf"
                                            BorderStyle="None">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="http://racwiki/images/Warehouse_Diagram_550.jpg"
                                                BorderStyle="None" /></asp:HyperLink>
</asp:Content>

