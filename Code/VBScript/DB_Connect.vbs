On Error resume next

Dim strPath
Dim strPath2
Dim variable1

local = InputBox("Enter your name:")

strFolderPath = "C:\Crash\files2\" & local & "\Documents\"
strPath = "C:\Crash\files\" & local & "\Documents\"


SET FSO = CreateObject("Scripting.FileSystemObject")
Set FLD = FSO.GetFolder(strPath)

Set Conn = CreateObject("ADODB.Connection")


Conn.Open "DSN=CL2", "pro-user", "login4pronet"

Set rs = CreateObject("ADODB.RecordSet")
Set rs2 = CreateObject("ADODB.RecordSet")
Set rs3 = CreateObject("ADODB.RecordSet")

'Create folders from all DBs name - Login to system name and create
'SQL4 = "SELECT * FROM Sys.Databases"

'Searches to find if the folder exist, if not needs to be created.
If NOT FSO.FolderExists(strFolderPath) Then
		Set newfolder = FSO.CreateFolder(strFolderPath)
End If


SQL= "Select FileName From [" & local & "].[dbo].Documents"
'msgbox(SQL)
rs.Open SQL, Conn

'select name from sys.databases

SQL3 = "Select CategoryName FROM [" & local & "].[dbo].DocumentCategories"
rs3.Open SQL3, Conn
'Create folder directory Here
Do Until rs3.EOF
	For each Y in rs3.fields
	strPath2 = "C:\Crash\files2\"  & local & "\Documents\" & y.value
	 If not FSO.FolderExists(strPath2) Then
	 	Set newfolder = FSO.CreateFolder(strPath2)
		END IF
	 
	Next
	rs3.MoveNext
Loop
rs3.Close

Do until rs.EOF
	for each x in rs.fields
	'msgbox("x.value: " & x.value)

	SQL2 = 	"SELECT A.ID as Cat_ID, A.CategoryName, B.SourceFile, B.FileName FROM [" & local & "].[dbo].[DocumentCategories] A " & _
			"INNER JOIN [" & local & "].[dbo].[Documents] B ON B.Category = A.ID Where FileName like '" & x.value & "'"
	
    'Msgbox(SQL2)
    'Select SourceFile, FileName From Documents Where FileName like '" & x.value & "'"
	rs2.Open SQL2, Conn
	
	'msgbox("SQL2: " & SQL2)
   'msgbox("CategoryName: " & rs2("CategoryName"))
	'msgbox("SourceFile: " & rs2("SourceFile"))
	
	strOldName = strPath & x.value 
	strNewName = "C:\Crash\files2\" & local & "\Documents\" & Trim(rs2("CategoryName")) & "\" & rs2("SourceFile")
	
    'if instr(strOldName, "File000201") THEN
	'msgbox("Old Name: " & strOldName)
	'msgbox("New Name: " & strNewName)
	'msgbox("New ch Name: " & Replace(strNewName,".", chr(45)))
	
	'END IF
	
	If NOT FSO.FileExists(strNewName) Then
		FSO.CopyFile strOldName,  strNewName
		'MsgBox("strOldName: "  & FSO.FileExists(strOldName))
        'MsgBox("strNewName: "  & FSO.FileExists(strNewName))
	End If

rs2.close

	next
rs.MoveNext
Loop
	
rs.close
conn.close

MSGBOX("Complete.  Please check folders " & local & " to ensure proper name placement.")

