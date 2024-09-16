---- Create a new database
--CREATE DATABASE EducationDB;
--GO

---- Use the new database
--USE EducationDB;
--GO

---- Create the EmployeeAttendance table
--CREATE TABLE EmployeeAttendance (
--    EmployeeID INT,
--    StartDate DATE,
--    EndDate DATE
--);
--GO


----------------------------------------------

-- Insert sample data into EmployeeAttendance
--INSERT INTO EmployeeAttendance (EmployeeID, StartDate, EndDate) VALUES
--(1, '2024-01-01', '2024-01-05'),
--(1, '2024-01-10', '2024-01-15'),
--(1, '2024-01-20', '2024-01-25'),
--(2, '2024-02-01', '2024-02-03'),
--(2, '2024-02-07', '2024-02-10'),
--(2, '2024-02-15', '2024-02-20'),
--(3, '2024-03-01', '2024-03-05'),
--(3, '2024-03-07', '2024-03-12'),
--(3, '2024-03-18', '2024-03-22');
--GO


WITH OrderedAttendance AS (
    SELECT 
        EmployeeID,
        StartDate,
        EndDate,
        ROW_NUMBER() OVER (PARTITION BY EmployeeID ORDER BY StartDate) AS rn
    FROM EmployeeAttendance
),
DateGaps AS (
    SELECT 
        a1.EmployeeID,
        a1.EndDate AS PreviousEndDate,
        a2.StartDate AS NextStartDate,
        DATEDIFF(DAY, a1.EndDate, a2.StartDate) AS GapDays
    FROM OrderedAttendance a1
    JOIN OrderedAttendance a2
        ON a1.EmployeeID = a2.EmployeeID
        AND a1.rn = a2.rn - 1
    WHERE a2.StartDate > a1.EndDate
)
SELECT 
    EmployeeID,
    PreviousEndDate,
    NextStartDate,
    GapDays
FROM DateGaps
WHERE GapDays > 1;
