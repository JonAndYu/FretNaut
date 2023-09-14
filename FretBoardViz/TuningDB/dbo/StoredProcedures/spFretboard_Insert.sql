CREATE PROCEDURE [dbo].[spFretboard_Insert]
	@TuningId int,
	@Notes NVARCHAR(MAX)
AS
BEGIN
	-- Check if the @TuningId exists
    IF EXISTS (SELECT 1 FROM [dbo].[Fretboard] WHERE TuningId = @TuningId)
    BEGIN
        -- Update the user's information
        INSERT INTO [dbo].[Fretboard] (TuningId, Fretboard)
        VALUES (@TuningId,@Notes);

        -- Return a success status or message
        SELECT 'Fretboard information updated successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'Tuning not found. Update operation failed' AS [Status];
    END
END