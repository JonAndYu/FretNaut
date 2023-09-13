﻿CREATE PROCEDURE [dbo].[spUser_Insert]
    @Username NVARCHAR(50),
    @PasswordHash NVARCHAR(255),
    @Email NVARCHAR(100)
AS
BEGIN
    -- Insert a new user into the Users table
    INSERT INTO dbo.[Users] (Username, PasswordHash, Email)
    VALUES (@Username, @PasswordHash, @Email);

    -- Retrieve the UserId of the newly inserted user
    DECLARE @UserId INT;
    SET @UserId = SCOPE_IDENTITY();

    -- Insert default tunings for the user into the Tunings table
    INSERT INTO dbo.[Tunings] (Name, Instrument, TuningValues, UserId)
    VALUES ('Standard', 'Guitar', '["E", "A", "D", "G", "B", "E"]', @UserId);

    INSERT INTO dbo.[Tunings] (Name, Instrument, TuningValues, UserId)
    VALUES ('Standard', 'Bass', '["E", "A", "D", "G"]', @UserId);
END;
