/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


Drop Table IF EXISTS tblCustomer.sql
Drop Table IF EXISTS tblDirector.sql
Drop Table IF EXISTS tblFormat.sql
Drop Table IF EXISTS tblGenre.sql
Drop Table IF EXISTS tblMovie.sql
Drop Table IF EXISTS tblMovieGenre.sql
Drop Table IF EXISTS tblOrder.sql
Drop Table IF EXISTS tblOrderltem.sql
Drop Table IF EXISTS tblRating.sql
Drop Table IF EXISTS tblUser.sql
