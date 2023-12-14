create database ProductInventoryDB
use  ProductInventoryDB

create table Products
(ProductId int primary key,
ProductName nvarchar(50),
Price float,
Quantity int,
MfDate date,
ExpDate date)

insert into Products values(10,'Laptop',52000.50,2,'12/12/2023','11/12/2026')

select * from Products








