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

function validaBorradorMetaClient() {

    if ($('.txtMedioVerificacion').val().trim() === '') {
        $('.txtMedioVerificacion').addClass('form-control-danger');
        $('.txtMedioVerificacionLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtMedioVerificacion').removeClass('form-control-danger');
        $('.txtMedioVerificacionLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.txtNumero').val().trim() === '') {
        $('.txtNumero').addClass('form-control-danger');
        $('.txtNumeroLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtNumero').removeClass('form-control-danger');
        $('.txtNumeroLabel').removeClass('text-danger').addClass('text-muted');
    }

    if ($('.txtDescripcion').val().trim() === '') {
        $('.txtDescripcion').addClass('form-control-danger');
        $('.txtDescripcionLabel').addClass('text-danger').removeClass('text-muted');
        return false;
    } else {
        $('.txtDescripcion').removeClass('form-control-danger');
        $('.txtDescripcionLabel').removeClass('text-danger').addClass('text-muted');
    }
    
    return true;
}

$(".soloNumeros").bind('keypress', function (event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
});