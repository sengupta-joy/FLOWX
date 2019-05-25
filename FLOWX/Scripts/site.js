$(document).ready(function () {
    $(".nav-link").click(function () {
        console.debug(this);
        $(this).parent().find(".sub-menu").toggle("slow");
    });

    $(".page-menu").click(function () {
        var frm = $("#frmMain");
        var url = $(this).attr("href");

        $(frm).css("display","none");
        $(frm).attr("src", url);
        $(frm).fadeIn("slow");
        return false;
    })

});