Imports RestSharp
Imports Newtonsoft.Json
Imports Square
Imports Square.Models

Public Class MakePayment
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    Public Shared Sub ProcessPayment(ByVal token As String, ByVal rbOneMonth As Boolean, ByVal rbSixMonth As Boolean)

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim SQL As String

        Dim amount As New Money.Builder
        Dim MonthsSubscribe As String

        'In Cents
        Select Case True
            Case rbOneMonth
                amount.Amount(2000L) '100 x 20 = 2000 ($20)
                MonthsSubscribe = "1"
            Case rbSixMonth
                amount.Amount(10000L) '100 x 100 = 10000 ($100)
                MonthsSubscribe = "6"
        End Select


        amount.Currency("USD")
        'amount.Build()


        Dim client As New SquareClient.Builder

        client.Environment(Square.Environment.Production)
        client.AccessToken("YourToken")

        Dim IdemKey As String
        IdemKey = Guid.NewGuid.ToString

        Dim body As CreatePaymentRequest.Builder
        body = New CreatePaymentRequest.Builder(token, IdemKey, amount.Build)
        body.LocationId("YourID")


        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12

        Dim response As CreatePaymentResponse
        response = client.Build.PaymentsApi.CreatePayment(body.Build)


        If response.Errors Is Nothing Then

            If HttpContext.Current.Session("PayMode") = "0" Then

                con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
                con.Open()

                cmd.Connection = con
                da.SelectCommand = cmd

                SQL = SQL & "Insert Into Users(Email, Password, UserType, MonthsSubscribe, RegisterDate) "
                SQL = SQL & "VALUES ('"
                SQL = SQL & HttpContext.Current.Session("Email") & "','"
                SQL = SQL & HttpContext.Current.Session("Password") & "',"
                SQL = SQL & HttpContext.Current.Session("UserType") & ","
                SQL = SQL & MonthsSubscribe & ",'"
                SQL = SQL & Now & "')"


                cmd.CommandText = SQL

                cmd.ExecuteNonQuery()
                con.Close()

                HttpContext.Current.Session.Clear()
            Else

                con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
                con.Open()

                cmd.Connection = con
                da.SelectCommand = cmd

                SQL = SQL & "Update Users Set RegisterDate = '" & Now & "' "
                SQL = SQL & "Where UserID = " & HttpContext.Current.Session("UserID")

                cmd.CommandText = SQL

                cmd.ExecuteNonQuery()
                con.Close()

                HttpContext.Current.Session.Clear()
            End If

        End If

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