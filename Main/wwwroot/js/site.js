// Write your JavaScript code.
$(document).ready(function () {
    function sleep(delay) {
        var start = new Date().getTime();
        while (new Date().getTime() < start + delay);
    }

    function getCharacPicture(nomPerso) {
        var data = new FormData();
        data.append("nomPerso", nomPerso);
        $.ajax({
            type: "POST",
            url: "/Characters/GetPicture",
            processData: false,
            contentType: false,
            data: data,
            success: function (res) {
                document.getElementById("characPic").src = res + "?" + (new Date()).getTime();
            },
            error: function (message) {
                console.log(message);
            }
        });
    };

    function loadDetails(nomPerso) {
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
        getCharacPicture(nomPerso);
    }

    $(".details").click(function () {
        var nomPerso = $(this).parent().attr("id");
        loadDetails(nomPerso);
    });
});