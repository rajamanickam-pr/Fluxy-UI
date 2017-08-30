$('#attributeTable').dataTable();
function Add(url) {
    var menuAttributeObj = {
        Id: $('#Id').val(),
        AttributeKey: $('#AttributeKey').val(),
        AttributeValue: $('#AttributeValue').val()
    }
    $.ajax({
        url: url,
        data: JSON.stringify(menuAttributeObj),
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

$('#attributeModal').on('hide.bs.modal', function () {
    $(this)
        .find('input,textarea')
        .val('')
        .end()
        .find('input[type=checkbox],input[type=radio]')
        .prop('checked', '')
        .end()
        .find('select')
        .find('option')
        .remove()
        .end();
})

function getbyID(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#AttributeValue').val(result.AttributeValue);
            $('#AttributeKey').val(result.AttributeKey);
            $('#attributeModal').modal('show');
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
    var menuAttributeObj = {
        Id: $('#Id').val(),
        AttributeKey: $('#AttributeKey').val(),
        AttributeValue: $('#AttributeValue').val()
    }
    debugger;
    $.ajax({
        url: url,
        data: JSON.stringify(menuAttributeObj),
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

