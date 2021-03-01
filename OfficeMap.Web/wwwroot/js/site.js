const siteData = function () {
    var clickedPathFillColor = "rgb(91, 164, 255)";

/* Map events */
    var prevPath = null;

    $(".map").on("click", "path", function (event) {
        const mapPath = event.target;
        const dataId = mapPath.getAttribute("data-id");
        const objId = dataId.substring(dataId.indexOf("_") + 1);

        if (prevPath) {
            prevPath.style.fill = "";
        }

        mapPath.style.fill = clickedPathFillColor;
        prevPath = mapPath;

        $(".details-sidebar .details-main").html("");
        $(".details-sidebar .details-options").html("");
        detailsObj.setId(objId);
        detailsObj.show();
    });

/* Navbar events */
    $(".collapse-btn").click(function () {
        $(".details-sidebar").slideUp(100);
    });
};
