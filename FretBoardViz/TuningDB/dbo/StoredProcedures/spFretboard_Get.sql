CREATE PROCEDURE [dbo].[spFretboard_Get]
	@TuningValues NVARCHAR(25)
AS
BEGIN
	SELECT TuningValues, Notes
	FROM dbo.[Fretboard]
	WHERE TuningValues = @TuningValues
END
