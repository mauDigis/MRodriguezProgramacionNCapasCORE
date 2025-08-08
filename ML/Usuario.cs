using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML
{
    public class Usuario
    {
        //Este archivo contiene los campos de MI TABLA de la BD

        //Metodo GET - Obtengo los datos

        //Metodo SET - Modifico los datos y establesco un dato nuevo a la propiedad

        //Definición de una propiedad: public int Id { get; set; }

        //Propiedades

        [Key] //Marca como un identificador único.

        public int IdUsuario { get; set; }

        //DATA ANNOTATIONS

        [Required(ErrorMessage = "UserName es un campo obligatorio")] //Se utiliza para colocar una propiedad obligatoria.
        [Display(Name = "DA Nombre de Usuario")] //Display atributo para proporcionar un texto intuitivo para las propiedades.
        [MaxLength(50, ErrorMessage = "UserName no puede exceder los 50 caracteres")] //Se utiliza para limitar el campo a un máximo de caracteres.
        [MinLength(3)] //Funciona para delimitar un minimo de caracters.
        [RegularExpression(@"\S+", ErrorMessage = "No se pueden introducir espacios")] //Coloca una Expresion Regular
        public string? UserName { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "DA Nombre")]
        [MaxLength(50, ErrorMessage = "Nombre no puede exceder los 50 caracteres")]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "Solo se permiten letras y espacios.")] 
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio.")]
        [Display(Name = "DA Apellido Paterno")]
        [MaxLength(50, ErrorMessage = "Apellido Paterno no puede exceder los 50 caracteres")]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "No se pueden introducir números.")]
        public string? ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es obligatorio.")]
        [Display(Name = "DA Apellido Materno")]
        [MaxLength(50, ErrorMessage = "Apellido Materno no puede exceder los 50 caracteres")]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "No se pueden introducir números.")]
        public string? ApellidoMaterno { get; set; }


        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [Display(Name = "DA Correo Electrónico")]
        [MaxLength(254, ErrorMessage = "Correo Electrónico no puede exceder los 254 caracteres")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "El formato del correo electrónico es inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [Display(Name = "DA Contraseñaa")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener mínimo 8 caracters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.")]
        public string? Passwrd { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio.")]
        [Display(Name = "DA Genero del Usuario")]
        [MinLength(1)]
        public string? Sexo { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [Display(Name = "Número de Teléfono")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "El número de teléfono no es válido. Por favor, usa 10 dígitos.")]
        public string? Telefono { get; set; }

        
        [Display(Name = "Número de Celular")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "El número de celular no es válido. Por favor, usa 10 dígitos.")]

        public string? Celular { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Display(Name = "Fecha de Nacimiento")]
        public string? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El CURP es obligatorio.")]
        [Display(Name = "CURP")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "El CURP debe tener 18 caracteres.")]
        [RegularExpression(@"^[A-Z]{4}[0-9]{6}[H|M][A-Z]{2}[B|C|D|F|G|H|J|K|L|M|N|Ñ|P|Q|R|S|T|V|W|X|Y|Z]{3}[0-9|A-Z]{2}$",
        ErrorMessage = "El CURP no es válido. Verifica el formato.")]
        public string? CURP { get; set; }
        public Rol? Rol { get; set; } //Defino mi propiedad de mi modelo MLRol para acceder a las propiedades de navegación.
        public List<object>? Usuarios { get; set; } //Definición de una lista de objetos de Usuarios
    }
}
