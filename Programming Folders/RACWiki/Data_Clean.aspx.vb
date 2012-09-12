Imports Oracle.DataAccess.Client
Imports System.Data

Partial Class Data_Clean
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        OPEN_TEXT.Text = "<h2>Data Cleansing</h2>Data cleansing is the process of removing invalid values and standardizing the format of the data.  HighTouch currently does not have a control in place to restrict the entry of valid information. This process will be carried out within the MDM as part of the initial load.  The customer-columns will be cleansed and standardized.<br /><br />  " & _
                           "The type of cleansing and standardization can be found in the following table.  The Code Ref numbers 1 - 41 assigned to each action refers to the SQL that is in the file embedded in this document, which can be found at the end of this section."

        Update_Rules.Text = "New Rules effective: <b>February 14, 2011.</b>"
        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Dim Selection As Integer = 5

        'SQL Statement
        Dim sql As String = "SELECT Code_ID,COLUMN_NAME,ACTION, NEW_ACTION from ( select Code_ID,COLUMN_NAME,ACTION,NEW_ACTION, row_number() over (order by Column_id) r from MD_MDM_DATA_CLEANSING )where r between 0 and 41"
        Dim sql2 As String = "SELECT Code_ID,COLUMN_NAME,ACTION, NEW_ACTION from ( select Code_ID,COLUMN_NAME,ACTION,NEW_ACTION, row_number() over (order by Column_id) r from MD_MDM_DATA_CLEANSING )where r between 42 and 82"
        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim myCommand As New OracleDataAdapter(cmd)

        'Create Data Set
        Dim ds As New DataSet
        myCommand.Fill(ds)

        'Build Bound Columns
        Dim Code_ID As New BoundField
        Code_ID.HeaderText = "Rule ID"
        Code_ID.DataField = "Code_ID"
        GridView1.Columns.Add(Code_ID)
        GridView1.Columns(0).ItemStyle.Width = New Unit("55px")
        GridView1.Columns(0).ItemStyle.HorizontalAlign = HorizontalAlign.Center

        Dim Column_Name As New BoundField
        Column_Name.HeaderText = "Column Name"
        Column_Name.DataField = "Column_Name"
        GridView1.Columns.Add(Column_Name)
        GridView1.Columns(1).ItemStyle.Width = New Unit("75px")
        GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Center

        Dim ACTION As New BoundField
        ACTION.HeaderText = "ACTION"
        ACTION.DataField = "ACTION"
        GridView1.Columns.Add(ACTION)
        GridView1.Columns(2).ItemStyle.Width = New Unit("210px")
        GridView1.Columns(2).ItemStyle.HorizontalAlign = HorizontalAlign.Left

        Dim NEW_ACTION As New BoundField
        NEW_ACTION.HeaderText = "New Rule"
        NEW_ACTION.DataField = "NEW_ACTION"
        GridView1.Columns.Add(NEW_ACTION)
        GridView1.Columns(3).ItemStyle.Width = New Unit("210px")
        GridView1.Columns(3).ItemStyle.HorizontalAlign = HorizontalAlign.Left

        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = True


        cmd = New OracleCommand(sql2, conn)
        cmd.CommandType = CommandType.Text
        myCommand = New OracleDataAdapter(cmd)

        Dim ds2 As New DataSet
        myCommand.Fill(ds2)

        'Build Bound Columns

        Code_ID.HeaderText = "Rule ID"
        Code_ID.DataField = "Code_ID"
        GridView2.Columns.Add(Code_ID)
        GridView2.Columns(0).ItemStyle.Width = New Unit("55px")
        GridView2.Columns(0).ItemStyle.HorizontalAlign = HorizontalAlign.Center


        Column_Name.HeaderText = "Column Name"
        Column_Name.DataField = "Column_Name"
        GridView2.Columns.Add(Column_Name)
        GridView2.Columns(1).ItemStyle.Width = New Unit("75px")
        GridView2.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Center


        ACTION.HeaderText = "ACTION"
        ACTION.DataField = "ACTION"
        GridView2.Columns.Add(ACTION)
        GridView2.Columns(2).ItemStyle.Width = New Unit("210px")
        GridView2.Columns(2).ItemStyle.HorizontalAlign = HorizontalAlign.Left

        NEW_ACTION.HeaderText = "New Rule"
        NEW_ACTION.DataField = "NEW_ACTION"
        GridView2.Columns.Add(NEW_ACTION)
        GridView2.Columns(3).ItemStyle.Width = New Unit("210px")
        GridView2.Columns(3).ItemStyle.HorizontalAlign = HorizontalAlign.Left

        GridView2.DataSource = ds2
        GridView2.DataBind()
        GridView2.Visible = True

    End Sub
End Class

