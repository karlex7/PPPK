using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class PutniNalog
    {
        public int IDPutniNalog { get; set; }
        [Required]
        public int VozacID { get; set; }
        [Required]
        public int VoziloID { get; set; }
        [Required]
        public DateTime VrijemePocetka { get; set; }
        [Required]
        public DateTime VrijemeZavrsetka { get; set; }
        [Required]
        public string OstaliDetalji { get; set; }
        public Status Stanje { get; set; }

        public PutniNalog()
        {
            
        }
        public void PostaviStanje()
        {
            DateTime danasnjiDatum = DateTime.Now;
            int comparePocetak = DateTime.Compare(danasnjiDatum, DateTime.Parse(VrijemePocetka.ToString()));
            int compareZavrsni = DateTime.Compare(danasnjiDatum, VrijemeZavrsetka);
            if (comparePocetak<0&&compareZavrsni<0)
            {
                //Status = 3;//Buduci
                Stanje = Status.Buduci;
                return;

            }
            if(comparePocetak>0&&compareZavrsni<0)
            {
                //Status = 2;//
                Stanje = Status.Otvoreni;
                return;
            }
            if (compareZavrsni > 0)
            {
                //Status = 1;
                Stanje = Status.Zavrseni;
                return;
            }
        }

    }
}