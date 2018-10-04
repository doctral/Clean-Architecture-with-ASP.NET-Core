MERGE INTO dbo.Libraries AS TARGET
USING ( VALUES
	(1, 'Jeffson Library','101 Brentwood Ln')
)
AS SOURCE (Id, [Name], [Address])
ON TARGET.Id = SOURCE.Id
WHEN MATCHED THEN
	UPDATE SET 
		[Name]=SOURCE.[Name],
		[Address]=SOURCE.[Address]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Name], [Address])
	VALUES ([Name], [Address])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;