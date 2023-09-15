CREATE TABLE [dbo].[Tunings]
(
	TuningId INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing tuning ID
    Name NVARCHAR(100) NOT NULL, -- Tuning name
    Instrument NVARCHAR(50) NOT NULL, -- Instrument name
    TuningValues NVARCHAR(25) NOT NULL, -- JSON representation of tuning values (use NVARCHAR(MAX) for JSON storage)
    UserId INT NOT NULL, -- Foreign key to link tunings to users
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE -- Create a foreign key relationship
)
