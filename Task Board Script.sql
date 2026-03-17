CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    Name NVARCHAR(100),
    Designation NVARCHAR(100)
);

CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT,
    Title NVARCHAR(200),
    Description NVARCHAR(500),
    Priority NVARCHAR(50)
);




CREATE PROCEDURE prc_CreateTask
    @EmployeeId INT,
    @Name NVARCHAR(200),
    @Title NVARCHAR(200),
    @Description NVARCHAR(500),
    @Priority NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF @EmployeeId IS NULL OR @EmployeeId = 0
    BEGIN
        SELECT @EmployeeId = ISNULL(MAX(EmployeeId), 0) + 1 FROM Employees;
    END

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeId = @EmployeeId)
    BEGIN
        INSERT INTO Employees (EmployeeId, Name, Designation)
        VALUES (@EmployeeId, @Name, 'Unknown'); -- default Designation
    END

    INSERT INTO Tasks (EmployeeId, Title, Description, Priority)
    VALUES (@EmployeeId, @Title, @Description, @Priority);
END
GO

CREATE PROCEDURE prc_GetTasks
    @EmployeeId INT,
    @Title NVARCHAR(200),
    @Description NVARCHAR(500),
    @Priority NVARCHAR(50)
AS
BEGIN
    INSERT INTO Tasks(EmployeeId, Title, Description, Priority)
    VALUES (@EmployeeId, @Title, @Description, @Priority)
END

CREATE PROCEDURE prc_UpdateTask
    @Id INT,
    @EmployeeId INT,
    @Name NVARCHAR(200),
    @Title NVARCHAR(200),
    @Description NVARCHAR(500),
    @Priority NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Employees WHERE EmployeeId = @EmployeeId)
    BEGIN
        UPDATE Employees
        SET Name = @Name
        WHERE EmployeeId = @EmployeeId;
    END

    UPDATE Tasks
    SET 
        EmployeeId = @EmployeeId,
        Title = @Title,
        Description = @Description,
        Priority = @Priority
    WHERE EmployeeId = @EmployeeId;
END
GO

CREATE PROCEDURE prc_DeleteTask
    @Id INT
AS
BEGIN
    DELETE FROM Tasks WHERE Id = @Id
END

CREATE PROCEDURE prc_GetTasks
AS
BEGIN
    SELECT 
        t.Id,
        t.EmployeeId,
        e.Name,
        e.Designation,
        t.Title,
        t.Description,
        t.Priority
    FROM Tasks t
    LEFT JOIN Employees e ON t.EmployeeId = e.EmployeeId
END
GO


