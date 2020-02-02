/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Utils;

import java.io.IOException;
import model.PutniNalog;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDDocumentInformation;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDType1Font;

/**
 *
 * @author FRIDAY
 */
public class PdfGenerator {
    
    public void generatePutniNalogPDF(PutniNalog putniNalog) throws IOException{
        
        PDDocument document=new PDDocument();
        String path="C:\\Users\\FRIDAY\\Documents\\PPPK\\Projekt\\PPPK JPA\\"+putniNalog.getId()+".pdf";
        
        
        PDDocumentInformation documentInformation=new PDDocumentInformation();
        documentInformation.setTitle("Putninalog report "+putniNalog.getId());
        document.setDocumentInformation(documentInformation);
        
        PDPage dPage=new PDPage();
        document.addPage(dPage);
        
        PDPageContentStream contentStream=new PDPageContentStream(document, dPage);
        
        contentStream.beginText();
        contentStream.newLineAtOffset(40, 700);
        contentStream.setFont(PDType1Font.HELVETICA_BOLD, 22 );
        contentStream.showText("Putni nalog report");
        contentStream.endText();
        
        //id
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 620);
        contentStream.showText("Putni nalog ID: "+putniNalog.getId());
        contentStream.endText();
        
        //vozac
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 580);
        contentStream.showText("Vozac: "+putniNalog.getVozac().getIme()+" "+putniNalog.getVozac().getPrezime());
        contentStream.endText();
        
        //Vozilo
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 540);
        contentStream.showText("Vozilo: "+putniNalog.getVozilo().getMarkaVozila().getNaziv()+" "+putniNalog.getVozilo().getTipVozila().getNaziv());
        contentStream.endText();
        
        //Vrijeme pocetka
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 500);
        contentStream.showText("Vrijeme pocetka: "+putniNalog.getVrijemePocetka().toString());
        contentStream.endText();
        
        //Vrijeme zavrsetka
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 460);
        contentStream.showText("Vrijeme zavrsetka: "+putniNalog.getVrijemeZavrsetka().toString());
        contentStream.endText();
        
        //Ostali detalji
        contentStream.beginText();
        contentStream.setFont(PDType1Font.HELVETICA, 14 );
        contentStream.newLineAtOffset(60, 420);
        contentStream.showText("Ostali detalji: "+putniNalog.getOstaliDetalji());
        contentStream.endText();
        
        contentStream.close();
        
        document.save(path);
        document.close();
        
    }
}
