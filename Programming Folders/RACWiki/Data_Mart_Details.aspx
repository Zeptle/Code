<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Data_Mart_Details.aspx.vb" Inherits="Data_Mart_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<br />
                             <!-- Dept Dr
                             opdown -->
                            <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" CssClass="dropdown_Marts"
                                DataSourceID="SqlDataSource2" DataTextField="Type" 
                                DataValueField="Column_ID" AutoPostBack="True" >
                                
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
                            
                            <!-- SubType Dropdown -->
                            <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="false" 
                                CssClass="dropdown_Marts" DataSourceID="SqlDataSource3" DataTextField="Type" 
                                DataValueField="Type_ID" AutoPostBack="True">
                                
                            </asp:DropDownList>
                            
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource> 
                            
                            
                             <!-- Table Dropdown -->
                            <asp:DropDownList ID="Table_DropdownList" runat="server" DataSourceID="SqlDataSource1"
                              CssClass="dropdown_Marts"  DataTextField="ENTITY_NAME" DataValueField="ENTITY_ID" AutoPostBack="True" AppendDataBoundItems="False">
                                <asp:ListItem Text="--- Select Table/Mart ---" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp&nbsp&nbsp&nbsp
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.OracleClient"
                                ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;" 
                                SelectCommand=""></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align=center>
  <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="800px" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px" CellPadding="3" GridLines="Vertical"
                                CssClass="DM_gridvew" ForeColor="Black" 
        EmptyDataText="Sorry, no results.  Please choose from the dropdown menu above." FieldHeaderStyle-Wrap="True"
                                FieldHeaderStyle-CssClass="FieldHeaderStyle" 
        FieldHeaderStyle-Width="140px" AutoGenerateRows="False">
                                <FooterStyle BackColor="#CCCCCC" />

<FieldHeaderStyle Wrap="True" CssClass="FieldHeaderStyle" Width="140px"></FieldHeaderStyle>

                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <Fields>
                                    <asp:BoundField DataField="ENTITY_NAME" HeaderText="Table/Mart:" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                    <asp:BoundField DataField="ORIGINATION_SOURCE" 
                                        HeaderText="Origination Source" />
                                    <asp:BoundField DataField="PRODUCTION_SOURCE" HeaderText="Production Source" />
                                    <asp:BoundField DataField="ETL_PROCESS_NAME" HeaderText="ETL Process" />
                                    <asp:BoundField DataField="UPDATE_DATE" HeaderText="Uppdate Date" />
                                </Fields>
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                            </asp:DetailsView>
                                     
                            <asp:GridView ID="GridView1" CssClass="DM_gridvew" runat="server" CellPadding="4"
                                ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" EnableViewState="false"
                                Width="800px">
                                <RowStyle BackColor="#EFF3FB" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#0F8491" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                            </div><br />
                            &nbsp&nbsp&nbsp&nbsp<asp:ImageButton ID="Data_Map_IMG" runat="server" ImageUrl="~/images/SM_DATA_MAP.JPG" Visible="False" ImageAlign="Top" />
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkButton1">Click Here - More Details</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="LinkButton1">Click Here - Less Details</asp:LinkButton>

                            <asp:LinkButton ID="Data_Map_LinkButton" CssClass="LinkButton2" runat="server" Visible="False">View Data Map</asp:LinkButton>

<br /><br />
</asp:Content>

