Imports System.Net
Imports System.Web.Mvc
Imports System.Web.Mvc.Filters

Public Class CustomAuthorization : Implements System.Web.Mvc.IAuthorizationFilter



    Public Overloads Sub OnAuthorization(filterContext As AuthorizationContext) Implements Mvc.IAuthorizationFilter.OnAuthorization
        If Not authorized(filterContext.ActionDescriptor.ActionName, filterContext.Controller.ToString()) Then
            filterContext.HttpContext.Response.StatusCode = 403
            filterContext.HttpContext.Response.End()
        End If
    End Sub

    Private Function authorized(actionName As String, controlername As String) As Boolean
        Dim arr = controlername.Split(".")
        If arr.Contains("login" + "Controller") Then
            Return True
        End If

        Dim usr As LogedInUserInfo = DirectCast(HttpContext.Current.Session("SESSION_USER"), LogedInUserInfo)

        If usr Is Nothing Then
            Return False
        End If

        If String.IsNullOrEmpty(usr.Token) Then
            Return False
        End If

        If Not isValidToken(usr.Token) Then
            Return False
        End If

        Return True
    End Function

    Private Function isValidToken(token As String) As Boolean
        Return True
    End Function
End Class
