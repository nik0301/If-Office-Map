const mapData = function (floorId, search, types, filters, units, height, width) {
    // Global variables for Mapael
    var zoomResetContent = "&middot;";
    var zoomInContent = "&plus;";
    var zoomOutContent = "&minus;";

    const showMap = function (areas, height, width) {

        $(".mapcontainer").mapael({
            "map": {
                "name": "office_map",
                "zoom": {
                    "enabled": true,
                    "maxLevel": 10,
                    "animDuration": 200,
                    "buttons": {
                        "reset": {
                            "cssClass": "zoom-btn zoom-btn-reset",
                            "content": zoomResetContent,
                            "title": "Reset zoom"
                        },
                        "in": {
                            "cssClass": "zoom-btn zoom-btn-in",
                            "content": zoomInContent,
                            "title": "Zoom in"
                        },
                        "out": {
                            "cssClass": "zoom-btn zoom-btn-out",
                            "content": zoomOutContent,
                            "title": "Zoom out"
                        }
                    }
                },
                "defaultArea": {
                    "attrs": {
                        "fill": "none",
                        "stroke": "none",
                        "stroke-width": 1
                    },
                    "attrsHover": {
                        "fill": "rgb(91, 164, 255)",
                        "stroke": "none",
                        "animDuration": 0
                    },
                    "text": {
                        "attrs": {
                            "fill": "#000000"
                        },
                        "attrsHover": {
                            "fill": "#000000"
                        }
                    }
                }
            },
            "areas": areas
        });
    };

    const generateMap = function(paths, height, width) {
        (function (factory) {
            if (typeof define === 'function' && define.amd) {
                // AMD. Register as an anonymous module.
                define(['jquery', 'mapael'], factory);
            } else {
                // Browser globals
                factory(jQuery, jQuery.mapael);
            }

        }(function($, Mapael) {

            "use strict";

            var viewBoxHeight = height;
            var viewBoxWidth = width;
            var contentHeight = $(".content").height();
            var contentWidth = $(".content").width();

            if (height >= width) {
                viewBoxWidth = (height * contentWidth) / contentHeight;
            } else {
                viewBoxHeight = (width * contentHeight) / contentWidth;
            }

            $.extend(true, Mapael,
                {
                    maps: {
                        office_map: {
                            "width": viewBoxWidth,
                            "height": viewBoxHeight,
                            getCoords: function (lat, lon) {

                                return { 'x': x, 'y': y };
                            },
                            elems: paths
                        }
                    }
                }
            );

            return Mapael;
        }));
    };

    const createMap = function (search, types, filters, units, height, width) {
        $.ajax({
            method: "GET",
            dataType: "json",
            url: "api/MapAreaApi",
            data: {
                floorId: floorId,
                search: search,
                types: types,
                filters: filters,
                units: units
            }
        }).done(function (data) {
            var areas = {};

            $.each(data, function(key, value) {
                const text = {
                    content: value.text,
                    attrs: { "font-size": 14 }
                };

                const attrs = {
                    fill: value.fill,
                    stroke: value.stroke,
                    transform: "r" + value.rotationAngle
                };

                const attrsHover = {
                    stroke: value.stroke
                };

                areas[value.id] = {
                    attrs: attrs,
                    attrsHover: attrsHover,
                    text: text,
                    cssClass: value.cssClass
                };
            });

            showMap(areas, height, width);
        });
    };

    const loadFloor = function (floorId, search, types, filters, units, height, width) {
        $.ajax({
            method: "GET",
            dataType: "json",
            url: "api/PathApi",
            data: { floorId: floorId }
        }).done(function(data) {
            var paths = {};

            $.each(data,
                function(key, value) {
                    paths[value.id] = value.draw;
                });

            generateMap(paths, height, width);
            createMap(search, types, filters, units, height, width);
        });
    };

    // This executes immediately
    loadFloor(floorId, search, types, filters, units, height, width);

    // The only events and data available outside this function
    return {
        createMap: createMap
    };
};
