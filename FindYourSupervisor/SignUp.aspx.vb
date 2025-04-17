Public Class SignUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("UserID") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub cmdSignUp_Click(sender As Object, e As ImageClickEventArgs) Handles cmdSignUp.Click

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim SQL As String

        Dim Email As String
        Dim Password As String
        Dim PasswordConfirm As String
        Dim UserType As String
        Dim Code As String

        Dim txtPasswordConfirm As System.Web.UI.WebControls.TextBox
        txtPasswordConfirm = Page.FindControl("txtPasswordConfirm")

        Email = Trim(txtEmail.Text)
        Password = Trim(txtPassword.Text)
        PasswordConfirm = Trim(txtPasswordConfirm.Text)
        Code = Trim(txtCode.Text)

        If chkIntern.Checked = False And chkSupervisor.Checked = False Then
            lblError.Text = "Please pick intern or supervisor"
            Exit Sub
        End If

        If Email = "" Then
            lblError.Text = "Please enter Email"
            Exit Sub
        End If

        If Password = "" Then
            lblError.Text = "Please enter Password"
            Exit Sub
        End If

        If PasswordConfirm = "" Then
            lblError.Text = "Please enter Password Cofirmation"
            Exit Sub
        End If

        'Put Back
        If Code = "" Then
            lblError.Text = "Please enter registration code"
            Exit Sub
        End If

        If CInt(Code) <> Session("Code") Then
            lblError.Text = "Registration code is invalid"
            Exit Sub
        End If

        If Password <> PasswordConfirm Then
            lblError.Text = "Passwords do not match"
            Exit Sub
        End If

        Select Case True
            Case chkIntern.Checked
                UserType = "0"
            Case chkSupervisor.Checked
                UserType = "1"
        End Select



        If UserType = "0" Then
            con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
            con.Open()

            cmd.Connection = con
            da.SelectCommand = cmd

            SQL = SQL & "Insert Into Users(Email, Password, UserType, HoursWorked, HoursDateEntered) "
            SQL = SQL & "VALUES ('"
            SQL = SQL & Email & "','"
            SQL = SQL & Password & "',"
            SQL = SQL & UserType & ","
            SQL = SQL & "0" & ",'"
            SQL = SQL & Now & "')"

            cmd.CommandText = SQL

            cmd.ExecuteNonQuery()
            con.Close()

            lblError.Text = "Registration Successfull"
        Else
            Session.Add("Email", Email)
            Session.Add("Password", Password)
            Session.Add("UserType", UserType)
            Session.Add("PayMode", 0)
            Response.Redirect("MakePayment.aspx")
        End If


    End Sub

    Protected Sub cmdGetCode_Click(sender As Object, e As EventArgs) Handles cmdGetCode.Click

        Dim Email As String
        Dim Smtp_Server As System.Net.Mail.SmtpClient
        Dim e_mail As System.Net.Mail.MailMessage
        Dim r As Random
        Dim Code As Integer

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As DataTable
        Dim SQL As String

        Email = Trim(txtEmail.Text)

        If Email = "" Then
            lblError.Text = "Please enter a valid Email address"
            Exit Sub
        End If


        'Check if email already exists
        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        SQL = SQL & "Select * From Users "
        SQL = SQL & "Where Email = '"
        SQL = SQL & Email & "'"

        cmd.CommandText = SQL

        table = New DataTable
        da.Fill(table)

        con.Close()

        If table.Rows.Count > 0 Then
            lblError.Text = "Email is already registered"
            Exit Sub
        End If


        r = New Random
        Code = r.Next(1, 99999)
        Session("Code") = Code

        Smtp_Server = New System.Net.Mail.SmtpClient
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.EnableSsl = False

        Smtp_Server.Credentials = New Net.NetworkCredential("YourEmail", "YourPass")
        Smtp_Server.Port = 25 '80 '25
        Smtp_Server.Host = "relay-hosting.secureserver.net"

        e_mail = New System.Net.Mail.MailMessage
        e_mail.From = New System.Net.Mail.MailAddress("YourEmail")
        e_mail.To.Add(Email)
        e_mail.Subject = "Find Your Supervisor Registration Code"
        e_mail.IsBodyHtml = False

        e_mail.Body = "Thank you for choosing to join FindYourSupervisor.com," & vbCrLf & _
                      "Below you will find the registraton code required to complete the sign in process." & vbCrLf & _
                      vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & _
                      Code

        Smtp_Server.Send(e_mail)
        lblError.Text = "Email sent"

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