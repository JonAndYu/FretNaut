CREATE TABLE [dbo].[Users]
(
	UserId INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing user ID
    Username NVARCHAR(50) NOT NULL UNIQUE, -- User's username (unique)
    PasswordHash NVARCHAR(255) NOT NULL, -- Hashed password
    Email NVARCHAR(100) NOT NULL UNIQUE -- User's email (unique)
)
