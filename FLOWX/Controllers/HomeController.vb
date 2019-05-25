Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim req As New Requester()
        Dim resp = req.getRequestArray("menu")
        Dim obj = resp.Response
        Dim lst As New List(Of MdlMenu)
        Dim mn As MdlMenu


        'ViewState("menu") = dt

        If resp.Success Then
            For i = 0 To obj.Count - 1
                mn = New MdlMenu()

                mn.ID = obj.Item(i).Item("ID")
                mn.Name = obj.Item(i).Item("Name")
                mn.Parent = obj.Item(i).Item("Parent")
                mn.Order = obj.Item(i).Item("Order")
                mn.Address = obj.Item(i).Item("Address")

                lst.Add(mn)
            Next
        End If



        Return View(lst)
    End Function

End Class
