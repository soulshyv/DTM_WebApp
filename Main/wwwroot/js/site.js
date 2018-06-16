// Write your JavaScript code.
$(document).ready(function () {
    function sleep(delay) {
        var start = new Date().getTime();
        while (new Date().getTime() < start + delay);
    }

    function loadDetails(idPerso) {
        $("#details").load("Characters/GetDetails?idPerso=" + idPerso);
    }

    $(".details").click(function () {
        var idPerso = $(this).parent().attr("id");
        loadDetails(idPerso);
    });
});