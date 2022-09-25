function set_data_form(data) {
    $('#id_register').val(data.Id);
    $('#txt_legal_name').val(data.LegalName);
    $('#txt_legal_surname').val(data.LegalSurname);

    $('#cbx_employee').prop('checked', false);
    $('#cbx_contractor').prop('checked', false);

    $('#txt_print_name').val(data.PrintName);
    $('#txt_ssn').val(data.Ssn);
    $('#ddl_gender').val(data.Gender);
    $('#txt_date_birth').val(data.DateBirth);
    $('#ddl_marital_status').val(data.MaritalStatus);
    $('#ddl_us_citizen').val(data.UsCitizen);
    $('#ddl_ethnicity').val(data.Ethnicity);
    $('#ddl_disability').val(data.Disability);
    $('#txt_disability_description').val(data.DisabilityDescription);
    $('#ddl_i9_form').val(data.I9Form);
    $('#txt_work_expires').val(data.WorkExpires);
    $('#ddl_us_veteran').val(data.UsVeteran);
    $('#txt_veteran_status').val(data.VeteranStatus);
    $('#txt_address_1').val(data.Address1);
    $('#txt_address_2').val(data.Address2);
    $('#txt_city').val(data.City);
    $('#txt_state_province').val(data.StateProvince);
    $('#txt_postal_code').val(data.PostalCode);
    $('#txt_phone').val(data.PhoneNumber);
    $('#txt_mobile').val(data.MobileNumber);
    $('#txt_email').val(data.Email);
    $('#txt_contact_name_1').val(data.ContactName1);
    $('#txt_contact_phone_1').val(data.ContactPhone1);
    $('#txt_relation_1').val(data.ContactRelation1);
    $('#txt_contact_name_2').val(data.ContactName2);
    $('#txt_contact_phone_2').val(data.ContactPhone2);
    $('#txt_relation_2').val(data.ContactRelation2);

    $('#cbx_active').prop('checked', data.Active);


    //if (data.EmployeeType == 2) {
    //    $('#cbx_employee').prop('checked', true).trigger('click');
    //}
    //else {
    //    $('#cbx_contractor').prop('checked', true).trigger('click');
    //}
}



function set_focus_form() {
    $('#txt_legal_name').focus();
}


function get_data_add() {
    return {
        Id: 0,
        LegalName: '',
        LegalSurname: '',
        PrintName: '',
        Ssn: '',
        Gender: '',
        DateBirth: '',
        MaritalStatus: '',
        UsCitizen: '',
        Ethnicity: '',
        Disability: '',
        DisabilityDescription: '',
        I9Form: '',
        WorkExpires: '',
        UsVeteran: '',
        VeteranStatus: '',
        Address1: '',
        Address2: '',
        City: '',
        StateProvince: '',
        PostalCode: '',
        PhoneNumber: '',
        MobileNumber: '',
        Email: '',
        ContactName1: '',
        ContactPhone1: '',
        ContactRelation1: '',
        ContactName2: '',
        ContactPhone2: '',
        ContactRelation2: '',
        Active: true
    };
}
function get_data_form() {

    //var form = new FormData();
    //form.append('Id', $('#id_register').val());
    //form.append('LegalName', $('#txt_legal_name').val());
    //form.append('LegalSurname', $('#txt_legal_surname').val());
    //form.append('EmployeeType', $('#cbx_person').val());
    //form.append('PrintName', $('#txt_print_name').val());
    //form.append('Ssn', $('#txt_ssn').val());
    //form.append('Gender', $('#txt_gender').val());
    //form.append('DateBirth', $('#txt_date_birth').val());
    //form.append('MaritalStatus', $('#ddl_marital_status').val());
    //form.append('UsCitizen', $('#ddl_us_citizen').val());
    //form.append('Ethnicity', $('#ddl_ethnicity').val());
    //form.append('Disability', $('#ddl_disability').val());
    //form.append('DisabilityDescription', $('#txt_disability_description').val());
    //form.append('I9Form', $('#ddl_i9_form').val());
    //form.append('WorkExpires', $('#txt_work_expires').val());
    //form.append('UsVeteran', $('#ddl_us_veteran').val());
    //form.append('VeteranStatus', $('#txt_veteran_status').val());

    //form.append('Address1', $('#txt_address_1').val());
    //form.append('Address2', $('#txt_address_2').val());
    //form.append('City', $('#txt_city').val());
    //form.append('StateProvince', $('#txt_state_province').val());
    //form.append('PostalCode', $('#txt_postal_code').val());
    //form.append('PhoneNumber', $('#txt_phone').val());
    //form.append('MobileNumber', $('#txt_mobile').val());
    //form.append('Email', $('#txt_email').val());
    //form.append('ContactName1', $('#txt_contact_name_1').val());
    //form.append('ContactPhone1', $('#txt_contact_phone_1').val());
    //form.append('ContactRelation1', $('#txt_relation_1').val());
    //form.append('ContactName2', $('#txt_contact_name_2').val());
    //form.append('ContactPhone2', $('#txt_contact_phone_2').val());
    //form.append('ContactRelation2', $('#txt_relation_2').val());

    //form.append('Active', $('#cbx_active').prop('checked'));
    //form.append('__RequestVerificationToken', $('[name = __RequestVerificationToken]').val());


    //return form;

    return {
        Id: $('#id_register').val(),
        LegalName: $('#txt_legal_name').val(),
        LegalSurname: $('#txt_legal_surname').val(),

        EmployeeType: $('#cbx_contractor').is(':checked') ? 2 : 1,

        PrintName: $('#txt_print_name').val(),
        Ssn: $('#txt_ssn').val(),
        Gender: $('#txt_gender').val(),
        DateBirth: $('#txt_date_birth').val(),
        MaritalStatus: $('#ddl_marital_status').val(),
        UsCitizen: $('#ddl_us_citizen').val(),
        Ethnicity: $('#ddl_ethnicity').val(),
        Disability: $('#ddl_disability').val(),
        DisabilityDescription: $('#txt_disability_description').val(),
        I9Form: $('#ddl_i9_form').val(),
        WorkExpires: $('#txt_work_expires').val(),
        UsVeteran: $('#ddl_us_veteran').val(),
        VeteranStatus: $('#txt_veteran_status').val(),

        Address1: $('#txt_address_1').val(),
        Address2: $('#txt_address_2').val(),
        City: $('#txt_city').val(),
        StateProvince: $('#txt_state_province').val(),
        PostalCode: $('#txt_postal_code').val(),
        PhoneNumber: $('#txt_phone').val(),
        MobileNumber: $('#txt_mobile').val(),
        Email: $('#txt_email').val(),
        ContactName1: $('#txt_contact_name_1').val(),
        ContactPhone1: $('#txt_contact_phone_1').val(),
        ContactRelation1: $('#txt_relation_1').val(),
        ContactName2: $('#txt_contact_name_2').val(),
        ContactPhone2: $('#txt_contact_phone_2').val(),
        ContactRelation2: $('#txt_relation_2').val(),

        Active: $('#cbx_active').prop('checked')
    };
}


