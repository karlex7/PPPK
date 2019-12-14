using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.Models
{
    public class TroskoviGoriva
    {
        public int IDTroskoviGoriva { get; set; }
        public int PutniNalogID { get; set; }
        public float KolicinaGoriva { get; set; }
        public float CijenaGoriva { get; set; }
        public DateTime VrijemePlacanja { get; set; }
        public TroskoviGoriva()
        {

        }

    }
}