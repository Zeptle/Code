
Partial Class CP_Login
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim Login As String = TextBox1.Text.ToString()
        'Dim Password As String = TextBox2.ToString()


        If UCase(TextBox1.Text.ToString()) = "ADMIN" And UCase(TextBox2.Text.ToString()) = "ADMIN" Then
            Response.Redirect("Control_Panel.aspx?id=Pass")
        Else
            Response.Write("ERROR")
        End If
    End Sub
End Class
