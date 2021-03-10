using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInformatica.Models
{
    public class Usuario
    {
        public int CodUsuario { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome do Usuário")]
        public String NomeUsuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [Display(Name = "Senha do Usuário")]
        public String SenhaUsuario { get; set; }
    }
}