const objectAttributeAddData = function (columnName, columnValue, objectId) {
    $(".content").on("click", ".add", function () {
        $.ajax({
            type: "GET",
            url: "/ObjectAttribute/Create",
            data: {
                id: $(this).attr("data-id")
            },
            success: function (response) {
                $("button.add").hide();
                $("#CreateForm div").html(response).hide().slideDown();

                // add validation from model
                $.validator.unobtrusive.parse($('#CreateForm div form'));
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    $("#CreateForm").on("click", ".cancel", function () {
        $("#CreateForm div").slideUp(300, function () {
            $(this).html("").show();
            $("button.add").show();
        });
    });

// Attribute select
    $("#CreateForm").on("change", "#AttributeId", function () {
        if ($(this).val() === "other") {
            $(".new-attribute").show();

            $("#CreateForm form").find("#NewAttributeId").rules("add",
                {
                    required: true,
                    maxlength: 10,
                    messages: {
                        required: "Lūdzu aizpildiet ievadlauku",
                        maxlength: "Lūdzu ievadiet ne vairāk kā {0} rakstzīmes"
                    }
                });

            $("#CreateForm form").find("#NewAttributeName").rules("add",
                {
                    required: true,
                    maxlength: 50,
                    messages: {
                        required: "Lūdzu aizpildiet ievadlauku",
                        maxlength: "Lūdzu ievadiet ne vairāk kā {0} rakstzīmes"
                    }
                });
        } else {
            $(".new-attribute").hide();

            $("#CreateForm form").find("#NewAttributeId").rules("remove");
        }
    });

    $("#CreateForm").on("submit", "form", function (event) {
        event.preventDefault();

        var attributeSelect = $(this).find("#AttributeId");
        var isOther = false;
        var newAttrId;
        var newAttrName;
        var value = $(this).find("#Value").val();

        if (attributeSelect.val() === "other") {
            newAttrId = $(".new-attribute #NewAttributeId");
            newAttrName = $(".new-attribute #NewAttributeName");
            isOther = true;
        }

        var attributeName;
        var data;

        if (isOther) {
            attributeName = newAttrName.val();

            data = new Object();
            data.AttributeId = newAttrId.val();
            data.AttributeName = newAttrName.val();
            data.IsNewAttribute = true;
            data.ObjectId = objectId;
            data.Value = value;
        } else {
            data = $("#CreateForm form").serialize();
            attributeName = attributeSelect.find('option:selected').text();
        }

        $.ajax({
            url: "/api/ObjectAttributesApi/",
            type: "POST",
            data: data,
            success: function (newObjAttrId) {
                // remove Add form
                $("#CreateForm div").html("");
                $("button.add").show();

                // create table if not exists
                if (!$(".list table").length) {
                    $(".list").html([
                        '<table class="table">',
                        "<thead>",
                        "<tr>",
                        "<th>" + columnName + "</th>",
                        "<th>" + columnValue + "</th>",
                        '<th style="width: 25%">Opcijas</th>',
                        "</tr>",
                        "</thead>",
                        "<tbody></tbody>",
                        "</table>"
                    ].join(""));
                }

                // append row
                $(".list table tbody").append([
                    '<tr data-id="' + newObjAttrId + '">',
                    '<td class="attr-name">' + attributeName + '</td>',
                    '<td class="attr-value" data-id="' + value + '">' + value + '</td>',
                    "<td>",
                    '<div class="input-group">',
                    '<button class="btn bg-green edit">Labot</button>',
                    '<button class="btn bg-red delete">Dzēst</button>',
                    '<button class="btn bg-green update" style="display: none">Saglabāt</button>',
                    '<button class="btn bg-orange cancel" style="display: none">Atcelt</button>',
                    "</div>",
                    "</td>",
                    "</tr>"
                ].join(""));

                showMessage("success", "Atribūts veiksmīgi pievienots!");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });
};