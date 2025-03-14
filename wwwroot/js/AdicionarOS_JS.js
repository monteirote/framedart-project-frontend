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

