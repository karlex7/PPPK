using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class TipVozila
    {
        public int IDTipVozila { get; set; }
        public string Naziv { get; set; }
        public TipVozila()
        {

        }
        public override string ToString()
        {
            return Naziv;
        }
    }
}