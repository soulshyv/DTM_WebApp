// Write your JavaScript code.
$(document).ready(function () {
    console.log("coucou");
    $("#form-caracs").submit(function () {
        console.log("submit");
        //var form = $(this);
        //console.log(form);
        //$.ajax({
        //    url: "Characters/UpdateCaracs",
        //    type: "POST",
        //    data: form,
        //    sucess: function(data) {
        //        console.log(data);
        //    },
        //    error: function(data) {
        //        console.log(data);
        //    }
        //});
    });

    $(".details").click(function () {
        console.log("test");
        var nomPerso = $(this).parent().attr("id");
        $("#details").load("Characters/GetDetails?nomPerso=" + nomPerso);
    });
});