Public Class SignIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("UserID") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub cmdSignIn_Click(sender As Object, e As ImageClickEventArgs) Handles cmdSignIn.Click

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As System.Data.DataTable
        Dim UserRow As DataRow
        Dim SQL As String

        Dim Email As String
        Dim Password As String
        Dim MonthsSubscribe As Integer
        Dim RegisterDate As DateTime
        Dim HoursDateEntered As DateTime


        Email = Trim(txtEmail.Text)
        Password = Trim(txtPassword.Text)


        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        SQL = SQL & "Select * From Users Where "
        SQL = SQL & "Email = '" & Email & "' AND "
        SQL = SQL & "Password = '" & Password & "'"

        cmd.CommandText = SQL

        table = New Data.DataTable
        da.Fill(table)
        con.Close()


        If table.Rows.Count > 0 Then

            UserRow = table.Rows(0)

            'Check Subscription for Supervisors only
            'And Ignore 12 month secial flag set for admin
            'users on live database
            If UserRow("UserType") = 1 And UserRow("MonthsSubscribe") <> 12 Then

                MonthsSubscribe = UserRow("MonthsSubscribe")
                RegisterDate = UserRow("RegisterDate")

                If Today > RegisterDate.AddMonths(MonthsSubscribe) Then
                    Session.Add("UserID", UserRow("UserID"))
                    Session.Add("PayMode", 1)
                    Response.Redirect("MakePayment.aspx")
                Else
                    Session.Add("UserID", UserRow("UserID"))
                    Session.Add("UserType", UserRow("UserType"))
                    Session.Add("Email", Email)
                    Session.Add("DocList_Edit", "")
                    Session.Add("Items_Edit", Nothing)
                    Session.Add("CurrPage_Edit", 0)
                    Session.Add("TotalPages_Edit", 0)
                    Response.Redirect("Default.aspx")
                End If
            Else

                Session.Add("UserID", UserRow("UserID"))
                Session.Add("UserType", UserRow("UserType"))
                Session.Add("Email", Email)
                Session.Add("DocList_Edit", "")
                Session.Add("Items_Edit", Nothing)
                Session.Add("CurrPage_Edit", 0)
                Session.Add("TotalPages_Edit", 0)

                If table.Rows(0)("UserType") = 0 Then

                    HoursDateEntered = UserRow("HoursDateEntered")

                    If Today > HoursDateEntered.AddDays(7) Then
                        Session.Add("HoursEntered", 0)
                        Response.Redirect("EnterHours.aspx")
                    Else
                        Session.Add("HoursEntered", 1)
                        Response.Redirect("Default.aspx")
                    End If

                End If

            End If

        Else
            lblError.Visible = True
        End If

    End Sub

    Protected Sub cmdSignUp_Click(sender As Object, e As ImageClickEventArgs) Handles cmdSignUp.Click
        Response.Redirect("SignUp.aspx")
    End Sub
    Protected Sub lbHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHome.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lbSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSignIn.Click
        Response.Redirect("SignIn.aspx")
    End Sub

    Protected Sub lbSignUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSignUp.Click
        Response.Redirect("SignUp.aspx")
    End Sub

    Protected Sub lbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEdit.Click

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        Response.Redirect("SupervisorEdit.aspx")
    End Sub

    Protected Sub lbLougout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLougout.Click
        Session.Remove("UserID")
        Session.Remove("UserType")
        Session.Remove("Email")
        Response.Redirect("Default.aspx")
    End Sub

End Class