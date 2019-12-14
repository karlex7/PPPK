/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk.bulkimport.java;

import DAL.IRepo;
import DAL.RepoFactory;
import Model.Vozilo;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author FRIDAY
 */
public class PPPKBulkImportJAVA {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        String FILE_NAME="TestDataTEST.csv";
        File file=new File(FILE_NAME);
        List<Vozilo> listaVozila=new ArrayList<Vozilo>();
        IRepo repo=RepoFactory.getRepo();
        try {
            Scanner insputStream=new Scanner(file);
            insputStream.next();//Da maknemo prvu liniju
            while (insputStream.hasNext()) {
                String data=insputStream.next();
                String[] values= data.split(",");
                
                int tip=Integer.parseInt(values[0]);
                int marka=Integer.parseInt(values[1]);
                int godina=Integer.parseInt(values[2]);
                float kilometri=Float.parseFloat(values[3]);
                
                Vozilo v=new Vozilo(tip, marka, godina, kilometri);
                listaVozila.add(v);
            }
            //Dodavanje vozila
            repo.insertVozila(listaVozila);
            
            //Provjera
            List<Vozilo> listaSvihVozila=repo.getVozila();
            List<Vozilo> listaUvezenihVozila=new ArrayList<>();
            int importSize=10;//listaVozila.size();
            int fullSize=listaSvihVozila.size();
            int startIndex=fullSize-importSize;
            
            int counterImporta=0;
            for (int i = startIndex ; i < fullSize; i++) {
                System.out.println(listaSvihVozila.get(i).getInicijalnoStanjeKilometara());
                System.out.println(listaVozila.get(counterImporta).getInicijalnoStanjeKilometara());
                counterImporta++;
                System.out.println("-----------------------------");
            }
            
            
        } catch (FileNotFoundException ex) {
            Logger.getLogger(PPPKBulkImportJAVA.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        
    }
    
}
