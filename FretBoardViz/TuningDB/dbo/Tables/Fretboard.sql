CREATE TABLE [dbo].[Fretboard]
(
    [TuningValues] NVARCHAR(25) PRIMARY KEY, -- Primary key There is no reference to TuningValues, but there should be.
    [Notes] NVARCHAR(MAX) NOT NULL -- JSON representation of the fretboard
);

