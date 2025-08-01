using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Este archivo contiene los campos de MI TABLA de la BD

        //Metodo GET - Obtengo los datos

        //Metodo SET - Modifico los datos y establesco un dato nuevo a la propiedad

        //Definición de una propiedad: public int Id { get; set; }

        //Propiedades
        public int IdUsuario { get; set; }
        public string? UserName { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Email { get; set; }
        public string? Passwrd { get; set; }
        public string? Sexo { get; set; }

        public string[]? Sexos = new[] { "M", "F" };
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? CURP { get; set; }
        public Rol? Rol { get; set; } //Defino mi propiedad de mi modelo MLRol para acceder a las propiedades de navegación.
        public List<object>? Usuarios { get; set; } //Definición de una lista de objetos de Usuarios
    }
}
