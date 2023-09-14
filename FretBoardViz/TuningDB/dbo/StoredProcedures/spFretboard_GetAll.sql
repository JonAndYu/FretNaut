CREATE PROCEDURE [dbo].[spFretboard_GetAll]
AS
BEGIN
	SELECT TuningId, Fretboard
	FROM dbo.[Fretboard]
END