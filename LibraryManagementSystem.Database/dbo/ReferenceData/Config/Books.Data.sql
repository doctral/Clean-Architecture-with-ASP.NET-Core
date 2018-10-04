MERGE INTO dbo.Books AS TARGET
USING ( VALUES
	(1, 'Organic Chemistry',1),
	(2, 'Physical Chemistry',1),
	(3, 'Java',1),
	(4, 'Advance Java',1)
)
AS SOURCE (Id, [Name], [LibraryId])
ON TARGET.Id = SOURCE.Id
WHEN MATCHED THEN
	UPDATE SET 
		[Name]=SOURCE.[Name],
		[LibraryId]=SOURCE.[LibraryId]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Name], [LibraryId])
	VALUES ([Name], [LibraryId])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;