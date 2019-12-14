using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class MarkaVozila
    {
        public int IDMarkaVozila { get; set; }
        public string Naziv { get; set; }
        public MarkaVozila()
        {

        }
        public override string ToString()
        {
            return Naziv;
        }
    }
}