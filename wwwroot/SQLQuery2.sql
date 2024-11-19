CREATE PROCEDURE AddAlert
    @Type NVARCHAR(30),
    @Description NVARCHAR(MAX),
    @Date DATETIME,
    @Severity NVARCHAR(30),
    @Status NVARCHAR(30),
    @HardDriveId INT -- �������� ������ ���� HardDriveId
AS
BEGIN
    -- ������� ������ � ������� Alerts
    INSERT INTO Alerts (Type, Description, Date, Severity, Status)
    VALUES (@Type, @Description, @Date, @Severity, @Status);
    
    -- �������� ID ����������� ������
    DECLARE @AlertId INT = SCOPE_IDENTITY();

    -- ��������� ������ � ������� ����� AlertsHardDrives
    INSERT INTO AlertHardDrive (AlertsId, HardDrivesId)
    VALUES (@AlertId, @HardDriveId);
END