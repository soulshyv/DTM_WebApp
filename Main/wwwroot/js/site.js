// Write your JavaScript code.
$(document).ready(function() {
    $(".details").click(function () {
        $.ajax({
            url: "Characters/Details",
            type: "POST",
            data: {nomPerso: $(this).parent().attr("id")},
            sucess: function(data) {
                console.log(data);
            },
            error: function(data) {
                console.log(data);
            }
        });
    });
});