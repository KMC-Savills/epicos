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
        zoom: 17,
        center: coordinates,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    showAllMarker();
}

function showAllMarker() {
    $.each(buildings, function (i, item) {

        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(item.Latitude, item.Longitude),
            map: map
        });

        var imageInfo =
            "<div class='card'>" +
            "<div class='card-body'>" +
            "<span style='color:black;font-size:14px'>" + item.Name +
            "</span>" + "<br/>" +
            "<span style='color: blue;'>" + item.Address + ", " + item.CityName + "</span>" +
            "</div>" +
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