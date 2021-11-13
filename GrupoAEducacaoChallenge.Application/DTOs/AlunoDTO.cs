using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Application.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The RA is Required")]
        [DisplayName("RA")]
        public int Ra { get; set; }

        [Required(ErrorMessage = "The CPF is Required")]
        [DisplayName("CPF")]
        public string CPF { get; set; }
    }
}
