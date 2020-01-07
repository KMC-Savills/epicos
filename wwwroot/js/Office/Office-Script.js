var latitude = parseFloat($("#GPSLat").val());
var longitude = parseFloat($("#GPSLon").val());
var buildings = JSON.parse($("#Buildings").val());
var country = "Philippines";
var coordinates = { lat: latitude, lng: longitude };
var markers = [];
var infowindows = [];
var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 15,
        center: coordinates,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    showAllMarker();
}

function showAllMarker() {
    $("#officeList .office-item").each(function (i, item) {
        var lat = $(this).attr("data-latitude");
        var long = $(this).attr("data-longitude");
        var ID = $(this).attr("data-id");

        var officeName = $("#officesName").text();

        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(lat, long),
            map: map
        });

        var imageInfo =
            "<span style='color:blue;font-size:14px'>" + officeName + "</span>"


        var infowindow = new google.maps.InfoWindow({
            content: imageInfo
        });

        google.maps.event.addListener(marker, 'click', function () {
            var i;
            for (i = 0; i < infowindows.length; i++) {
                infowindows[i].close();
            }
            infowindow.open(map, marker);
        });

        if (ID != 0) {
            marker.addListener('mouseover', function () {
                infowindow.open(map, this);

            });

            // assuming you also want to hide the info window when user mouses-out
            marker.addListener('mouseout', function () {
                infowindow.close();
            });
        }

        markers.push(marker);

    });

    $.each(buildings, function (i, item) {

        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(item.Latitude, item.Longitude),
            map: map
        });

        var imageInfo =
            "<div class='card'>" +
            "<div class='card-body'>" +
            "<span style='color:blue;font-size:14px'>" + item.Name + "</span>" +
            "</div>"
        "</div>";

        var infowindow = new google.maps.InfoWindow({
            content: imageInfo
        });

        infowindows.push(infowindow);

        google.maps.event.addListener(marker, 'click', function () {
            var i;
            for (i = 0; i < infowindows.length; i++) {
                infowindows[i].close();
            }
            infowindow.open(map, marker);
        });

        if (item.ID != 0) {
            marker.addListener('mouseover', function () {
                infowindow.open(map, this);

            });

            // assuming you also want to hide the infowindow when user mouses-out
            marker.addListener('mouseout', function () {
                infowindow.close();
            });
        }

        markers.push(marker);

    });
}

function centerMap(x, y) {
    latitude = x;
    longitude = y;
    coordinates = { lat: latitude, lng: longitude };

    map.setCenter(coordinates);

    for (var i = 0; i < buildings.length; i++) {
        if (markers[i].coordinates === coordinates) {
            google.maps.event.trigger(markers[i], 'click');

        }
    };
}