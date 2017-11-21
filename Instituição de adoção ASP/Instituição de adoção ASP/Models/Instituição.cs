using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Instituição_de_adoção_ASP.Models
{
    [Table("Instituições")]
    public class Instituição
    {
        [Key]
        public int InstituiçãoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(15, ErrorMessage = " No máximo 15 caracteres")]
        [Display(Name = "Login da Instituição")]
        public string InstituiçãoLogin { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(18, ErrorMessage = " 18")]
        [Display(Name = "Senha da Instituição")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string InstituiçãoSenha { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Nome da Instituição")]
        public string InstituiçãoNome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(10, ErrorMessage = " No mínimo 10 caracteres")]
        [MaxLength(10, ErrorMessage = " No máximo 10 caracteres")]
        [Display(Name = "Telefone da Instituição")]
        public string InstituiçãoTelefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 13 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Email da Instituição")]
        public string InstituiçãoEmail { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = " No mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = " No máximo 50 caracteres")]
        [Display(Name = "Endereço da Instituição")]
        public string InstituiçãoEndereco { get; set; }
        public Categoria Categoria { get; set; }
        public Animal Animal { get; set; }
        public Usuario Usuario { get; set; }
    }
}