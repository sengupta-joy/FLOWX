Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Newtonsoft.Json

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class ProxyService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function send(controller As String, data As String, method As String, token As String) As String
        data = data.Replace("`", "'")
        Dim values As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(data)
        Dim resp = Requester.ProxyGetRequest(token, controller,, values)

        Return resp
    End Function

End Class