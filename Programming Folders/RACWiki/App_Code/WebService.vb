Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Oracle.DataAccess.Client
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
   Public Shared Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=/;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'SQL Statement
        Dim sql As String = "SELECT MD_MAIN.KEYWORDS FROM BROLAU.MD_MAIN"
        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader

        Dim items As New ArrayList()
        Dim strArray As String()

        For Each a In dr
            Dim Str As String = dr("KEYWORDS")
            strArray = Str.Split(",")

            For count = 0 To strArray.Length - 1
                items.Add(Trim(strArray(count)))
            Next
        Next

        items.Sort()
        Dim ArrCount As Integer = items.Count
        For i = ArrCount - 1 To 1 Step -1
            If (items(i).ToString() = items(i - 1).ToString()) Then
                items.RemoveAt(i)
            End If
        Next i


        Dim string_array() As String
        string_array = DirectCast(items.ToArray(GetType(String)), String())

        ' Return matching myArray
        Return (From m In string_array Where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) Select m).Take(count).ToArray()

        'Close Connection
        conn.Close()
        conn.Dispose()

    End Function
End Class
