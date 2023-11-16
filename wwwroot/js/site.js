

$(document).ready(function () {
    // passar configurações da api tabela 
    getDatatable();

    // Abrir modal total clientes
    $('.btn-total-clientes').click(function () {
        var usuarioId = $(this).attr('usuario-id');

        $.ajax({
            type: 'GET',
            url: '/Usuario/ListarClientesPorUsuarioId/' + usuarioId,
            success: function (result) {
                $("#listaClientesUsuario").html(result);
                getDatatable();
                $('#modalClientesUsuario').modal('show');
            }
        });
    });

    // Fechar modal todal clientes
    $('.btn-close').on('click', function () {
        $('#modalClientesUsuario').modal('hide');
    });

});


function getDatatable() {
    $('.table').DataTable({
        "destroy": true,
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "_END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}



$(document).ready(function () {
    var mensagemSucesso = $(".alert-success");
    var mensagemErro = $(".alert-danger");

    if (mensagemSucesso.length) {
        mensagemSucesso.fadeIn();
        setTimeout(function () {
            mensagemSucesso.fadeOut();
        }, 2500);
    }
    if (mensagemErro.length) {
        mensagemErro.fadeIn();
        setTimeout(function () {
            mensagemErro.fadeOut();
        }, 4500);
    }
});
