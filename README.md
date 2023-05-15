# ProductList
step 1-Download Visual Studio Latest Version in your system(https://visualstudio.microsoft.com/vs/community/)

step 2-Download SQL Server in your system(https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
step 3-Download Download SQL Server Management Studio (SSMS)(https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16))
step 4-Open SQL Server Management Studio then
Execute All (1 to 5) Query line by line

1)// Query fro Database Creation 

CREATE DATABASE DbPranav;

2)//Query for Accessing database

use DbPranav;

3)//query for table creation into database

CREATE TABLE product(
No int,
SN int not null identity(1,1) CONSTRAINT SN PRIMARY KEY,
Product varchar(100) not null,
Descrip varchar(200) not null,
Price int not null,
Created datetime not null
)

4)//query for stored procedures creation into database

CREATE PROC productAddEdit1
(

@SN int,
@Product varchar(100),
@Descrip varchar(200),
@Price int
)
AS
IF @SN=0
BEGIN
	INSERT INTO product(Product,Descrip,Price,Created)
	VALUES(@Product,@Descrip,@Price,GETDATE())

	SELECT @@ROWCOUNT as TotalRowCount
END
ELSE
BEGIN
	UPDATE product SET
	Product=@Product,
	Descrip=@Descrip,
	Price=@Price
	WHERE SN=@SN

	SELECT @@ROWCOUNT as TotalRowCount
END

5)//query for stored procedures(Delete Product) creation into database

CREATE PROC productDelete1
(
@SN int
)
AS
	DELETE FROM product WHERE SN=@SN

	SELECT @@ROWCOUNT as TotalRowCount

step 5-Download zip code file-extract zip file-open project using visual studio
step 6-open tools visual studio tools menu- then mouse hover on NuGet Package Manager-open Manage Nuget Packages for solution-
then install 3 packages 1]microsoft.entityframeworkcore(6.0.11)
2]microsoft.entityframeworkcore.sqlserver(6.0.11)
3]Dapper(2.0.123)
step7-Then run project.
 