function fill_line_grid(param, line) {
    line
        .eq(0).html(param.LegalName).end()
        .eq(1).html(param.LegalSurname).end()
        .eq(2).html(param.Active ? 'YES' : 'NO');
}

//function save_custom(url, param, save_ok, save_error) {
//    $.ajax({
//        type: 'POST',
//        processData: false,
//        contentType: false,
//        data: param,
//        url: url,
//        dataType: 'json',
//        success: function (response) {
//            save_ok(response, get_param());
//        },
//        error: function () {
//            save_error();
//        }
//    });
//}
//function get_param() {
//    return {
//        Id: $('#id_register').val(),
//        LegalName: $('#txt_legal_name').val(),
//        LegalSurname: $('#txt_legal_surname').val(),

//        EmployeeType: $('#cbx_contractor').is(':checked') ? 2 : 1,

//        PrintName: $('#txt_print_name').val(),
//        Ssn: $('#txt_ssn').val(),
//        Gender: $('#txt_gender').val(),
//        DateBirth: $('#txt_date_birth').val(),
//        MaritalStatus: $('#ddl_marital_status').val(),
//        UsCitizen: $('#ddl_us_citizen').val(),
//        Ethnicity: $('#ddl_ethnicity').val(),
//        Disability: $('#ddl_disability').val(),
//        DisabilityDescription: $('#txt_disability_description').val(),
//        I9Form: $('#ddl_i9_form').val(),
//        WorkExpires: $('#txt_work_expires').val(),
//        UsVeteran: $('#ddl_us_veteran').val(),
//        VeteranStatus: $('#txt_veteran_status').val(),

//        Address1: $('#txt_address_1').val(),
//        Address2: $('#txt_address_2').val(),
//        City: $('#txt_city').val(),
//        StateProvince: $('#txt_state_province').val(),
//        PostalCode: $('#txt_postal_code').val(),
//        PhoneNumber: $('#txt_phone').val(),
//        MobileNumber: $('#txt_mobile').val(),
//        Email: $('#txt_email').val(),
//        ContactName1: $('#txt_contact_name_1').val(),
//        ContactPhone1: $('#txt_contact_phone_1').val(),
//        ContactRelation1: $('#txt_relation_1').val(),
//        ContactName2: $('#txt_contact_name_2').val(),
//        ContactPhone2: $('#txt_contact_phone_2').val(),
//        ContactRelation2: $('#txt_relation_2').val(),



//        Active: $('#cbx_active').prop('checked')
//    };
//}

