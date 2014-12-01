$(function () {

    $('.btnEliminar').on('click', function (e) {
        return confirm('Confirma que desea eliminar el elemento?');
    });

    $('.multiCmbDocentes').on('change', function (e) {
        var n = $('option:selected', this).length;
        $(this).prev('span').html('Docentes ('+n+'):');
    }).trigger('change');


});