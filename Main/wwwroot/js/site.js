// Write your JavaScript code.
$(document).ready(function() {
//    $("#btnCaracs").click(function () {
//        $.ajax({
//            url: "Characters/UpdateCaracs",
//            type: "POST",
//            data: {
//                Json.convert()
//            },
//            sucess: function(data) {
//                console.log(data);
//            },
//            error: function(data) {
//                console.log(data);
//            }
//        });
//    });

    $(".details").click(function () {
        var nomPerso = $(this).parent().attr("id");
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
    });

    var onSuccess = function () {
        var nomPerso = $("#nomPerso").text();
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
    };
});