using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upravljanje_Flotom.Models;

namespace Upravljanje_Flotom.DAL
{
    public interface IRepo
    {
        //Vozila
        List<Vozilo> getAllVozila();
        void insertVozilo(Vozilo v);
        void updateVozilo(Vozilo v);
        void deleteVozilo(int idVozilo);
        List<TipVozila> getAllTipVozila();
        List<MarkaVozila> getAllMarkaVozila();
        Vozilo getVozilo(int id);

        //Vozac
        List<Vozac> getAllVozaci();
        void insertVozac(Vozac v);
        void updateVozac(Vozac v);
        void deleteVozac(int idVozac);
        Vozac getVozac(int id);
        void deleteALLVozac();

        //Putni nalog
        List<PutniNalog> getAllPutniNalog();
        void insetPutniNalog(PutniNalog p);
        void updatePutniNalog(PutniNalog p);
        void deletePutniNalog(int idPutniNalog);
        List<PutniNalog> getAllPutniNalogForVozac(int idVozac);
        PutniNalog GetPutniNalog(int id);

        //Troskivi goriva ???
        //Dodatno
        List<int> getGodine();

    }
}
