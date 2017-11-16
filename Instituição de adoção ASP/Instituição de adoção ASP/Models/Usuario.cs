using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instituição_de_adoção_ASP.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Nome de Usuario")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(10, ErrorMessage = " No mínimo 10 caracteres")]
        [MaxLength(10, ErrorMessage = " No máximo 10 caracteres")]
        [Display(Name = "Telefone de Usuairio")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 13 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Email de Usuario")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Endereço de Usuario")]
        public string Endereco { get; set; }

    }
}