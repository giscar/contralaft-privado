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