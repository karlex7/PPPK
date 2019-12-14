using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class Vozilo
    {
        public int IDVozilo { get; set; }
        [Required]
        public int TipVozilaID { get; set; }
        [Required]
        public int MarkaVozilaID { get; set; }
        [Required]
        public int GodinaProizvodnje { get; set; }
        [Required]
        public float InicijalnoStanjeKilometara { get; set; }
        public Vozilo()
        {

        }
        
    }
}