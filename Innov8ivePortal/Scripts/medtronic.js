function toggle() {
    // Get the checkbox
    var checkBox = document.getElementById("adminFill");

    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        document.getElementById('admin').style.display = "block";
    } else {
        document.getElementById('admin').style.display = "none";
    }

}

function makeid(length) {
    var result = '';
    var characters = '0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}

function prefill() {
    document.getElementById('patientId').value = makeid(10);
    document.getElementById('visitNumber').value = makeid(10);
    document.getElementById('patientName').value = "Patient Pete";
    document.getElementById('patientDOB').value = "1/1/1990";
    document.getElementById('streetAddress').value = "123 Main St.";
    document.getElementById('city').value = "Madison";
    document.getElementById('state').value = "WI";
    document.getElementById('zip').value = "53917";
    document.getElementById('hcpName').value = "Doctor Denise";
    document.getElementById('hcpEmail').value = "doctordenise@mudge.co";
    document.getElementById('adminName').value = "Admin Andy";
    document.getElementById('adminEmail').value = "adminandy@mudge.co";
    document.getElementById('repName').value = "Fieldrep Frank";
    document.getElementById('repEmail').value = "senderrob+medtronic@outlook.com";
    document.getElementById('cmn').checked = "true";
    document.getElementById('rx').checked = "true";
}