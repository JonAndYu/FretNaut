﻿CREATE PROCEDURE [dbo].[spFretboard_Delete]
	@TuningValues NVARCHAR(25)
AS
BEGIN
	-- Check if the @TuningId exists
    IF EXISTS (SELECT 1 FROM [dbo].[Fretboard] WHERE TuningValues = @TuningValues)
    BEGIN
        -- Delete the Fretboards's information
        DELETE
	    FROM dbo.[Fretboard]
	    WHERE TuningValues = @TuningValues

        -- Return a success status or message
        SELECT 'Fretboard information Deleted successfully' AS [Status];
    END
    ELSE
    BEGIN
        -- Return an error status or message if the user doesn't exist
        SELECT 'Tuning not found. Delete operation failed' AS [Status];
    END
END
