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
