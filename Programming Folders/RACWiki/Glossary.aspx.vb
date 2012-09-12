Imports Oracle.DataAccess.Client
Imports System.Data
Partial Class Glossary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim Selection As String = Request.QueryString("id")
        Dim Glossary_Type As String

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Label1.Text = ""
        Label2.Text = ""

        '*********************************
        ' Hard coded drop down for terms
        '*********************************
        Select Case (DropDownList1.SelectedValue)
            Case 1
                Glossary_Type = " and DICT_TYPE='GENR' "
            Case 2
                Glossary_Type = " and DICT_TYPE='TECH' "
            Case Else
                Glossary_Type = ""
        End Select

        '*********************************
        ' Begin list display Glossary Terms
        '*********************************
        'SQL Statement
        Dim sql As String = "SELECT Entity_ID, Entity_Name, Summary FROM Glossary WHERE DEPT_ID like '%DICT%' and Publish = 1 " & Glossary_Type & "ORDER BY UPPER(ENTITY_NAME) ASC"

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader
        Dim test As String = 0
        Dim URL_STRING As String

        Label2.Text = Label2.Text & "<dl>"
        For Each a In dr
            'Displays first letter, provides header at top of glossary
            If UCase(dr("Entity_Name").Substring(0, 1)) <> UCase(test) Then
                'Displays the word and Definition
                Label2.Text = Label2.Text & ("<dt class=Glossary_Letter><a name='" & UCase(dr("Entity_Name").Substring(0, 1)) & "'>" & dr("Entity_Name").Substring(0, 1) & "</a>  <a href='#top'>(TOP)</a><a href='http://racwiki/Comments.aspx' onClick='return popup(this)'> <img align='middle' src='http://racwiki/images/Sm_Question.png' border=0 alt='small question' /></a></dt><br /><br />")
                test = dr("Entity_Name").Substring(0, 1)
                URL_STRING = URL_STRING & " | " & test
            Else
                test = test
            End If
            Label2.Text = Label2.Text & ("<dt><B><a name='" & dr("Entity_ID") & "'>" & dr("Entity_Name") & "</a> </B></dt><br /><dd>" & dr("Summary") & "</dd><br /><br />")
        Next
        Label2.Text = Label2.Text & "</dl>"
        Dim strArray As String()
        strArray = URL_STRING.Split("|")

        For count = 0 To strArray.Length - 1
            Label1.Text = Label1.Text & ("<a href='#" & Trim(strArray(count)) & "'>" & Trim(strArray(count)) & "</a> | ")
        Next
        Label1.Text = "<a name='#top'></a> " & Label1.Text
        Label3.Text = Label1.Text
        '*********************************
        ' End list display Glossary Terms
        '*********************************


        '*********************** BEGIN UPDATE RESULTS ***********************

        If Selection <> Nothing Then

            'Hit Counter
            Dim sql3 As String = "SELECT SEARCH_RESULTS.Hit_Count FROM SEARCH_RESULTS SEARCH_RESULTS WHERE (SEARCH_RESULTS.ENTITY_ID ='" & Selection & "')"
            'Response.Write(sql3)

            Dim cmd3 As New OracleCommand(sql3, conn)
            cmd3.CommandType = CommandType.Text
            Dim dr3 As OracleDataReader = cmd3.ExecuteReader
            'Get last count from DB counter
            Dim last_hit As String

            'Data Reader information
            While dr3.Read()
                If Not dr3.GetValue(0) Is DBNull.Value Then _
                    last_hit = dr3.GetValue(0)
            End While
            dr3.Close()
            last_hit = last_hit + 1

            Dim sql4 As String = "UPDATE SEARCH_RESULTS " & _
                                     "SET Hit_Count =" & last_hit & ", Date_Hit =SYSDATE " & _
                                    "WHERE SEARCH_RESULTS.ENTITY_ID ='" & Selection & "'"
            'Response.Write(sql4)
            Dim cmd4 As New OracleCommand(sql4, conn)
            cmd4.ExecuteNonQuery()
        End If
        '*********************** END UPDATE RESULTS ***********************
        conn.Close()
        conn.Dispose()
    End Sub


End Class
