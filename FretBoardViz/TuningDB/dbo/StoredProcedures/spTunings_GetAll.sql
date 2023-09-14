CREATE PROCEDURE [dbo].[spTunings_GetAll]
AS
BEGIN
	SELECT TuningId, Name, Instrument, TuningValues, UserId
	FROM dbo.[Tunings]
END
