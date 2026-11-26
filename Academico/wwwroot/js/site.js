$(document).ready(function () {
    // Máscara dinâmica para Telefone (8 ou 9 dígitos)
    var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    spOptions = {
        onKeyPress: function (val, e, field, options) {
            field.mask(SPMaskBehavior.apply({}, arguments), options);
        }
    };

    $('.telefone-mask').mask(SPMaskBehavior, spOptions);

    // Máscara para CEP
    $('.cep-mask').mask('00000-000');
});
