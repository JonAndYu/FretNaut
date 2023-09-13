using System.Text.Json;

namespace FretAPI.Utils;

public static class BaseTuningFileGenerator
{
    // Checks to see if there exists a Tunings.json file
    public static bool CheckFile()
    {
        string filePath = "Tunings.json";
        return File.Exists(filePath);
    }

    public static void CreateDefaultFile()
    {
        if (!BaseTuningFileGenerator.CheckFile())
        {
            BaseTuningFileGenerator.GenerateFile();
            BaseTuningFileGenerator.PopulateFile();
        }
    }

    // Generates an empty Tunings.json file
    // If a file already exists, it delates it
    public static void GenerateFile()
    {
        string filePath = "Tunings.json"; // Replace with the desired file path

        try
        {
            if (BaseTuningFileGenerator.CheckFile())
            {
                File.Delete(filePath);
            }
            File.Create(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Generates Standard, Drop D for Base and Guitar
    public static void PopulateFile()
    {
        var objects = new List<Object>
        {
            BaseTuningFileGenerator.GenerateEntry(instrument : "Guitar", name : "Standard", tuning : new List<string>{ "E", "A", "D", "G", "B", "E" }),
            BaseTuningFileGenerator.GenerateEntry(instrument : "Guitar", name : "Drop D", tuning : new List<string>{ "D", "A", "D", "G", "B", "E" }),
            BaseTuningFileGenerator.GenerateEntry(instrument : "Bass", name : "Standard", tuning : new List<string>{ "E", "A", "D", "G" }),
            BaseTuningFileGenerator.GenerateEntry(instrument : "Bass", name : "Drop D", tuning : new List<string>{ "D", "A", "D", "G" })
        };

        // Serializes teh list of objects to JSON
        string jsonString = JsonSerializer.Serialize(objects);

        string filePath = "Tunings.json";

        try
        {
            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"JSON data has been written to '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Generates Data for a single JSON entry
    private static object GenerateEntry(string instrument, string name, List<string> tuning)
    {
        List<List<string>> fretboard = new List<List<string>>();
        foreach (string note in tuning)
        {
            try
            {
                fretboard.Add(SemitoneGenerator.GetNext12Semitones(startingNote: note));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        return new
        {
            instrument = instrument,
            name = name,
            tuning = tuning,
            fretboard = fretboard
        };
    }

}
