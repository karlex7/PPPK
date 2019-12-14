/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author FRIDAY
 */
public class Vozilo {
    
    private int TipVozilaID;
    private int MarkaVozilaID;
    private int GodinaProizvodanje;
    private float InicijalnoStanjeKilometara;

    public Vozilo() {
    }
    

    public Vozilo(int TipVozilaID, int MarkaVozilaID, int GodinaProizvodanje, float InicijalnoStanjeKilometara) {
        this.TipVozilaID = TipVozilaID;
        this.MarkaVozilaID = MarkaVozilaID;
        this.GodinaProizvodanje = GodinaProizvodanje;
        this.InicijalnoStanjeKilometara = InicijalnoStanjeKilometara;
    }

    public int getTipVozilaID() {
        return TipVozilaID;
    }

    public void setTipVozilaID(int TipVozilaID) {
        this.TipVozilaID = TipVozilaID;
    }

    public int getMarkaVozilaID() {
        return MarkaVozilaID;
    }

    public void setMarkaVozilaID(int MarkaVozilaID) {
        this.MarkaVozilaID = MarkaVozilaID;
    }

    public int getGodinaProizvodanje() {
        return GodinaProizvodanje;
    }

    public void setGodinaProizvodanje(int GodinaProizvodanje) {
        this.GodinaProizvodanje = GodinaProizvodanje;
    }

    public float getInicijalnoStanjeKilometara() {
        return InicijalnoStanjeKilometara;
    }

    public void setInicijalnoStanjeKilometara(float InicijalnoStanjeKilometara) {
        this.InicijalnoStanjeKilometara = InicijalnoStanjeKilometara;
    }
    

}
