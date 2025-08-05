
function SoloLetras(input, event) {  //Funcion que permite solo letras y espacios
    let regex = /^[a-zA-Z ]*$/

    if (regex.test(event.key)) {

        $("txtNombre").css("border", "2px solid green");
        $("#msgUsuarioNombre")                            // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                       // Detiene animaciones anteriores
            .css({ "color": "green", "font-weight": "bold" }) // Color verde y texto en negritas
            .text("Entrada válida.")                // Cambia el mensaje
            .show()                                 // Lo muestra
            .delay(3000)                            // Espera 3 segundos
            .fadeOut();                             // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtUserName").css("border", "1px solid #ccc");
        }, 3000);

        return true;
    } else {
        $("txtNombre").css("border", "2px solid red");
        $("#msgUsuarioNombre")                         // Id de mi etiqueta <p> que muestra el mensaje.
            .stop(true, true)                    // Detiene animaciones anteriores
            .css({ "color": "red", "font-weight": "bold" })  // Color rojo y texto en negritas
            .text("No se permiten números.")    // Cambia el mensaje
            .show()                              // Lo muestra
            .delay(3000)                         // Espera 3 segundos
            .fadeOut();                          // Desaparece el mensaje

        // Cambia el borde a gris después de 3 segundos
        setTimeout(function () {
            $("#txtUserName").css("border", "1px solid #ccc");
        }, 3000);

        return false;
    }
}
function SoloNumeros(input, event) {
    let regex = /^[0-9]$/

    if (regex.test(event.key)) {
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
    let regex = /\s/;

    if (regex.test(event.key)) {
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

function ValidarCorreo(input, event) {
    let regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/

    if (regex.test($(input).val())) {

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


// Validacion para numeros  Celular y telefono
// Validacion para username
// validacion CURP, correo  evento onblur