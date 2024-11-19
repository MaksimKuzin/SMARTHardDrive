CREATE PROCEDURE AddAlert
    @Type NVARCHAR(30),
    @Description NVARCHAR(MAX),
    @Date DATETIME,
    @Severity NVARCHAR(30),
    @Status NVARCHAR(30),
    @HardDriveId INT -- Передаем только один HardDriveId
AS
BEGIN
    -- Вставка записи в таблицу Alerts
    INSERT INTO Alerts (Type, Description, Date, Severity, Status)
    VALUES (@Type, @Description, @Date, @Severity, @Status);
    
    -- Получаем ID вставленной записи
    DECLARE @AlertId INT = SCOPE_IDENTITY();

    -- Вставляем запись в таблицу связи AlertsHardDrives
    INSERT INTO AlertHardDrive (AlertsId, HardDrivesId)
    VALUES (@AlertId, @HardDriveId);
END