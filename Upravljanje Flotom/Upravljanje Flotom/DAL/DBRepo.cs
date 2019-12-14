using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Upravljanje_Flotom.Models;

namespace Upravljanje_Flotom.DAL
{
    public class DBRepo : IRepo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public void deletePutniNalog(int idPutniNalog)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "DELETE_PUTNI_NALOG";
                    comm.Parameters.AddWithValue("@IDputniNalog", idPutniNalog);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void deleteVozac(int idVozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm = con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "DELETE_VOZAC";
                    comm.Parameters.AddWithValue("@IDvozac", idVozac);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void deleteVozilo(int idVozilo)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm = con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "DELETE_VOZILO";
                    comm.Parameters.AddWithValue("@IDvozilo", idVozilo);
                    comm.ExecuteNonQuery();
                }
            }
        }
        //TEXT
        public List<MarkaVozila> getAllMarkaVozila()
        {
            List<MarkaVozila> allVozila = new List<MarkaVozila>();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = "select * from MarkaVozila";
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                allVozila.Add(new MarkaVozila { 
                                    IDMarkaVozila=(int)r["IDMarkaVozila"],
                                    Naziv=r["Naziv"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return allVozila;
        }
        //-------TRANSACTION---------
        public List<PutniNalog> getAllPutniNalog()
        {
            List<PutniNalog> allPutniNalog = new List<PutniNalog>();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    using (SqlCommand comm = new SqlCommand("select * from PutniNalog",con,transaction))
                    {
                        using (SqlDataReader r = comm.ExecuteReader())
                        {
                            if (r.HasRows)
                            {
                                while (r.Read())
                                {
                                    allPutniNalog.Add(new PutniNalog
                                    {
                                        IDPutniNalog = (int)r["IDPutniNalog"],
                                        VozacID = (int)r["VozacID"],
                                        VoziloID = (int)r["VoziloID"],
                                        VrijemePocetka = (DateTime)r["VrijemePocetka"],
                                        VrijemeZavrsetka = (DateTime)r["VrijemeZavrsetka"],
                                        OstaliDetalji = r["OstaliDetalji"].ToString()
                                    });
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                
            }
            return allPutniNalog;
        }

        public List<PutniNalog> getAllPutniNalogForVozac(int idVozac)
        {
            List<PutniNalog> putniNalogForVozac = new List<PutniNalog>();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GET_PUTNI_NALOZI_FOR_VOZAC";
                    comm.Parameters.AddWithValue("@IDvozac", idVozac);
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                putniNalogForVozac.Add(new PutniNalog { 
                                IDPutniNalog=(int)r["IDPutniNalog"],
                                VozacID=(int)r["VozacID"],
                                VoziloID=(int)r["VoziloID"],
                                VrijemePocetka=(DateTime)r["VrijemePocetka"],
                                VrijemeZavrsetka=(DateTime)r["VrijemeZavrsetka"],
                                OstaliDetalji=r["OstaliDetalji"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return putniNalogForVozac;
        }

        public List<TipVozila> getAllTipVozila()
        {
            List<TipVozila> allTipVozila = new List<TipVozila>();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.Text;
                    comm.CommandText = "select* from TipVozila";
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                allTipVozila.Add(new TipVozila
                                {
                                    IDTipVozila = (int)r["IDTipVozila"],
                                    Naziv = r["Naziv"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return allTipVozila;
        }

        public List<Vozac> getAllVozaci()
        {
            List<Vozac> allVozac = new List<Vozac>();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GET_ALL_VOZACI";
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                allVozac.Add(new Vozac { 
                                IDVozac=(int)r["IDVozac"],
                                Ime=r["Ime"].ToString(),
                                Prezime=r["Prezime"].ToString(),
                                BrojMobitela=r["BrojMobitela"].ToString(),
                                BrojVozacke=r["BrojVozacke"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return allVozac;
        }

        public List<Vozilo> getAllVozila()
        {
            List<Vozilo> allVozila = new List<Vozilo>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm = con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GET_ALL_VOZILA";
                    using (SqlDataReader r = comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                allVozila.Add(new Vozilo
                                {
                                    IDVozilo=(int)r["IDVozilo"],
                                    TipVozilaID=(int)r["TipVozilaID"],
                                    MarkaVozilaID=(int)r["MarkaVozilaID"],
                                    GodinaProizvodnje=(int)r["GodinaProizvodnje"],
                                    InicijalnoStanjeKilometara=float.Parse(r["InicijalnoStanjeKilometara"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            return allVozila;
        }

        public List<int> getGodine()
        {
            List<int> godine = new List<int>();
            for (int i = 1990; i < 2019; i++)
            {
                godine.Add(i);
            }
            return godine;
        }

        public PutniNalog GetPutniNalog(int id)
        {
            PutniNalog p = new PutniNalog();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GET_PUTNI_NALOG";
                    comm.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {

                                p.IDPutniNalog = (int)r["IDPutniNalog"];
                                p.VozacID = (int)r["VozacID"];
                                p.VoziloID = (int)r["VoziloID"];
                                p.VrijemePocetka = (DateTime)r["VrijemePocetka"];
                                p.VrijemeZavrsetka = (DateTime)r["VrijemeZavrsetka"];
                                p.OstaliDetalji = r["OstaliDetalji"].ToString();
                            }
                        }
                    }
                }
            }
            return p;
        }

        public Vozac getVozac(int id)
        {
            Vozac v = new Vozac();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm = con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "GET_VOZAC";
                    comm.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader r=comm.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                v.IDVozac = (int)r["IDVozac"];
                                v.Ime = r["Ime"].ToString();
                                v.Prezime = r["Prezime"].ToString();
                                v.BrojMobitela = r["BrojMobitela"].ToString();
                                v.BrojVozacke = r["BrojVozacke"].ToString();
                            }
                        }
                    }
                }
            }
            return v;
        }

        public Vozilo getVozilo(int id)
        {
            Vozilo v = new Vozilo();
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand conn=con.CreateCommand())
                {
                    conn.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.CommandText = "GET_VOZILO";
                    conn.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader r = conn.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                v.IDVozilo = (int)r["IDVozilo"];
                                v.TipVozilaID = (int)r["TipVozilaID"];
                                v.MarkaVozilaID = (int)r["MarkaVozilaID"];
                                v.GodinaProizvodnje = (int)r["GodinaProizvodnje"];
                                v.InicijalnoStanjeKilometara = float.Parse(r["InicijalnoStanjeKilometara"].ToString());
                            }
                        }
                    }
                }
            }
            return v;
        }

        public void insertVozac(Vozac v)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "INSERT_VOZAC";
                    comm.Parameters.AddWithValue("@Ime", v.Ime);
                    comm.Parameters.AddWithValue("@Prezime", v.Prezime);
                    comm.Parameters.AddWithValue("@BrojMobitela", v.BrojMobitela);
                    comm.Parameters.AddWithValue("@BrojVozacke", v.BrojVozacke);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void insertVozilo(Vozilo v)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "INSERT_VOZILO";
                    comm.Parameters.AddWithValue("@TipVozilaID", v.TipVozilaID);
                    comm.Parameters.AddWithValue("@MarkaVozilaID", v.MarkaVozilaID);
                    comm.Parameters.AddWithValue("@GodinaProizvodnje", v.GodinaProizvodnje);
                    comm.Parameters.AddWithValue("@InicijalnoStanjeKilometara", v.InicijalnoStanjeKilometara);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void insetPutniNalog(PutniNalog p)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm = con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "INSERT_PUTNI_NALOG";
                    comm.Parameters.AddWithValue("@VozacID", p.VozacID);
                    comm.Parameters.AddWithValue("@VoziloID", p.VoziloID);
                    comm.Parameters.AddWithValue("@VrijemePocetka", p.VrijemePocetka);
                    comm.Parameters.AddWithValue("@VrijemeZavrsetka", p.VrijemeZavrsetka);
                    comm.Parameters.AddWithValue("@OstaliDetalji", p.OstaliDetalji);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void updatePutniNalog(PutniNalog p)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "UPDATE_PUTNI_NALOG";
                    comm.Parameters.AddWithValue("@IDputniNalog", p.IDPutniNalog);
                    comm.Parameters.AddWithValue("@VozacID", p.VozacID);
                    comm.Parameters.AddWithValue("@VoziloID", p.VoziloID);
                    comm.Parameters.AddWithValue("@VrijemePocetka", p.VrijemePocetka);
                    comm.Parameters.AddWithValue("@VrijemeZavrsetka", p.VrijemeZavrsetka);
                    comm.Parameters.AddWithValue("@OstaliDetalji", p.OstaliDetalji);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void updateVozac(Vozac v)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "UPDATE_VOZAC";
                    comm.Parameters.AddWithValue("@IDvozac", v.IDVozac);
                    comm.Parameters.AddWithValue("@Ime", v.Ime);
                    comm.Parameters.AddWithValue("@Prezime", v.Prezime);
                    comm.Parameters.AddWithValue("@BrojMobitela", v.BrojMobitela);
                    comm.Parameters.AddWithValue("@BrojVozacke", v.BrojVozacke);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void updateVozilo(Vozilo v)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand comm=con.CreateCommand())
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.CommandText = "UPDATE_VOZILO";
                    comm.Parameters.AddWithValue("@IDvozila", v.IDVozilo);
                    comm.Parameters.AddWithValue("@TipVozilaID", v.TipVozilaID);
                    comm.Parameters.AddWithValue("@MarkaVozilaID", v.MarkaVozilaID);
                    comm.Parameters.AddWithValue("@GodinaProizvodnje", v.GodinaProizvodnje);
                    comm.Parameters.AddWithValue("@InicijalnoStanjeKilometara", v.InicijalnoStanjeKilometara);
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}