var save_custom = null;

function add_anti_forgery_token(data) {
    data.__RequestVerificationToken = $('[name = __RequestVerificationToken]').val();
    return data;
}
//Table ordenation with arrow down and up
function highligth_ordenation_camp(column) {
    var order_crescent = true,
        order = column.find('i');

    if (order.length > 0) {
        order_crescent = order.hasClass('glyphicon-arrow-down');
        if (order_crescent) {
            order.removeClass('glyphicon-arrow-down');
            order.addClass('glyphicon-arrow-up');
        }
        else {
            order.removeClass('glyphicon-arrow-up');
            order.addClass('glyphicon-arrow-down');
        }
    }
    else {
        $('.column-ordenation i').remove();
        column.append('&nbsp;<i class="glyphicon glyphicon-arrow-down" style="color:#000000"></i>');
    }
}

function get_order_grid() {
    var column_grid = $('.column-ordenation'),
        ret = '';

    column_grid.each(function (index, item) {
        var column = $(item),
            order = column.find('i');

        if (order.length > 0) {
            order_crescent = order.hasClass('glyphicon-arrow-down');
            ret = column.attr('data-campo') + (order_crescent ? '' : ' desc');
            return true;
        }
    });
    return ret;
}
//END Table ordenation with arrow down and up

function format_message_warning(message) {
    var template = 
        '<ul>' +
        '{{ #. }}' +
        '<li>{{ . }}</li>' +
        '{{ /. }}' +
    '</ul>';

    return Mustache.render(template, message);

}

function open_form(data) {
    set_data_form(data);


    var modal_register = $('#modal_register');

    $('#msg_message_warning').empty();
    $('#msg_warning').hide();
    $('#msg_message_warning').hide();
    $('#msg_error').hide();


    bootbox.dialog({
        title: 'Register' + page_title,
        message: modal_register,
        className: 'dialog',
    })
        .on('shown.bs.modal', function () {
            modal_register.show(0, function () {
                set_focus_form();
            });
        })
        .on('hidden.bs.modal', function () {
            modal_register.hide().appendTo('body');
        });
}

function add_line_grid(data) { 

    var template = $('#template-grid').html();
    return Mustache.render(template, data);

}

function save_ok(response, param) {
    if (response.Result == "OK") {
        if (param.Id == 0) {
            param.Id == response.IdSaved;
            var table = $('#grid_register').find('tbody'),
                line = add_line_grid(param);

            table.append(line);
            $('#grid_register').removeClass('invisible');
            $('#message_grid').addClass('invisible');


            window.location.reload(); //REFRESH PAGE BEFORE ADDING NEW ITEM
        }
        else {
            var line = $('#grid_register').find('tr[data-id=' + param.Id + ']').find('td');
            fill_line_grid(param, line);
        }

        $('#modal_register').parents('.bootbox').modal('hide');
    }
    else if (response.Result == "Error") {
        $('#msg_warning').hide();
        $('#msg_message_warning').hide();
        $('#msg_error').show();
    }
    else if (response.Result == "Warning") {
        $('#msg_message_warning').html(format_message_warning(response.Message));
        $('#msg_warning').show();
        $('#msg_message_warning').show();
        $('#msg_error').hide();
    }
}

function save_error() {
    swal('Warning', 'Could not save the information. Try again later.', 'warning');
}

