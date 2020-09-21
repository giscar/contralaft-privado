function showInactiv(msg) {
    console.log(1)
    $("#mensaje").html(msg);
    $('#modal-alerta').modal('show');
}


function mensaje(msg, title) {
    $("#mensaje").html(msg);
    $("#titulo").html(title);
    $("#modal-alerta").modal('show');
    
}

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

$(".soloLetras").bind('keypress', function (event) {
    var regex = new RegExp("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
});

$(".soloNumeros").bind('keypress', function (event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
});