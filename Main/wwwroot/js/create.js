$(document).ready(function () {
    function reloadPersos(idPerso, anchor) {
        location.reload();
    }

    /* Envoie les données */
    $(".btn-submit-form").click(
        window.saveData("Characters/Create", reloadPersos)
    );
}