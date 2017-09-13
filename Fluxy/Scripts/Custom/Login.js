$('#btnLogout').click(function() {
    var form = document.getElementById('logoutForm').submit();
    $('#btnLogout').attr("href", form);
})