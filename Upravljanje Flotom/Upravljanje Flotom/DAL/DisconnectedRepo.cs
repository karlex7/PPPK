using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Upravljanje_Flotom.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Xml;
using System.Xml.Linq;

namespace Upravljanje_Flotom.DAL
{
    public class DisconnectedRepo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        static SqlDatabase db = new SqlDatabase(cs);
        private readonly string XML_PATH_PUTNI_NALOG = System.Web.Hosting.HostingEnvironment.MapPath("~/putniNalozi.xml");
        private readonly string XML_PATH_VOZACI = System.Web.Hosting.HostingEnvironment.MapPath("~/vozaci.xml");

        public List<MarkaVozila> getAllMarkaVozila()
        {
            List<MarkaVozila> markaVozilas = new List<MarkaVozila>();
            DataTable dt = new DataTable();
            dt.Load(db.ExecuteReader("GET_ALL_MARKE"));

            foreach (DataRow row in dt.Rows)
            {
                markaVozilas.Add(new MarkaVozila {
                IDMarkaVozila=int.Parse(row["IDMarkaVozila"].ToString()),
                Naziv=row["Naziv"].ToString()});
            }
            return markaVozilas;
        }
        public void insertVozilo(Vozilo v)
        {
            db.ExecuteNonQuery("INSERT_VOZILO", v.TipVozilaID, v.MarkaVozilaID, v.GodinaProizvodnje, v.InicijalnoStanjeKilometara);
        }


        /**********X M L********/
        public void exportPutniNalogXML()
        {
            SqlConnection con = new SqlConnection(cs);
            DataSet ds = new DataSet("PutniNalog");
            SqlDataAdapter sda = new SqlDataAdapter("select * from PutniNalog", con);

            sda.Fill(ds);
            ds.Tables[0].TableName = "PutniNalogs";
            ds.WriteXml(XML_PATH_PUTNI_NALOG, XmlWriteMode.WriteSchema);

            con.Close();
            
        }
        public List<PutniNalog> loadPtuniNalogXML()
        {
            List<PutniNalog> putniNalogs = new List<PutniNalog>();

            DataSet ds = new DataSet();

            ds.ReadXml(XML_PATH_PUTNI_NALOG);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                putniNalogs.Add(new PutniNalog
                {
                    IDPutniNalog = int.Parse(row["IDPutniNalog"].ToString()),
                    VozacID = int.Parse(row["VozacID"].ToString()),
                    VoziloID = int.Parse(row["VoziloID"].ToString()),
                    VrijemePocetka = (DateTime)row["VrijemePocetka"],
                    VrijemeZavrsetka = (DateTime)row["VrijemeZavrsetka"],
                    OstaliDetalji = row["OstaliDetalji"].ToString()
                });
            }


            return putniNalogs;
        }

        /*************X M L READER/WRITER***************/

        public void writeVozacsXml()
        {
            XmlWriterSettings xmlPostavke = new XmlWriterSettings();
            xmlPostavke.Indent=true;
            XmlWriter xmlWriter = XmlWriter.Create(XML_PATH_VOZACI, xmlPostavke);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("vozaci");  //Ishodisni element

            foreach (Vozac vozac in RepoFactory.GetRepo().getAllVozaci())
            {

                //Vozac
                xmlWriter.WriteStartElement("vozac");
                xmlWriter.WriteAttributeString("ID", vozac.IDVozac.ToString());

                //Ime
                xmlWriter.WriteStartElement("ime");
                xmlWriter.WriteString(vozac.Ime);
                xmlWriter.WriteEndElement();

                //Prezime
                xmlWriter.WriteStartElement("prezime");
                xmlWriter.WriteString(vozac.Prezime);
                xmlWriter.WriteEndElement();

                //Broj mobitela
                xmlWriter.WriteStartElement("brojMobitela");
                xmlWriter.WriteString(vozac.BrojMobitela);
                xmlWriter.WriteEndElement();

                //Broj vozacke
                xmlWriter.WriteStartElement("brojVozacke");
                xmlWriter.WriteString(vozac.BrojVozacke);
                xmlWriter.WriteEndElement();

                //Kraj vozaca
                xmlWriter.WriteEndElement();
            }
            //Kraj ishodisnog
            xmlWriter.WriteEndElement();

            xmlWriter.Close();
        }

        public List<Vozac> getVozacsXml()
        {
            //Brisanje svih vozaca
            //RepoFactory.GetRepo().deleteALLVozac();


            List<Vozac> vozacs = new List<Vozac>();

            XmlDocument xmlDOM = new XmlDocument();
            xmlDOM.Load(XML_PATH_VOZACI);

            XmlNodeList kolekcijaVozaca = xmlDOM.GetElementsByTagName("vozac");

            foreach (XmlNode vozac in kolekcijaVozaca)
            {
                Vozac v = new Vozac();
                v.IDVozac = int.Parse(vozac.Attributes[0].Value);

                foreach (XmlNode podatak in vozac.ChildNodes)
                {
                    switch (podatak.Name)
                    {
                        case "ime":
                            v.Ime = podatak.InnerText;
                            break;
                        case "prezime":
                            v.Prezime = podatak.InnerText;
                            break;
                        case "brojMobitela":
                            v.BrojMobitela = podatak.InnerText;
                            break;
                        case "brojVozacke":
                            v.BrojVozacke = podatak.InnerText;
                            break;
                        default:
                            break;
                    }
                }
                
                    vozacs.Add(v);
            }
            foreach (Vozac vozac in vozacs)
            {
                RepoFactory.GetRepo().insertVozac(vozac);
            }
            return vozacs;
        }

    }
}