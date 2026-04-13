DELETE FROM Results;
DELETE FROM Questions;
DELETE FROM Quizzes;
DELETE FROM Lessons;
DELETE FROM Courses;
DELETE FROM Users;

DBCC CHECKIDENT ('Results', RESEED, 0);
DBCC CHECKIDENT ('Questions', RESEED, 0);
DBCC CHECKIDENT ('Quizzes', RESEED, 0);
DBCC CHECKIDENT ('Lessons', RESEED, 0);
DBCC CHECKIDENT ('Courses', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);

SELECT * FROM Users;

SELECT * FROM Courses WHERE Title = 'HTML';

SELECT * FROM Users ORDER BY FullName;

SELECT u.FullName, c.Title
FROM Users u
INNER JOIN Courses c ON u.UserId = c.CreatedBy;

SELECT u.FullName, r.Score
FROM Users u
LEFT JOIN Results r ON u.UserId = r.UserId;

SELECT UserId, COUNT(*) AS TotalAttempts
FROM Results
GROUP BY UserId;

SELECT AVG(Score) AS AverageScore FROM Results;

SELECT * FROM Results
WHERE Score > (SELECT AVG(Score) FROM Results);

SELECT FullName FROM Users
UNION
SELECT Title FROM Courses;

INSERT INTO Users (FullName, Email, PasswordHash, CreatedAt)
VALUES ('Vinay', 'vinay@test.com', '123', GETDATE());

UPDATE Users SET FullName = 'Vinay Kumar' WHERE UserId = 1;

DELETE FROM Users WHERE UserId = 2;