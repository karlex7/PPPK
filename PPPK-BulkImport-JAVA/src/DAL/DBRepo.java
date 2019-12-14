/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DAL;

import Model.Vozilo;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import javax.sql.DataSource;

/**
 *
 * @author FRIDAY
 */
public class DBRepo implements IRepo{
    String sql1 = "insert into Vozilo(TipVozilaID,MarkaVozilaID,GodinaProizvodnje,InicijalnoStanjeKilometara) values(?,?,?,?)";
    private static final String GET_ALL_VOZILA = "{ CALL GET_ALL_VOZILA }";
    

    @Override
    public void insertVozila(List<Vozilo> listaVozila) {
        DataSource dataSource=SQLConnection.getInstance();
        try(Connection con=dataSource.getConnection();
                PreparedStatement ps=con.prepareStatement(sql1)) {
            final int batchSize = 10;
            int count = 0;
            
            for (Vozilo v : listaVozila) {
                ps.setInt(1, v.getTipVozilaID());
                ps.setInt(2, v.getMarkaVozilaID());
                ps.setInt(3, v.getGodinaProizvodanje());
                ps.setFloat(4, v.getInicijalnoStanjeKilometara());
                ps.addBatch();
                if(++count % batchSize == 0) {
		ps.executeBatch();
	        }
            }
            ps.executeBatch();
            ps.close();
            con.close();
        } catch (Exception e) {
        }
    }

    @Override
    public List<Vozilo> getVozila() {
        List<Vozilo> vozila = new ArrayList<>();
        DataSource dataSource = (DataSource) SQLConnection.getInstance();
        try (Connection con = dataSource.getConnection();
                CallableStatement stmt = con.prepareCall(GET_ALL_VOZILA);
                ResultSet resultSet = stmt.executeQuery()){
                    while (resultSet.next()) {
                        vozila.add(new Vozilo(
                                resultSet.getInt("TipVozilaID"),
                                resultSet.getInt("MarkaVozilaID"),
                                resultSet.getInt("GodinaProizvodnje"),
                                resultSet.getFloat("InicijalnoStanjeKilometara")));
                    }
            return vozila;
            
        } catch (Exception e) {
            e.printStackTrace();
        }
        return vozila;
    }
    
}
