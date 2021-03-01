const objectAttributeData = function () {
    function swapTrButtons(parentTr) {
        parentTr.find("td .edit").toggle();
        parentTr.find("td .delete").toggle();
        parentTr.find("td .update").toggle();
        parentTr.find("td .cancel").toggle();
    }

    $(".content").on("click", "tr .edit", function () {
            const parentTr = $(this).parents("tr");
            const valueTd = parentTr.find("td.attr-value");
            const value = valueTd.attr("data-id");

            // hide add form if exists
            if ($("#CreateForm div form").length) {
                $("#CreateForm div").html("").show();
                $("button.add").show();
            }

            valueTd.html('<input type="text" class="form-control" value=' + value + ">");
            swapTrButtons(parentTr);
    });

    $(".content").on("click", "tr .cancel", function () {
        const parentTr = $(this).parents("tr");
        const valueTd = parentTr.find("td.attr-value");

        valueTd.html(valueTd.attr("data-id"));
        swapTrButtons(parentTr);
    });

    $(".content").on("click", "tr .update", function () {
        const parentTr = $(this).parents("tr");
        const id = parentTr.attr("data-id");
        const newValueInput = parentTr.find("td.attr-value input");
        const newValue = newValueInput.val();

        if (newValue === "") {
            showFormError(newValueInput, "Lūdzu, aizpildiet vērtības lauku");
        } else {
            clearFormErrors(newValueInput);
            var attributeValue = new Object();
            attributeValue.Id = id;
            attributeValue.NewValue = newValue;

            $.ajax({
                type: "PUT",
                url: "/api/ObjectAttributesApi/",
                data: attributeValue,
                success: function () {
                    const valueTd = parentTr.find("td.attr-value");
                    valueTd.html("").text(newValue);
                    valueTd.attr("data-id", newValue);
                    swapTrButtons(parentTr);
                    showMessage("success", "Atribūta vērtība veiksmīgi izmainīta!");
                },
                error: function (response) {
                    showMessage("error", response.responseText);
                }
            });
        }
    });

// Delete opens modal
    $(".content").on("click", "tr .delete", function () {
        const parentTr = $(this).parents("tr");
        const id = parentTr.attr("data-id");

        // hide add form if exists
        if ($("#CreateForm div form").length) {
            $("#CreateForm div").html("").show();
            $("button.add").show();
        }

        $("#DeleteModal").modal("show");
        $("#DeleteModal .modal-body").html("Vai tiešām vēlaties dzēst attribūtu <strong>" +
            parentTr.find(".attr-name").text().trim() +
            "</strong>?");
        $("#DeleteModal .delete").attr("data-id", id);
    });

// Modal delete
    $("#DeleteModal").on("click", ".delete", function () {
        const id = $(this).attr("data-id");
        const parentTr = $('tr[data-id="' + id + '"]');

        $("#DeleteModal").modal("hide");

        $.ajax({
            type: "DELETE",
            url: "/api/ObjectAttributesApi/" + id,
            success: function () {
                if ($(".list table tbody tr").length >= 2) {
                    parentTr.fadeOut(300,
                        function () {
                            parentTr.remove();
                        });
                } else {
                    $(".list").html("");
                }
                showMessage("success", "Attribūts veiksmīgi dzēsts");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });
}
