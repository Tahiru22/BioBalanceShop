$(document).ready(function () {
    $(".openModalBtn").click(function () {
        var userId = $(this).data("id");
        var userName = $(this).data("user");
        $("#deleteUser").attr("value", userId);
        $("#userName").html(userName);
        $("#modalConfirmDelete").modal('show');
    });
});