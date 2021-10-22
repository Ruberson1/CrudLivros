using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage ="O [0] deve ser ao menos {2} e maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Titulo")]

        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, ErrorMessage = "O [0] deve ser ao menos {2} e maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha lançamento")]
        public DateTime FechaLancamento { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Autor { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        public int Preco { get; set; }


    }
}
