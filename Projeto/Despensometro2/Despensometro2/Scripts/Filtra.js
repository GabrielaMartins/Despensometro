function filtra() {

    $("table tbody tr").remove();

    debugger
    var entrada = $("#icon_prefix").val();

    var url = '/Produto/PesquisaProduto?valor=' + entrada;

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        async: true,
        success: function (data) {

            Mostra(data);
        }

    });
}

function Mostra(data) {
    $(data).each(function (i, item) {

        if (item.perecivel == true) {
            var perecivel = "Sim";
        } else {
            var perecivel = "Não"
        }

        $("table tbody").append(
            "<tr>" +
                "<td>" + item.produto_nome + "</td>" +
                "<td>" + item.produto_peso + "</td>" +
                "<td>" + item.sabor + "</td>" +
                "<td>" + item.nome_fabricante + "</td>" +
                "<td>" + item.numero_ean + "</td>" +
                "<td>" + item.categoria_produto + "</td>" +
                "<td>" + perecivel + "</td>" +
                "<td><a class=\"btn-floating red\"><i class=\"material-icons tooltipped\" data-position=\"top\" data-delay=\"50\" data-tooltip=\"Adicione produtos ao estoque\">shopping_basket</i></a> </td>" +
               "<td><a class=\"btn-floating disabled\"><i class=\"material-icons tooltipped\" data-position=\"top\" data-delay=\"50\" data-tooltip=\"Edite produto\">edit_mode</i></a></td>" +
               "<td><a class=\"btn-floating disabled\"><i class=\"material-icons tooltipped\" data-position=\"top\" data-delay=\"50\" data-tooltip=\"Delete produto\">delete</i></a></td>" +
            "</tr>"

            );
    });
}