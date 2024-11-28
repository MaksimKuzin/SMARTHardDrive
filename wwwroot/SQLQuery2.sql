CREATE PROCEDURE AddAlert
    @Type NVARCHAR(30),
    @Description NVARCHAR(MAX),
    @Date DATETIME,
    @Severity NVARCHAR(30),
    @Status NVARCHAR(30),
    @HardDriveId INT 
AS
BEGIN
    IF EXISTS (SELECT 1 FROM HardDrives WHERE Id = @HardDriveId)
    BEGIN
        INSERT INTO Alerts (Type, Description, Date, Severity, Status)
        VALUES (@Type, @Description, @Date, @Severity, @Status);
    
        DECLARE @AlertId INT = SCOPE_IDENTITY();

        INSERT INTO AlertHardDrive (AlertsId, HardDrivesId)
        VALUES (@AlertId, @HardDriveId);
    END
END