$(document).on('click', '#btn_add', function () {
    open_form(get_data_add());
})
    .on('click', '.btn-edit', function () {
        var btn = $(this),
            id = btn.closest('tr').attr('data-id'),
            url = url_edit,
            param = { 'id': id };

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response) {
                open_form(response);
            }
        })
            .fail(function () {
                swal('Warning', 'The information could not be retrieved. Try again later.', 'warning');
            });
    })
    .on('click', '.btn-delete', function () {
        var btn = $(this),
            tr = btn.closest('tr'),
            id = tr.attr('data-id'),
            url = url_delete,
            param = { 'id': id };

        bootbox.confirm({
            message: "Do you really want to delete this" + page_title + "?",
            buttons: {
                confirm: {
                    label: "Yes",
                    className: 'btn-danger'
                },
                cancel: {
                    label: "No",
                    className: 'btn-success'
                }
            },


            callback: function (result) {
                if (result) {
                    $.post(url, add_anti_forgery_token(param), function (response) {
                        if (response) {
                            tr.remove();
                            var quant = $('#grid_register > tbody > tr').length;
                            if (quant == 0) {
                                $('#grid_register').addClass('invisible');
                                $('#message_grid').removeClass('invisible');

                            }
                        }
                        window.location.reload(); //REFRESH PAGE BEFORE ADDING NEW ITEM
                    })
                        .fail(function () {
                            swal('Warning', 'The information could not be deleted. Try again later.', 'warning');
                        });
                }

            }
        });
    })
    .on('click', '#btn_save', function () {

        var btn = $(this),
            url = url_save,
            param = get_data_form();

        if (save_custom && typeof (save_custom) == 'function') {
            save_custom(url, param, save_ok, save_error);
        }
        else {
            $.post(url, add_anti_forgery_token(param), function (response) {
                save_ok(response, param);
            })
                .fail(function () {
                    save_error();
                });
        }
    })
    .on('click', '.page-item', function () { //pagination
        var order = get_order_grid(),
            btn = $(this),
            filter = $('#txt_filter'),
            lenPage = $('#ddl_len_page').val(),
            page = btn.text(),
            url = url_page_click,
            param = { 'page': page, 'lenPage': lenPage, 'filter': filter.val(), 'order': order };


        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response) {

                var table = $('#grid_register').find('tbody');

                table.empty();

                if (response.length > 0) {
                    $('#grid_register').removeClass('invisible');
                    $('#message_grid').addClass('invisible');

                    for (var i = 0; i < response.length; i++) {
                        table.append(add_line_grid(response[i]));

                    }

                }
                else {
                    $('#grid_register').addClass('invisible');
                    $('#message_grid').removeClass('invisible');
                }

                btn.siblings().removeClass('active');
                btn.addClass('active');
            }
        })
            .fail(function () {
                swal('Warning', 'The information could not be retrieved. Try again later.', 'warning');
            });
    })
    .on('change', '#ddl_len_page', function () { //dropdown pagination
        var order = get_order_grid(),
            ddl = $(this),
            filter = $('#txt_filter'),
            lenPage = ddl.val(),
            page = 1,
            url = url_len_page_change,
            param = { 'page': page, 'lenPage': lenPage, 'filter': filter.val(), 'order': order };

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response) {

                var table = $('#grid_register').find('tbody');

                table.empty();

                if (response.length > 0) {
                    $('#grid_register').removeClass('invisible');
                    $('#message_grid').addClass('invisible');

                    for (var i = 0; i < response.length; i++) {
                        table.append(add_line_grid(response[i]));

                    }

                }
                else {
                    $('#grid_register').addClass('invisible');
                    $('#message_grid').removeClass('invisible');
                }

                ddl.siblings().removeClass('active');
                ddl.addClass('active');
            }
        })
            .fail(function () {
                swal('Warning', 'The information could not be retrieved. Try again later.', 'warning');
            });
    })

    .on('keyup', '#txt_filter', function () {
        var order = get_order_grid(),
            filter = $(this),
            ddl = $('#ddl_len_page'),
            lenPage = ddl.val(),
            page = 1,
            url = url_filter,
            param = { 'page': page, 'lenPage': lenPage, 'filter': filter.val(), 'order': order };

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response) {

                var table = $('#grid_register').find('tbody');

                table.empty();
                if (response.length > 0) {
                    $('#grid_register').removeClass('invisible');
                    $('#message_grid').addClass('invisible');

                    for (var i = 0; i < response.length; i++) {
                        table.append(add_line_grid(response[i]));

                    }

                }
                else {
                    $('#grid_register').addClass('invisible');
                    $('#message_grid').removeClass('invisible');
                }

                ddl.siblings().removeClass('active');
                ddl.addClass('active');
            }
        })
            .fail(function () {
                swal('Warning', 'The information could not be retrieved. Try again later.', 'warning');
            });
    })

    .on('click', '.column-ordenation', function () {
        highligth_ordenation_camp($(this));

        var order = get_order_grid(),
            filter = $('#txt_filter'),
            ddl = $('#ddl_len_page'),
            lenPage = ddl.val(),
            page = 1,
            url = url_filter,
            param = { 'page': page, 'lenPage': lenPage, 'filter': filter.val(), 'order': order };

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response) {

                var table = $('#grid_register').find('tbody');

                table.empty();
                if (response.length > 0) {
                    $('#grid_register').removeClass('invisible');
                    $('#message_grid').addClass('invisible');

                    for (var i = 0; i < response.length; i++) {
                        table.append(add_line_grid(response[i]));

                    }

                }
                else {
                    $('#grid_register').addClass('invisible');
                    $('#message_grid').removeClass('invisible');
                }

                ddl.siblings().removeClass('active');
                ddl.addClass('active');
            }
        })
            .fail(function () {
                swal('Warning', 'The information could not be retrieved. Try again later.', 'warning');
            });
    });




$(document)
    .ready(function () {
        var grid = $('#grid_register > tbody');
        for (var i = 0; i < liness.length; i++) {
            grid.append(add_line_grid(liness[i]));
        }

        highligth_ordenation_camp($('#grid_register thead tr th:nth-child(1) span'));


    });


