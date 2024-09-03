using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysSeguridadG05.EN
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es Obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        [Display(Name = "Nombre Usuario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Login es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "El Password debe estar 5 y 32 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Estatus es Obligatorio")]
        public byte Estatus { get; set; }
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
        public Rol Rol { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar Password")]
        [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y comfirmar password deben " +
            "ser iguales")]
        [Display(Name = "Confirmar Password")]
        public string ConfirmPassword_aux { get; set; }
    }
    public enum Estatus_Usuario
    { 
        ACTIVO = 1,
        INACTIVO = 2
    }
}
