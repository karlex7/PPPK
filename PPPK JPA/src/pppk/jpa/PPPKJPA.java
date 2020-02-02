/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk.jpa;

import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import model.PutniNalog;

/**
 *
 * @author FRIDAY
 */
public class PPPKJPA {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        EntityManagerFactory emf=Persistence.createEntityManagerFactory("PPPK_JPAPU");
        
        ispisiPutneNaloge(emf);
        
    }

    private static void ispisiPutneNaloge(EntityManagerFactory emf) {
        boolean useNativeQuery = false;

        EntityManager em = null;
        try { 
            em = emf.createEntityManager();
            em.getTransaction().begin();

            if (useNativeQuery) {
                // nativni SQL query
                Query dohvatiPjesmeNative = em.createNativeQuery("select * from PutniNalog", PutniNalog.class);
                List<PutniNalog> putniNalogs = dohvatiPjesmeNative.getResultList();
                for(PutniNalog p : putniNalogs) {
                    System.out.println("Vozac: " + p.getVozac().toString() + ", id=" + p.getId());
                }
            } else {
                // JPQL query
                Query dohvatiPjesmeJPQL = em.createQuery("select PutniNalog from PutniNalog as PutniNalog", PutniNalog.class);
                List<PutniNalog> putniNalogs2 = dohvatiPjesmeJPQL.getResultList();
                for(PutniNalog p : putniNalogs2) {
                    System.out.println("Vozac: " + p.getVozac().toString() + ", id=" + p.getId());
                }
            }
            
            em.getTransaction().commit();
        } catch(Exception e) {
            e.printStackTrace();
        } finally {
            if (em != null) em.close();
        }
    }

    
}
