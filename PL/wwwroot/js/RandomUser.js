function GenerarRandomUser()
{
    $.ajax({
        type: 'GET',
        url: 'https://randomuser.me/api/',
        dataType: 'json',
        success: function (infoObtenida) {
            // Almacena la cadena HTML en una variable.
            var Tabladinamica = 
            "<tr>" +
                "<td>" + infoObtenida.results[0].name.title + " " + infoObtenida.results[0].name.first + " " + infoObtenida.results[0].name.last + "</td>" +
                "<td>" + infoObtenida.results[0].gender + "</td>" +
                "<td>" + infoObtenida.results[0].location.state + " " + infoObtenida.results[0].location.country + "</td>" +
                "<td>" + infoObtenida.results[0].email + "</td>" +
                "<td>" + infoObtenida.results[0].dob.date + "</td>" +
                "<td>" + infoObtenida.results[0].phone + "</td>" +
                "<td>" + "<img src='" + infoObtenida.results[0].picture.large + "'>" + "</img>" + "</td>" +
            "</tr>";

            $("#TablaDinamica tbody").append(Tabladinamica); 
        }
    });
}