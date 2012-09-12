Imports Oracle.DataAccess.Client
Imports System.Data
Partial Class MetaData_Update
    Inherits System.Web.UI.Page

    Protected Sub Schema_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schema_DropDownList.SelectedIndexChanged

        Dim POC_ID As String = Request.QueryString("POC")

        If POC_ID = "" Then
            POC_ID = 1
        End If

        Dim sql As String = "SELECT Entity_Name, ENTITY_ID FROM MD_MAIN WHERE DEPT_ID = '" & Schema_DropDownList.SelectedValue & "' and POC_ID = " & POC_ID & _
                            "Union SELECT Type, Type_ID FROM CATEGORY_DROPDOWNS Where Column_ID = 63"

        SqlDataSource1.SelectCommand = sql
        SqlDataSource1.DataBind()

    End Sub

    Protected Sub Table_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Table_DropDownList.SelectedIndexChanged

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Response.Write(Table_DropDownList.SelectedValue)
        Dim sql As String = "SELECT a.Keywords, a.Summary, NVL(B.ADDITIONAL_INFO, ''), NVL(B.EXCLUSIONS,''), NVL(B.INCLUSIONS,''), NVL(b.ORIGINATION_SOURCE,''), NVL(b.PRODUCTION_SOURCE,''),NVL(b.REFRESH_NUM,'') ,NVL(B.REFRESH_TRIGGER,''),  NVL(b.DEPT_ASSIGNED,''), a.Publish, NVL(a.Completed,'') FROM MD_MAIN a Inner Join MD_MDM_SPECS b ON " & _
                            "A.ENTITY_ID = B.MAIN_ID WHERE ENTITY_ID = " & Table_DropDownList.SelectedValue

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader

        While dr.Read()
            Keyword_TextBox.Text = FixNull(dr(0))
            Summary_TextBox.Text = FixNull(dr(1))
            AddComments_TextBox.Text = FixNull(dr(2))
            Exclusions_TextBox.Text = FixNull(dr(3))
            Inclusions_TextBox.Text = FixNull(dr(4))
            Source_TextBox.Text = FixNull(dr(5))
            Production_TextBox.Text = FixNull(dr(6))
            Refresh_TextBox.Text = FixNull(dr(8))
            RefreshNum_TextBox.Text = FixNull(dr(7))
            Deptartment_TextBox.Text = FixNull(dr(9))

            'If FixNull(dr(10)) = 1 Then
            'Publish_CheckBox.Checked = False
            'Else
            'Publish_CheckBox.Checked = True
            'End If

            If FixNull(dr(11)) = 1 Then
                Completed_CheckBox.Checked = True
            Else
                Completed_CheckBox.Checked = False
            End If
        End While
        HyperLink1.NavigateUrl = "Column_Maintence.aspx?Entity_ID=" & Table_DropDownList.SelectedValue
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim POC_ID As String = Request.QueryString("POC")

        If POC_ID = "" Then
            POC_ID = 1
        End If

        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Response.Write(Table_DropDownList.SelectedValue)
        Dim sql As String = "SELECT F_Name, L_Name FROM MD_DEPT_CONTACT where C_ID = " & POC_ID

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader

        While dr.Read()
            Name_Label.Text = dr(0) & " " & dr(1)

        End While
    End Sub

    Protected Sub Update_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update_Button.Click

        Dim Keywords As String = FixApost(Keyword_TextBox.Text)
        Dim Summary As String = FixApost(Summary_TextBox.Text)
        Dim Exclusions As String = FixApost(Exclusions_TextBox.Text)
        Dim Inclusions As String = FixApost(Inclusions_TextBox.Text)
        Dim ORIGINATION_SOURCE As String = FixApost(Source_TextBox.Text)
        Dim Production_Source As String = FixApost(Production_TextBox.Text)
        Dim Refresh_Trigger As String = FixApost(Refresh_TextBox.Text)
        Dim DEPT_ASSIGNED As String = FixApost(Deptartment_TextBox.Text)

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'Declared Variables

        Dim sql As String
        Dim sql2 As String
        Dim Publish As Integer
        Dim Completed As Integer

        'If Publish_CheckBox.Checked = True Then
        ' Publish = 1
        ' Else
        ' Publish = 0
        ' End If

        If Completed_CheckBox.Checked = True Then
            Completed = 1
        Else
            Completed = 0
        End If


        sql = "Update MD_MAIN " & _
              "Set Keywords='" & Keywords & "', Summary='" & Summary & "', Publish=" & Publish & ",Completed=" & Completed & ",Update_Date=SYSDATE " & _
              "WHERE ENTITY_ID=" & Table_DropDownList.SelectedValue

        sql2 = "Update MD_MDM_SPECS " & _
               "Set Exclusions='" & Exclusions & "', Inclusions='" & Inclusions & "', ORIGINATION_SOURCE='" & ORIGINATION_SOURCE & "', Production_Source='" & Production_TextBox.Text & _
               "', Refresh_Trigger='" & Refresh_Trigger & "', Refresh_NUM=" & RefreshNum_TextBox.Text & ", DEPT_ASSIGNED='" & DEPT_ASSIGNED & "', DATE_UPDATE=SYSDATE " & _
               "WHERE Main_ID=" & Table_DropDownList.SelectedValue
        'Response.Write(sql2)
        Dim cmd As New OracleCommand(sql, conn)
        cmd.ExecuteNonQuery()

        Dim cmd2 As New OracleCommand(sql2, conn)
        cmd2.ExecuteNonQuery()

        '*********************************************************
        ' Close Hit Counter Connection
        '*********************************************************
        conn.Close()
        conn.Dispose()

    End Sub
    Public Function FixApost(ByVal Strvalue) As String

        If InStr(Strvalue, "'") > 0 Then
            Strvalue = Replace(Strvalue, "'", "`")
            Return Strvalue.ToString
        Else
            Return Strvalue.ToString
        End If

    End Function

End Class
