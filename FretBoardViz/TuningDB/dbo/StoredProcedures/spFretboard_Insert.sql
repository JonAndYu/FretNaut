CREATE PROCEDURE [dbo].[spFretboard_Insert]
	@TuningValues NVARCHAR(25),
	@Notes NVARCHAR(MAX)
AS
BEGIN
	-- Check if the @TuningValue exists
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Fretboard] WHERE TuningValues = @TuningValues)
    BEGIN
        -- Update the user's information
        INSERT INTO [dbo].[Fretboard] (TuningValues, Notes)
        VALUES (@TuningValues,@Notes);

        -- Return a success status or message
        SELECT 'Fretboard information updated successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'Fretboard already exists' AS [Status];
    END
END