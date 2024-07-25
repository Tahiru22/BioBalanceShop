$(document).ready(function () {
    var $msg = $('#siteMsg');

    if ($msg.html().trim().length > 0) {
        $msg.slideDown();
        $msg.css("display", "block")
    }
    setTimeout(function () {
        $msg.slideUp();
    }, 5000);
});