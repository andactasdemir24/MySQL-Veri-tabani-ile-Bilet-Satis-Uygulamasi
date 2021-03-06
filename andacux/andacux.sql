create database andacux;
use andacux;


CREATE TABLE andacux_uyeler
(
	uye_id			varchar(64)		not null,
    uye_ad			varchar(64)		not null,
    uye_soyad 		varchar(64)		not null,
    uye_tel			varchar(25)		not null,
    uye_tc			varchar(11)		not null,
    uye_mail 		varchar(250)	not null,
    uye_sehir		varchar(64)		not null,
    uye_yas			varchar(3)		not null,
    uye_adres		varchar(250)	not null,

	primary key(uye_id)
);

CREATE TABLE andacux_biletler
(
	bilet_id		varchar(64)		not null,
    bilet_ad		varchar(64)		not null,
    bilet_adet 		float	        not null,
    bilet_kategori	varchar(64)		not null,
    bilet_fiyat		float			not null,
    bilet_adres		varchar(250)	not null,
    
    primary key(bilet_id)
);

CREATE TABLE andacux_satislar
(
	satis_id		varchar(64)		not null,
    uye_id			varchar(64)		not null,
    bilet_id		varchar(64)		not null,
    satis_tarihi	datetime		not null,
    satis_fiyat		float			not null,
    
    primary key(satis_id),
    
    foreign key(uye_id) references andacux_uyeler(uye_id)
		on delete cascade on update cascade,
        
	foreign key(bilet_id) references andacux_biletler(bilet_id)
		on delete cascade on update cascade
);

CREATE TABLE andacux_odemeler
(
	odeme_id		varchar(64)		not null,
    uye_id			varchar(64)		not null,
    odeme_tarihi	datetime		not null,
    odeme_tutar		float			not null,
    odeme_turu		varchar(25)		not null,
    odeme_aciklama	varchar(250)	not null,
    
    primary key(odeme_id),
    
    foreign key(uye_id)	references andacux_uyeler(uye_id)
		on delete cascade on update cascade
);

DELIMITER $$
CREATE PROCEDURE andacux_UyeEkle (
	id  	varchar(64) ,
    ad		varchar(64) ,
    soy 	varchar(64) ,
    tel 	varchar(25) ,
    tc		varchar(11),
    mail 	varchar(64),
    sehir	varchar(250),
    yas		varchar(25),
    adr 	varchar(250)
)
BEGIN
	INSERT INTO andacux_uyeler
    VALUES 	(id, ad, soy, tel,tc, mail,sehir, yas, adr);
END $$
DELIMITER ;



DELIMITER $$
CREATE PROCEDURE andacux_UyeHepsi ()
BEGIN
	SELECT 
		uye_id 		as ID,
		uye_ad 		as Adı,
		uye_soyad 	as Soyadı,
		uye_tel		as Telefon, 
        uye_tc		as TC,
		uye_mail 	as Mail,
		uye_sehir 	as Şehir,
        uye_yas		as Yaş,
        uye_adres 	as Adres
    FROM andacux_uyeler;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_UyeBul (
	filtre  varchar(32) 
)
BEGIN
	SELECT 
		uye_id 		as ID,
		uye_ad 		as Adı,
		uye_soyad 	as Soyadı,
		uye_tel		as Telefon, 
        uye_tc		as TC,
		uye_mail 	as Mail,
		uye_sehir 	as Şehir,
        uye_yas		as Yaş,
        uye_adres 	as Adres
    FROM andacux_uyeler
    WHERE 
		uye_ad		LIKE  CONCAT('%',filtre,'%') OR
		uye_soyad 	LIKE  CONCAT('%',filtre,'%') OR
		uye_tel 	LIKE  CONCAT('%',filtre,'%') OR
        uye_tc 		LIKE  CONCAT('%',filtre,'%') OR
		uye_mail 	LIKE  CONCAT('%',filtre,'%') OR
        uye_sehir 	LIKE  CONCAT('%',filtre,'%') OR
        uye_yas 	LIKE  CONCAT('%',filtre,'%') OR
		uye_adres 	LIKE  CONCAT('%',filtre,'%');
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_UyeGuncelle (
	id  	varchar(64) ,
    ad		varchar(64) ,
    soy 	varchar(64) ,
    tel 	varchar(25) ,
    tc		varchar(11),
    mail 	varchar(64),
    sehir	varchar(250),
    yas		varchar(25),
    adr 	varchar(250)
)
BEGIN
	UPDATE andacux_uyeler
    SET 
		uye_ad		= ad,
		uye_soyad 	= soy,
		uye_tel 	= tel,
		uye_tc 		= tc,
        uye_mail	= mail,
        uye_sehir	= sehir,
        uye_yas		= yas,
		uye_adres 	= adr
	WHERE 
    	uye_id  	= id;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_UyeSil (
	id  	varchar(64) 
)
BEGIN
	DELETE FROM andacux_uyeler
	WHERE  	uye_id  = id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_UyeGetir ()
BEGIN
	SELECT 
		uye_id 		as ID,
		uye_ad 		as Adı,
		uye_soyad 	as Soyadı,
		uye_tel		as Telefon, 
        uye_tc		as TC,
		uye_mail 	as Mail,
		uye_sehir 	as Şehir,
        uye_yas		as Yaş,
        uye_adres 	as Adres
    FROM andacux_uyeler;
END $$
DELIMITER ;




