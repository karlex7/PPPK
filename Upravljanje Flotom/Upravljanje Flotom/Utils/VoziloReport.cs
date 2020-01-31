using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Upravljanje_Flotom.DAL;
using Upravljanje_Flotom.Models;

namespace Upravljanje_Flotom.Utils
{
    public class VoziloReport
    {
        private string PATH_REPORT = @"C:\Users\FRIDAY\Documents\PPPK\Projekt\Upravljanje Flotom\Upravljanje Flotom";
        private string path;
        IRepo repo = RepoFactory.GetRepo();
        private PPPKFleetManagementEntities db = new PPPKFleetManagementEntities();

        public void generateReport(int idVozilo)
        {
            path = PATH_REPORT + @"\" + idVozilo + ".html";

            Vozilo vozilo = repo.getVozilo(idVozilo);

            //Dohvacanje servisa
            List<Servi> servisi = new List<Servi>();
            foreach (GET_SERVISI_FOR_VOZILO_Result item in db.GET_SERVISI_FOR_VOZILO(idVozilo))
            {
                int idServis = item.IDServis;
                string naziv = item.Naziv;
                string detalji = item.Detalji;
                double cijena = double.Parse(item.Cijena.ToString());
                int idvozilo = int.Parse(item.VoziloID.ToString());

                Servi s = new Servi();
                s.IDServis = idServis;
                s.Naziv = naziv;
                s.Detalji = detalji;
                s.Cijena = cijena;
                s.VoziloID = idvozilo;

                servisi.Add(s);
            }

            makeReport(vozilo, servisi);
        }

        private void makeReport(Vozilo vozilo, List<Servi> servisi)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head><link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css\"></head><body>");
            sb.Append("<div class='container'>");
            sb.Append("<h1>Report za vozilo</h1>");
            sb.Append("<h3> Vozilo ID: "+vozilo.IDVozilo.ToString()+"</h3>");
            sb.Append("<h3> Marka : " + getMarka(vozilo.MarkaVozilaID) + "</h3>");
            sb.Append("<h3> Godina proizvodnje : " + vozilo.GodinaProizvodnje.ToString() + "</h3>");
            sb.Append("<h3> Inicijalno stanje kilometra : " + vozilo.InicijalnoStanjeKilometara.ToString() + "km </h3>");

            sb.Append("<br>");
            sb.Append("<h2>Servisi</h2>");
            foreach (Servi s in servisi)
            {
                sb.Append("<h4> Naziv: " + s.Naziv + "</h4>");
                sb.Append("<h4> Detalji: " + s.Detalji + "</h4>");
                sb.Append("<h4> Ciejna: " + s.Cijena + " HRK</h4>");
                sb.Append("<hr/>");
            }
              

            sb.Append("</div></body></html>");
            System.IO.File.WriteAllText(path, sb.ToString()) ;
        }
        private string getMarka(int idMarka)
        {
            List<MarkaVozila> listaMarka = repo.getAllMarkaVozila();

            foreach (MarkaVozila marka in listaMarka)
            {
                if (marka.IDMarkaVozila==idMarka)
                {
                    return marka.Naziv;
                }
            }
            return "Greska";

        }

    }
}