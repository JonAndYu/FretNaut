using Microsoft.AspNetCore.Components.Forms;

namespace FretAPI.Utils;

public static class NotesHelper
{
	public static bool IsValidString(string text)
	{

		text = text.ToUpper();
		// Check if any character is not within the range 'A' to 'G' (inclusive) or is not '#'
		if (text.Any(c => (c < 'A' || c > 'G') && c != '#'))
		{
			return false;
		}

		// Check if the string contains "B#" or "E#"
		return !(text.Contains("B#") || text.Contains("E#"));
	}

	public static List<string> ConvertToList(string text)
	{
		List<string> notes = new List<string>();
		int index = 0;

		while (index < text.Length)
		{
			string note = text[index].ToString();
			index++;

			// Check if the next character is '#' (sharp)
			if (index < text.Length && text[index] == '#')
			{
				note += "#"; // Append '#' to the note
				index++;
			}

			notes.Add(note);
		}

		return notes;
	}
}