DELIMITER $$
CREATE PROCEDURE andacux_BiletEkle (
	id			varchar(64)  ,
    ad 			varchar(250) ,
    adet 		float 		 ,
	kategori 	varchar(64)	 ,
    fiyat		float 		 ,
    adres	   	varchar(250) 
)
BEGIN
	INSERT INTO andacux_biletler
    VALUES 	(id, ad, adet, kategori, fiyat, adres);
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_BiletlerHepsi ()
BEGIN
	SELECT 
		bilet_id    	as ID,
		bilet_ad 		as 'Bilet Adı' ,
		bilet_adet  	as  Adet,
		bilet_kategori  as	Kategori,
		bilet_fiyat 	as	Fiyat,
		bilet_adres 	as  Adres
    FROM andacux_biletler;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_BiletBul (
	filtre		varchar(32)
)
BEGIN
	SELECT 
		bilet_ad 		as 'Bilet Adı' ,
		bilet_adet  	as  Adet,
		bilet_kategori  as	Kategori,
		bilet_fiyat 	as	Fiyat,
		bilet_adres 	as  Adres
    FROM andacux_biletler
    WHERE 
    	bilet_id  	  LIKE  CONCAT('%',filtre,'%') OR
		bilet_ad 	  LIKE  CONCAT('%',filtre,'%') OR
		bilet_adet	  LIKE  CONCAT('%',filtre,'%') OR
		bilet_kategori 	  LIKE  CONCAT('%',filtre,'%') OR
		bilet_fiyat	  LIKE  CONCAT('%',filtre,'%') OR
		bilet_adres	  LIKE  CONCAT('%',filtre,'%') ;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_BiletGuncelle (
	id			varchar(64)  ,
    ad 			varchar(250) ,
    adet 		float 		 ,
	kategori 	varchar(64)	 ,
    fiyat		float 		 ,
    adres	   	varchar(250)  
)
BEGIN
	UPDATE andacux_biletler
    SET 
		bilet_ad 	  = ad,
		bilet_adet 	  = adet,
		bilet_kategori 	  = kategori,
		bilet_fiyat	  = fiyat,
		bilet_adres	  = adres
	WHERE 
    	bilet_id  	  = id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_BiletSil (
	id			varchar(64)  
)
BEGIN
	DELETE FROM andacux_biletler
	WHERE bilet_id  = id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_SatisEkle (
	sid		varchar(64) ,
	uid		varchar(64) ,
	bid		varchar(64) ,    
	tarih 	datetime,
	fiyat 	float 
)
BEGIN
	INSERT INTO andacux_satislar
    VALUES 	(sid, uid, bid, tarih, fiyat );
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_SatisDetay (
)
BEGIN
	SELECT 
		s.satis_id,
        u.uye_id,
        b.bilet_id,
        CONCAT(uye_ad, ' ', uye_soyad ) as 'Üyeler Ad Soyad',
        bilet_ad as 'Bilet',
        bilet_kategori as 'Kategori',
        bilet_fiyat as 'Bilet Fiyat',
        satis_fiyat as 'Satış Fiyatı',
        satis_tarihi as 'Satış Tarihi'
FROM  	andacux_uyeler u inner join andacux_satislar s 
	on u.uye_id = s.uye_id 
		inner join andacux_biletler b on s.bilet_id = b.bilet_id;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_SatisGuncelle (
	sid			varchar(64),
	uid			varchar(64),
    bid 		varchar(64),
    tarih 		datetime   ,
	fiyat 		float      
)
BEGIN
	UPDATE andacux_satislar
    SET 
		uye_id    = uid,
		bilet_id 	  = bid,
		satis_tarihi	  = tarih,
		satis_fiyat	  = fiyat
	WHERE 
		satis_id 	  = sid;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_SatisSil (
	id			varchar(64)  
)
BEGIN
	DELETE FROM andacux_satislar
	WHERE satis_id  = id;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_OdemeEkle (
	oid		varchar(64) ,
	uid		varchar(64) ,   
    tarih 	datetime 	,
	tutar 	float 		,
	tur		varchar(25) ,
    aciklama varchar(250)
)
BEGIN
	INSERT INTO andacux_odemeler
    VALUES 	(oid, uid, tarih, tutar, tur, aciklama);
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE andacux_OdemeDetay (
)
BEGIN
	SELECT 
		o.odeme_id,
        u.uye_id,
        CONCAT(uye_ad, ' ', uye_soyad ) as 'Üyeler Ad Soyad',
        o.odeme_tarihi as 'Ödeme Tarihi',
        o.odeme_tutar as 'Ödeme Tutarı',
        o.odeme_turu as 'Ödeme Türü',
        o.odeme_aciklama as 'Ödeme Açıklama'
        
FROM  	andacux_uyeler u inner join andacux_odemeler o 
	on u.uye_id = o.uye_id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_OdemeGuncelle (
	oid		varchar(64) ,
	uid		varchar(64) ,   
    tarih 	datetime 	,
	tutar 	float 		,
	tur		varchar(25) ,
    aciklama varchar(250)
)
BEGIN
	UPDATE andacux_odemeler
    SET
		uye_id			= uid,
        odeme_tarihi	= tarih,
        odeme_tutar		= tutar,
        odeme_turu		= tur,
        odeme_aciklama 	= aciklama
 	WHERE 
		odeme_id = oid; 
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE andacux_OdemeSil (
	oid		varchar(64) 
)
BEGIN
	DELETE FROM andacux_odemeler
    WHERE odeme_id = oid;
END $$
DELIMITER ;

