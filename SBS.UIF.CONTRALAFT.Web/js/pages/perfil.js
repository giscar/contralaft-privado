(function ($) {

    $('#idConfirmacion').click(function () {
        if ($('.txtNombrePerfil').val().trim() === '') {
            $('.txtNombrePerfil').addClass('form-control-danger');
            $('.txtNombrePerfilLabel').addClass('text-danger').removeClass('text-muted');
            return false;
        } else {
            $('.txtNombrePerfil').removeClass('form-control-danger');
            $('.txtNombrePerfilLabel').removeClass('text-danger').addClass('text-muted');
        }

        if ($('.txtDescripcion').val().trim() === '') {
            $('.txtDescripcion').addClass('form-control-danger');
            $('.txtDescripcionLabel').addClass('text-danger').removeClass('text-muted');
            return false;
        } else {
            $('.txtDescripcion').removeClass('form-control-danger');
            $('.txtDescripcionLabel').removeClass('text-danger').addClass('text-muted');
        }
        $('#confirmacion').modal('show');
    })

    $(".soloLetras").bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    }); 
   
})(jQuery);

function validaEditarPerfilClient() {
    if ($('.txtEditarDescripcion').val().trim() === '') {
        $('.txtEditarDescripcion').addClass('form-control-danger');
        $('.txtEditarDescripcionLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtEditarDescripcion').removeClass('form-control-danger');
        $('.txtEditarDescripcionLabel').removeClass('text-danger').addClass('text-muted');
    }
    return true;
}