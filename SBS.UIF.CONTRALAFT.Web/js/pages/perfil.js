(function ($) {

    $('#idConfirmacion').click(function () {
        if ($('.txtNombrePerfil').val().trim() === '') {
            mensaje('Debe ingresar el nombre del perfil', 'Alerta');
            $('.txtNombrePerfil').addClass('form-control-danger')
            return;
        } else {
            $('.txtNombrePerfil').removeClass('form-control-danger');
        }
        if ($('.txtDescripcion').val().trim() === '') {
            mensaje('Debe ingresar la descripción del perfil', 'Alerta');
            $('.txtDescripcion').addClass('form-control-danger')
            return;
        } else {
            $('.txtDescripcion').removeClass('form-control-danger');
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

