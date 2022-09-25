function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#ddl_country').val(data.IdCountry);
    $('#cbx_active').prop('checked', data.Active);

    $('#ddl_province').val(data.IdProvince);
    $('#ddl_province').prop('disabled', data.IdProvince <= 0 || data.IdProvince == undefined);




    var including = (data.Id == 0);
    if (including) {


        $('#ddl_city').empty();
        $('#ddl_city').prop('disabled', true);
        $('#ddl_country').val(-1);

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

            }
            sel_city(id_city);
        });
    }
    else {
        $('#ddl_province').val(-1);

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
        IdCountry: 0,
        IdProvince: 0,
        Active: true
    };
}
function get_data_form() {
    return {
        Id: $('#id_register').val(),
        Name: $('#txt_name').val(),
        IdCountry: $('#ddl_country').val(),
        IdProvince: $('#ddl_province').val(),
        Active: $('#cbx_active').prop('checked')
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.NameCountry).end()
        .eq(2).html(param.NameProvince).end()
        .eq(3).html(param.Active ? 'YES' : 'NO');
}

$(document).on('change', '#ddl_country', function () {
    change_country();
})

$(document).on('change', '#ddl_province', function () {
    change_province();
});
