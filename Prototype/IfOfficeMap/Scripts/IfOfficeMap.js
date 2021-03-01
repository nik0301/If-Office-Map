$(function () {
    $(".mapcontainer").mapael({
        map: {
            name: "finalmap",
            // Enable zoom on the map
            zoom: {
                enabled: true
            },
            // Set default plots and areas style
            //    defaultPlot: {
            //        attrs: {
            //            fill: "#004a9b",
            //            opacity: 0.6
            //        },
            //        attrsHover: {
            //            opacity: 1
            //        },
            //        text: {
            //            attrs: {
            //                fill: "#000"
            //            },
            //            attrsHover: {
            //                fill: "#000"
            //            }
            //        }
            //    },
                defaultArea: {
                    attrs: {
                        //fill: "#008ED5",
                        stroke: "#ced8d0"
                    },
                    attrsHover: {
                        fill: "#008ED5"
                    },
                    text: {
                        attrs: {
                            fill: "#000"
                        },
                        attrsHover: {
                            fill: "#fff"
                        }
                    }
                }
        },
        // Customize some areas of the map
        areas: {
            "department-56": {
                text: { content: "Kitchen", attrs: { "font-size": 10 } },
                tooltip: {
                    content: "Microwave, Refridgerator, Magazines, Coffee Maker"
                },
                href: "http://fr.wikipedia.org/wiki/Morbihan"
            },
            "department-21": {
                text: { content: "Kitchen 2", attrs: { "font-size": 10 } },
                attrs: {
                    fill: "#00BBFF"
                },
                attrsHover: {
                    fill: "#00BBFF"
                },
                href: "http://fr.wikipedia.org/wiki/C%C3%B4te-d%27Or",
                target: "_blank"
            },
            "department-29": {
                attrs: {
                    fill: "#00BBFF"
                },
                attrsHover: {
                    fill: "#00BBFF"
                },
                href: "http://fr.wikipedia.org/wiki/C%C3%B4te-d%27Or",
                target: "_blank"
            }
        },

        // Add some plots on the map
        plots: {
            // Image plot
            /*'paris': {
                              type: "image",
                              url: "http://www.neveldo.fr/mapael/assets/img/marker.png",
                              width: 12,
                              height: 40,
                              latitude: 48.86,
                              longitude: 2.3444,
                              attrs: {
                                  opacity: 1
                              },
                              attrsHover: {
                                  transform: "s1.5"
                              },
                              href: "http://fr.wikipedia.org/wiki/Paris",
                              target: "_blank"
                          },*/
            // Circle plot
            /*'lyon': {
                              type: "circle",
                              size: 50,
                              latitude: 45.758888888889,
                              longitude: 4.8413888888889,
                              value: 700000,
                              tooltip: {content: "<span style=\"font-weight:bold;\">City :</span> Lyon"},
                              text: {content: "Lyon"},
                              href: "http://fr.wikipedia.org/wiki/Lyon"
                          },*/
            // Square plot
            "John Doe": {
                type: "circle",
                size: 20,
                x: 26,
                y: 100,
                tooltip: {
                    content:
                    '<span style="font-weight:bold;"><h2>John Doe</h2><br>Software Engineer</span> <br>Available',
                    cssClass: "customTooltip"
                },
                //text: { content: "John Doe", size: "35" },
                href: "#"
            },
            "John Doe 2": {
                type: "circle",
                size: 40,
                x: 660,
                y: 165,
                latitude: 49.114166666667,
                longitude: 2.6808333333333,
                tooltip: {
                    content:
                        '<span style="font-weight:bold;">Software Engineer</span> <br>Away'
                },
                text: { content: "John Doe 2", size: "35" },
                href: "#",
                attrs: {
                    fill: "yellow"
                }
            }
        }
    });
});
