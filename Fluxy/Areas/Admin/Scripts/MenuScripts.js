﻿function Add(url) {
    var menuObj = {
        Id: $('#Id').val(),
        MenuAttributeId: $('#MenuAttributeId').val(),
        Name: $('#Name').val(),
        ShortName: $('#ShortName').val(),
        LinkText: $('#LinkText').val(),
        ActionName: $('#ActionName').val(),
        ControllerName: $('#ControllerName').val(),
    }
    $.ajax({
        url: url,
        data: JSON.stringify(menuObj),
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
            $('#MenuAttributeId').val(result.MenuAttributeId);
            $('#Name').val(result.Name);
            $('#ShortName').val(result.ShortName);
            $('#LinkText').val(result.LinkText);
            $('#ActionName').val(result.ActionName);
            $('#ControllerName').val(result.ControllerName);
            $('#myModal').modal('show');
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

    var url = url;
    var menuObj = {
        Id: $('#Id').val(),
        MenuAttributeId: $('#MenuAttributeId').val(),
        Name: $('#Name').val(),
        ShortName: $('#ShortName').val(),
        LinkText: $('#LinkText').val(),
        ActionName: $('#ActionName').val(),
        ControllerName: $('#ControllerName').val(),
    }

    $.ajax({
        url: url,
        data: JSON.stringify(menuObj),
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
