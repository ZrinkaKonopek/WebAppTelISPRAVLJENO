using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppTel.Models
{
        public class Marka
        {
            [Required(ErrorMessage = "Polje {0} je obvezno.")]
            [Display(Name = "#")]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
            [Required(ErrorMessage = "Polje {0} je obvezno.")]
            public string Naziv { get; set; }

            public List<Mobitel> Mobiteli { get; set; }
        }
    }

