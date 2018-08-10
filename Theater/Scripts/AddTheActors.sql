/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DELETE FROM Actor;
INSERT INTO [dbo].[Actor] (Id, FirstName, LastName) VALUES (1, 'Petar', 'Jankovic');
INSERT INTO [dbo].[Actor] (Id, FirstName, LastName) VALUES (2, 'Jovan', 'Gavrilovic');
INSERT INTO [dbo].[Actor] (Id, FirstName, LastName) VALUES (3, 'Marija', 'Petrovic');
INSERT INTO [dbo].[Actor] (Id, FirstName, LastName) VALUES (4, 'Nikolina', 'Iliskovic');
INSERT INTO [dbo].[Actor] (Id, FirstName, LastName) VALUES (5, 'Lazar', 'Lukic');