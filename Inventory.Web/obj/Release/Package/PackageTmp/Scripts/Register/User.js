function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#txt_email').val(data.Email);
    $('#txt_login').val(data.Login);
    $('#txt_password').val(data.Password);
}

function set_focus_form() {
    $('#txt_name').focus();
}


function get_data_add() {
    return {
        Id: 0,
        Name: '',
        Email: '',
        Login: '',
        Password: ''
    };
}
function get_data_form() {
    return {
        Id: $('#id_register').val(),
        Name: $('#txt_name').val(),
        Email: $('#txt_email').val(),
        Login: $('#txt_login').val(),
        Password: $('#txt_password').val()
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.Login);
}

