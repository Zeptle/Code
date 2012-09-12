Imports Oracle.DataAccess.Client
Imports System.Data
Partial Class Data_Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Selection As String = Request.QueryString("id")
        Dim ID As String = Request.QueryString("EID")
        Label1.Text = Selection


        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Dim sql As String = "SELECT ENTITY_NAME, ENTITY_ID, DATA_MAP FROM DATAWAREHOUSE_01 WHERE ENTITY_ID = " & ID

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text
        Dim dr As OracleDataReader = cmd.ExecuteReader
        Dim strArray As String()
        Dim URL_Name As String

        While dr.Read()
            strArray = dr("DATA_MAP").Split(",")
            Label1.Text = dr("ENTITY_NAME") & " Data Maps:"
            For count = 0 To strArray.Length - 1
                URL_Name = strArray(count).Replace("_", " ")
                URL_Name = URL_Name.Replace("DataModel.pdf", "")
                URL_Name = URL_Name.Replace("http://racwiki/documents/Erwin/", "")
                URL_Name = URL_Name.Replace(".pdf", "")
                Label2.Text = (Label2.Text & "<br /><a href='http://racwiki/documents/Erwin/" & Trim(strArray(count))) & "' target='_blank'>" & URL_Name & "</a>"
            Next

        End While

    End Sub
End Class
