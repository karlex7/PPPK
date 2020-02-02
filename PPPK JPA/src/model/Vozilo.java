/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

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
@Table(name = "Vozilo")
public class Vozilo {
    @Column(name = "IDVozilo")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "TipVozilaID", referencedColumnName = "IDTipVozila")
    private TipVozila tipVozila;
    
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "MarkaVozilaID", referencedColumnName = "IDMarkaVozila")
    private MarkaVozila markaVozila;
    
    @Column(name = "GodinaProizvodnje")
    private int godinaProizvodnje;
    
    @Column(name = "InicijalnoStanjeKilometara")
    private int inicijalnoStanjeKilometara;

    public Vozilo(TipVozila tipVozila, MarkaVozila markaVozila, int godinaProizvodnje, int inicijalnoStanjeKilometara) {
        this.tipVozila = tipVozila;
        this.markaVozila = markaVozila;
        this.godinaProizvodnje = godinaProizvodnje;
        this.inicijalnoStanjeKilometara = inicijalnoStanjeKilometara;
    }

    public Vozilo(int id, TipVozila tipVozila, MarkaVozila markaVozila, int godinaProizvodnje, int inicijalnoStanjeKilometara) {
        this.id = id;
        this.tipVozila = tipVozila;
        this.markaVozila = markaVozila;
        this.godinaProizvodnje = godinaProizvodnje;
        this.inicijalnoStanjeKilometara = inicijalnoStanjeKilometara;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public TipVozila getTipVozila() {
        return tipVozila;
    }

    public void setTipVozila(TipVozila tipVozila) {
        this.tipVozila = tipVozila;
    }

    public MarkaVozila getMarkaVozila() {
        return markaVozila;
    }

    public void setMarkaVozila(MarkaVozila markaVozila) {
        this.markaVozila = markaVozila;
    }

    public int getGodinaProizvodnje() {
        return godinaProizvodnje;
    }

    public void setGodinaProizvodnje(int godinaProizvodnje) {
        this.godinaProizvodnje = godinaProizvodnje;
    }

    public int getInicijalnoStanjeKilometara() {
        return inicijalnoStanjeKilometara;
    }

    public void setInicijalnoStanjeKilometara(int inicijalnoStanjeKilometara) {
        this.inicijalnoStanjeKilometara = inicijalnoStanjeKilometara;
    }
    
    
    
    
}
