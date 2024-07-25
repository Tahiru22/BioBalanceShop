$(document).ready(function () {
    $(".openModalBtn").click(function () {
        var productId = $(this).data("id");
        var productName = $(this).data("product");
        $("#deleteProduct").attr("value", productId);
        $("#productName").html(productName);
        $("#modalConfirmDelete").modal('show');
    });
});