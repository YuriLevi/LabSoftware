using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProvedorDeServicos.Models
{
    public class Usuario : IdentityUser
    {


        [Required]
        [Column(TypeName = "char(1)")]
        public int Tipo { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public int FullName { get; set; }


        /*
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public String Nome { get; set; }


        [Required]
        [Column(TypeName = "varchar(14)")]
        public String CPF { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public String Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public String Senha { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public String Endereco { get; set; }

        */
    }
}
