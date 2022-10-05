Create Table Manufacturers (
ManfID int identity(1,1) primary key,
Name nvarchar(50));

Create Table Medicines (
MedID int identity(1,1) primary key,
Name nvarchar(50),
Annotation nvarchar(150),
Manufacturer int,
StorageLife nvarchar(50),
StorageLocation nvarchar(50),
foreign key (Manufacturer) references Manufacturers(ManfID) on delete cascade,
foreign key (Manufacturer) references Manufacturers(ManfID) on update cascade);

alter table Medicines add foreign key (Manufacturer) references Manufacturers(ManfID) on delete cascade,
foreign key (Manufacturer) references Manufacturers(ManfID) on update cascade;


Create Table Pharmacists (
PharmstID int identity(1,1) primary key,
Name nvarchar(50),
Surname nvarchar(50),в
Patronymic nvarchar(50),
Age int);

Create Table Arrival (
ArrID int identity(1,1) primary key,
Medicine int,
ArrivalDate date,
BuyCount int,
PriceForUnit int,
Pharmacist int,
foreign key (Medicine) references Medicines(MedID) on delete cascade,
foreign key (Medicine) references Medicines(MedID) on update cascade,
foreign key (Pharmacist) references Pharmacists(PharmstID) on delete cascade,
foreign key (Pharmacist) references Pharmacists(PharmstID) on update cascade);

Create Table Realization (
RealizID int identity(1,1) primary key,
Medicine int,
RealizationDate date,
CellCount int,
PriceForUnit int,
Pharmacist int,
foreign key (Medicine) references Medicines(MedID) on delete cascade,
foreign key (Medicine) references Medicines(MedID) on update cascade,
foreign key (Pharmacist) references Pharmacists(PharmstID) on delete cascade,
foreign key (Pharmacist) references Pharmacists(PharmstID) on update cascade);



insert into Manufacturers(Name) 
values ('Р-Фарм');

insert into Manufacturers(Name) 
values ('Биокад');

insert into Manufacturers(Name) 
values ('Генериум');

insert into Manufacturers(Name) 
values ('Валента Фарм');

insert into Manufacturers(Name) 
values ('Фармасинтез');

select * from Manufacturers;

insert into Medicines(Name, Annotation, Manufacturer, StorageLife, StorageLocation)
values ('Мукалтин','Лекарство против кашля', 1, '3 года', 'Вне холодильника'), 
('Мирамистин','Противомибный антисебтический, спрей', 2 , '3 года', 'Вне холодильника'), 
('Суприма-лор','От боли в горле, таблетки', 3, '3 года' , 'Вне холодильника' ), 
('Спазмалгон','Спазмалитическое средство', 4, '2 года', 'Вне холодильника'), 
('Нурофен','Противовоспалительные препарат', 5, '3 года', 'Вне холодильника' ), 
('Ингалипт', 'От боли в горле, спрей', 1, '2 года', 'Вне холодильника'),
('Левомиколь','Противовоспалительное средство, мазь', 1, '3.5 лет', 'В холодильнике');

select * from Medicines;

insert into Pharmacists(Name, Surname, Patronymic, Age)
values ('Катерина','Максимовна', 'Мешалкина' , 19), 
('Вадим','Валерьевич','Медоев', 18),
('Евгения', 'Дмитриевна', 'Астафьева', 28), 
('Александр','Павлович', 'Карпов' , 34), 
('Кристина','Михайловна', 'Шаров' , 27); 

select * from Pharmacists;

insert into Arrival(Medicine, ArrivalDate, BuyCount, PriceForUnit, Pharmacist)
values ( 1, '2022-05-12', 30, 100, 1),
( 2, '2022-05-12', 40, 550, 1),
( 3, '2022-05-14', 25, 180, 2),
( 4, '2022-05-14', 50, 200, 2),
( 5, '2022-05-16', 55, 90, 3),
( 6, '2022-05-18', 20, 140, 4),
( 7, '2022-05-20', 35, 190, 5);

select * from Arrival;

insert into Realization(Medicine, RealizationDate, CellCount, PriceForUnit, Pharmacist)
values ( 1, '2022-05-22', 2, 200, 1),
( 2, '2022-05-22', 1, 1100, 1),
( 3, '2022-05-22', 2, 360, 1),
( 4, '2022-05-24', 1, 400, 2),
( 5, '2022-05-26', 1, 180, 3),
( 6, '2022-05-28', 2, 280, 4),
( 7, '2022-05-30', 1, 380, 5),
( 1, '2022-06-2', 5, 200, 1),
( 2, '2022-06-4', 1, 1100, 2),
( 3, '2022-06-4', 1, 360, 2),
( 4, '2022-06-4', 1, 400, 2),
( 5, '2022-06-6', 4, 180, 3),
( 6, '2022-06-8', 2, 280, 4),
( 7, '2022-06-10', 1, 380, 5);

select * from Realization;


select * from Medicines, Manufacturers  where ManfID = Manufacturer;

select * from Manufacturers; 
select * from Medicines;
select * from Pharmacists;
select * from Arrival;
select * from Realization;