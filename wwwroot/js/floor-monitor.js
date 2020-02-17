
$(document).ready(function () {

    setInterval(function () {
        refreshOccupancy();
    }, 5000);
});
function refreshOccupancy() {
    var url = '/api/device/telemery/list';
    var dt = new Date();
    var currentStart = + dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate() + " " + dt.getHours() + ":" + ((dt.getMinutes() > 5) ? dt.getMinutes() - 5 : dt.getMinutes()) + ":" + dt.getSeconds();
    var currentTime = + dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate() + " " + dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();

    var filter = new Object();
    filter.DateStart = currentStart;
    filter.DateEnd = currentTime;
    filter.OfficeID = getOfficeID;
    filter.FloorID = getFloorID;

    var parameter = JSON.stringify(filter);

    $.ajax({
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        url: url,
        data: parameter,
        processData: false,
        success: function (xd) {
            $(".workpoint").removeClass("green");
            $.each(xd, function (i, item) {
                $("#workpoint-" + item.getWorkpointID  ).addClass("green");
                console.log(item.getWorkpointID + "HAHAHA");
            });
        }
    });
}
