//$(document).ready(function () {

//    var alertClass = "alert";
//    var dangerClass = "alert-danger";

//    /* Charge les détails du personnage */
//    function loadDetails(idPerso, anchor) {
//        $("#details").empty();
//        $("#details").load("Characters/GetDetails?idPerso=" + idPerso);

//        if (anchor !== null && anchor !== "") {
//            var jump = $("button[data-target=" + anchor + "]");
//            window.scrollTo(0, $("#" + jump));
//        }
//    }

//    /* Envoie les données et recharge les détails */
//    $(".btn-submit-form").click(
//        window.saveData("Characters/Update", loadDetails)
//    );

//    /* Envoie la nouvelle image du personnage et recharge la page */
//    $("#btn-submit-file").click(function () {
//        var form = $(this).parent().parent();
//        var anchor = form.parent().parent().parent().parent().attr("id");
//        var fileUpload = $("#picUpload").get(0);
//        var files = fileUpload.files;
//        var data = new FormData();
//        var nomPerso = $(document).find("#nomPerso").text();
//        var idPerso = $(document).find("#idPerso").text();
//        data.append(files[0].name, files[0]);
//        data.append("nomPerso", nomPerso);
//        $(".modal-backdrop").remove();
//        $.ajax({
//            type: "POST",
//            url: "/Characters/UpdatePic",
//            contentType: false,
//            processData: false,
//            data: data,
//            success: function () {
//                loadDetails(idPerso, anchor);
//            },
//            error: function (message) {
//                console.log(message);
//                alert("Une erreur est survenue pendant l'upload du fichier");
//            }
//        });
//    });

//    /* Récupère et affiche la description du don sélectionné */
//    $(".donLibelleInput").change(function () {
//        var libelle = $(this).val();
//        var donDesc = $(this).parent().find(".donDescInput");
//        var inputDesc = $(this).parent().parent().find(".elementDescInput");
//        var data = new FormData();
//        data.append("libelle", libelle);
//        $.ajax({
//            type: "POST",
//            url: "/Characters/GetDonByLibelle",
//            contentType: false,
//            processData: false,
//            data: data,
//            success: function (res) {
//                donDesc.text(res);
//                inputDesc.val(res);
//            },
//            error: function (message) {
//                console.log(message);
//                alert("Une erreur est survenue pendant la recherche des données");
//            }
//        });
//    });

//    /* Récupère et affiche la description de l'élément sélectionné */
//    $(".elementLibelleInput").change(function () {
//        var libelle = $(this).val();
//        var elementDesc = $(this).parent().parent().find(".elementDesc");
//        var inputDesc = $(this).parent().parent().find(".elementDescInput");
//        var data = new FormData();
//        data.append("libelle", libelle);
//        $.ajax({
//            type: "POST",
//            url: "/Characters/GetElementByLibelle",
//            contentType: false,
//            processData: false,
//            data: data,
//            success: function (res) {
//                elementDesc.text(res);
//                inputDesc.val(res);
//            },
//            error: function (message) {
//                console.log(message);
//                alert("Une erreur est survenue pendant la recherche des données");
//            }
//        });
//    });

//    /* Récupère et affiche les détails du démon sélectionné */
//    $(".demonNomInput").change(function () {
//        var nom = $(this).val();
//        var demonPassif = $(this).parent().parent().find(".demonPassifDetails");
//        var data = new FormData();
//        data.append("nom", nom);
//        $.ajax({
//            type: "POST",
//            url: "/Characters/GetPassifDemonByNomDemon",
//            contentType: false,
//            processData: false,
//            data: data,
//            success: function (res) {
//                demonPassif.text(res);
//            },
//            error: function (message) {
//                console.log(message);
//                alert("Une erreur est survenue pendant la recherche des données");
//            }
//        });
//    });

//    /* Récupère et affiche la description du skill sélectionné */
//    $(".elementLibelleInput").change(function () {
//        var libelle = $(this).val();
//        var elementDesc = $(this).parent().parent().find(".elementDesc");
//        var inputDesc = $(this).parent().parent().find(".elementDescInput");
//        var data = new FormData();
//        data.append("libelle", libelle);
//        $.ajax({
//            type: "POST",
//            url: "/Characters/GetSkillByLibelle",
//            contentType: false,
//            processData: false,
//            data: data,
//            success: function (res) {
//                elementDesc.text(res);
//                inputDesc.val(res);
//            },
//            error: function (message) {
//                console.log(message);
//                alert("Une erreur est survenue pendant la recherche des données");
//            }
//        });
//    });

//    /* Vérifie qu'on ne sélectionne pas plusieurs fois la même chose dans différents select d'un même formulaire */
//    $(".libelleInput").change(function () {
//        var parent = $(this).parent().parent().parent().parent().parent();
//        var allLibelleInputs = parent.find(".libelleInput");

//        var btn = parent.find("button.btn-submit-form");
//        btn.prop("disabled", false);

//        if (allLibelleInputs.length > 1) {
//            allLibelleInputs.each(function () {
//                this.classList.remove(alertClass);
//                this.classList.remove(dangerClass);
//            });

//            for (var i = 0; i < allLibelleInputs.length; i++) {
//                for (var j = 0; j < allLibelleInputs.length; j++) {
//                    if (i === j) {
//                        continue;
//                    }

//                    if (allLibelleInputs[i].value === allLibelleInputs[j].value) {
//                        allLibelleInputs[i].classList.add(alertClass);
//                        allLibelleInputs[i].classList.add(dangerClass);
//                        allLibelleInputs[j].classList.add(alertClass);
//                        allLibelleInputs[j].classList.add(dangerClass);
//                        btn.prop("disabled", true);
//                    }
//                }
//            }
//        }
//    });

//    /* Vérifie les taux des dons et désactive ou active le bouton de validation du formulaire en conséquences */
//    $(".donTauxInput").change(function () {
//        var donTauxInputs = $(".donTauxInput");
//        var input10 = 0;
//        var input15 = 0;
//        var input20 = 0;

//        donTauxInputs.each(function () {
//            if (this.value === "10") {
//                input10 += 1;
//            } else {
//                if (this.value === "15") {
//                    input15 += 1;
//                } else {
//                    input20 += 1;
//                }
//            }
//        });

//        var btn = $("#btn-don");
//        btn.prop("disabled", false);

//        donTauxInputs.each(function () {
//            this.classList.remove(alertClass);
//            this.classList.remove(dangerClass);

//            if (this.value === "10" && input10 !== 1 || this.value === "15" && input15 !== 2 || this.value === "20" && input20 !== 1) {
//                this.classList.add(alertClass);
//                this.classList.add(dangerClass);
//                btn.prop("disabled", true);
//            }
//        });
//    });

//});