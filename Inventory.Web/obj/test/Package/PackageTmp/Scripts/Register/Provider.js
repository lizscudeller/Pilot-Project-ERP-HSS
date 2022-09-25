function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#txt_doc_num').val(data.DocNum);
    $('#txt_corporate_name').val(data.CorporateName);
    $('#txt_phone').val(data.Phone);
    $('#txt_contact').val(data.Contact);
    $('#txt_address').val(data.Address);
    $('#txt_number').val(data.Number);
    $('#txt_instruction').val(data.Instruction);
    $('#txt_postal_code').val(data.PostalCode);
    $('#cbx_active').prop('checked', data.Active);

    $('#cbx_legal_person').prop('checked', false);
    $('#cbx_natural_person').prop('checked', false);

    if (data.Type == 2) {
        $('#cbx_legal_person').prop('checked', true).trigger('click');
    }
    else {
        $('#cbx_natural_person').prop('checked', true).trigger('click');
    }

    var including = (data.Id == 0);
    if (including) {
        $('#ddl_province').empty();
        $('#ddl_province').prop('disable', true);

        $('#ddl_city').empty();
        $('#ddl_city').prop('disable', true);
    }
    else {

        $('#ddl_country').val(data.IdCountry);
        change_country(data.IdProvince, data.IdCity);
    }

}

function change_country(id_province, id_city) {
    var ddl_country = $('#ddl_country'),
        id_country = parseInt(ddl_country.val()),
        ddl_province = $('#ddl_province'),
        ddl_city = $('#ddl_city');

    if (id_country > 0) {
        var url = url_list_provinces,
            param = { idCountry: id_country };

        ddl_province.empty();
        ddl_province.prop('disabled', true);

        ddl_city.empty();
        ddl_city.prop('disabled', true);



        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response && response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    ddl_province.append('<option value=' + response[i].Id + '>' + response[i].Name + '</option>');
                }
                ddl_province.prop('disabled', false);
                ddl_province.find('option: eq(1)').prop('selected', true);
            }
            sel_province(id_province);
            change_province(id_city);
        });
    }

}

function change_province(id_city) {
    var ddl_province = $('#ddl_province'),
        id_province = parseInt(ddl_province.val()),
        ddl_city = $('#ddl_city');

    if (id_province > 0) {
        var url = url_list_cities,
            param = { idProvince: id_province };

        ddl_city.empty();
        ddl_city.prop('disabled', true);


        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response && response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    ddl_city.append('<option value=' + response[i].Id + '>' + response[i].Name + '</option>');
                }
                ddl_city.prop('disabled', false);
                ddl_city.find('option: eq(1)').prop('selected', true);

            }
            sel_city(id_city);
        });
    }
}

function sel_province(id_province) {
    $('#ddl_province').val(id_province);
    $('#ddl_province').prop('disable', $('#ddl_province option').length == 0);

}

function sel_city(id_city) {
    $('#ddl_city').val(id_city);
    $('#ddl_city').prop('disable', $('#ddl_city option').length == 0);

}


function set_focus_form() {
    $('#txt_name').focus();
}

function get_data_add() {
    return {
        Id: 0,
        Name: '',
        DocNum: '',
        CorporateName: '',
        Type: 2,
        Phone: '',
        Contact: '',
        Address: '',
        Number: '',
        Instruction: '',
        PostalCode: '',
        IdCountry: 0,
        IdProvince: 0,
        IdCity: 0,
        Active: true
    };
}
function get_data_form() {
    return {
        Id: $('#id_register').val(),
        Name: $('#txt_name').val(),
        DocNum: $('#txt_doc_num').val(),
        CorporateName: $('#txt_corporate_name').val(),
        Type: $('#cbx_legal_person').is(':checked') ? 2 : 1,
        Phone: $('#txt_phone').val(),
        Contact: $('#txt_contact').val(),
        Address: $('#txt_address').val(),
        Number: $('#txt_number').val(),
        Instruction: $('#txt_instruction').val(),
        PostalCode: $('#txt_postal_code').val(),
        IdCountry: $('#ddl_country').val(),
        IdProvince: $('#ddl_province').val(),
        IdCity: $('#ddl_city').val(),
        Active: $('#cbx_active').prop('checked')
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.Phone).end()
        .eq(2).html(param.Contact).end()
        .eq(3).html(param.Active ? 'YES' : 'NO');
}



$(document)
    .ready(function () {
        $('#txt_phone').mask('(000) 000-0000');
        $('#txt_postal_code').mask('A0A 0A0', {
            'translation': { A: { pattern: /[A-Za-z]/ } }
        });

    })
    .on('click', '#cbx_legal_person', function () {
        $('label[for="txt_doc_num"]').text('Business Number');
        $('#txt_doc_num').mask('000000000 RP 0000', { reverse: true });
        $('#container_corporate_name').removeClass('invisible');
    })

    .on('click', '#cbx_natural_person', function () {
        $('label[for="txt_doc_num"]').text('ID Number');
        $('#txt_doc_num').mask('000.000.000', { reverse: true });
        $('#container_corporate_name').addClass('invisible');

    })
$(document).on('change', '#ddl_country', function () {
    change_country();
})

$(document).on('change', '#ddl_province', function () {
    change_province();
});
