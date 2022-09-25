function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_name').val(data.Name);
    $('#cbx_active').prop('checked', data.Active);

    var list_users = $('#list_users');
    list_users.find('input[type=checkbox]').prop('checked', false);

    if (data.Users) {
        for (var i = 0; i < data.Users.length; i++) {
            var users = data.Users[i];
            var cbx = list_users.find('input[data-id-users=' + users.Id + ']');
            if (cbx) {
                cbx.prop('checked', true);
            }
        }
    }
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
        Active: $('#cbx_active').prop('checked'),
        idUsers: get_list_users_checked()
    };
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Name).end()
        .eq(1).html(param.Active ? 'Yes' : 'No');
}

function get_list_users_checked() {
    var ids = [],
        list_users = $('#list_users');

    list_users.find('input[type=checkbox]').each(function (index, input) {
        var cbx = $(input),
            checked = cbx.is(':checked');

        if (checked) {
            ids.push(parseInt(cbx.attr('data-id-users')));
        }
    });
    return ids;
}

