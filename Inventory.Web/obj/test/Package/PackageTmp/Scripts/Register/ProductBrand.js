function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#cbx_active').prop('checked', data.Active);
}

function set_focus_form() {
    $('#txt_name').focus();
}


function get_data_add() {
    return {
        Id: 0,
        Name: '',
        Active: true
    };
}
function get_data_form() {
    return {
        Id: $('#id_register').val(),
        Name: $('#txt_name').val(),
        Active: $('#cbx_active').prop('checked')
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.Active ? 'Yes' : 'No');
}

