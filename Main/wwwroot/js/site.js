// Write your JavaScript code.
$(document).ready(function () {
    function sleep(delay) {
        var start = new Date().getTime();
        while (new Date().getTime() < start + delay);
    }

    function loadDetails(nomPerso) {
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
    }

    $(".details").click(function () {
        var nomPerso = $(this).parent().attr("id");
        loadDetails(nomPerso);
    });
});