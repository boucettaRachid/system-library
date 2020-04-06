--create database db_library

use db_library

create table Product(
ID nvarchar(300) primary key not null,
Name nvarchar(300),
Quntity int,
Types nvarchar(100),
Money float,
date_add date,
capital float,
Pictuer image)




create table Orders(
ID int not null primary key identity(1,1),
ID_cmd int not null,
product nvarchar(300) not null,
Quntity int not null,
price float,
date_order date)



create table Admins(
ID int not null primary key identity(1,1),
UserName nvarchar(300),
Password nvarchar(300),
Access varchar(100))



create table Settinge(
Theme varchar(300),
languges nvarchar(300)) 


create table Typee(
ID int not null primary key identity(1,1),
Name nvarchar(200))


create table email(
Email_S nvarchar(300),
Email_A nvarchar(300),
Passwordmail_A nvarchar(300),
Port int,
Smtp nvarchar(300),
subjecte varchar(200),
messag nvarchar(800)
)

=
select * from email
--insert into email values('rachid.bouctta1997@gmail.com','win1997.2020@gmail.com','win19972020','587','smtp.gmail.com','LIBRAIRIE AMITIEE','<style type="text/css">body {margin: 0; padding: 0; min-width: 100%!important;}.content {width: 100%; max-width: 600px;} </style>
--</head><body yahoo bgcolor="#33cccc"><table width="100%" bgcolor="#33cccc" border="0" cellpadding="0" cellspacing="0">
--<tr><td><table class="content" align="center" cellpadding="0" cellspacing="0" border="0"><tr><td><h1>Bienveune</h1></td></tr></table>
--</td></tr></table></body></html>')



--for Products end in stock
select * from Product where Quntity <= 0

--for Products active in stock
select * from Product where Quntity > 0


update Product set Name='Note pad',Quntity='20',Types='Tools shcool',date_add='2020-02-26',Money='50' where ID = '4'


select count(id) as NUMBER,Sum(price) as su, date_order from Orders Group by date_order

select date_order,Sum(price) as TRotal from Orders Group by date_order



select count(product) from Orders where product = 2
select Quntity from Product where ID = 2



use db_library

select * from Orders

