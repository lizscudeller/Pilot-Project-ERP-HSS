function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_code').val(data.Code);
    $('#txt_name').val(data.Name);
    $('#txt_cost_value').val(data.CostValue);
    $('#txt_price').val(data.Price);
    $('#txt_storage_quant').val(data.StorageQuant);
    $('#ddl_unit_measure').val(data.IdUnitMeasure);
    $('#ddl_group').val(data.IdGroup);
    $('#ddl_brand').val(data.IdBrand);
    $('#ddl_provider').val(data.IdProvider);
    $('#ddl_storage_location').val(data.IdStorageLocation);
    $('#cbx_active').prop('checked', data.Active);
    //$('#txt_image').val(data.Image);

}

function set_focus_form() {
    var alter = (parseInt($('#id_register').val()) > 0);
    $('#txt_storage_quant').attr('readonly', alter);


    $('#txt_name').focus();
}

function get_data_add() {
    return {
        Id: 0,
        Code: '',
        Name: '',
        CostValue: 0,
        Price: 0,
        StorageQuant: 0,
        IdUnitMeasure: 0,
        IdGroup: 0,
        IdBrand: 0,
        IdProvider: 0,
        IdStorageLocation: 0,
        Active: true,
        Image: '',
    };
}
function get_data_form() {

    var form = new FormData();
    form.append('Id', $('#id_register').val());
    form.append('Code', $('#txt_code').val());
    form.append('Name', $('#txt_name').val());
    form.append('CostValue', $('#txt_cost_value').val());
    form.append('Price', $('#txt_price').val());
    form.append('StorageQuant', $('#txt_storage_quant').val());
    form.append('IdUnitMeasure', $('#ddl_unit_measure').val());
    form.append('IdGroup', $('#ddl_group').val());
    form.append('IdBrand', $('#ddl_brand').val());
    form.append('IdProvider', $('#ddl_provider').val());
    form.append('IdStorageLocation', $('#ddl_storage_location').val());
    form.append('Active', $('#cbx_active').prop('checked'));
    form.append('Image', $('#txt_image').prop('files')[0]);
    form.append('__RequestVerificationToken', $('[name = __RequestVerificationToken]').val());


    return form;
}

function fill_line_grid(param, line) {
    line
        .eq(0).html(param.Code).end()
        .eq(1).html(param.Name).end()
        .eq(2).html(param.StorageQuant).end()
        .eq(3).html(param.Active ? 'Yes' : 'No');
}

function save_custom(url, param, save_ok, save_error) {
    $.ajax({
        type: 'POST',
        processData: false,
        contentType: false,
        data: param,
        url: url,
        dataType: 'json',
        success: function (response) {
            save_ok(response, get_param());
        },
        error: function () {
            save_error();
        }
    });
}


function get_param() {
    return {
        Id: $('#id_register').val(),
        Code: $('#txt_code').val(),
        Name: $('#txt_name').val(),
        StorageQuant: $('#txt_storage_quant').val(),
        Active: $('#cbx_active').prop('checked'),
        Image: $('#txt_image').prop('files')[0]
    };
}

$(document)
    .ready(function () {
        $('#txt_cost_value,#txt_price').mask('#.##0,00', { reverse: true });
        $('#txt_storage_quant').mask('00000');
    })
    .on('click', '.btn-exibir-imagem', function () {
        var nome_imagem = $(this).closest('tr').attr('data-imagem'),
            modal_imagem = $('#modal_imagem'),
            template_imagem = $('#template-imagem'),
            conteudo_modal_imagem = Mustache.render(template_imagem.html(), { Imagem: nome_imagem });

        modal_imagem.html(conteudo_modal_imagem);

        bootbox.dialog({
            title: `Imagem ${nome_imagem}`,
            message: modal_imagem,
            className: 'dialogo'
        })
            .on('shown.bs.modal', function () {
                modal_imagem.show();
            })
            .on('hidden.bs.modal', function () {
                modal_imagem.hide().appendTo('body');
            });
    });





$(document)
    .on("focus", "#txt_cost_value, #txt_price", function () {
        $(this).mask('#.##0,00', { reverse: true });
    })
    .on("focus", "#txt_storage_quant", function () {
        $(this).mask('00000');
    })
    .on('click', '.btn-show-image', function () {
        var name_image = $(this).closest('tr').attr('data-image'),
            modal_image = $('#modal_image'),
            template_image = $('#template-image'),
            cont_modal_image = Mustache.render(template_image.html(), { Image: name_image });

        modal_image.html(cont_modal_image);

        bootbox.dialog({
            title: `Image ${name_image}`,
            message: modal_image,
            className: 'dialog'
        })
            .on('shown.bs.modal', function () {
                modal_image.show();
            })
            .on('hidden.bs.modal', function () {
                modal_image.hide().appendTo('body');
            });
    });