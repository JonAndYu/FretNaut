CREATE PROCEDURE [dbo].[spFretboard_GetAll]
AS
BEGIN
	SELECT TuningValues, Notes
	FROM dbo.[Fretboard]
END