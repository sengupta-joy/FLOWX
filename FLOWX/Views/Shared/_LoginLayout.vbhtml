
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
    <link href="~/Content/login.css" rel="stylesheet" />
    @Styles.Render("~/Content/assets")
    @Scripts.Render("~/bundles/jquery")

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnLogin").click(function () {
                var url = "/login/details";
                var uid = $("#txtUser").val();
                var pass = $("#txtPass").val();

                $("#lblMsg").text("waiting for server..");

                $.ajax({
                    url: url,
                    data: { id: uid, password: pass },
                    type: 'GET',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function (result) {
                        console.log(result);
                        //if result = success, navigate home page
                        //else display error message
                        if (result.msg != "SUCCESS") {
                            $("#lblMsg").text(result.msg);
                        } else {
                            $(location).attr("href", "home/index");
                        }
                    },
                    error: function (error) {
                        console.log(error);
                        alert("error");
                    }
                });
            });
        });
    </script>



</head>
<body>
    <div class='bold-line'></div>
    <div class='container'>
        <div class='window'>
            <div class='overlay'></div>
            <div class='content'>
                <div class='welcome'>FlowR</div>
                <p></p>
                <div class='subtitle'>We're almost done. Before using our services, you must enter your credentials.</div>
                <div class='input-fields'>
                    
                 @Html.TextBox("txtUser",
                 Nothing,
                 New With {
                        .id = "txtUser",
                        .class = "input-line full-width",
                        .placeholder = "User ID"
                          }
                    )

                 @Html.Password("txtPass",
                    Nothing,
                    New With {
                          .id = "txtPass",
                          .class = "input-line full-width",
                          .placeholder = "password"
                    }
                )

            </div>

                <div>
                    <Button ID="btnLogin" class='ghost-round full-width login-button'>Let me in</Button>
                </div>
                <div class='spacing' id="lblMsg">
                    @RenderBody()
                </div>
            </div>
        </div>
    </div>
</body>
</html>
