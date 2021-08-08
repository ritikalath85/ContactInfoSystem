function SetGender(rdbutton) {
    debugger;
    var radiobuttonId = rdbutton.id;
    if ($("#" + radiobuttonId).prop("checked")) {
        $("#hdnGender").val($("#" + radiobuttonId).val());
    }
}

function ValidateUser() {
    debugger;
    var txtUserFullName = $("#txtUserFullName").val();
    var txtUserEmail = $("#txtUserEmail").val();
    var txtPassword = $("#txtPassword").val();
    var txtConfirmPassword = $("#txtConfirmPassword").val();
    var txtMobileNo = $("#txtMobileNo").val();
    var scDesignation = $("#scDesignation").val();
    var scCountry = $("#scCountry").val();
    var userfilename = $('#exampleFormControlFile1').val()

    if (txtUserFullName == null || txtUserFullName == undefined || txtUserFullName == '') {
        alert("Please enter User full name");
        $("#txtUserFullName").focus();
        return false;
    }
    else if (txtUserEmail == null || txtUserEmail == undefined || txtUserEmail == '') {
        alert("Please enter Email Address");
        $("#txtUserEmail").focus();
        return false;
    }
    else if (txtPassword == null || txtPassword == undefined || txtPassword == '') {
        alert("Please enter password");
        $("#txtPassword").focus();
        return false;
    }
    else if (txtConfirmPassword == null || txtConfirmPassword == undefined || txtConfirmPassword == '') {
        alert("Please enter confirm password");
        $("#txtConfirmPassword").focus();
        return false;
    }
    else if (txtPassword != txtConfirmPassword) {
        alert("Password and confirm password should be same");
        $("#txtConfirmPassword").focus();
        return false;
    }
    else if (txtMobileNo == null || txtMobileNo == undefined || txtMobileNo == '') {
        alert("Please enter Mobile No");
        $("#txtMobileNo").focus();
        return false;
    }
    else if ($('input[name="grpGender"]:checked').length == 0) {
        alert("Please select gender");
        $("#rdMale").focus();
        return false;
    }
    else if (scDesignation == "0") {
        alert("Please select designation");
        $("#txtMobileNo").focus();
        return false;
    }
    else if (scDesignation == "0") {
        alert("Please select country");
        $("#scCountry").focus();
        return false;
    }
    else if (userfilename == null || userfilename == undefined || userfilename == '') {
        alert("Please provide profile image!!");
        $("#exampleFormControlFile1").focus();
        return false;
    }
    else if (!validate_filesize('exampleFormControlFile1')) {
        alert("File size cannot be greater than 2MB");
        $("#exampleFormControlFile1").focus();
        return false;
    }
    else if (!validate_fileupload(userfilename)) {
        alert("Only png, jpg and jpeg is allowed");
        $("#exampleFormControlFile1").focus();
        return false;
    }
    else {
        if (confirm('Are you sure you want to submit the data?')) {
            return true;
        }
        else {
            return false;
        }
    }
}

function validate_filesize(filecontrolId) {
    var fileSize = $('#' + filecontrolId)[0].files[0].size;
    if (fileSize > (2048 * 1024)) {
        return false;
    }
    else {
        return true;
    }
}


function validate_fileupload(fileName) {
    var allowed_extensions = new Array("jpg", "png", "jpeg");
    var file_extension = fileName.split('.').pop().toLowerCase();

    var fileSize = $('#exampleFormControlFile1')[0].files[0].size;
    if (fileSize > (2048 * 1024)) {

    }
    // alert(fileSize);

    // var fileSize = $('#exampleFormControlFile1').File;
    for (var i = 0; i <= allowed_extensions.length; i++) {
        if (allowed_extensions[i] == file_extension) {
            return true; // valid file extension
        }
    }

    return false;
}
