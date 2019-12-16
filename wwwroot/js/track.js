var latitude = parseFloat($("#Latitude").val());
var longitude = parseFloat($("#Longitude").val());
//var country = $("Country").val();
var country = "Philippines";
//var coordinates = { lat: 19.23, lng: 132.32 };
var coordinates = { lat: latitude, lng: longitude };
var geocoder;
var marker;
var map;
var mapOptions;
var markerOptions;


//$("#Address").on("focusout", function () {
//    codeAddress($("#Address").val() + ", " + country);
//});

$("#Latitude").on("focusout", function () {
    refreshCoordinates();
    initMap();
});

$("#Longitude").on("focusout", function () {
    refreshCoordinates();
    initMap();
});


function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 17,
        center: coordinates,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    marker = new google.maps.Marker({
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        position: coordinates
    });
    marker.addListener('click', toggleBounce);
    marker.addListener('dragend', updateCoordinates);
    var noPoi = [
        {
            featureType: 'poi.business',
            stylers: [{ visibility: 'off' }]
        },
        {
            featureType: 'transit',
            elementType: 'labels.icon',
            stylers: [{ visibility: 'off' }]
        }
    ];
    map.setOptions({ styles: noPoi });
}

function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

function refreshCoordinates() {
    latitude = parseFloat($("#Latitude").val());
    longitude = parseFloat($("#Longitude").val());
    coordinates = { lat: latitude, lng: longitude };
}

function updateCoordinates() {
    $("#Latitude").val(this.position.lat());
    $("#Longitude").val(this.position.lng());
    refreshCoordinates();
}