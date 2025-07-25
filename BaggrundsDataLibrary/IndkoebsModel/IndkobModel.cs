﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WindsorX_2027.LagerModel;

namespace WindsorX_2027.IndkoebsModel
{
    public class IndkobModel
    {
        public int Id { get; set; }
        public string? ordreNummer { get; set; }
        public string? kundeNummer { get; set; }
        public DateTime ordreDato { get; set; } = DateTime.Now;
        public string? ordreDetaljer { get; set; }
        public string? referenceDetaljer { get; set; }
        public string? leverandorNummer { get; set; }
        public bool open { get; set; } = true; // status om ordren er aktiv

        // Liste af ordrelinjer knyttet til dette indkøb
        public List<OrdreModel> ordreLinjer { get; set; } = new List<OrdreModel>();
    }

    public class OrdreModel
    {
        public int Id { get; set; }
        public string? leverandørNummer { get; set; }
        public string? vareNummer { get; set; }
        public string? vareTekst { get; set; }
        public double? ordreAntal { get; set; }
        public string? enheder { get; set; }
        public double? kostPris { get; set; }

        // Foreign key til IndkobModel
        public int IndkobModelId { get; set; } // Ikke-nullable

        // Navigation property til at referere til IndkobModel
        [ForeignKey("IndkobModelId")]
        public IndkobModel IndkobModel { get; set; } = null!; // Ikke-nullable
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
