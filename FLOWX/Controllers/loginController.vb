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

            params.Add("id", id)
            params.Add("password", password)

            Dim resp = req.getRequest("login", "GetValue", params)

            If resp.Success Then
                If resp.Response Is Nothing Then
                    dic.Add("token", "")
                    dic.Add("msg", "Server unavailiable")
                End If
                If Not resp.Response("Tocken").Equals("") Then
                    Session(SESSION_USER) = New UserInfo(resp.Response)
                    dic.Add("token", "1234")
                    dic.Add("msg", "success")
                End If
            Else
                dic.Add("token", "")
                dic.Add("msg", "Server unavailiable")
            End If

            Return JsonConvert.SerializeObject(dic, Formatting.Indented)



        End Function

        ' GET: login/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: login/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: login/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: login/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: login/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: login/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace