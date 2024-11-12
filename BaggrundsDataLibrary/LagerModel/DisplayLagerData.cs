using System.ComponentModel.DataAnnotations;

namespace WindsorX_2027.LagerModel
{
    public class DisplayLagerData()
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Varenummer er påkrævet")]
        public string? vareNummer { get; set; }
        public string? vareTekst { get; set; }
        public double? vareMaengde { get; set; }
        public string? enheder { get; set; }
        public double? kostPris { get; set; }
        public double? maxLager { get; set; }
        public double? minLager { get; set; }
        public double? salgsPris { get; set; }
        public string? location1 { get; set; }
        public string? location2 { get; set; }
        public DateTime? oprDato { get; set; }
        public DateTime? sidsteLagerBevDato { get; set; }
        public DateTime? sidsteBesstillingsDato { get; set; }
        public double? bestiltAntal { get; set; }
        public DateTime? lagerOptaltDato { get; set; }
    }
}
