CREATE PROCEDURE [dbo].[spTunings_Get]
	@Id int
AS
BEGIN
	SELECT TuningId, Name, Instrument, TuningValues, UserId
	FROM dbo.[Tunings]
	WHERE TuningId = @Id
END
