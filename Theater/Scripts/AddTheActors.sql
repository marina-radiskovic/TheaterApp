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

DELETE FROM Actors;
INSERT INTO [dbo].[Actors] (FirstName, LastName) VALUES ('Petar', 'Jankovic');
INSERT INTO [dbo].[Actors] (FirstName, LastName) VALUES ('Jovan', 'Gavrilovic');
INSERT INTO [dbo].[Actors] (FirstName, LastName) VALUES ('Marija', 'Petrovic');
INSERT INTO [dbo].[Actors] (FirstName, LastName) VALUES ('Nikolina', 'Iliskovic');
INSERT INTO [dbo].[Actors] (FirstName, LastName) VALUES ('Lazar', 'Lukic');