(function ($) {

    $('#idConfirmacion').click(function () {
        console.log($('.txtNombrePerfil').val());
        if ($('.txtNombrePerfil').val().trim() === '') {
            alertar('Debe ingresar el nombre del perfil')
            $('.txtNombrePerfil').addClass('form-control-danger')
            return;
        } else {
            $('.txtNombrePerfil').removeClass('form-control-danger');
        }
        if ($('.txtDescripcion').val().trim() === '') {
            alertar('Debe ingresar la descripción del perfil')
            $('.txtDescripcion').addClass('form-control-danger')
            return;
        } else {
            $('.txtDescripcion').removeClass('form-control-danger');
        }
        $('#modal-confirmacion').modal('show');
    })

    $(".soloLetras").bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });
   
    function alertar(msg) {
        $("#modal-alerta").modal('show');
        $("#mensaje").html(msg);
    }

     
   
})(jQuery);

function showEdit(id, desTipo, detDetalle) {
    $('.txtId').val(id);
    $('.txtEditarPerfil').val(desTipo);
    $('.txtEditarDescripcion').val(detDetalle);
    $('#editarPerfil').modal('show');
}
