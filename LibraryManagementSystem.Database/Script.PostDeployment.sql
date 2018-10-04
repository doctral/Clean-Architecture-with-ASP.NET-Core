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

:r .\dbo\ReferenceData\Config\Libraries.Data.sql
:r .\dbo\ReferenceData\Config\Clients.Data.sql
:r .\dbo\ReferenceData\Config\Books.Data.sql
:r .\dbo\ReferenceData\Config\ClientXBooks.Data.sql