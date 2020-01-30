use PPPKFleetManagement
go

create table Vozac(
IDVozac int primary key identity,
Ime nvarchar(25) NOT NULL,
Prezime nvarchar(25) NOT NULL,
BrojMobitela nvarchar(15) NOT NULL,
BrojVozacke nvarchar(25) NOT NULL
)

create table TipVozila(
IDTipVozila int primary key identity,
Naziv nvarchar(30) NOT NULL
)

create table MarkaVozila(
IDMarkaVozila int primary key identity,
Naziv nvarchar(30) NOT NULL
)

create table Vozilo(
IDVozilo int primary key identity,
TipVozilaID int foreign key references TipVozila(IDTipVozila),
MarkaVozilaID int foreign key references MarkaVozila(IDMarkaVozila),
GodinaProizvodnje int NOT NULL,
InicijalnoStanjeKilometara float NOT NULL
)

create table PutniNalog(
IDPutniNalog int primary key identity,
VozacID int foreign key references Vozac(IDVozac),
VoziloID int foreign key references Vozilo(IDVozilo),
VrijemePocetka date,
VrijemeZavrsetka date,
OstaliDetalji nvarchar(300)
)

create table TroskoviGoriva(
IDTroskoviGoriva int primary key identity,
PutniNalogID int foreign key references PutniNalog(IDPutniNalog),
KolicinaGoriva float,
CijenaGoriva float,
VrijemePlacanja date
)
