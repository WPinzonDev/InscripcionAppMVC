$(document).ready(function () {
    $('#InscripcionesTb').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _END_ de _MAX_ Registros",
            "infoEmpty": "Mostrando 0 encontrados de _MAX_ Registros",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        layout: {
            topStart: {
                buttons: ['excel', 'pdf', 'print']
            }
        },
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var title = column.footer().textContent;

                var input = document.createElement('input');
                input.placeholder = "Buscar";
                column.footer().replaceChildren(input);

                input.addEventListener('keyup', function () {
                    if (column.search() !== this.value) {
                        column.search(this.value).draw();
                    }
                });
            });
        }
    });
});

$(document).ready(function () {
    $('#siguiente').click(function () {
        $('#step1').addClass('offscreen');
        $('#step2').removeClass('offscreen');
        $('#siguiente').addClass('offscreen');
        $('#anterior').removeClass('offscreen');
        $('#registrar').removeClass('offscreen');
        $('#infopersonal').removeClass('step-active');
        $('#infoacademica').addClass('step-active');
        $('#infoacademica>div').addClass('border-sky-800').removeClass('border-gray-400');
        $('#infopersonal>div').removeClass('border-sky-800').addClass('border-gray-400');
    });

    $('#anterior').click(function () {
        $('#step2').addClass('offscreen');
        $('#step1').removeClass('offscreen');
        $('#siguiente').removeClass('offscreen');
        $('#anterior').addClass('offscreen');
        $('#registrar').addClass('offscreen');
        $('#infopersonal').addClass('step-active');
        $('#infoacademica').removeClass('step-active');
        $('#infopersonal>div').addClass('border-sky-800').removeClass('border-gray-400');
        $('#infoacademica>div').removeClass('border-sky-800').addClass('border-gray-400');
    });

    $('form').submit(function (event) {
        var isValid = true;
        $('#step1 :input[required]').each(function () {
            if (!this.validity.valid) {
                isValid = false;
                return false;
            }
        });

        if (!isValid) {
            $('#step1').removeClass('offscreen');
            $('#step2').addClass('offscreen');
            $('#siguiente').removeClass('offscreen');
            $('#anterior').addClass('offscreen');
            $('#registrar').addClass('offscreen');
            $('#infopersonal').addClass('step-active');
            $('#infoacademica').removeClass('step-active');
            $('#infopersonal>div').addClass('border-sky-800').removeClass('border-gray-400');
            $('#infoacademica>div').removeClass('border-sky-800').addClass('border-gray-400');
            event.preventDefault();
        }
    });
});
