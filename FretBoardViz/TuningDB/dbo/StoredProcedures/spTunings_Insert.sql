CREATE PROCEDURE [dbo].[spTunings_Insert]
    @Name NVARCHAR(100),
    @Instrument NVARCHAR(50),
    @TuningValues NVARCHAR(25),
    @UserId INT
AS
BEGIN
    -- Check if the @UserId exists (assuming UserId is a foreign key)
    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UserId = @UserId)
    BEGIN
        -- Insert a new tuning record
        INSERT INTO [dbo].[Tunings] (Name, Instrument, TuningValues, UserId)
        VALUES (@Name, @Instrument, @TuningValues, @UserId);

        -- Return a success status or message
        SELECT 'Tuning information inserted successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'User not found. Insert operation failed' AS [Status];
    END
END