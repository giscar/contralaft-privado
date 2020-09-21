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

(function ($) {
    'use strict';
    $(function () {
        $('.icheck input').iCheck({
            checkboxClass: 'icheckbox_minimal-blue',
            radioClass: 'iradio_minimal',
            increaseArea: '20%'
        });
        $('.icheck-square input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square',
            increaseArea: '20%'
        });
        $('.icheck-flat input').iCheck({
            checkboxClass: 'icheckbox_flat-blue',
            radioClass: 'iradio_flat',
            increaseArea: '20%'
        });
        var icheckLineArray = $('.icheck-line input');
        for (var i = 0; i < icheckLineArray.length; i++) {
            var self = $(icheckLineArray[i]);
            var label = self.next();
            var label_text = label.text();

            label.remove();
            self.iCheck({
                checkboxClass: 'icheckbox_line-blue',
                radioClass: 'iradio_line',
                insert: '<div class="icheck_line-icon"></div>' + label_text
            });
        }
        $('.icheck-polaris input').iCheck({
            checkboxClass: 'icheckbox_polaris',
            radioClass: 'iradio_polaris',
            increaseArea: '20%'
        });
        $('.icheck-futurico input').iCheck({
            checkboxClass: 'icheckbox_futurico',
            radioClass: 'iradio_futurico',
            increaseArea: '20%'
        });
    });
})(jQuery);

$('#idConfirmacion').click(function () {
    if ($('.txtNombreRol').val().trim() === '') {
        $('.txtNombreRol').addClass('form-control-danger');
        $('.txtNombreRolLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtNombreRol').removeClass('form-control-danger');
        $('.txtNombreRolLabel').removeClass('text-danger').addClass('text-muted');
    }
    if ($('.txtDescripcion').val().trim() === '') {
        $('.txtDescripcion').addClass('form-control-danger');
        $('.txtDescripcionLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtDescripcion').removeClass('form-control-danger');
        $('.txtDescripcionLabel').removeClass('text-danger').addClass('text-muted');
    }
    if ($('.ddlCodigoPerfil input:checked').val()) {
        $('#modal-confirmacion').modal('show');
    } else {
        $('.ddlCodigoPerfilLabel').addClass('text-danger').removeClass('text-muted');
    }
});

function validaEditarRolClient() {
    if ($('.txtEditarRol').val().trim() === '') {
        $('.txtEditarRol').addClass('form-control-danger');
        $('.txtEditarRolLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtEditarRol').removeClass('form-control-danger');
        $('.txtEditarRolLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.txtEditarDescripcion').val().trim() === '') {
        $('.txtEditarDescripcion').addClass('form-control-danger');
        $('.txtEditarDescripcionLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtEditarDescripcion').removeClass('form-control-danger');
        $('.txtEditarDescripcionLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.ddlCodigoPerfilEdit input:checked').val()) {
        $('.ddlCodigoPerfilEditLabel').removeClass('text-danger').addClass('text-muted');
        return true;
    } else {
        $('.ddlCodigoPerfilEditLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    }
    
    return true;
}