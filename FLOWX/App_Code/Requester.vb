Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Requester


    Private ReadOnly Property ServerPath As String
        Get
            Return ConfigurationSettings.AppSettings.Item("server-url").ToString()
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Function getRequest(controller As String, Optional action As String = "", Optional parameters As Dictionary(Of String, String) = Nothing) As APIResponse
        Dim req As HttpWebRequest
        Dim resp As HttpWebResponse
        Dim responseFromServer = ""
        Dim url As String
        Dim user As UserInfo = DirectCast(HttpContext.Current.Session(SESSION_USER), UserInfo)
        Dim ThisToken As Object
        Dim apiResp As APIResponse

        url = ServerPath + controller

        If Not action.Equals(String.Empty) Then
            url = ServerPath + controller + "/" + action
        End If


        If Not parameters Is Nothing Then
            url = url + "?"
            For Each p In parameters
                url = url + p.Key + "=" + p.Value + "&"
            Next

            If url.Last() = "&" Then
                url = Mid(url, 1, Len(url) - 1)
            End If
        End If


        req = DirectCast(WebRequest.Create(url), HttpWebRequest)
        req.Method = "GET"
        req.Accept = "application/json"

        If Not user Is Nothing Then
            req.Headers.Add("token", user.Token)
        End If

        Try
            resp = DirectCast(req.GetResponse(), HttpWebResponse)
            If resp.StatusDescription.Equals("OK") Then
                Using strm = resp.GetResponseStream()
                    Dim reader = New StreamReader(strm)
                    responseFromServer = reader.ReadToEnd()
                End Using


                ThisToken = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JObject)(responseFromServer)

                apiResp = New APIResponse(ThisToken, True, "")

            Else
                apiResp = New APIResponse(Nothing, False, DirectCast(resp, HttpWebResponse).StatusDescription)
            End If


        Catch ex As Exception
            apiResp = New APIResponse(Nothing, False, ex.Message)
        End Try

        Return apiResp
    End Function

    Public Function getRequestArray(controller As String, Optional action As String = "", Optional parameters As Dictionary(Of String, String) = Nothing) As APIResponse
        Dim req As HttpWebRequest
        Dim resp As HttpWebResponse
        Dim responseFromServer = ""
        Dim url As String
        Dim user As UserInfo = DirectCast(HttpContext.Current.Session(SESSION_USER), UserInfo)
        Dim ThisToken As Object
        Dim apiResp As APIResponse

        url = ServerPath + controller

        If Not action.Equals(String.Empty) Then
            url = ServerPath + controller + "/" + action
        End If


        If Not parameters Is Nothing Then
            url = url + "?"
            For Each p In parameters
                url = url + p.Key + "=" + p.Value + "&"
            Next

            If url.Last() = "&" Then
                url = Mid(url, 1, Len(url) - 1)
            End If
        End If


        req = DirectCast(WebRequest.Create(url), HttpWebRequest)
        req.Method = "GET"
        req.Accept = "application/json"

        If Not user Is Nothing Then
            req.Headers.Add("token", user.Token)
        End If

        Try
            resp = DirectCast(req.GetResponse(), HttpWebResponse)
            If resp.StatusDescription.Equals("OK") Then
                Using strm = resp.GetResponseStream()
                    Dim reader = New StreamReader(strm)
                    responseFromServer = reader.ReadToEnd()
                End Using


                ThisToken = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JArray)(responseFromServer)
                apiResp = New APIResponse(ThisToken, True, "")

            Else
                apiResp = New APIResponse(Nothing, False, DirectCast(resp, HttpWebResponse).StatusDescription)
            End If

        Catch ex As Exception
            apiResp = New APIResponse(Nothing, False, ex.Message)
        End Try


        Return apiResp
    End Function

    Public Function postRequest(controller As String, Optional action As String = "", Optional DataBodyContent As Object = Nothing) As String
        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte
        Dim url As String

        Dim user As UserInfo = DirectCast(HttpContext.Current.Session(SESSION_USER), UserInfo)

        If Not action = "" Then
            url = ServerPath + controller + "/" + action
        Else
            url = ServerPath + controller
        End If

        Try
            webClient.Headers("content-type") = "application/json"
            webClient.Headers.Add("token", user.Token)
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(DataBodyContent, Formatting.Indented))
            resByte = webClient.UploadData(url, reqString)
            resString = Encoding.Default.GetString(resByte)
            Console.WriteLine(resString)
            webClient.Dispose()
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


    End Function

    Public Shared Function proxyPostRequest(token As String, controller As String, Optional action As String = "", Optional data2 As Object = Nothing) As String
        Dim ResponseString As String = ""
        Dim response As HttpWebResponse = Nothing
        Dim url As String
        Dim servicePath = ConfigurationSettings.AppSettings.Item("server-url").ToString()


        url = servicePath + controller

        If Not action.Equals(String.Empty) Then
            url = servicePath + controller + "/" + action
        End If

        Try
            Dim request = CType(WebRequest.Create(url), HttpWebRequest)
            request.Accept = "application/json"
            request.Method = "POST"
            Dim obj As New Dictionary(Of String, String)

            obj.Add("ID", "AUBUSR190690000W")

            Dim jss As JavaScriptSerializer = New JavaScriptSerializer()
            Dim myContent = jss.Serialize(obj)
            Dim data = Encoding.ASCII.GetBytes(myContent)
            request.ContentType = "application/json"
            request.ContentLength = data.Length
            request.Headers.Add("token", token)

            Using stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            response = CType(request.GetResponse(), HttpWebResponse)
            ResponseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
        Catch ex As WebException

            If ex.Status = WebExceptionStatus.ProtocolError Then
                response = CType(ex.Response, HttpWebResponse)
                ResponseString = "Some error occured: " & response.StatusCode.ToString()
            Else
                ResponseString = "Some error occured: " & ex.Status.ToString()
            End If
        End Try

        Return ResponseString
    End Function
    Public Shared Function ProxyGetRequest(token As String, controller As String, Optional action As String = "", Optional parameters As Dictionary(Of String, String) = Nothing) As String
        Dim req As HttpWebRequest
        Dim resp As HttpWebResponse
        Dim responseFromServer = ""
        Dim url As String
        Dim servicePath = ConfigurationSettings.AppSettings.Item("server-url").ToString()


        url = servicePath + controller

        If Not action.Equals(String.Empty) Then
            url = servicePath + controller + "/" + action
        End If


        If Not parameters Is Nothing Then
            url = url + "?"
            For Each p In parameters
                url = url + p.Key + "=" + p.Value + "&"
            Next

            If url.Last() = "&" Then
                url = Mid(url, 1, Len(url) - 1)
            End If
        End If


        req = DirectCast(WebRequest.Create(url), HttpWebRequest)
        req.Method = "GET"
        req.Accept = "application/json"


        req.Headers.Add("token", token)


        Try
            resp = DirectCast(req.GetResponse(), HttpWebResponse)
            If resp.StatusDescription.Equals("OK") Then
                Using strm = resp.GetResponseStream()
                    Dim reader = New StreamReader(strm)
                    responseFromServer = reader.ReadToEnd()
                End Using
            Else
                responseFromServer = ""
            End If


        Catch ex As Exception
            responseFromServer = ex.Message
        End Try

        Return responseFromServer
    End Function
End Class
