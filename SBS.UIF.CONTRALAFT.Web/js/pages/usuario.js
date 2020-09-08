(function ($) {
    'use strict';
    if ($("#fileuploader").length) {
        $("#fileuploader").uploadFile({
            url: "YOUR_FILE_UPLOAD_URL",
            fileName: "fileDocumento"
        });
    }
})(jQuery);

(function ($) {
    'use strict';
    $(function () {
        $('.file-upload-browse').on('click', function () {
            var file = $(this).parent().parent().parent().find('.file-upload-default');
            file.trigger('click');
        });
        $('.file-upload-default').on('change', function () {
            $(this).parent().find('.form-control').val($(this).val().replace(/C:\\fakepath\\/i, ''));
        });
    });
})(jQuery);

function validaCrearUsuarioClient() {
    if ($('.txtDocumento').val().trim() === '') {
        $('.txtDocumento').addClass('form-control-danger');
        $('.txtDocumentoLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtDocumento').removeClass('form-control-danger');
        $('.txtDocumentoLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.ddlCodigoPerfil').val().trim() === '0') {
        $('.ddlCodigoPerfil').addClass('form-control-danger');
        $('.ddlCodigoPerfilLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.ddlCodigoPerfil').removeClass('form-control-danger');
        $('.ddlCodigoPerfilLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.txtNombre').val().trim() === '') {
        $('.txtNombre').addClass('form-control-danger');
        $('.txtNombreLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtNombre').removeClass('form-control-danger');
        $('.txtNombreLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.txtEmail').val().trim() === '') {
        $('.txtEmail').addClass('form-control-danger');
        $('.txtEmailLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        if (!isEmail($('.txtEmail').val().trim())) {
            $('.txtEmail').addClass('form-control-danger');
            $('.txtEmailLabel').addClass('text-danger').removeClass('text-muted');
            return false;
        }
        $('.txtEmail').removeClass('form-control-danger');
        $('.txtEmailLabel').removeClass('text-danger').addClass('text-muted');
    }

    if (!$('.fileDocumento').val()) {
        $('.file-upload-info').addClass('form-control-danger');
        $('.fileDocumentoLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.file-upload-info').removeClass('form-control-danger');
        $('.fileDocumentoLabel').removeClass('text-danger').addClass('text-muted');
    }

    if (parseInt($('.ddlCodigoPerfil').val()) > 0)
        if ($('.ddlCodigoEntidad').val().trim() === '0') {
            $('.ddlCodigoEntidad').addClass('form-control-danger');
            $('.ddlCodigoEntidadLabel').addClass('text-danger').removeClass('text-muted');
            return false;
        } else {
            $('.ddlCodigoEntidad').removeClass('form-control-danger');
            $('.ddlCodigoEntidadLabel').removeClass('text-danger').addClass('text-muted');
        }
    return true;
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