/*For Edit Device*/
if (window.location.href.indexOf('Edit') != -1) {
    $("#OfficeID").on("change", function () {

        $('#hidden-floor').html('');
        initDropdown();
    });
    $(document).ready(function () {
        var mFloor = $("#FloorID").val();
        $('#hidden-floor option').each(function () {
            if ($(this).val() == mFloor) {
                $(this).hide();
            } else {
                console.log("Not Match!");
            }
        });

        initDropdown();
    });
    function initDropdown() {
        console.log("Edit Working!!!");
        var requestURL = "/api/floor/getbyofficeid/" + $("#OfficeID").val();
        var hFloor = $("#hidden-floor").val();
        var mFloor = $("#FloorID").val();
        console.log("Hidden floor = " + hFloor);
        console.log("Model floor = " + mFloor);

        $.getJSON(requestURL).done(function (floors) {
            if (floors != null) {
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
    });

} else {

    /*For Add Device*/
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
    });
}
