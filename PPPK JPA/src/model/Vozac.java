/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 *
 * @author FRIDAY
 */
@Entity
@Table(name = "Vozac")
public class Vozac {
    @Column(name = "IDVozac")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    
    @Column(name = "Ime")
    private String ime;
    
    @Column(name = "Prezime")
    private String prezime;
    
    @Column(name = "BrojMobitela")
    private String BrojMobitela;
    
    @Column(name = "BrojVozacke")
    private String BrojVozacke;

    public Vozac() {
    }
    

    public Vozac(String ime, String prezime, String BrojMobitela, String BrojVozacke) {
        this.ime = ime;
        this.prezime = prezime;
        this.BrojMobitela = BrojMobitela;
        this.BrojVozacke = BrojVozacke;
    }

    public Vozac(int id, String ime, String prezime, String BrojMobitela, String BrojVozacke) {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.BrojMobitela = BrojMobitela;
        this.BrojVozacke = BrojVozacke;
    }

    @Override
    public String toString() {
        return "Vozac{" + "id=" + id + ", ime=" + ime + ", prezime=" + prezime + ", BrojMobitela=" + BrojMobitela + ", BrojVozacke=" + BrojVozacke + '}';
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getIme() {
        return ime;
    }

    public void setIme(String ime) {
        this.ime = ime;
    }

    public String getPrezime() {
        return prezime;
    }

    public void setPrezime(String prezime) {
        this.prezime = prezime;
    }

    public String getBrojMobitela() {
        return BrojMobitela;
    }

    public void setBrojMobitela(String BrojMobitela) {
        this.BrojMobitela = BrojMobitela;
    }

    public String getBrojVozacke() {
        return BrojVozacke;
    }

    public void setBrojVozacke(String BrojVozacke) {
        this.BrojVozacke = BrojVozacke;
    }
    
    
    
    
    
}
