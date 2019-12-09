function validarCombo(s, args) {
    args.IsValid = (args.Value != "0");
}

function validarCaptcha(s, args) {
    var captcha = $("input[id*='ccSISDEL']");
    args.IsValid = (captcha.val() != "");
}

function openWindow(urlDir, hg, wd) {
     try {
        //var w = window.innerWidth - 50;
        //var h = window.innerHeight - 50;
         var w = screen.width - (screen.width*0.30);
         var h = screen.height - (screen.height*0.10);
        var rv = olw(urlDir, h, w);
        return true;
    } catch (identifier) {
        return false;
    }
}

function olw(u, h, w) {
    var url = encodeURI(u);
    var hs = window.open(url, "_blank", "location=0,status=0,scrollbars=1,resizable=1,width=" + w + ",height=" + h + ",top=20,left=20");
    return hs;
}

function habilitarMenu(pactivo1, pactivo2, pactivo3) {
    pactivo1 ? $('#liEnviar').addClass('active') : $('#liEnviar').removeClass('active');
    pactivo2 ? $('#liConsultar').addClass('active') : $('#liConsultar').removeClass('active');
    pactivo3 ? $('#liGuiaUsuario').addClass('active') : $('#liGuiaUsuario').removeClass('active');
}

function openModalExpirado() {
    $('#modalExpirado').modal({
        backdrop: 'static',
        keyboard: true
    });
}

function toggleLoadingState(btn) {
        var jBtn = $(btn);
        jBtn.button('loading');
}

function toggleLoadingStateCustom(btn, validationGroup) {
    if (Page_ClientValidate(validationGroup)) {
        var jBtn = $(btn);
        jBtn.button('loading');
    }
}

function toggleNormalState(btn) {
    var jBtn = document.getElementById(btn);
    $(jBtn).button('reset');
}