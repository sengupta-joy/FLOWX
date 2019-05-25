@ModelType IEnumerable(Of FLOWX.MdlMenu)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code



<ul class="nav">
    @For Each item In Model.Where(Function(x) x.Parent = "")
        @<li class="nav-item">
            <a class="nav-link menu-head" href="#" onclick="javascript:return false;">
                <i class="material-icons">p</i>
                <p>@item.Name</p>
            </a>
            <input type="Hidden" ID="hdnMainMenuID" Value='@item.id' />
            <div class="sub-menu">
                <ul class="nav">
                    @For Each item2 In Model.Where(Function(x) x.Parent = item.ID)
                        @<li class="nav-item">
                             <a class="nav-link menu-head" href="#" onclick="javascript:return false;">
                                 <i class="material-icons">p</i>
                                 <p>@item2.Name</p>
                             </a>
                        </li>
                    Next
                </ul>
            </div>
        </li>
    Next
</ul>

