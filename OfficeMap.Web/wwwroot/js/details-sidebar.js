const detailsSidebarData = function () {
    var objectId;

    const setId = function (id) {
        objectId = id;
    }

    const getStatusColor = function (status) {
        switch (status) {
            case "Online":
                return "green";
            case "BeRightBack":
            case "Away":
                return "orange";
            case "Busy":
            case "DoNotDisturb":
                return "red";
            default:
                return "default";
        }
    };

    const showWorkplaceOptions = function () {
        $.ajax({
            method: "GET",
            url: "/Details/WorkplaceData/",
            data: {
                id: objectId
            },
            success: function (response) {
                $(".details-sidebar .details-options").html(response);
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    };

    const showEmployeeStatus = function () {
        var elem = $(".details-employee .employee-email");

        if (elem.length) {
            var email = elem.attr("data-id");

            if (email) {
                $.ajax({
                    url: "/Details/EmployeeStatus",
                    data: {
                        email: email
                    },
                    success: function (status) {
                        var statusColor = getStatusColor(status);
                        var statusToDisplay = status.replace(/([A-Z])/g, " $1").trim();

                        $(".details-content .label-status").addClass("bg-" + statusColor);
                        $(".details-content .label-status").text(statusToDisplay).hide().fadeIn();
                        $(".details-content .circle-avatar").attr("class", "circle-avatar border-" + statusColor);
                    }
                });
            }
        }
    };

    const show = function () {
        $.ajax({
            method: "GET",
            url: "/Details/Get/",
            data: {
                id: objectId
            },
            success: function(response) {
                $(".details-sidebar .details-main").html(response);

                if (!$(".details-sidebar").is(":visible")) {
                    $(".details-sidebar").slideDown();
                }

                showEmployeeStatus();
                showWorkplaceOptions();
            },
            error: function(response) {
                showMessage("error", response.responseText);
            }
        });
    };

// Events
    $(".details-sidebar").on("click", ".details-close", function () {
        $(".details-sidebar").fadeOut();
    });

    $(".details-sidebar").on("click", ".change-workplace-employee .btn", function (event) {
        $.ajax({
            url: "/Details/WorkplaceEmployeeSet",
            method: "GET",
            data: {
                id: objectId
            },
            success: function (response) {
                $(event.target).hide();
                $(".details-sidebar .changes-list").hide();
                $("#ChangeContainer .form-container").html(response);
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    $(".details-sidebar").on("click", "#ProposesAcceptForm .accept", function (event) {
        const id = $(event.target).parent().find(".employee-list").val();

        $.ajax({
            url: "/Details/AcceptProposal",
            method: "POST",
            data: {
                id: id
            },
            success: function () {
                show();
                showMessage("success", "Darba vieta pieprasījums veiksmīgi apstiprināts");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    $(".details-sidebar").on("click", "#ProposesAcceptForm .decline", function (event) {
        const id = $(event.target).parent().find(".employee-list").val();
        var select = $(".form-control.employee-list");

        clearFormErrors(select);

        if (id) {
            $.ajax({
                url: "/Details/DeclineProposal",
                method: "POST",
                data: {
                    id: id
                },
                success: function() {
                    showWorkplaceOptions();
                    showMessage("success", "Darba vietas pieprasījums noraidīts");
                },
                error: function(response) {
                    showMessage("error", response.responseText);
                }
            });
        } else {
            showFormError(select, "Izvēlieties personu", true);
        }
    });

    $(".details-sidebar").on("click", "#ChangeEmployeeForm .save", function (event) {
        const id = $(event.target).parent().find(".employee-list").val();

        $.ajax({
            url: "/Details/WorkplaceEmployeeSet",
            method: "POST",
            data: {
                id: objectId,
                employeeId: id
            },
            success: function () {
                show();
                showMessage("success", "Persona veikmīgi pievienota darba vietai");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    $(".details-sidebar").on("click", "#ChangeEmployeeForm .cancel", function () {
        $("#ChangeContainer .form-container").html("");
        $(".change-workplace-employee .btn").show();
        $(".details-sidebar .changes-list").show();
    });

    $(".details-sidebar").on("click", ".sitting-here .btn", function () {
        $.ajax({
            url: "/Details/SendProposal",
            method: "GET",
            data: {
                id: objectId
            },
            success: function () {
                showWorkplaceOptions();
                showMessage("success", "Pieprasījums veiksmīgi nosūtīts!");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    $(".details-sidebar").on("click", ".release-workplace .btn", function () {
        $.ajax({
            url: "/Details/ReleaseWorkplace",
            method: "POST",
            data: {
                id: objectId
            },
            success: function () {
                show();
                showMessage("success", "Darba vieta veiksmīgi atbrīvota");
            },
            error: function (response) {
                showMessage("error", response.responseText);
            }
        });
    });

    // The only events and data available outside this function
    return {
        setId: setId,
        show: show
    };
}
