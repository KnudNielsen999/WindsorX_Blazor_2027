using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggrundsDataLibrary.LagerTransAktioner
{
    public class TransaktionerModel
    {
        public int Id { get; set; }
        public string? ProduktNummer { get; set; }
        public string? ProduktNavn { get; set; }
        public double? ProduktAntal { get; set; }
        public DateTime TransaktionsDato { get; set; } = DateTime.Now;
        public string? TransaktionsType { get; set; }
        public string? OrdreNummer { get; set; }
        public string? BrugerId { get; set; }

    }

}
