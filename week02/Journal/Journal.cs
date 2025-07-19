public class Journal
{
    public List<Entry> Entries { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine(entry.FormatForSave());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry(parts[0], parts[1], parts[2]);
            Entries.Add(entry);
        }
    }
}