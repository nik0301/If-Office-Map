const menuData = function(urlObj, mapObj, searchValue, typesString, filtersString, unitsString) {
    var delimiter = ",";
    var text = "";
    var items = [];
    var filters = [];
    var units = [];

    const updateMap = function() {
        mapObj.createMap(text, items.join(delimiter), filters.join(delimiter), units.join(delimiter));
    };

    const search = function(searchValue) {
        text = searchValue;

        if (text) {
            urlObj.set("search", text);
        } else {
            urlObj.removeKey("search");
        }
        urlObj.replaceBrowserUrl();

        mapObj.createMap(text, items.join(","), filters.join(","));
    };

    const toggleType = function(typeTitle, status) {
        $("#object-type-dropdown span[data-id=" + typeTitle + "]").attr("hidden", !status);
        $("#object-type-dropdown a.type-link[data-id=" + typeTitle + "] em").attr("hidden", !status);
    };

    const showTypes = function() {
        for (var i = 0; i < items.length; i++) {
            const status = urlObj.hasValue("type", items[i]);

            toggleType(items[i], status);
        }
    };

    const toggleUnit = function(unitId, status) {
        $("#unit-dropdown span[data-id=" + unitId + "]").attr("hidden", !status);
        $("#unit-dropdown a.unit-link[data-id=" + unitId + "] em").attr("hidden", !status);
    };

    const showUnits = function() {
        for (var i = 0; i < units.length; i++) {
            const status = urlObj.hasValue("unit", units[i]);

            toggleUnit(units[i], status);
        }
    };

    const filter = function(typeTitle) {
        const status = urlObj.toggle("type", typeTitle);
        items = urlObj.values("type");

        toggleType(typeTitle, status);

        urlObj.replaceBrowserUrl();

        updateMap();
    };

    const filterWorkplaces = function(workplaceFilter) {
        urlObj.toggle("filters", workplaceFilter);
        filters = urlObj.values("filters");
        urlObj.replaceBrowserUrl();

        updateMap();
    };

    const filterUnits = function(unitId) {
        const status = urlObj.toggle("unit", unitId);
        units = urlObj.values("unit");

        toggleUnit(unitId, status);

        urlObj.replaceBrowserUrl();

        updateMap();
    };

    const setEvents = function() {
        $('form[role=search]').submit(function() {
            const text = $('input[type=search]').val();
            search(text);
            return false;
        });

        $('#object-type-dropdown .type-link').click(function() {
            const typeTitle = $(this).attr('data-id');
            filter(typeTitle);
            return false;
        });

        $('#free-workplaces').click(function() {
            filterWorkplaces("free workplaces");
            $(this).parent().toggleClass("active");
            return false;
        });

        $('#unit-dropdown .unit-link').click(function() {
            const unitId = $(this).attr('data-id');
            filterUnits(unitId);
            return false;
        });
    };

    const setActive = function(menu) {
        if (menu === "free workplaces") {
            $("#free-workplaces").parent().addClass("active");
        }
    };

    const init = function() {
        // initialize search
        text = searchValue;
        $('input[type=search]').val(text);

        // initialize types
        if (typesString) {
            items = typesString.split(delimiter);
            showTypes();
        }

        // initialize filters
        if (filtersString) {
            filters = filtersString.split(delimiter);

            if (filters.indexOf("free workplaces") > -1) {
                setActive("free workplaces");
            }
        }

        // initialize units
        if (unitsString) {
            units = unitsString.split(delimiter);
            showUnits();
        }

        setEvents();
    };

    // This executes immediately
    init();

    // The only events and data available outside this function
    return {
        init: init,
        search: search,
        filter: filter,
        filterWorkplaces: filterWorkplaces
    };
};
