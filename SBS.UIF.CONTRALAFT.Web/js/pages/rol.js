(function ($) {

    

    $(".soloLetras").bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });
   
    function alertar(msg) {
        $("#mensaje").html(msg);
        $("#modal-alerta").modal('show');
    }

     
   
})(jQuery);

function showEdit(id, desTipo, detDetalle) {
    $('.txtId').val(id);
    $('.txtEditarPerfil').val(desTipo);
    $('.txtEditarDescripcion').val(detDetalle);
    $('#editarPerfil').modal('show');
}


function showInactive(id) {
    $('.txtIdInactive').val(id);
    $('#modal-inactivacion').modal('show');
}
