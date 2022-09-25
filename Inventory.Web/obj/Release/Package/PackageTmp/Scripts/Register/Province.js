function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#txt_pcode').val(data.ProvinceCode);
    $('#ddl_country').val(data.IdCountry);
    $('#cbx_active').prop('checked', data.Active);



    var including = (data.Id == 0); /*SELECT THE -1 ID COUNTRY ON DROPDOWN*/
    if (including) {
        $('#ddl_country').val(-1);
    }
    else {

        $('#ddl_country').val(data.IdCountry);
    }

}


function set_focus_form() {
    $('#txt_name').focus();
}


function get_data_add() {
    return {
        Id: 0,
        Name: '',
        ProvinceCode: '',
        IdCountry: 0,
        Active: true
    };
}
function get_data_form() {
    return {
        Id: $('#id_register').val(),
        Name: $('#txt_name').val(),
        ProvinceCode: $('#txt_pcode').val(),
        IdCountry: $('#ddl_country').val(),
        Active: $('#cbx_active').prop('checked')
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.ProvinceCode).end()
        .eq(2).html(param.Active ? 'YES' : 'NO');
}

