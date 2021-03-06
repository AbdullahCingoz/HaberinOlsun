CREATE DATABASE HaberinOlsun_DB
GO
USE HaberinOlsun_DB
CREATE TABLE YoneticiTurler
(
ID int IDENTITY(1,1),
Isim nvarchar (50) NOT NULL,
CONSTRAINT pk_YoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurler(Isim) VALUES('Admin')
INSERT INTO YoneticiTurler(Isim) VALUES('Moderat?r')
GO
CREATE TABLE Yoneticiler
(
ID int IDENTITY (1,1),
YoneticiTurID int,
Isim nvarchar(50),
Soyisim nvarchar(50),
Email nvarchar(100),
Sifre nvarchar (20),
Durum Bit,
CONSTRAINT pk_yonetici PRIMARY KEY(ID),
CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID,Isim,Soyisim,Email,Sifre,Durum) VALUES(1,'Abdullah','Cing?z','abdullahcn03@gmail.com','1234',1)
GO
CREATE TABLE Uyeler
(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
KullaniciAdi nvarchar(50),
Email nvarchar(120),
Sifre nvarchar(20),
UyelikTarihi datetime,
Durum bit,
CONSTRAINT pk_uye PRIMARY KEY(ID)
)
GO
CREATE TABLE Kategoriler
(
ID int IDENTITY(1,1),
Isim nvarchar(50),
CONSTRAINT pk_kategori PRIMARY KEY(ID)
)
GO
CREATE TABLE Haberler
(
ID int IDENTITY(10000,1),
KategoriID int,
YazarID int,
Baslik nvarchar(50),
Ozet nvarchar(500),
Icerik nvarchar(MAX),
KapakResim nvarchar(75),
GoruntulenmeSayisi int,
EklemeTarihi datetime,
Durum bit,
CONSTRAINT pk_makale PRIMARY KEY(ID),
CONSTRAINT fk_makaleKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID),
CONSTRAINT fk_makaleYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Yorumlar
(
ID int IDENTITY(1,1),
UyeID int,
HaberID int,
Icerik nvarchar(500),
YorumTarihi datetime,
OnayDurum bit,
CONSTRAINT pk_yorum PRIMARY KEY(ID),
CONSTRAINT fk_yorumMakale FOREIGN KEY(HaberID) REFERENCES Haberler(ID),
CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)
)
