Imports Oracle.DataAccess.Client
Imports System.Data
Partial Class Data_Mart_Details
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Selection As String

        If Not Page.IsPostBack Then

            Selection = Request.QueryString("id")
            'Label1.Text = Selection

            If Selection = "" Then
                Selection = 0
            End If

            Table_DropdownList.SelectedValue = Selection

            Dim sql_DL1 As String = "Select Type, Column_ID, Type_ID From Category_Dropdowns where Dept_ID = 0 and Type_ID = 0 or Type_ID = 9999 Order by Type"
            SqlDataSource2.SelectCommand = sql_DL1
            SqlDataSource2.DataBind()

            Dim sql_DL2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Type_ID = 9998 Order by Type"
            SqlDataSource3.SelectCommand = sql_DL2
            SqlDataSource3.DataBind()

            'Pass variable to function
            Dropdown_Select(Selection)
        Else
            Selection = Table_DropdownList.SelectedValue
            Data_Map_LinkButton.Visible = False
            Data_Map_IMG.Visible = False

            Dim sql_DL1 As String = "Select Type, Column_ID, Type_ID From Category_Dropdowns where Dept_ID = 0 and Type_ID = 0 or Type_ID = 9999 Order by Type "
            SqlDataSource2.SelectCommand = sql_DL1
            SqlDataSource2.DataBind()

            Dim sql_DL2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Type_ID = 9998 Order by Type"
            SqlDataSource3.SelectCommand = sql_DL2
            SqlDataSource3.DataBind()

        End If

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'SQL Statement - View Summary and main parats
        Dim sql As String = "SELECT Entity_Name, Description, ORIGINATION_SOURCE, PRODUCTION_SOURCE, PRODUCTION_SOURCE_KEY, ETL_PROCESS_NAME, " & _
                            "UPDATE_DATE FROM DATAWAREHOUSE_01 WHERE ENTITY_ID =" & Selection

        Dim sql2 As String = "SELECT PRIMARY_KEY, COLUMN_NAME, DATA_TYPE, COLUMN_PURPOSE " & _
                             "FROM DATAWAREHOUSE_ATTRIBUTES_01  WHERE ENTITY_ID = " & Selection & " Order by Primary_Key DESC, Column_Name"

        'Hit Counter
        'Dim sql3 As String = "SELECT SEARCH_RESULTS.Hit_Count FROM SEARCH_RESULTS SEARCH_RESULTS WHERE (SEARCH_RESULTS.ENTITY_ID ='" & Selection & "')"

        Dim sql4 As String = "SELECT DATA_MAP FROM DATAWAREHOUSE_01 WHERE ENTITY_ID =" & Selection

        Dim cmd As New OracleCommand(sql, conn)
        Dim cmd2 As New OracleCommand(sql2, conn)
        ' Dim cmd3 As New OracleCommand(sql3, conn)
        Dim cmd4 As New OracleCommand(sql4, conn)

        cmd.CommandType = CommandType.Text
        cmd2.CommandType = CommandType.Text
        ' cmd3.CommandType = CommandType.Text
        cmd4.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader
        Dim myCommand As New OracleDataAdapter(cmd2)
        'Dim dr3 As OracleDataReader = cmd3.ExecuteReader
        Dim dr4 As OracleDataReader = cmd4.ExecuteReader

        'Get last count from DB counter
        'Dim last_hit As String

        'Data Reader information
        ' While dr3.Read()
        'If Not dr3.GetValue(0) Is DBNull.Value Then _
        'last_hit = dr3.GetValue(0)
        'End While

        'dr3.Close()

        While dr4.Read()

            ' Dim drread As String = dr4(0).ToString()

            If Not dr4.GetValue(0) Is DBNull.Value Then
                If InStr(dr4.GetValue(0), ",") Then
                    Data_Map_LinkButton.Visible = True
                    Data_Map_IMG.Visible = True
                    Data_Map_LinkButton.OnClientClick = "window.open('Data_Map.aspx?id=http://racwiki/documents/Erwin/id=" & Selection & "&EID=" & Selection & "','child','height=400,width=300, scrollbars=0,resizable=0')"
                    Data_Map_IMG.OnClientClick = "window.open('Data_Map.aspx?id=http://racwiki/documents/Erwin/id=" & Selection & "&EID=" & Selection & "','child',height=400,width=300, scrollbars=0, resizable=0')"
                Else
                    Data_Map_LinkButton.Visible = True
                    Data_Map_IMG.Visible = True
                    Data_Map_LinkButton.OnClientClick = "window.open('http://racwiki/documents/Erwin/" & dr4.GetValue(0) & "')"
                    Data_Map_IMG.OnClientClick = "window.open('" & dr4.GetValue(0) & "')"
                End If
            ElseIf Selection = 0 Then
                Data_Map_LinkButton.Visible = False
                Data_Map_IMG.Visible = False
            Else
                Data_Map_LinkButton.Visible = False
                Data_Map_IMG.Visible = False
            End If
        End While

        dr4.Close()

        'Display Results


        DetailsView1.DataSource = dr
        DetailsView1.DataBind()
        DetailsView1.Visible = True

        '*******************************
        ' Create gridview - Begin
        '*******************************

        'Create Data Set
        Dim ds As New DataSet
        myCommand.Fill(ds)

        'Build Bound Columns
        Dim Primary_KEY As New BoundField
        Primary_KEY.HeaderText = "Primary Key"
        Primary_KEY.DataField = "Primary_Key"
        GridView1.Columns.Add(Primary_KEY)
        GridView1.Columns(0).ItemStyle.Width = New Unit("15px")
        GridView1.Columns(0).ItemStyle.HorizontalAlign = HorizontalAlign.Center

        Dim Column_Name As New BoundField
        Column_Name.HeaderText = "Column Name"
        Column_Name.DataField = "Column_Name"
        GridView1.Columns.Add(Column_Name)
        GridView1.Columns(1).ItemStyle.Width = New Unit("100px")
        GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Center

        Dim Data_type As New BoundField
        Data_type.HeaderText = "Data Type"
        Data_type.DataField = "Data_type"
        GridView1.Columns.Add(Data_type)
        GridView1.Columns(2).ItemStyle.Width = New Unit("150px")
        GridView1.Columns(2).ItemStyle.HorizontalAlign = HorizontalAlign.Center

        Dim Column_Purpose As New BoundField
        Column_Purpose.HeaderText = "Column Purpose"
        Column_Purpose.DataField = "Column_Purpose"
        GridView1.Columns.Add(Column_Purpose)
        GridView1.Columns(3).ItemStyle.Width = New Unit("210px")

        GridView1.DataSource = ds
        GridView1.DataBind()
        GridView1.Visible = False

        If Selection = 0 Then
            LinkButton1.Visible = False
            LinkButton2.Visible = False
        Else
            LinkButton1.Visible = True
            LinkButton2.Visible = False
        End If

        '*******************************
        ' Create gridview - End
        '*******************************

        '********************************************************
        'Close Oracle connection
        'Oracle won't allow more than one transaction
        '********************************************************
        conn.Close()

        '*********************************************************
        ' Hits Counter increment
        '*********************************************************
        'last_hit = last_hit + 1
        'conn.Open()

        'Dim sql5 As String = "UPDATE SEARCH_RESULTS " & _
        '                     "SET Hit_Count =" & last_hit & ", Date_Hit =SYSDATE " & _
        '                     "WHERE SEARCH_RESULTS.ENTITY_ID =" & Selection
        'Response.Write(sql4)
        'Dim cmd5 As New OracleCommand(sql5, conn)
        'cmd5.ExecuteNonQuery()

        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        GridView1.Visible = True
        LinkButton1.Visible = False
        LinkButton2.Visible = True
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        GridView1.Visible = False
        LinkButton1.Visible = True
        LinkButton2.Visible = False
    End Sub

    Sub Dropdown_Select(ByVal Selection As String)
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Dim sql As String = "Select Type_ID, Dept_ID FROM CATEGORY_DROPDOWNS Where Type_id = (Select Type from DATAWAREHOUSE_01 Where Entity_ID = " & Selection & ")"
        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader


        While dr.Read()
            'Response.Write(dr("Type_ID") & " - " & dr("Dept_ID"))

            DropDownList2.SelectedValue = dr("Dept_ID")

            Dim sql_DL2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Dept_ID =" & dr("Dept_ID") & "  or Type_ID = 9998 OR Type_ID = 901 Order by Type"
            SqlDataSource3.SelectCommand = sql_DL2
            SqlDataSource3.DataBind()

            Dim sql_DL3 As String = "SELECT TO_CHAR(Type_ID) as ENTITY_ID, TO_CHAR(Type) as ENTITY_NAME FROM Category_Dropdowns Where Type_ID = 9997 " & _
                             "Union SELECT TO_CHAR(ENTITY_ID), TO_CHAR(UPPER(ENTITY_NAME)) as ENTITY_NAME FROM DATAWAREHOUSE_01 WHERE (Type =" & dr("Type_ID") & " and Publish = 1 ) Order by Entity_NAME, ENTITY_ID"


            '"SELECT ENTITY_ID, ENTITY_NAME FROM MD_MAIN MD_MAIN WHERE (Type =" & dr("Type_ID") & ") Order by Entity_NAME, ENTITY_ID"
            SqlDataSource1.SelectCommand = sql_DL3
            SqlDataSource1.DataBind()

            DropDownList3.SelectedValue = dr("Type_ID")
            Table_DropdownList.SelectedValue = Selection
        End While
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        Dim sql2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE DEPT_ID =" & DropDownList2.SelectedValue & " or Type_ID = 9998 OR ((Type_ID = 901 or Type_ID = 902) and DEPT_ID =" & DropDownList2.SelectedValue & ") Order by Type"

        SqlDataSource3.SelectCommand = sql2
        SqlDataSource3.DataBind()

        ' Dim sql3 As String = "SELECT TO_CHAR(Dept_ID) as ENTITY_ID, TO_CHAR(Type) as ENTITY_NAME FROM Category_Dropdowns Where Dept_ID = 9997 " & _
        '     "Union SELECT TO_CHAR(ENTITY_ID), TO_CHAR(UPPER(ENTITY_NAME)) as ENTITY_NAME FROM MD_MAIN WHERE (Type =0 and Publish = 1 ) Order by Entity_NAME, ENTITY_ID"

        'SqlDataSource1.SelectCommand = sql3
        'SqlDataSource1.DataBind()
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        Dim sql3 As String = "SELECT TO_CHAR(Dept_ID) as ENTITY_ID, TO_CHAR(Type) as ENTITY_NAME FROM Category_Dropdowns Where Type_ID = 9997 " & _
                     "Union SELECT TO_CHAR(ENTITY_ID), TO_CHAR(UPPER(ENTITY_NAME)) as ENTITY_NAME FROM DATAWAREHOUSE_01 WHERE (Type =" & DropDownList3.SelectedValue & " and Publish = 1 ) Order by Entity_NAME, ENTITY_ID"

        SqlDataSource1.SelectCommand = sql3
        SqlDataSource1.DataBind()
    End Sub
End Class