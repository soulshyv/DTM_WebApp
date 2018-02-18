// Write your JavaScript code.
$(document).ready(function () {
    function loadDetails(nomPerso) {
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
    }

    $(".details").click(function () {
        var nomPerso = $(this).parent().attr("id");
        loadDetails(nomPerso);
    });
});