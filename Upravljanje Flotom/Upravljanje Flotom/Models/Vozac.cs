using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class Vozac
    {
        public int IDVozac { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string BrojMobitela { get; set; }
        [Required]
        public string BrojVozacke { get; set; }
        public Vozac()
        {

        }

        public override string ToString()
        {
            return Ime+" "+Prezime;
        }
    }
}