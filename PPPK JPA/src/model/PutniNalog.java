/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.util.Date;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Table;

/**
 *
 * @author FRIDAY
 */
@Entity
@Table(name = "PutniNalog")
public class PutniNalog {
    @Column(name = "IDPutniNalog")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "VozacID", referencedColumnName = "IDVozac")
    private Vozac vozac;
    
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "VoziloID", referencedColumnName = "IDVozilo")
    private Vozilo vozilo;
    
    @Column(name = "VrijemePocetka")
    private Date vrijemePocetka;
    
    @Column(name = "VrijemeZavrsetka")
    private Date vrijemeZavrsetka;
    
    @Column(name = "OstaliDetalji")
    private String ostaliDetalji;

    public PutniNalog() {
    }
    

    public PutniNalog(int id, Vozac vozac, Vozilo vozilo, Date vrijemePocetka, Date vrijemeZavrsetka, String ostaliDetalji) {
        this.id = id;
        this.vozac = vozac;
        this.vozilo = vozilo;
        this.vrijemePocetka = vrijemePocetka;
        this.vrijemeZavrsetka = vrijemeZavrsetka;
        this.ostaliDetalji = ostaliDetalji;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Vozac getVozac() {
        return vozac;
    }

    public void setVozac(Vozac vozac) {
        this.vozac = vozac;
    }

    public Vozilo getVozilo() {
        return vozilo;
    }

    public void setVozilo(Vozilo vozilo) {
        this.vozilo = vozilo;
    }

    public Date getVrijemePocetka() {
        return vrijemePocetka;
    }

    public void setVrijemePocetka(Date vrijemePocetka) {
        this.vrijemePocetka = vrijemePocetka;
    }

    public Date getVrijemeZavrsetka() {
        return vrijemeZavrsetka;
    }

    public void setVrijemeZavrsetka(Date vrijemeZavrsetka) {
        this.vrijemeZavrsetka = vrijemeZavrsetka;
    }

    public String getOstaliDetalji() {
        return ostaliDetalji;
    }

    public void setOstaliDetalji(String ostaliDetalji) {
        this.ostaliDetalji = ostaliDetalji;
    }

    @Override
    public String toString() {
        return "Putni nalog ID:"+ getId() +" Marka Vozila:" + getVozilo().getMarkaVozila().getNaziv()+ " Tip vozila:" +getVozilo().getTipVozila().getNaziv()+ "Vozac:"+ getVozac().getIme()+ " Datum pocetka:"+ getVrijemePocetka()+" Datum zavrsteka:"+getVrijemeZavrsetka();
    }
    
    
    
    
}
