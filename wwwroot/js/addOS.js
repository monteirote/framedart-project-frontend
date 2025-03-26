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

function convertImagesToBase64 (files) {
    return Promise.all(files.map(file => fileToBase64(file)));
}

function fileToBase64 (file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = () => resolve(reader.result.split(',')[1]); // Retorna apenas a parte Base64
        reader.onerror = (error) => reject(error);
        reader.readAsDataURL(file);
    });
}

async function SubmitOrder(framedArtworks) {

    let order = {
        reference: $('#dsNumeroOS').val(),
        priority: $('#dsPrioridade').val(),
        customerId: $('#cdCliente').val(),
        totalPrice: 0,
        expectedDeliveryDate: $('#dtEntrega').val(),
        framedArtworks: FormattingFramedArtworks(framedArtworks)
    };

    $.ajax({
        type: 'POST',
        url: '/Order/CreateOrder',
        data: JSON.stringify(order), 
        contentType: 'application/json',
        success: function (data) {
            console.log('Sucesso:', data);
        },
        error: function (error) {
            console.error('Erro:', error);
        }
    });
}

function FormattingFramedArtworks(framedArtworks) {
    return framedArtworks.map(x => ({
        width: x.largura,
        height: x.altura,
        price: 0,
        glassId: x.vidro.id,
        frameId: x.moldura.id,
        backgroundId: x.fundo.id,
        paperId: x.papel.id,
        images: x.imagens
    }));
}