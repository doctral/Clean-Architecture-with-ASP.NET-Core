MERGE INTO dbo.ClientXBooks AS TARGET
USING ( VALUES
	(1, 1,1,1,GETDATE(), DATEADD(DAY,30, GETDATE())),
	(1, 1,2,1,GETDATE(), DATEADD(DAY,30, GETDATE())),
	(1, 1,3,1,GETDATE(), DATEADD(DAY,30, GETDATE())),
	(1, 1,4,1,GETDATE(), DATEADD(DAY,30, GETDATE()))
)
AS SOURCE (Id, ClientId, BookId, CreatedById, CreatedDate, ExpirationDate)
ON TARGET.Id = SOURCE.Id
WHEN MATCHED THEN
	UPDATE SET 
		ClientId=SOURCE.ClientId,
		BookId=SOURCE.BookId,
		CreatedById=SOURCE.CreatedById,
		CreatedDate=SOURCE.CreatedDate,
		ExpirationDate=SOURCE.ExpirationDate
WHEN NOT MATCHED BY TARGET THEN
	INSERT (ClientId, BookId, CreatedById, CreatedDate, ExpirationDate)
	VALUES (ClientId, BookId, CreatedById, CreatedDate, ExpirationDate)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;