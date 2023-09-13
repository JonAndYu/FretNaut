CREATE TABLE [dbo].[Fretboard]
(
    TuningId INT PRIMARY KEY REFERENCES [dbo].[Tunings] (TuningId), -- Primary key references Tunings.TuningId
    Fretboard NVARCHAR(MAX) NOT NULL -- JSON representation of the fretboard
);

