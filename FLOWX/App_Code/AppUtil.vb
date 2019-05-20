Imports System.Data

Public Class AppUtil


    Public Shared Sub loadDropDown(ddl As DropDownList, dt As DataTable, valueField As String, displayField As String)
        ddl.Items.Clear()

        ddl.DataSource = dt
        ddl.DataTextField = displayField
        ddl.DataValueField = valueField
        ddl.DataBind()


        Dim item As New ListItem("Please Select", 0)
        ddl.Items.Insert(0, item)

    End Sub

End Class
