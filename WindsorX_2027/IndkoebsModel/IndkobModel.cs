using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using WindsorX_2027.LagerModel;

namespace WindsorX_2027.IndkoebsModel
{
    public class IndkobModel
    {
        public int Id { get; set; }
        public string? ordreNummer { get; set; }
        public string? kundeNummer { get; set; }
        public DateTime ordreDato { get; set; }
        public string? ordreDetaljer { get; set; }
        public string? referenceDetaljer { get; set; }
        public string? leverandorNummer { get; set; }

        public List<OrdreModel> ordreLinjer { get; set; } = new List<OrdreModel>();

    }
    public class OrdreModel
    {
        public int Id { get; set; }
       
        public string? leverandørNummer { get; set; }
        public Lagermodel? vareNummer { get; set; }
        public Lagermodel? vareTekst { get; set; }
        public double? ordreAntal { get; set; }
        public Lagermodel?  enheder { get; set; }
        public Lagermodel? kostPris { get; set; }
        public int IndkobModelId { get; set; }       // Fremmednøgle
        public IndkobModel Indkob { get; set; }      // Navigationsejendom

    }
    public class LeverandorReg
    {
        public int Id { get; set; }
        public string? leverandorNummer { get; set; }
        public string? Firmanavn { get; set; }
        public string? adresse { get; set; }

        public string? byNavn { get; set; }
        public string? postNummer { get; set; }
        public string? telefonNummer1 { get; set; }
        public string? telefonNummer2 { get; set; }
        public string? kontaktPerson { get; set; }
        public string? kontaktOplysninger { get; set; }
        public string? email1 { get; set; }
        public string? email2 { get; set;}

    }
}
