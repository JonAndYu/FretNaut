CREATE PROCEDURE [dbo].[spFretboard_Get]
	@Id int
AS
BEGIN
	SELECT TuningId, Fretboard
	FROM dbo.[Fretboard]
	WHERE TuningId = @Id
END
