<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Column_Maintence.aspx.vb" Inherits="Column_Maintence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.OracleClient"
                        
            ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;" 
            ConflictDetection="CompareAllValues" 
            DeleteCommand="DELETE FROM &quot;MD_DEFINED_DATA&quot; WHERE &quot;RECORD_ID&quot; = :original_RECORD_ID AND ((&quot;PRIMARY_KEY&quot; = :original_PRIMARY_KEY) OR (&quot;PRIMARY_KEY&quot; IS NULL AND :original_PRIMARY_KEY IS NULL)) AND ((&quot;COLUMN_NAME&quot; = :original_COLUMN_NAME) OR (&quot;COLUMN_NAME&quot; IS NULL AND :original_COLUMN_NAME IS NULL)) AND ((&quot;DATA_TYPE&quot; = :original_DATA_TYPE) OR (&quot;DATA_TYPE&quot; IS NULL AND :original_DATA_TYPE IS NULL)) AND ((&quot;DEFINED_DATA&quot; = :original_DEFINED_DATA) OR (&quot;DEFINED_DATA&quot; IS NULL AND :original_DEFINED_DATA IS NULL)) AND ((&quot;COLUMN_PURPOSE&quot; = :original_COLUMN_PURPOSE) OR (&quot;COLUMN_PURPOSE&quot; IS NULL AND :original_COLUMN_PURPOSE IS NULL)) AND ((&quot;ADDITIONAL_COMMENTS&quot; = :original_ADDITIONAL_COMMENTS) OR (&quot;ADDITIONAL_COMMENTS&quot; IS NULL AND :original_ADDITIONAL_COMMENTS IS NULL))" 
            InsertCommand="INSERT INTO &quot;MD_DEFINED_DATA&quot; (&quot;RECORD_ID&quot;, &quot;PRIMARY_KEY&quot;, &quot;COLUMN_NAME&quot;, &quot;DATA_TYPE&quot;, &quot;DEFINED_DATA&quot;, &quot;COLUMN_PURPOSE&quot;, &quot;ADDITIONAL_COMMENTS&quot;) VALUES (:RECORD_ID, :PRIMARY_KEY, :COLUMN_NAME, :DATA_TYPE, :DEFINED_DATA, :COLUMN_PURPOSE, :ADDITIONAL_COMMENTS)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT &quot;RECORD_ID&quot;, &quot;PRIMARY_KEY&quot;, &quot;COLUMN_NAME&quot;, &quot;DATA_TYPE&quot;, &quot;DEFINED_DATA&quot;, &quot;COLUMN_PURPOSE&quot;, &quot;ADDITIONAL_COMMENTS&quot; FROM &quot;MD_DEFINED_DATA&quot; WHERE (&quot;ENTITY_ID&quot; = :ENTITY_ID)" 
            UpdateCommand="UPDATE &quot;MD_DEFINED_DATA&quot; SET &quot;PRIMARY_KEY&quot; = :PRIMARY_KEY, &quot;COLUMN_NAME&quot; = :COLUMN_NAME, &quot;DATA_TYPE&quot; = :DATA_TYPE, &quot;DEFINED_DATA&quot; = :DEFINED_DATA, &quot;COLUMN_PURPOSE&quot; = :COLUMN_PURPOSE, &quot;ADDITIONAL_COMMENTS&quot; = :ADDITIONAL_COMMENTS WHERE &quot;RECORD_ID&quot; = :original_RECORD_ID AND ((&quot;PRIMARY_KEY&quot; = :original_PRIMARY_KEY) OR (&quot;PRIMARY_KEY&quot; IS NULL AND :original_PRIMARY_KEY IS NULL)) AND ((&quot;COLUMN_NAME&quot; = :original_COLUMN_NAME) OR (&quot;COLUMN_NAME&quot; IS NULL AND :original_COLUMN_NAME IS NULL)) AND ((&quot;DATA_TYPE&quot; = :original_DATA_TYPE) OR (&quot;DATA_TYPE&quot; IS NULL AND :original_DATA_TYPE IS NULL)) AND ((&quot;DEFINED_DATA&quot; = :original_DEFINED_DATA) OR (&quot;DEFINED_DATA&quot; IS NULL AND :original_DEFINED_DATA IS NULL)) AND ((&quot;COLUMN_PURPOSE&quot; = :original_COLUMN_PURPOSE) OR (&quot;COLUMN_PURPOSE&quot; IS NULL AND :original_COLUMN_PURPOSE IS NULL)) AND ((&quot;ADDITIONAL_COMMENTS&quot; = :original_ADDITIONAL_COMMENTS) OR (&quot;ADDITIONAL_COMMENTS&quot; IS NULL AND :original_ADDITIONAL_COMMENTS IS NULL))">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="326" Name="ENTITY_ID" 
                    QueryStringField="Entity_ID" Type="Decimal" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_RECORD_ID" Type="Decimal" />
                <asp:Parameter Name="original_PRIMARY_KEY" Type="String" />
                <asp:Parameter Name="original_COLUMN_NAME" Type="String" />
                <asp:Parameter Name="original_DATA_TYPE" Type="String" />
                <asp:Parameter Name="original_DEFINED_DATA" Type="String" />
                <asp:Parameter Name="original_COLUMN_PURPOSE" Type="String" />
                <asp:Parameter Name="original_ADDITIONAL_COMMENTS" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="PRIMARY_KEY" Type="String" />
                <asp:Parameter Name="COLUMN_NAME" Type="String" />
                <asp:Parameter Name="DATA_TYPE" Type="String" />
                <asp:Parameter Name="DEFINED_DATA" Type="String" />
                <asp:Parameter Name="COLUMN_PURPOSE" Type="String" />
                <asp:Parameter Name="ADDITIONAL_COMMENTS" Type="String" />
                <asp:Parameter Name="original_RECORD_ID" Type="Decimal" />
                <asp:Parameter Name="original_PRIMARY_KEY" Type="String" />
                <asp:Parameter Name="original_COLUMN_NAME" Type="String" />
                <asp:Parameter Name="original_DATA_TYPE" Type="String" />
                <asp:Parameter Name="original_DEFINED_DATA" Type="String" />
                <asp:Parameter Name="original_COLUMN_PURPOSE" Type="String" />
                <asp:Parameter Name="original_ADDITIONAL_COMMENTS" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="RECORD_ID" Type="Decimal" />
                <asp:Parameter Name="PRIMARY_KEY" Type="String" />
                <asp:Parameter Name="COLUMN_NAME" Type="String" />
                <asp:Parameter Name="DATA_TYPE" Type="String" />
                <asp:Parameter Name="DEFINED_DATA" Type="String" />
                <asp:Parameter Name="COLUMN_PURPOSE" Type="String" />
                <asp:Parameter Name="ADDITIONAL_COMMENTS" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RECORD_ID" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            PageSize="20">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="RECORD_ID" HeaderText="RECORD_ID" ReadOnly="True" 
                    SortExpression="RECORD_ID" Visible="False" />
                <asp:TemplateField HeaderText="PRIMARY KEY" SortExpression="PK">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="edit2" 
                            Text='<%# Bind("PRIMARY_KEY") %>' Width="50px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PRIMARY_KEY") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COLUMN NAME" SortExpression="COLUMN NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("COLUMN_NAME") %>' 
                            Width="150px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("COLUMN_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DATA TYPE" SortExpression="DATA TYPE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DATA_TYPE") %>' 
                            Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DATA_TYPE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEFINED DATA" SortExpression="DEFINED DATA">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Height="150px" 
                            Text='<%# Bind("DEFINED_DATA") %>' TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("DEFINED_DATA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PURPOSE" SortExpression="PURPOSE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Height="150px" 
                            Text='<%# Bind("COLUMN_PURPOSE") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("COLUMN_PURPOSE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ADDITIONAL COMMENTS" 
                    SortExpression="ADDITIONAL COMMENTS">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="edit2" Height="150px" 
                            Text='<%# Bind("ADDITIONAL_COMMENTS") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ADDITIONAL_COMMENTS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
