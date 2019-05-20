Imports Newtonsoft.Json.Linq

Public Class APIResponse


    Private _response As JContainer
    Private _success As Boolean
    Private _msg As String




    Public Sub New(rsp As JContainer, succs As Boolean, msg As String)
        _response = rsp
        _success = succs
        _msg = msg
    End Sub

    Public ReadOnly Property Response As JContainer
        Get
            Return _response
        End Get
    End Property

    Public ReadOnly Property Success As Boolean
        Get
            Return _success
        End Get
    End Property

    Public ReadOnly Property Message As String
        Get
            Return _msg
        End Get
    End Property
End Class
