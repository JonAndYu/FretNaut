﻿using System;
using System.Collections.Generic;

namespace FretAPI.Utils;
public class SemitoneGenerator
{
    // Define the notes and their semitone offsets
    private static readonly Dictionary<string, int> NoteOffsets = new Dictionary<string, int>
        {
            { "C", 0 },
            { "C#", 1 },
            { "D", 2 },
            { "D#", 3 },
            { "E", 4 },
            { "F", 5 },
            { "F#", 6 },
            { "G", 7 },
            { "G#", 8 },
            { "A", 9 },
            { "A#", 10 },
            { "B", 11 }
        };

    public static List<string> GetNext12Semitones(string startingNote, int numNotes = 13)
    {
        if (!NoteOffsets.ContainsKey(startingNote))
        {
            throw new ArgumentException("Invalid starting note.");
        }

        List<string> semitones = new List<string>() { };

        int currentOffset = NoteOffsets[startingNote];

        for (int i = 0; i < numNotes; i++)
        {
            semitones
                .Add(
                    NoteOffsets.FirstOrDefault(x => x.Value == currentOffset).Key
                );

            currentOffset = (currentOffset + 1) % 12;
        }

        return semitones;
    }

	public static List<List<string>> CreateNotesArray(List<string> notes)
	{
		List<List<string>> res = new List<List<string>>();

		foreach (string note in notes)
		{
			res.Add(GetNext12Semitones(note));
		}
		return res;
	}
}
