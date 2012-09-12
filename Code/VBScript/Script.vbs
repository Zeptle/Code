Option Explicit

Dim strPath
Dim FSO
Dim FLD
Dim fil
Dim strOldName
Dim strNewName
Dim strFileParts
Dim oldfile


	'Define the path to the file
	strPath = "C:\Crash\files\"


	'Create the instance of the FSO
	Set FSO = CreateObject("Scripting.FileSystemObject")
	
	Set FLD = FSO.GetFolder(strPath)

	'Loop through each file in the folder
	For Each fil in FLD.Files
		'Get complete file name with path
		strOldName = fil.Path
msgbox(strOldName)
msgbox("fil: " & fil)
		
		'Check the file has an underscore in the name
		If InStr(strOldName, "_") > 0 Then
			'Split the file on the underscore so we can get everything before it
			strFileParts = Split(strOldName, "_")
			'Build the new file name with everything before the 
			'first under score plus the extension
			strNewName = strFileParts(0) & ".txt"
msgbox(strNewName)

			'Use the MoveFile method to rename the file
			FSO.MoveFile strOldName, strNewName
		End If
	Next

	'Cleanup the objects
	Set FLD = Nothing
	Set FSO = Nothing