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
        $('.txtEmail').removeClass('form-control-danger');
        $('.txtEmailLabel').removeClass('text-danger').addClass('text-muted');
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

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}