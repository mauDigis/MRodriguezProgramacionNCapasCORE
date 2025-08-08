
function SoloLetras(input, event) {  //Funcion que permite solo letras y espacios
    let regexLetters = /^[a-zA-Z ]*$/;
    //let p = $("#" + pId);

    if (event.type == "keypress") {

        //Encontrar a el contenedor de mi etiqueta input
        var div = $(input).closest("div"); //el div más cerca de mi input
        var p = div.children("p"); //De mi etiqueta padre DIV, selecciona la etiqueta p

        if (regexLetters.test(event.key)) {

            $(input).css("border", "2px solid green");

            $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

            p.stop(true, true).css({ "color": "green", "font-weight": "bold" }).text("Entrada válida.")
                .show()                                 // Lo muestra
                .delay(3000)                            // Espera 3 segundos
                .fadeOut();                             // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(input).css("border", "1px solid #ccc");
            }, 3000);

            return true;
        } else {
            $(input).css("border", "2px solid red");

            $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

            p.stop(true, true).css({ "color": "red", "font-weight": "bold" }).text("No se permiten números.")    // Cambia el mensaje
                .show()                              // Lo muestra
                .delay(3000)                         // Espera 3 segundos
                .fadeOut();                          // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(input).css("border", "1px solid #ccc");
            }, 3000);

            return false;
        }

    } else if (event.type == "blur") {

        //Encontrar a el contenedor de mi etiqueta input
        var div = $(input).closest("div"); //el div más cerca de mi input
        var p = div.children("p"); //De mi etiqueta padre DIV, selecciona la etiqueta p

        if (regexLetters.test($(input).val())){

            $(input).css("border", "2px solid green");

            $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

            p.stop(true, true).css({ "color": "green", "font-weight": "bold" }).text("Entrada válida.")
                .show()                                 // Lo muestra
                .delay(3000)                            // Espera 3 segundos
                .fadeOut();                             // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(input).css("border", "1px solid #ccc");
            }, 3000);

            return true;
        } else {
            $(input).css("border", "2px solid red");

            $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

            p.stop(true, true).css({ "color": "red", "font-weight": "bold" }).text("No se permiten números.")    // Cambia el mensaje
                .show()                              // Lo muestra
                .delay(3000)                         // Espera 3 segundos
                .fadeOut();                          // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(input).css("border", "1px solid #ccc");
            }, 3000);

            return false;
        }
    }

}
function SoloNumeros(input, event) {
    let regexNumbers = /^[0-9]$/

    if (regexNumbers.test(event.key)) {
        $("txtTelefono").css("border", "2px solid green");
        $("#msgUsuarioTelefono")                            // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                       // Detiene animaciones anteriores
            .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
            .text("Entrada válida.")                // Cambia el mensaje de mi html
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtTelefono").css("border", "1px solid #ccc");
        }, 3000);

        return true;

    } else {
        $("txtTelefono").css("border", "2px solid red");
        $("#msgUsuarioTelefono")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("No se permiten letras.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra
            .delay(3000)                         // Espera 3 segundos
            .fadeOut();                          // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtTelefono").css("border", "1px solid #ccc");
        }, 3000);

        return false;
    }
}
function SinEspacios(input, event) { //Funcion que elimina espacios
    let regexNoSpaces = /\s/;

    if (regexNoSpaces.test(event.key)) {
        $(input).css("border", "2px solid red");

        $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

        $("#msgUsuarioUserName")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("No se permiten espacios.")    // Cambia el mensaje
            .show()                              // Lo muestra
            .delay(3000)                         // Espera 3 segundos
            .fadeOut();                          // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(input).css("border", "1px solid #ccc");
        }, 3000);

        return false;
    } else {
        $(input).css("border", "2px solid green");

        $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

        $("#msgUsuarioUserName")
            .stop(true, true)
            .css({ "color": "green", "font-weight": "bold" })
            .text("Entrada válida.")
            .show()
            .delay(3000)
            .fadeOut();

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(input).css("border", "1px solid #ccc");
        }, 3000);

        return true;
    }
}
function Solo10Numeros(input, pId, event) {
    let regexNumbers = /^[0-9]$/;
    let p = $("#" + pId);

    if (event.type == "keypress") {

        if (regexNumbers.test(event.key)) {
            $(input).css("border", "2px solid green");
            $(p)                            // Id de mi etiqueta <p> que muestra el mensaje.
                .stop(true, true)                       // Detiene animaciones anteriores
                .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
                .text("Entrada válida.")                // Cambia el mensaje de mi html
                .show()                                 // Lo muestra
                .delay(3000)                            // Espera 3 segundos
                .fadeOut();                             // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(p).css("border", "1px solid #ccc");
            }, 3000);

            return true;

        } else {
            $(input).css("border", "2px solid red");
            $(p)                         // Id de mi etiqueta <p> que muestra el mensaje.
                .stop(true, true)                    // Detiene animaciones anteriores
                .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
                .text("No se permiten letras ni espacios.")    // Cambia el mensaje de mi html
                .show()                              // Lo muestra
                .delay(3000)                         // Espera 3 segundos
                .fadeOut();                          // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(p).css("border", "1px solid #ccc");
            }, 3000);

            return false;
        }

    } else if (event.type == "blur") {

        let regexPhoneNumber = /^[0-9]{10}$/

        if (regexPhoneNumber.test($(input).val())) { //$(input).val() Me permite obtener el valor de toda mi caja
            $(input).css("border", "2px solid green");

            $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida
            
            $(p)                         // Id de mi etiqueta <p> que muestra el mensaje.
                .stop(true, true)                    // Detiene animaciones anteriores
                .css({ "color": "green", "font-weight": "bold" })  // Color rojo y texto en negritas
                .text("Datos correctos.")    // Cambia el mensaje de mi html
                .show()                              // Lo muestra
                .delay(3000)                         // Espera 3 segundos
                .fadeOut();                          // Desaparece el mensaje

            // Cambia el borde a gris después de 3 segundos
            setTimeout(function () {
                $(p).css("border", "1px solid #ccc");
            }, 3000);

            return true;
        } else {
            $(input).css("border", "2px solid red");

            $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

            $(p)                         // Id de mi etiqueta <p> que muestra el mensaje.
                .stop(true, true)                    // Detiene animaciones anteriores
                .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
                .text("Deben ser 10 dígitos.")    // Cambia el mensaje de mi html
                .show();                          // Lo muestra

            return false;
        }

    }

}
function ValidarCorreo(input, event) {
    let regexEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/

    if (regexEmail.test($(input).val())) {

        $(input).css("border", "2px solid green");

        $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

        $("#msgUsuarioEmail")                            // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                       // Detiene animaciones anteriores
            .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
            .text("Correo válido.")                // Cambia el mensaje de mi html
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(input).css("border", "1px solid #ccc");
        }, 3000);

        return true;
    } else {
        $(input).css("border", "2px solid red");

        $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

        $("#msgUsuarioEmail")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("Correo no válido.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra

        return false;
    }
}
function ValidarCurp(input, event) {
    let regexCurp = /^([A-Z][AEIOU][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/

    if (regexCurp.test($(input).val())) { //onblur

        $(input).css("border", "2px solid green");

        $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

        $("#msgUsuarioCurp")                            // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                       // Detiene animaciones anteriores
            .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
            .text("Curp válido.")                // Cambia el mensaje de mi html
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(input).css("border", "1px solid #ccc");
        }, 3000);

        return true;
    } else {
        $(input).css("border", "2px solid red");

        $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

        $("#msgUsuarioCurp")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("Curp no válido, deben ser 18 caracters.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra
        // Desaparece el mensaje

        return false;
    }
}
function ValidarPassword(input, event) {

    let regexPassword = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/

    if (regexPassword.test($(input).val())) {

        $(input).css("border", "2px solid green");

        $(input).addClass('is-valid').removeClass("is-invalid"); //Agrega la clase valida y elimina la invalida

        $("#msgUsuarioPassword")                            // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                       // Detiene animaciones anteriores
            .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
            .text("Contraseña válida.")                // Cambia el mensaje de mi html
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(input).css("border", "1px solid #ccc");
        }, 3000);

        return true;
    } else {
        $(input).css("border", "2px solid red");

        $(input).addClass('is-invalid').removeClass("is-valid"); //Agrega la clase invalida y elimina la valida

        $("#msgUsuarioPassword")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("Mínimo ocho caracteres, al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra

        return false;
    }
}
function ValidarRadioButton(radioButt, event) {

}
function ValidarDDL(DDL,event) {

    //Encontrar a el contenedor de mi etiqueta DDL
    var div = $(DDL).closest("div"); //el div más cerca de mi input
    var p = div.children("p"); //De mi etiqueta padre DIV, selecciona la etiqueta p

    // == string = "2"    int 2
    // ===   int "2"   int "2"S

    if ($(DDL).val() === "") {
        $(DDL).css("border", "2px solid red");
        p.stop(true, true).css({ "color": "red", "font-weight": "bold" }).text("Por favor, selecciona un rol.")    // Cambia el mensaje
            .show()                              // Lo muestra
            .delay(3000)                         // Espera 3 segundos
            .fadeOut();                          // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(DDL).css("border", "1px solid #ccc");
        }, 3000);

        return false;
    } else {
        p.stop(true, true).css({ "color": "green", "font-weight": "bold" }).text("Entrada válida.")
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $(DDL).css("border", "1px solid #ccc");
        }, 3000);

        return true;
    }
}

