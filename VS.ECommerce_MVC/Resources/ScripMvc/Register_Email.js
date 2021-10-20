function Register_Email() {
    debugger;
    var email = $("#txtemail").val();
    if ($("#txtemail").val() == "") {
        alert("Chưa điền thông tin email");
    } else {
        $.post("/AllPage/Register_Email",
            { "VEmail": email },
                 function (data)
                 {
                     $("#tb").html(data);
                 });
    }
}