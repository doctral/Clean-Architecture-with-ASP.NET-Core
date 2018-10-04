MERGE INTO dbo.Clients AS TARGET
USING ( VALUES
	(1, 'Eric', 'Li', 'test@gmail.com', GETDATE(), 1, NULL,NULL,NULL,NULL),
	(2, 'Emily', 'Li', 'test@gmail.com', GETDATE(), 1, NULL,NULL,NULL,NULL)
)
AS SOURCE (Id, FirstName, LastName, Email, CreatedDate, CreatedById, ModifiedDate, ModifiedById, DeletedDate, DeletedById)
ON TARGET.Id = SOURCE.Id
WHEN MATCHED THEN
	UPDATE SET 
	FirstName=SOURCE.FirstName,
	LastName=SOURCE.LastName,
	Email=SOURCE.Email,
	CreatedDate=SOURCE.CreatedDate,
	CreatedById=SOURCE.CreatedById,
	ModifiedDate=SOURCE.ModifiedDate,
	ModifiedById=SOURCE.ModifiedById,
	DeletedDate=SOURCE.DeletedDate,
	DeletedById=SOURCE.DeletedById
WHEN NOT MATCHED BY TARGET THEN
	INSERT (FirstName, LastName, Email, CreatedDate, CreatedById, ModifiedDate, ModifiedById, DeletedDate, DeletedById)
	VALUES (FirstName, LastName, Email, CreatedDate, CreatedById, ModifiedDate, ModifiedById, DeletedDate, DeletedById)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;