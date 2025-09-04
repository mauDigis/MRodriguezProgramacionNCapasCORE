
function SoloLetras(input, event) {  //Funcion que permite solo letras y espacios
    let regexLetters = /^[a-zA-Z ]*$/;
    //let p = $("#" + pId); 

    //Encontrar a el contenedor de mi etiqueta input
    var div = $(input).closest("div"); //el div más cerca de mi input
    var p = div.children("p"); //De mi etiqueta padre DIV, selecciona la etiqueta p

    console.log(div)
    console.log(p)

    if (regexLetters.test(event.key)) {

        $(input).css("border", "2px solid green");
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
        $("#txtUserName").css("border", "2px solid red");
        $("#msgUsuarioUserName")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("No se permiten espacios.")    // Cambia el mensaje
            .show()                              // Lo muestra
            .delay(3000)                         // Espera 3 segundos
            .fadeOut();                          // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtUserName").css("border", "1px solid #ccc");
        }, 3000);

        return false;
    } else {
        $("#txtUserName").css("border", "2px solid green");
        $("#msgUsuarioUserName")
            .stop(true, true)
            .css({ "color": "green", "font-weight": "bold" })
            .text("Entrada válida.")
            .show()
            .delay(3000)
            .fadeOut();

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtUserName").css("border", "1px solid #ccc");
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
        $(input).css()
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
        $("#msgUsuarioCurp")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("Curp no válido.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra
                                      // Desaparece el mensaje

        return false;
    }
}
function ValidarPassword(input, event) {
    let regexPassword = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/

    if (regexPassword.test($(input).val())) {

        $(input).css("border", "2px solid green");
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
        $("#msgUsuarioPassword")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("Mínimo ocho caracteres, al menos una letra mayúscula, una letra minúscula, un número y un carácter especial.")    // Cambia el mensaje de mi html
            .show()                              // Lo muestra

        return false;
    }
}

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

