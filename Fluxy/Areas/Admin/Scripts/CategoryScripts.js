function Add(url) {
    var categoryObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val()
    }
    $.ajax({
        url: url,
        data: JSON.stringify(categoryObj),
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

$('#categoryModal').on('hide.bs.modal', function () {
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
            $('#Name').val(result.Name);
            $('#Description').val(result.Description);
            $('#categoryModal').modal('show');
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
    var categoryObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val()
    }
    debugger;
    $.ajax({
        url: url,
        data: JSON.stringify(categoryObj),
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

