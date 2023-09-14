CREATE PROCEDURE [dbo].[spTunings_Delete]
    @TuningId INT
AS
BEGIN
    -- Check if the @TuningId exists
    IF EXISTS (SELECT 1 FROM [dbo].[Tunings] WHERE TuningId = @TuningId)
    BEGIN
        -- Delete the tuning record
        DELETE 
        FROM [dbo].[Tunings] 
        WHERE TuningId = @TuningId;

        -- Return a success status or message
        SELECT 'Tuning information deleted successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the TuningId doesn't exist
        SELECT 'Tuning not found. Delete operation failed' AS [Status];
    END
END