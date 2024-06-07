using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorAmor.Application.DTO
{
    public class BlumeDTO
    {
        public Guid Guid { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Der Artname muss zwischen 2 und 100 Zeichen lang sein.")]
        public string Art { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Der Preis muss positiv sein.")]
        public decimal Preis { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Die Stückzahl muss positiv sein.")]
        public int Stückzahl { get; set; }

        [StringLength(50, ErrorMessage = "Die Farbe darf nicht mehr als 50 Zeichen enthalten.")]
        public string Farbe { get; set; }
    }
}
