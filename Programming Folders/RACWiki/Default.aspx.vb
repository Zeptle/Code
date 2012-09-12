Imports System.Data
Imports Oracle.DataAccess.Client
Partial Class Whatever
    Inherits System.Web.UI.Page


    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()


        '******************************* Note *******************************
        ' if the auto complete list is not working properly, double check
        ' & make sure that there are no keywords left blank
        '********************************************************************

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'SQL Statement
        Dim sql As String = "SELECT KEYWORDS, Entity_Name FROM Glossary A Where Publish = 1 " & _
                            "UNION " & _
                            "SELECT KEYWORDS, ENTITY_NAME FROM DATAWAREHOUSE_01 B " & _
                            "Where(Publish = 1)"
        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader

        Dim items As New ArrayList()
        Dim strArray As String()
        Dim str2Array As String()

        For Each a In dr
            Dim Str As String = dr("KEYWORDS")
            Dim Str2 As String = dr("Entity_Name")
            strArray = Str.Split(",")
            str2Array = Str2.Split(",")

            For count = 0 To strArray.Length - 1
                items.Add(Trim(strArray(count)))
            Next

            For count = 0 To str2Array.Length - 1
                items.Add(Trim(str2Array(count)))
            Next


        Next

        items.Sort()
        Dim ArrCount As Integer = items.Count
        For i = ArrCount - 1 To 1 Step -1
            If (LCase(items(i)).ToString() = LCase(items(i - 1)).ToString()) Then
                items.RemoveAt(i)
            End If
        Next i


        Dim string_array() As String
        string_array = DirectCast(items.ToArray(GetType(String)), String())

        ' Return matching myArray
        Return (From m In string_array Where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) Select m).Take(15).ToArray()

        'Close Connection
        conn.Close()
        conn.Dispose()

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        '****************************************
        ' Counts the number of hits to page
        '****************************************
        Dim client_ip As String
        Dim client_host As String
        Dim OLD As Integer = 0
        Dim Site_Counter As Integer = 0
        Dim sql_Counter2 As String

        client_host = System.Environment.MachineName()
        client_ip = Request.UserHostAddress()

        '**************************************************
        ' Finds most recent hit to item and site,
        ' Counts every hit on datawarehouse and Glossary
        '**************************************************

        Dim sql_Counter As String = "Select COUNT,IP_ADDRESS,COMP_NAME FROM SITE_COUNT"

        Dim cmd_Count As New OracleCommand(sql_Counter, conn)
        cmd_Count.CommandType = CommandType.Text
        Dim dr_count As OracleDataReader = cmd_Count.ExecuteReader

        dr_count.Read()


        For Each a In dr_count
            If dr_count(1) = client_ip Then
                Site_Counter = dr_count(0)
                OLD = 1
                Exit For
            End If
        Next

        Site_Counter += 1

        '****************************************
        ' Insert user IP address and number 
        ' of times used - Requested by John Gideon
        '****************************************

        If OLD = 1 Then
            sql_Counter2 = "UPDATE SITE_COUNT SET COUNT =" & Site_Counter & ", LH_DATE=SYSDATE " & _
                            "WHERE IP_ADDRESS = '" & client_ip & "'"
        Else
            sql_Counter2 = "INSERT INTO SITE_COUNT (COUNT,LH_DATE,IP_ADDRESS,COMP_NAME) VALUES " & _
                           "(" & Site_Counter & ",SYSDATE,'" & client_ip & "','" & client_host & "')"
        End If

        Dim cmd4 As New OracleCommand(sql_Counter2, conn)
        cmd4.ExecuteNonQuery()


        '****************************************
        ' Display Hits counter on page        ' 
        '****************************************
        Dim sql_Counter_TOTAL As String = "SELECT SUM(COUNT) FROM SITE_COUNT"

        Dim cmd_Count_TOTAL As New OracleCommand(sql_Counter_TOTAL, conn)
        cmd_Count.CommandType = CommandType.Text
        Dim dr_count_TOTAL As OracleDataReader = cmd_Count_TOTAL.ExecuteReader

        dr_count_TOTAL.Read()
        Counter_Label.Text = dr_count_TOTAL(0)

        '****************************************
        ' Build Tag Cloud Begin:
        ' Gets top 20 Hits from the Glossary
        ' - Requested by Sonia Holland
        '****************************************
        Dim sql As String = "SELECT A.ENTITY_ID, A.HIT_COUNT, B.ENTITY_NAME, URL, Update_Date FROM SEARCH_RESULTS A " & _
                            "INNER JOIN GLOSSARY B ON " & _
                            "A.ENTITY_ID = B.ENTITY_ID " & _
                            "WHERE ROWNUM < 20  and HIT_COUNT <> 0 ORDER by HIT_COUNT DESC"

        '"SELECT * FROM " & _
        '"(SELECT a.ENTITY_ID, b.Entity_Name, a.HIT_COUNT, b.Update_Date, B.URL, LENGTH(B.ENTITY_NAME) as LENGTH from SEARCH_RESULTS a " & _
        '"Inner Join MD_MAIN b ON a.ENTITY_ID = b.ENTITY_ID " & _
        '"Where B.PUBLISH = 1 and B.DEPT_ID='DICT' " & _
        '"Order by a.HIT_COUNT DESC) WHERE(ROWNUM <= 20)"

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim Rdr As OracleDataReader = cmd.ExecuteReader

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim ki As String = "keyword_id"
        Dim kv As String = "keyword_value"
        Dim kc As String = "keyword_count"
        Dim ku As String = "keyword_url"
        Dim da As Date
        dt.Columns.Add(ki, GetType(Integer))
        dt.Columns.Add(kv)
        dt.Columns.Add(kc, GetType(Integer))
        dt.Columns.Add(ku)
        dt.Columns.Add(da)
        While Rdr.Read()
            dr = dt.NewRow
            dr(ki) = Rdr("ENTITY_ID")
            dr(kv) = Rdr("Entity_Name")
            dr(kc) = Rdr("HIT_COUNT")
            dr(ku) = Rdr("URL") & "id=" & Rdr("ENTITY_ID") & "#" & Rdr("ENTITY_ID")
            dr(da) = Rdr("Update_Date")
            dt.Rows.Add(dr)
        End While

        ds.Tables.Add(dt)
        cloud1.DataIDField = ki
        cloud1.DataKeywordField = kv
        cloud1.DataCountField = kc
        cloud1.SortBy = da
        cloud1.DataURLField = ku
        cloud1.DataSource = ds
        cloud1.Visible = True

        '****************************************
        ' Build Tag Cloud END
        '****************************************
        conn.Close()
        conn.Dispose()

        '************************************************************
        ' Most recent updated glossary terms
        ' - requested by Sonia Holland,
        ' - thought having datawarehouse info would be confusing
        '************************************************************
        Dim sql2 As String = "SELECT * FROM  (SELECT ENTITY_ID,ENTITY_NAME, Concat(Substr(SUMMARY,0,50),'...') as Summary, TO_CHAR(Update_Date, 'YYYY-MM-DD') as Update_Date, " & _
                             "URL,  LENGTH(Entity_Name) as LENGTH FROM  GLOSSARY WHERE   (PUBLISH = 1) and (DEPT_ID = 'DICT')  Order by Update_Date DESC) " & _
                             "WHERE(ROWNUM < 6)"

        '"SELECT * FROM (SELECT MD_MAIN.ENTITY_ID, MD_MAIN.ENTITY_NAME,  Concat(Substr(MD_MAIN.SUMMARY,0,50),'...') as Summary,TO_CHAR(MD_MAIN.Update_Date, 'YYYY-MM-DD') as Update_Date, URL, LENGTH(Entity_Name) as LENGTH " & _
        '"FROM MD_MAIN WHERE PUBLISH = 1 and DEPT_ID = 'DICT' GROUP BY Entity_ID, Entity_Name, Summary, Update_Date, URL Order by Update_Date DESC) WHERE Rownum <=5"

        SqlDataSource2.ConnectionString = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        SqlDataSource2.SelectCommand = sql2
        ListView2.DataBind()
        ListView2.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Turn off opening features screen 
        Intro_Label.Visible = False
        IMPT_MSG_PANEL.Visible = False
        MAIN_Panel.Visible = False

        If Search_textBox.Text <> "" Then
            Dim sql As String = "SELECT ENTITY_ID, Entity_Name,Concat(Substr(SUMMARY,0,50),'...') As SUMMARY, URL, LENGTH(Entity_Name) as LENGTH FROM Glossary " & _
                                "WHERE (((UPPER(ENTITY_NAME) like Upper('%" & Search_textBox.Text & "%') and Dept_Id like 'DICT%' and Publish = 1))  or (UPPER(KEYWORDS) like Upper('%" & Search_textBox.Text & "%') and Dept_Id like 'DICT%' and Publish =1)) and rownum < 11"

            '"SELECT MD_MAIN.ENTITY_ID, MD_MAIN.ENTITY_NAME, Concat(Substr(MD_MAIN.SUMMARY,0,50),'...') As SUMMARY, URL, LENGTH(Entity_Name) as LENGTH FROM MD_MAIN " & _
            '"WHERE (((UPPER(ENTITY_NAME) like Upper('%" & Search_textBox.Text & "%') and Dept_Id like 'DICT%' and Publish = 1))  or (UPPER(KEYWORDS) like Upper('%" & Search_textBox.Text & "%') and Dept_Id like 'DICT%' and Publish =1)) and rownum < 11"

            SqlDataSource1.SelectCommand = sql
            ListView1.DataBind()
            ListView1.Visible = True
        Else
            ListView1.Visible = False
            ListView2.Visible = True
            ListView1.Visible = True
        End If

        'If Statement for non glossary terms
        If Search_textBox.Text <> "" Then
            Dim sql2 As String = "SELECT ENTITY_ID, Entity_Name, Concat(Substr(DESCRIPTION,0,50),'...') As SUMMARY, URL, LENGTH(Entity_Name) as LENGTH FROM Datawarehouse_01 " & _
            "WHERE (((UPPER(ENTITY_NAME) like Upper('%" & Search_textBox.Text & "%') and Publish = 1))  or (UPPER(KEYWORDS) like Upper('%" & Search_textBox.Text & "%') and Publish =1)) and rownum < 11"

            '"SELECT MD_MAIN.ENTITY_ID, MD_MAIN.ENTITY_NAME, Concat(Substr(MD_MAIN.SUMMARY,0,50),'...') As SUMMARY, URL, DEPT_ID FROM MD_MAIN WHERE ((UPPER(KEYWORDS) LIKE Upper('%" & Search_textBox.Text & "%')and Dept_Id NOT like 'DICT%' OR UPPER(ENTITY_NAME) like Upper('%" & Search_textBox.Text & "%'))  and Dept_Id NOT like 'DICT%') and Publish = 1 Order by Entity_Name"

            SqlDataSource3.SelectCommand = sql2
            ListView3.DataBind()
            ListView3.Visible = True
        Else
            Intro_Label.Text = "<p>Sorry, no results were found.<br />  Please search again or submit a request for the topic by clicking on the Questions or Comments <img src='images/Big_Question.png'  height=17px width=17px /> icon at the top.</p>"
            Intro_Label.Visible = True
            ListView1.Visible = False
            ListView3.Visible = False
            MAIN_Panel.Visible = True
        End If

        If ListView1.Items.Count = 0 And ListView3.Items.Count = 0 Then
            Intro_Label.Text = "<p>Sorry, no results were found.<br />  Please search again or submit a request for the topic by clicking on the Questions or Comments <img src='images/Big_Question.png'  height=17px width=17px /> icon at the top.</p>"
            Intro_Label.Visible = True

        End If


    End Sub

End Class

