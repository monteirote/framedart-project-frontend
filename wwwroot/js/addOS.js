function IniciarSelectsModal () {

    $('#cdFundo').select2({
        dropdownParent: $('#modalQuadro'),
        placeholder: defaultPlaceholder,
        minimumInputLength: 3,
        ajax: {
            url: '/Order/SearchMaterial',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return { text: params.term, type: 'Background' };
            },
            processResults: function (data) {
                return {
                    results: data.data
                };
            },
            cache: true,
            async: true
        }
    });
    $('#cdMoldura').select2({
        dropdownParent: $('#modalQuadro'),
        placeholder: defaultPlaceholder,
        minimumInputLength: 3,
        ajax: {
            url: '/Order/SearchMaterial',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return { text: params.term, type: 'Frame' };
            },
            processResults: function (data) {
                return {
                    results: data.data
                };
            },
            cache: true,
            async: true
        }
    });
    $('#cdPapel').select2({
        dropdownParent: $('#modalQuadro'),
        placeholder: defaultPlaceholder,
        minimumInputLength: 3,
        ajax: {
            url: '/Order/SearchMaterial',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return { text: params.term, type: 'Paper' };
            },
            processResults: function (data) {
                return {
                    results: data.data
                };
            },
            cache: true,
            async: true
        }
    });
    $('#cdVidro').select2({
        dropdownParent: $('#modalQuadro'),
        placeholder: defaultPlaceholder,
        minimumInputLength: 3,
        ajax: {
            url: '/Order/SearchMaterial',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return { text: params.term, type: 'Glass' };
            },
            processResults: function (data) {
                return {
                    results: data.data
                };
            },
            cache: true,
            async: true
        }
    });

}

function SubmitOrder (framedArtworks) {

    let order = {
        reference: $('#dsNumeroOS').val(),
        priority: $('#dsPrioridade').val(),
        customerId: $('#cdCliente').val(),
        totalPrice: 0,
        expectedDeliveryDate: $('#dtEntrega').val(),
        framedArtworks: framedArtworks
    };

    $.ajax({
        type: 'POST',
        data: order,
        url: '/Order/CreateOrder',
        success: function (data) {
            console.log(data);
        },
        error: function (error) {
            console.log(error);
        }
    });

}
