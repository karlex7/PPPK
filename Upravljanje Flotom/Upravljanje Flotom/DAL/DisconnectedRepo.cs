using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Upravljanje_Flotom.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Upravljanje_Flotom.DAL
{
    public class DisconnectedRepo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        static SqlDatabase db = new SqlDatabase(cs);
        private readonly string XML_PATH = System.Web.Hosting.HostingEnvironment.MapPath("~/xml.xml");

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
            ds.WriteXml(XML_PATH, XmlWriteMode.WriteSchema);

            con.Close();
            
        }
        public List<PutniNalog> loadPtuniNalogXML()
        {
            List<PutniNalog> putniNalogs = new List<PutniNalog>();

            DataSet ds = new DataSet();

            ds.ReadXml(XML_PATH);
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
    }
}