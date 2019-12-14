

use PPPKFleetManagement
go

----------------------
---------VOZAC--------
----------------------

insert into Vozac(Ime,Prezime,BrojMobitela,BrojVozacke)
values('Lovro','Lovric','098273813','142324167554'),
('Ivan','Ivanovic','092762343','345346234234'),
('Marko','Markovic','091324234','324254232342'),
('Petar','Peric','0983214324','2342343242345'),
('Josip','Josipovic','095214423','456456456456'),
('Ana','Anic','0912142342','456456456456'),
('Karlo','Karlovic','098124234','3453454353543'),
('Mladen','Horvat','0912343242','4564564564564'),
('Ivan','Horvat','0982413234','45646545646456'),
('Blaz','Blazevic','0912345324','8709788797977')

-----------------------
------TIP-VOZILA-------
-----------------------

insert into TipVozila(Naziv)
values('SUV'),
('Sedan'),
('Coupe'),
('Cabrio'),
('Pick-up'),
('Limousine'),
('Hatchback')

------------------------
------MARKA-VOZILA------
------------------------

insert into MarkaVozila(Naziv)
values('BMW'),
('Mini'),
('Smart'),
('Audi'),
('VW'),
('Mercedes'),
('Kia'),
('Toyota'),
('Honda')

--------------------
------VOZILO--------
--------------------

insert into Vozilo(TipVozilaID,MarkaVozilaID,GodinaProizvodnje,InicijalnoStanjeKilometara)
values(3,1,2015,0),
(1,1,2010,13242),
(2,1,2018,0),
(7,2,2009,45634),
(6,4,2012,3452),
(3,3,2016,400222),
(6,6,2018,0)

-----------------------
------PUTNI-NALOG------
-----------------------

insert into PutniNalog(VozacID,VoziloID,VrijemePocetka,VrijemeZavrsetka,OstaliDetalji)
values(1,1,'2011-09-10','2011-10-01','Lose vrijeme'),
(2,2,'2013-03-22','2013-03-26','Guzva na cesti'),
(3,3,'2015-06-14','2015-07-02',''),
(4,4,'2014-11-01','2014-11-02','Pokupiti stvari za put'),
(5,5,'2019-11-09','','')