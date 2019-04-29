var fn = {
    //url: function (s) { return baseUrl + s; },
    resetForm: function () {
        $('.validar').each(function () {
            $(this).validate().resetForm();
        });
    },
    mensaje: function (p) { Materialize.toast(p, 4000); },
    notificar: function (o) {
        switch (o) {
            case 'add': Materialize.toast('SE CREO EL REGISTRO CORRECTAMENTE!', 4000); break;
            case 'mod': Materialize.toast('SE MODIFICO CORRECTAMENTE!', 4000); break;
            case 'anu': Materialize.toast('SE ANULO CORRECTAMENTE!', 4000); break;
            case 'rem': Materialize.toast('SE ELIMINO CORRECTAMENTE!', 4000); break;
            default: Materialize.toast('SE GRABARON LOS DATOS CORRECTAMENTE!', 4000);
        }
    },
    prompt: function (titulo, control, valor, mcallback) {
        swal({
            title: titulo,
            input: control,
            showCancelButton: true,
            closeOnConfirm: false,
            inputPlaceholder: "Ingrese dato",
            inputValue: valor,
            confirmButtonText: '<i class="mdi-navigation-check"></i> ACEPTAR',
            cancelButtonText: '<i class="mdi-navigation-close"></i> CANCELAR',
            inputValidator: function (value) {
                return new Promise(function (resolve, reject) {
                    if (value) {
                        resolve();
                    } else {
                        reject('Tu necesitas ingresar un dato válido!');
                    }
                });
            }
        }).then(function (result) {
            if (typeof mcallback === 'function') { mcallback(result); swal.close(); }
        });
    },
    CargarCombo: function (strUrl, strComboId, callbackOk, seleccionid) {
        $.ajax({
            url: window.location.origin + strUrl,
            data: {},
            success: function (result) {
                if (result !== null) {
                    var html = '';
                    $.each(result, function () {
                        if (seleccionid && this.Id == seleccionid)
                            html += "<option value=\"" + this.Id + "\" selected>" + this.Valor + "</option>";
                        else
                            html += "<option value=\"" + this.Id + "\">" + this.Valor + "</option>";
                    });
                    $("#" + strComboId).html(html);
                    $("#" + strComboId).not('.disabled').material_select();
                    if (typeof callbackOk === 'function') { callbackOk.call(this); }
                }
            }
        });
    }
};

$(document).ready(function () {
    $('input').blur(function () {
        this.value = this.value.toUpperCase();
    });
    //https://github.com/devbridge/jQuery-Autocomplete
    if ($('#autocompletar').data('url') !== null) {
        var txt = $('#autocompletar');
        if (txt.data('boton') !== null) $("#" + txt.data('boton')).attr('disabled', true);
        txt.data('idx', 0);
        txt.blur(function () { if ($(this).data('idx') == 0) $(this).val(""); });

        $.get(txt.data('url'), function (res) {            
            txt.devbridgeAutocomplete({
                //serviceUrl: '@Url.Action("listapais", "Home")',
                lookup: res,
                minChars: 2,
                onSelect: function (suggestion) {
                    $(this).removeClass('invalid');
                    $(this).addClass('valid');

                    if ($(this).data('seleccion') != null) $("#" + $(this).data('seleccion')).val(suggestion.data);
                    if ($(this).data('boton') != null) $("#" + $(this).data('boton')).attr('disabled', false);
                    if ($(this).data('funcion') != null) {
                        var funcion = $(this).data('funcion') + '(' + suggestion.data + ');';
                        setTimeout(funcion, 0);
                    }
                    $(this).data('idx', suggestion.data)

                },
                onInvalidateSelection: function () {

                    $(this).removeClass('valid');
                    $(this).addClass('invalid');

                    if ($(this).data('seleccion') != null) $("#" + $(this).data('seleccion')).val(0);
                    if ($(this).data('boton') != null) $("#" + $(this).data('boton')).attr('disabled', true);

                    $(this).data('idx', 0)
                },
                showNoSuggestionNotice: true,
                noSuggestionNotice: 'Lo siento, no hay resultados'
            });
        });
    }
});

