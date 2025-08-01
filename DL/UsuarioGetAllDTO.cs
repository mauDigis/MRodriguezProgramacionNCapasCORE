using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UsuarioGetAllDTO
    {
        //Propiedades del STORED PROCEDURE UsuarioGetAll
        public int IdUsuario { get; set; }

        public string UserName { get; set; }

        public string UsuarioNombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Email { get; set; }

        public string Passwrd {  get; set; }
        
        public string Sexo {  get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CURP { get; set; }

        public int IdRol {  get; set; }

        public string RolNombre { get; set; }
    }
}
