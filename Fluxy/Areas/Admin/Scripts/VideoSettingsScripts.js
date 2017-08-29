function Add(url) {
    var videoSettingsObj = {
        Id: $('#Id').val(),
        FrameWidth: $('#FrameWidth').val(),
        FrameHeight: $('#FrameHeight').val(),
        FrameFilters: $('#FrameFilters').val()
    }
    $.ajax({
        url: url,
        data: JSON.stringify(videoSettingsObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#FrameWidth').val(result.FrameWidth);
            $('#FrameHeight').val(result.FrameHeight);
            $('#ShortName').val(result.ShortName);
            $('#FrameFilters').val(result.FrameFilters);
            $('#videoSettingsModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update(url) {
    var videoSettingsObj = {
        Id: $('#Id').val(),
        FrameWidth: $('#FrameWidth').val(),
        FrameHeight: $('#FrameHeight').val(),
        FrameFilters: $('#FrameFilters').val()
    }

    $.ajax({
        url: url,
        data: JSON.stringify(videoSettingsObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delele(url) {

    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                location.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

