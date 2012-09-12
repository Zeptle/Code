Imports Oracle.DataAccess.Client
Imports System.Data

Partial Class TEST
    Inherits System.Web.UI.Page

    Protected Sub Schema_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schema_DropDownList.SelectedIndexChanged

        Dim sql As String = "SELECT Entity_Name, ENTITY_ID FROM DATAWAREHOUSE_01 WHERE DEPT_ID = '" & Schema_DropDownList.SelectedValue & "' " & _
                            "Union SELECT Type, Type_ID FROM CATEGORY_DROPDOWNS Where Column_ID = 63"

        SqlDataSource1.SelectCommand = sql
        SqlDataSource1.DataBind()
    End Sub

    Protected Sub TABLE_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TABLE_DropDownList.SelectedIndexChanged

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        Dim Publish As Integer
        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Response.Write(Table_DropDownList.SelectedValue)
        Dim sql As String = "SELECT KEYWORDS, DESCRIPTION,  ORIGINATION_SOURCE, PRODUCTION_SOURCE, ETL_PROCESS_NAME, Data_MAP, PUBLISH FROM DATAWAREHOUSE_01 WHERE(ENTITY_ID = " & TABLE_DropDownList.SelectedValue & ")"

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader

        While dr.Read()
            Keyword_TextBox.Text = FixNull(dr(0))
            Summary_TextBox.Text = FixNull(dr(1))
            ORIGINATION_SOURCE_TextBox.Text = FixNull(dr(2))
            PRODUCTION_SOURCE_TextBox.Text = FixNull(dr(3))
            ETL_PROCESS_NAME_TextBox.Text = FixNull(dr(4))
            Data_MAP_TextBox.Text = FixNull(dr(5))
            Publish = dr(6)

        End While

        If Publish = 1 Then
            RadioButtonList1.SelectedIndex = 0
        Else
            RadioButtonList1.SelectedIndex = 1
        End If

        HyperLink1.NavigateUrl = "Column_Maintence.aspx?Entity_ID=" & TABLE_DropDownList.SelectedValue
        HyperLink1.ForeColor = Drawing.Color.Blue

        '*********************************************************
        ' Close Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()


        Data_Map_LinkButton.OnClientClick = "window.open('File_Upload.aspx?id=" & TABLE_DropDownList.SelectedValue & "','child','height=400,width=300, scrollbars=0,resizable=0')"
        Data_Map_LinkButton.ForeColor = Drawing.Color.Blue
        EDIT_Panel.Visible = True

    End Sub

    Public Function FixNull(ByVal dbvalue) As String
        If dbvalue Is DBNull.Value Then
            Return ""
        Else
            'NOTE: This will cast value to string if
            'it isn't a string.

            Return dbvalue.ToString
        End If
    End Function

    Protected Sub Update_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update_Button.Click

        Dim Keywords As String = FixApost(Keyword_TextBox.Text)
        Dim Summary As String = FixApost(Summary_TextBox.Text)
        Dim ORIGINATION_SOURCE As String = FixApost(ORIGINATION_SOURCE_TextBox.Text)
        Dim PRODUCTION_SOURCE As String = FixApost(PRODUCTION_SOURCE_TextBox.Text)
        Dim ETL_PROCESS_NAME As String = FixApost(ETL_PROCESS_NAME_TextBox.Text)
        Dim Data_MAP As String = FixApost(Data_MAP_TextBox.Text)

        'Oracle DB connection
        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()


        'Declared Variables

        Dim sql As String
        Dim Publish As Integer = RadioButtonList1.SelectedValue

        sql = "Update DATAWAREHOUSE_01 " & _
              "Set Keywords='" & Keywords & "', DESCRIPTION='" & Summary & "', Publish=" & Publish & ",Completed=1,Update_Date=SYSDATE, ORIGINATION_SOURCE='" & ORIGINATION_SOURCE & _
              "',PRODUCTION_SOURCE = '" & PRODUCTION_SOURCE & "',ETL_PROCESS_NAME='" & ETL_PROCESS_NAME & "',Data_MAP='" & Data_MAP & "'  WHERE ENTITY_ID=" & TABLE_DropDownList.SelectedValue

     
        'Response.Write(sql2)
        Dim cmd As New OracleCommand(sql, conn)
        cmd.ExecuteNonQuery()


        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()
        Update_Label.Visible = True
        'Response.Write("Update successful.")

    End Sub
    Public Function FixApost(ByVal Strvalue) As String

        If InStr(Strvalue, "'") > 0 Then
            Strvalue = Replace(Strvalue, "'", "`")
            Return Strvalue.ToString
        Else
            Return Strvalue.ToString
        End If

    End Function
    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click

        Glossary_EDIT_Panel.Visible = False
        EDIT_Panel.Visible = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not Page.IsPostBack Then
            EDIT_Panel.Visible = False
            Glossary_EDIT_Panel.Visible = False
        End If

    End Sub
    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click

        Add_Button1.Visible = False
        Update_Button0.Visible = True
        Glossary_DropDownList.Visible = True

        EDIT_Panel.Visible = False
        Glossary_EDIT_Panel.Visible = True
        Glossary_DropDownList.Items.Clear()
        Dim SQL2 As String = "SELECT ENTITY_ID, ENTITY_NAME FROM GLOSSARY " & _
                             "ORDER BY ENTITY_NAME"
        Glossary_DropDownList.Items.Add(New ListItem("-- Select Term --", 0))

        SqlDataSource2.SelectCommand = SQL2
        SqlDataSource2.DataBind()

    End Sub

    Protected Sub Glossary_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Glossary_DropDownList.SelectedIndexChanged

        'Declared variables
        Dim Publish As Integer
        Dim DICT_TYPE As String

        'If Glossary_DropDownList.SelectedValue = 

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Response.Write(Table_DropDownList.SelectedValue)
        Dim sql As String = "SELECT ENTITY_NAME, KEYWORDS, SUMMARY, PUBLISH, DICT_TYPE FROM GLOSSARY WHERE ENTITY_ID = " & Glossary_DropDownList.SelectedValue

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader

        While dr.Read()
            Term_TextBox.Text = FixNull(dr(0))
            Keywords_TB.Text = FixNull(dr(1))
            Definition_TB.Text = FixNull(dr(2))
            Publish = dr(3)
            DICT_TYPE = dr(4)
        End While

        If Publish = 1 Then
            Publish_RadioButtonList.SelectedIndex = 0
        Else
            Publish_RadioButtonList.SelectedIndex = 1
        End If

        If UCase(DICT_TYPE) = "GENR" Then
            DICT_TYPE_DropDownList.SelectedValue = "GENR"
        Else
            DICT_TYPE_DropDownList.SelectedValue = "TECH"
        End If

        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()

    End Sub

    Protected Sub Update_Button0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update_Button0.Click
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Get Form variables
        Dim Glossary_Term As String = Term_TextBox.Text
        Dim Definition As String = Definition_TB.Text
        Dim Keywords As String = Keywords_TB.Text
        Dim DICT_TYPE As String = DICT_TYPE_DropDownList.SelectedValue
        Dim Publish As Integer = Publish_RadioButtonList.SelectedValue
        Dim Sql_Glossary_Update As String

        Sql_Glossary_Update = "Update Glossary " & _
                              "SET ENTITY_NAME='" & Glossary_Term & "', KEYWORDS='" & Keywords & "',SUMMARY='" & Definition & "'," & _
                              "UPDATE_DATE=SYSDATE, DICT_TYPE='" & DICT_TYPE & "',Publish=" & Publish & " WHERE ENTITY_ID =" & Glossary_DropDownList.SelectedValue


        Dim cmd As New OracleCommand(Sql_Glossary_Update, conn)
        cmd.ExecuteNonQuery()


        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()



        Label9.Visible = True
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        EDIT_Panel.Visible = False
        Glossary_EDIT_Panel.Visible = True
        Update_Button0.Visible = False
        Glossary_DropDownList.Visible = False
        Add_Button1.Visible = True
        Publish_RadioButtonList.SelectedValue = 1
    End Sub

    Protected Sub Add_Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add_Button1.Click

        DICT_TYPE_DropDownList.SelectedValue = "GENR"

        Dim ENTITY_NAME As String = Term_TextBox.Text
        Dim SUMMARY As String = Definition_TB.Text
        Dim KEYWORDS As String = Keywords_TB.Text
        Dim DICT_TYPE As String = DICT_TYPE_DropDownList.SelectedValue
        Dim PUBLISH As Integer = Publish_RadioButtonList.SelectedValue
        Dim sql As String = ""
        Dim get_sql As String = ""
        Dim sql_search As String = ""
        Dim Entity_ID As Integer

        If KEYWORDS = "" Then
            KEYWORDS = ENTITY_NAME
        End If


        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        sql = "INSERT INTO GLOSSARY (ENTITY_NAME, KEYWORDS, SUMMARY, UPDATE_DATE, DEPT_ID, URL, PUBLISH, DICT_TYPE) VALUES" & _
              " ('" & ENTITY_NAME & "','" & KEYWORDS & "','" & SUMMARY & "',SYSDATE, 'DICT', 'Glossary.aspx?'," & PUBLISH & ",'" & DICT_TYPE & "')"

        Dim cmd As New OracleCommand(sql, conn)
        cmd.ExecuteNonQuery()

        'Get Glossary Entity ID

        get_sql = "SELECT ENTITY_ID FROM GLOSSARY WHERE ENTITY_NAME = '" & ENTITY_NAME & "'"

        Dim cmd2 As New OracleCommand(get_sql, conn)
        cmd2.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd2.ExecuteReader

        While dr.Read
            Entity_ID = dr(0).ToString()
        End While

        ' Add to search results as well
        sql_search = "INSERT INTO SEARCH_RESULTS (ENTITY_ID, HIT_COUNT, DATE_HIT ) VALUES " & _
                     "(" & Entity_ID & ",0, SYSDATE) "

        Dim cmd3 As New OracleCommand(sql_search, conn)
        cmd3.ExecuteNonQuery()

        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()
        Label9.Visible = True
        Label9.Text = "Term: " & ENTITY_NAME & " added."


        Term_TextBox.Text = ""
        Definition_TB.Text = ""
        Keywords_TB.Text = ""
    End Sub
End Class