$(document).ready(function () {
    $('#UserForm').submit(function (event) {

        // Previene el envío del formulario por defecto
        event.preventDefault();

        // Bandera para rastrear el estado de la validación
        let isValid = true;

        // Limpia cualquier clase de error previa
        $('input, select').removeClass('is-invalid');

        // Validar cada campo de mi form

        //UserName
        if ($("#UserName").val() === "") {

            $("#UserName").css("border", "4px solid red");
            $("#UserName").addClass('is-invalid');
            isValid = false;
        } else {

            $("#UserName").addClass('is-valid');
            $("#UserName").css("border", "4px solid green");
        }

        //Password
        if ($("#Passwrd").val() === "") {

            $("#Passwrd").css("border", "4px solid red");
            $("#Passwrd").addClass('is-invalid');
            isValid = false;
        } else {

            $("#Passwrd").addClass('is-valid');
            $("#Passwrd").css("border", "4px solid green");
        }

        //Nombre
        if ($("#Nombre").val() === "") {

            $("#Nombre").css("border", "4px solid red");
            $("#Nombre").addClass('is-invalid');
            isValid = false;
        } else {

            $("#Nombre").addClass('is-valid');
            $("#Nombre").css("border", "4px solid green");
        }

        //ApellidoPaterno
        if ($("#ApellidoPaterno").val() === "") {

            $("#ApellidoPaterno").css("border", "4px solid red");
            $("#ApellidoPaterno").addClass('is-invalid');
            isValid = false;
        } else {

            $("#ApellidoPaterno").addClass('is-valid');
            $("#ApellidoPaterno").css("border", "4px solid green");
        }

        //ApellidoMaterno
        if ($("#ApellidoMaterno").val() === "") {

            $("#ApellidoMaterno").css("border", "4px solid red");
            $("#ApellidoMaterno").addClass('is-invalid');
            isValid = false;
        } else {

            $("#ApellidoMaterno").addClass('is-valid');
            $("#ApellidoMaterno").css("border", "4px solid green");
        }

        //Email
        if ($("#txtEmail").val() === "") {

            $("#txtEmail").css("border", "4px solid red");
            $("#txtEmail").addClass('is-invalid');
            isValid = false;
        } else {

            $("#txtEmail").addClass('is-valid');
            $("#txtEmail").css("border", "4px solid green");
        }

        //Fecha de Nacimiento
        if ($("#FechaNacimiento").val() === "") {

            $("#FechaNacimiento").css("border", "4px solid red");
            $("#FechaNacimiento").addClass('is-invalid');
            isValid = false;
        } else {

            $("#FechaNacimiento").addClass('is-valid');
            $("#FechaNacimiento").css("border", "4px solid green");
        }

        //Sexo
        //if ($("#Sexo").val() === "") {

        //    $("#Sexo").css("border", "4px solid red");
        //    $("#Sexo").addClass('is-invalid');
        //    isValid = false;
        //} else if ($("#sexoM").val() === "M" || $("#sexoF").val() === "F") { // Las || significan or.

        //    $("#Sexo").addClass('is-valid');
        //    $("#Sexo").css("border", "4px solid green");
        //}

        //Sexo
        if (!$("input[name='Sexo']:checked").val()) {

            $("#Sexo").css("border", "4px solid red");
            $("#Sexo").addClass('is-invalid');
            isValid = false;
        } else {

            $("#Sexo").addClass('is-valid');
            $("#Sexo").css("border", "4px solid green");
        }

        //Telefono
        if ($("#Telefono").val() === "") {

            $("#Telefono").css("border", "4px solid red");
            $("#Telefono").addClass('is-invalid');
            isValid = false;
        } else {
            
            $("#Telefono").addClass('is-valid').removeClass("is-invalid");
            $("#Telefono").css("border", "4px solid green");
        }

        //Celular
        if ($("#Celular").val() === "") {

            $("#Celular").css("border", "4px solid red");
            $("#Celular").addClass('is-invalid');
            isValid = false;
        } else {

            $("#Celular").addClass('is-valid');
            $("#Celular").css("border", "4px solid green");
        }

        //Curp
        if ($("#CURP").val() === "") {

            $("#CURP").css("border", "4px solid red");
            $("#CURP").addClass('is-invalid');
            isValid = false;
        } else {

            $("#CURP").addClass('is-valid');
            $("#CURP").css("border", "4px solid green");
        }

        // Validación específica para el rol
        if ($("#Rol_IdRol").val() === "") {

            $("#Rol_IdRol").css("border", "4px solid red");
            $("#Rol_IdRol").addClass('is-invalid');
            isValid = false;
        } else {

            $("#Rol_IdRol").addClass('is-valid');
            $("#Rol_IdRol").css("border", "4px solid green");
        }

        //Operador de negación lógica" o simplemente "not", y sirve para invertir el valor de verdad de una expresión.
        /*
            let isValid = true

            Si isValid es true → !isValid es false

            Si isValid es false → !isValid es true
           
        */

        // Si la validación falló en cualquier campo, muestra la alerta


        //Si es falso
        if (!isValid) {

            alert("Por favor, completa todos los campos obligatorios.");

        } else {
            // Si todo está correcto, envía el formulario
            this.submit();
        }
    });
});

/*
function SinEspacios(input, event) {
    let regex = /\s/; //Detecta cualquier espacio.

    if (regex.test(event.key)) {
        console.log("No paso");
        $("#txtUserName").css("border", "3px solid red");
        $("#msgUsuario").css("color", "red").text("No se permiten espacios.");
        return false;
    } else {
        console.log("Si paso");
        $("#txtUserName").css("border", "3px solid green");
        $("#msgUsuario").css("color", "green").text("Entrada válida.");
        return true;
    }
}
*/

