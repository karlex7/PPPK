

use PPPKFleetManagement
go


-----------------------------
---------VOZAC---------------
-----------------------------

create proc GET_ALL_VOZACI
as
select*from Vozac
go


create proc INSERT_VOZAC
@Ime nvarchar(25),
@Prezime nvarchar(25),
@BrojMobitela nvarchar(15),
@BrojVozacke nvarchar(25)
as
insert into Vozac(Ime,Prezime,BrojMobitela,BrojVozacke)
values(@Ime,@Prezime,@BrojMobitela,@BrojVozacke)
go



create proc UPDATE_VOZAC
@IDvozac int,
@Ime nvarchar(25),
@Prezime nvarchar(25),
@BrojMobitela nvarchar(15),
@BrojVozacke nvarchar(25)
as
update Vozac
set	Ime=@Ime,Prezime=@Prezime,BrojMobitela=@BrojMobitela,BrojVozacke=@BrojVozacke
where IDVozac=@IDvozac
go


create proc DELETE_VOZAC
@IDvozac int
as
delete from Vozac
where IDVozac=@IDvozac
go

create proc GET_VOZAC
@ID int
as
select*from Vozac
where IDVozac=@ID
go

create proc DELETE_ALL_VOZAC
as
delete from Vozac
go


-----------------------------
-------PUTNI-NALOG-----------
-----------------------------

create proc GET_ALL_PUTNI_NALOZI
as
select*from PutniNalog
go


create proc GET_PUTNI_NALOZI_FOR_VOZAC
@IDvozac int
as
select* from PutniNalog
where VozacID=@IDvozac
go


create proc INSERT_PUTNI_NALOG
@VozacID int,
@VoziloID int,
@VrijemePocetka date,
@VrijemeZavrsetka date,
@OstaliDetalji nvarchar(300)
as
insert into PutniNalog(VozacID,VoziloID,VrijemePocetka,VrijemeZavrsetka,OstaliDetalji)
values(@VozacID,@VoziloID,@VrijemePocetka,@VrijemeZavrsetka,@OstaliDetalji)
go


create proc UPDATE_PUTNI_NALOG
@IDputniNalog int,
@VozacID int,
@VoziloID int,
@VrijemePocetka date,
@VrijemeZavrsetka date,
@OstaliDetalji nvarchar(300)
as
update PutniNalog
set VozacID=@VozacID,VoziloID=@VoziloID,VrijemePocetka=@VrijemePocetka,VrijemeZavrsetka=@VrijemeZavrsetka,OstaliDetalji=@OstaliDetalji
where IDPutniNalog=@IDputniNalog
go


create proc DELETE_PUTNI_NALOG
@IDputniNalog int
as
delete from PutniNalog
where IDPutniNalog=@IDputniNalog
go

create proc GET_PUTNI_NALOG
@ID int
as select*from PutniNalog
where IDPutniNalog=@ID
go


-----------------------------
---------VOZILA--------------
-----------------------------


create proc GET_ALL_VOZILA
as
select*from Vozilo
go


create proc INSERT_VOZILO
@TipVozilaID int,
@MarkaVozilaID int,
@GodinaProizvodnje int,
@InicijalnoStanjeKilometara float
as
insert into Vozilo(TipVozilaID,MarkaVozilaID,GodinaProizvodnje,InicijalnoStanjeKilometara)
values(@TipVozilaID,@MarkaVozilaID,@GodinaProizvodnje,@InicijalnoStanjeKilometara)
go



create proc UPDATE_VOZILO
@IDvozila int,
@TipVozilaID int,
@MarkaVozilaID int,
@GodinaProizvodnje int,
@InicijalnoStanjeKilometara float
as
update Vozilo
set TipVozilaID=@TipVozilaID, MarkaVozilaID=@MarkaVozilaID, GodinaProizvodnje=@GodinaProizvodnje, InicijalnoStanjeKilometara=@InicijalnoStanjeKilometara
where IDVozilo=@IDvozila
go


create proc DELETE_VOZILO
@IDvozilo int
as
delete from Vozilo
where IDVozilo=@IDvozilo
go

create proc GET_VOZILO
@ID int
as
select* from Vozilo
where IDVozilo=@ID
go

create proc GET_ALL_MARKE
as
select*from MarkaVozila
go

-----------------------------
---------SERVIS--------------
-----------------------------
