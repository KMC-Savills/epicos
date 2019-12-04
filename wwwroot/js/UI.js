//var latitude = parseFloat($("#GPSLat").val());
//var longitude = parseFloat($("#GPSLon").val());
////var country = $("Country").val();
//var country = "Philippines";
//var coordinates = { lat: latitude, lng: longitude };
//var geocoder;
//var marker;
//var map;
//var mapOptions;
//var markerOptions;

function fileValidation() {
    var fileInput = document.getElementById('file');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert("Invalid file format!!");
        fileInput.value = '';
        return false;
    } else {
        //Image preview
        if (fileInput.files && fileInput.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById('imagePreview').innerHTML = '<img src="' + e.target.result + '"/>';
            };
            reader.readAsDataURL(fileInput.files[0]);
        }
    }
}

function valSelect() {
    var sel = document.getElementById('valsec').value;

    if (sel == "Select") {
        alert("Please select a gender!");
        return false;
    }
    else {
        alert("Great");
    }
}

//var map;
//function initMap() {
//    map = new google.maps.Map(document.getElementById('map'), {
//        center: { lat: 13.2548, lng: 123.6861 },
//        zoom: 12
//    });


//    var marker = new google.maps.Marker({
//        //var lat = marker.getPosition().lat();
//        //var lng = marker.getPosition().lng();
//        position: { lat: 13.2548, lng: 123.6861 },
//        map: map,
//        draggable: true
//    });


}
