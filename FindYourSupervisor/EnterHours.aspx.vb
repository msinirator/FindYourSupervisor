Public Class EnterHours
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

    End Sub

    Protected Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As New System.Data.DataTable


        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        cmd.CommandType = Data.CommandType.Text

        cmd.CommandText = "Update Users Set " &
                          "HoursWorked = " & txtHours.Text & "," &
                          "HoursDateEntered = '" & Now & "' " &
                          "Where UserID = " & Session("UserID")

        cmd.ExecuteNonQuery()
        con.Close()

        Session("HoursEntered") = 1
        Response.Redirect("InternHome.aspx")

    End Sub

End Class