$('#SubCategoryModal').on('show.bs.modal', function () {
    var url = 'Category/GetList';
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (data) {
            $("#SelectedCategory").empty();
            $.each(data, function (i) {
                var optionhtml = '<option value="' +
                    data[i].Id + '">' + data[i].Name + '</option>';
                $("#SelectedCategory").append(optionhtml);
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
})


function Add(url) {
    var subCategoryObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        CategoryId: $('#SelectedCategory').val(),
        Description: $('#Description').val()
    }
    $.ajax({
        url: url,
        data: JSON.stringify(subCategoryObj),
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
            $('#Name').val(result.Name);
            $("#SelectedCategory selected").val(result.CategoryId);
            $('#Description').val(result.Description); 
            $('#SubCategoryModal').modal('show');
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
    var subCategoryObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        CategoryId: $('#SelectedCategory').val(),
        Description: $('#Description').val()
    }
    debugger;
    $.ajax({
        url: url,
        data: JSON.stringify(subCategoryObj),
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

