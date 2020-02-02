/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk.jpa;

import Utils.PdfGenerator;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import model.MarkaVozila;
import model.PutniNalog;

/**
 *
 * @author FRIDAY
 */
public class PPPKJPA {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        EntityManagerFactory emf=Persistence.createEntityManagerFactory("PPPK_JPAPU");
        
        //ispisiMarke(emf);
        
        //ispisiPutneNaloge(emf);
        
        List<PutniNalog> listaPutniNalogs=getPutniNalogs(emf);
        
        char dalje='y';
        do {
            System.out.println("Ispisi PDF za Putni Nalog:");
            for (PutniNalog putniNalog : listaPutniNalogs) {
                System.out.println(putniNalog.getId());
            }
            System.out.println("Unesite ID naloga");
            Scanner keyboard = new Scanner(System.in);
            int idOdabir=keyboard.nextInt();
            
            PdfGenerator pdF=new PdfGenerator();
            PutniNalog p=new PutniNalog();
            for (PutniNalog putniNalog : listaPutniNalogs) {
                if (putniNalog.getId()==idOdabir) {
                    p=putniNalog;
                }
            }
            
            pdF.generatePutniNalogPDF(p);
            
            System.out.println("Zelite li ispisati jos jedan PDF?(y/n)");
            dalje=keyboard.next().charAt(0);
        } while (dalje=='y');
        
        
        emf.close();
        
    }

    private static void ispisiPutneNaloge(EntityManagerFactory emf) {
        EntityManager em = null;
        try { 
            em = emf.createEntityManager();
            em.getTransaction().begin();
            
            Query dohvatiPutneNaloge = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
            List<PutniNalog> putniNalogs = dohvatiPutneNaloge.getResultList();
            System.out.println("------------------------------------------------------------------------------------------------------------");
            for (PutniNalog putniNalog : putniNalogs) {
                putniNalog.toString();
            }
            PdfGenerator pdF=new PdfGenerator();
            pdF.generatePutniNalogPDF(putniNalogs.get(0));
            
        } catch(Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) em.close();
        }

    }

    private static void ispisiMarke(EntityManagerFactory emf) {
        EntityManager em = null;
        try { 
            em = emf.createEntityManager();
            em.getTransaction().begin();
            
            /*Query dohvatiPutneNaloge = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
            List<PutniNalog> putniNalogs = dohvatiPutneNaloge.getResultList();
            for (PutniNalog putniNalog : putniNalogs) {
                System.out.println(putniNalog.getId());
            }*/
            Query dohvatiMarke = em.createNativeQuery("select * from MarkaVozila", MarkaVozila.class);
            List<MarkaVozila> markaVozilas = dohvatiMarke.getResultList();
            for (MarkaVozila markaVozila : markaVozilas) {
                System.out.println(markaVozila.getNaziv());
            }
            
        } catch(Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) em.close();
        }
    }

    private static List<PutniNalog> getPutniNalogs(EntityManagerFactory emf) {
        List<PutniNalog> putniNalogs=new ArrayList<>();
        EntityManager em = null;
        try { 
            em = emf.createEntityManager();
            em.getTransaction().begin();
            
            Query dohvatiPutneNaloge = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
            putniNalogs = dohvatiPutneNaloge.getResultList();
           
            
        } catch(Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) em.close();
        }
        return putniNalogs;
    }

    
}
