$(document).ready(function () {
    $('.wp-submit').click(function () {
        var devices = JSON.parse($("#Devices").val());
        var workpoints = new Array();
        for (var i = 0; i < devices.length; i++) {
            devices[i].CoordinateX = $('[id="CoordinateX-' + devices[i].ID + '"]').eq(0).val();
            devices[i].CoordinateY = $('[id="CoordinateY-' + devices[i].ID + '"]').eq(0).val();
            devices[i].CoordinateZ = $('[id="CoordinateZ-' + devices[i].ID + '"]').eq(0).val();
            workpoints.push(devices[i].CoordinateX);
            workpoints.push(devices[i].CoordinateY);
            workpoints.push(devices[i].CoordinateZ);
        }

        $.post('@Url.Action("Assign", "Floor")', { 'Workpoints': devices },
            function () {
                console.log("Success!");
            });
    });
});

$(function () {
    $(".drag").draggable({
        revert: "invalid",
        helper: 'clone',
    });
    $("#frame").droppable({
        accept: '.drag',
        drop: function (event, ui) {
            var element = $(ui.draggable).clone();
            var id = element.attr('id');
            var left = ui.offset.left - $(this).offset().left;
            var top = ui.offset.top - $(this).offset().top;
            var coorID = $(".coordinates-" + id).attr('id');
            console.log("The ID:" + id);
            console.log("Coordinate ID: " + coorID);

            if (id == coorID) {
                $('[id="CoordinateX-' + id + '"]').eq(0).val(left);
                $('[id="CoordinateY-' + id + '"]').eq(0).val(top);
            }

            if ($('#frame').find('#' + id).length == 0) {
                $(this).append(element);
                $("#frame .drag").addClass("item " + id);
                $("." + id).removeClass("ui-draggable drag");
                $("." + id).css({
                    "left": left,
                    "top": top
                });
                $('.' + id).html('<img id="image_' + id + '" src="/images/1.png" class="image" style="width:30px; height:auto" />');
                $(".item" + '.' + id).draggable({
                    containment: 'frame',
                    drag: function (event, ui) {
                        var id = ui.helper.attr('id');
                        var X = $("#" + id).css("left");
                        var Y = $("#" + id).css("top");
                        X = X.split("px");
                        Y = Y.split("px");
                        console.log("ID Drag:" + id);
                        console.log("Left: " + X);
                        console.log("Top: " + Y);
                        if (id == coorID) {
                            $('[id="CoordinateX-' + id + '"]').eq(0).val(X[0]);
                            $('[id="CoordinateY-' + id + '"]').eq(0).val(Y[0]);
                        }
                        image(id);
                    }
                });
                image(id);
            }
        }

    });
});

function image(id) {
    var img = $('#image_' + id);
    var rotationCoorID = $(".coordinates-" + id).attr('id');
    if (img.length > 0) {
        var offset = img.offset();
        function mouse(event) {
            if (event.shiftKey) {
                var center_x = (offset.left) + (img.width() / 2);
                var center_y = (offset.top) + (img.height() / 2);
                var mouse_x = event.pageX;
                var mouse_y = event.pageY;
                var radians = Math.atan2(mouse_x - center_x, mouse_y - center_y);
                var degree = (radians * (180 / Math.PI) * -1) + 90;
                img.css('-moz-transform', 'rotate(' + degree + 'deg)');
                img.css('-webkit-transform', 'rotate(' + degree + 'deg)');
                img.css('-o-transform', 'rotate(' + degree + 'deg)');
                img.css('-ms-transform', 'rotate(' + degree + 'deg)');
                if (id == rotationCoorID) {
                    $('[id="CoordinateZ-' + id + '"]').eq(0).val(degree);
                }
                console.log(degree);
            }
        }

        $('#image_' + id).mousemove(mouse);
    }
}
$(document).ready(function () {
    $('#hub_li').click(function () {
        var frame = $('#workDefault').html();
        $('#workClone').html(frame);
    });
    $('#work_li').click(function () {
        $('#workClone').html('');
    });
});
function show_workpoint(arg) {
    $('#hub_a_options').hide();
    $('#hub_b_options').hide();
    if (arg == 'hub_a') {
        $('#hub_a_options').show();
    } else if (arg == 'hub_b') {
        $('#hub_b_options').show();
    }
    $('#workClone').find('.hub_a').removeClass('higlight');
    $('#workClone').find('.hub_b').removeClass('higlight');
    $('#workClone').find("." + arg).addClass('higlight');
}
