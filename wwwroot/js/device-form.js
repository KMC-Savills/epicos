$("#OfficeID").on("change", function () {
    initDropdown();
});
$(document).ready(function () {
    initDropdown();
});
function initDropdown() {
    console.log("Working!!!");
    var requestURL = "/api/floor/getbyofficeid/" + $("#OfficeID").val();
    $.getJSON(requestURL).done(function (floors) {
        if (floors != null) {
            $('#hidden-floor').html('');
            $.each(floors, function (i, item) {
                $("#hidden-floor").append(new Option(item.name, item.id));
                var f = document.getElementById("hidden-floor");
                var flr = f.options[f.selectedIndex].value;
                document.getElementById("FloorID").value = flr;
                console.log(flr);
            });
        }
    });
}
$("#hidden-floor").on("change", function () {
    var f = document.getElementById("hidden-floor");
    var flr = f.options[f.selectedIndex].value;
    document.getElementById("FloorID").value = flr;
    console.log(flr);
})
