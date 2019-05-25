Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class loginController
        Inherits Controller

        ' GET: login
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: login/Details/5
        Function Details(ByVal id As String, password As String) As String
            Dim req As New Requester()
            Dim params As New Dictionary(Of String, String)
            Dim dic As New Dictionary(Of String, String)

            Threading.Thread.Sleep(2000)

            params.Add("id", id)
            params.Add("password", password)

            Dim resp = req.getRequest("login", "GetValue", params)

            If resp.Success Then
                If resp.Response Is Nothing Then
                    dic.Add("token", "")
                    dic.Add("msg", "Invalid credentials")
                ElseIf resp.Response("Tocken") Is Nothing Then
                    dic.Add("token", "")
                    dic.Add("msg", "Invalid login")
                ElseIf Not resp.Response("Tocken").Equals("") Then
                    Session(SESSION_USER) = New LogedInUserInfo(resp.Response)
                    dic.Add("token", resp.Response("Tocken"))
                    dic.Add("msg", "SUCCESS")
                End If
            Else
                dic.Add("token", "")
                dic.Add("msg", "Server unavailiable")
            End If

            Return JsonConvert.SerializeObject(dic, Formatting.Indented)

        End Function






    End Class
End Namespace