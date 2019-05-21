Imports Newtonsoft.Json.Linq


<Serializable>
Public Class LogedInUserInfo

    Private _tok As String
    Private _id As String
    Private _name As String
    Private _email As String
    Private _desig As String
    Private _dept As String
    Private _brnch As String
    Private _boss As String
    Private _cmp As String

    Public ReadOnly Property Token As String
        Get
            Return _tok
        End Get
    End Property
    Public ReadOnly Property UserId As String
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Email As String
        Get
            Return _email
        End Get
    End Property

    Public ReadOnly Property Designation As String
        Get
            Return _desig
        End Get

    End Property

    Public ReadOnly Property Depertment As String
        Get
            Return _dept
        End Get

    End Property

    Public ReadOnly Property Branch As String
        Get
            Return _brnch
        End Get

    End Property

    Public ReadOnly Property Boss As String
        Get
            Return _boss
        End Get

    End Property

    Public ReadOnly Property Company As String
        Get
            Return _cmp
        End Get

    End Property

    Public Sub New(obj As JObject)
        _tok = obj("Tocken")
        _id = obj("UserInfo")("ID").ToString()
        _name = obj("UserInfo")("Name").ToString()
        _email = obj("UserInfo")("Email").ToString()
        _desig = obj("UserInfo")("Designation").ToString()
        _dept = obj("UserInfo")("Depertment").ToString()
        _brnch = obj("UserInfo")("Branch").ToString()
        _boss = obj("UserInfo")("Boss").ToString()
        _cmp = obj("UserInfo")("Company").ToString()
    End Sub
End Class
