// Write your JavaScript code.
$(document).ready(function () {
    function sleep(delay) {
        var start = new Date().getTime();
        while (new Date().getTime() < start + delay);
    }

    function loadDetails(idPerso) {
        $("#details").load(`Characters/GetDetails?idPerso=${idPerso}`);
    }

    function confirm() {
        return confirm("Êtes-vous certain ?");
    }

    /* Envoie les données */
    function saveData(urlToSend, funcOnSuccess) {
        var form = $(this).parent().parent();
        var idPerso = $(document).find("#idPerso").text();
        var anchor = form.parent().parent().parent().parent().attr("id");
        $(".modal-backdrop").remove();
        $.ajax({
            url: urlToSend,
            type: "POST",
            data: form.serialize(),
            success: function () {
                funcOnSuccess(idPerso, anchor);
            },
            error: function (message) {
                console.log(message);
                alert("Une erreur est survenue à l'enregistrement des données");
            }
        });
    }

    $(".details").click(function () {
        var idPerso = $(this).parent().attr("id");
        loadDetails(idPerso);
    });

    var redirectTo = function (url) {
        window.location.href = url;
    }
});