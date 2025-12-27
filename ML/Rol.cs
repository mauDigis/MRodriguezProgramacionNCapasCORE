using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        [Key]
        [Required(ErrorMessage = "El Rol es obligatorio.")]
        [Display(Name = "Rol de Usuario")]
        public int? IdRol { get; set; } //Value
        public string? Nombre { get; set; } //Text
        public List<object>? Roles { get; set; }
    }
}
