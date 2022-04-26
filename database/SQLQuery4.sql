Use MVC 
Go
CREATE TABLE Clients(
	ClientID nvarchar(50) not null,
	ClientName nvarchar(50) not null,
	Address nvarchar(50) not null,
	Phone nvarchar(50) not null,
	PRIMARY KEY CLUSTERED (ClientID ASC)
	);

CREATE TABLE Products(
	ProductID nvarchar(50) not null,
	ProductName nvarchar(50) not null,
	Quantity int not null,
	ImportPrice float(50) not null,
	ExportPrice float(53) not null,
	CONSTRAINT PK_Products PRIMARY KEY(ProductID)
	);
create table Export(
	BillID nvarchar (50) not null,
	[Date] datetime not null,
	ClientID nvarchar(50) not null,
	ProductID nvarchar(50) not null,
	ExportPrice float(53) not null,
	Quantity int not null,
	CONSTRAINT PK_Export PRIMARY KEY(BillID),
	CONSTRAINT FK_Export FOREIGN KEY(BillID) REFERENCES Orders(OrderID),
	CONSTRAINT FK_Export1 FOREIGN KEY(ClientID) REFERENCES Clients(ClientID),
	CONSTRAINT FK_Export2 FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	);
	
insert into Export values('B01','11/12/2022','KH01','P1',1300000, 123)

create table Import(
	BillID nvarchar (50) not null,
	ImportDate datetime not null,
	ProductID nvarchar(50) not null,
	ImportPrice float(53) not null,
	Quantity int not null,
	CONSTRAINT PK_Import PRIMARY KEY(BillID),
	CONSTRAINT FK_Import FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
);


CREATE TABLE Bill(
	BillID nvarchar(30) not null,
	Date datetime not null,
	ClientID nvarchar(10) not null,
	ExPrice float(53) not null,
	ImPrice float (53) not null,
	Total float(53) not null,
	PRIMARY KEY CLUSTERED (BillID ASC)
	);
CREATE TABLE Orders(
	OrderID nvarchar(50),
	ClientID nvarchar(50),
	ProductID nvarchar(50),
	ProductName nvarchar(50),
	Quantity int,
	Payment nvarchar(50),
	CONSTRAINT PK_Orders PRIMARY KEY(OrderID),
	CONSTRAINT FK_Orders FOREIGN KEY(ClientID) REFERENCES Clients(ClientID),
	CONSTRAINT FK_Orders1 FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
);



	 
	

Create table tblUser(
	UserID nvarchar(50),
	Password nvarchar(50)
	Primary key clustered ([UserID] asc)
	);

insert into [dbo].[Products] values('P1','Soy Sauce','500','1300000','1500000')
insert into [dbo].[Products] values('P2','Fish Sauce','500','3300000','3600000')
insert into [dbo].[Products] values('p3','Milk','50000','23000000','26000000')
insert into [dbo].[Products] values('p4','Sugar','1000','1500000','1800000')
insert into [dbo].[Products] values('p5','Peper','5000','43300000','45500000')
insert into [dbo].[Products] values('p6','Rice','3000','34900000','37900000')
insert into [dbo].[Products] values('p7','Salt','2500','9000000','1500000')

select * from [dbo].[Export]

select * from Export 
 

