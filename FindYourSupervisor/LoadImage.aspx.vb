Public Class LoadImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        Dim UserID As String
        UserID = Request.QueryString("UserID")

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As System.Data.DataTable
        Dim SQL As String


        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        SQL = SQL & "Select Image From Images Where "
        SQL = SQL & "UserID = " & UserID

        cmd.CommandText = SQL

        table = New Data.DataTable
        da.Fill(table)
        con.Close()

        Response.BinaryWrite(table.Rows(0)(0))


    End Sub

End Class