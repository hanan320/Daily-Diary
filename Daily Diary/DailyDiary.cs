using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiaryManager
{
    public class DailyDiary
    {
        private  string filePath;
        public List<Entry> entries;

        public object Entries { get; set; }

        public DailyDiary(string filePath)
        {
            this.filePath = filePath;
            this.entries = new List<Entry>();
            LoadEntries();
        }

        public void Run()
        {
            while (true)
            {
                

                Console.WriteLine("\nChoose an option enter the number you want:");
                Console.WriteLine("1. Read Diary");
                Console.WriteLine("2. Add Entry");
                Console.WriteLine("3. Delete Entry");
                Console.WriteLine("4. Count Entries");
                Console.WriteLine("5. Search Entries");
                Console.WriteLine("6. Exit\n");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear(); 
                        ReadDiaryFile();
                        break;
                    case "2":
                        Console.Clear();
                        AddEntry();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteEntry();
                        break;
                    case "4":
                        Console.Clear();
                        CountEntries();
                        break;
                    case "5":
                        Console.Clear();
                        SearchEntries();
                        break;
                    case "6":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        public void ReadDiaryFile()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("The diary is empty.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.Write($"\nDate : {entry.Date:yyyy-MM-dd} ,content : ");
                Console.WriteLine(entry.Content);
                Console.WriteLine();
            }
        }

        public void AddEntry()
        {
            try
            {
                Console.WriteLine("\nEnter the date (YYYY-MM-DD):");
                string dateInput = Console.ReadLine();
                Console.WriteLine("Enter the content:");
                string content = Console.ReadLine();

                if (!DateTime.TryParse(dateInput, out DateTime date))
                {
                    Console.WriteLine("Invalid date format.");
                    return;
                }

                entries.Add(new Entry { Date = date, Content = content });
                SaveEntries();
                Console.WriteLine("  AAAAA   DDDDD   DDDDD   EEEEEE   DDDDD");
                Console.WriteLine(" A     A  D    D  D    D  E        D    D");
                Console.WriteLine(" A     A  D    D  D    D  E        D    D");
                Console.WriteLine(" AAAAAAA  D    D  D    D  EEEE     D    D");
                Console.WriteLine(" A     A  D    D  D    D  E        D    D");
                Console.WriteLine(" A     A  D    D  D    D  E        D    D");
                Console.WriteLine(" A     A  DDDDD   DDDDD   EEEEEE   DDDDD");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the entry: {ex.Message}");
            }
        }

        public void DeleteEntry()
        {
            try
            {
                Console.WriteLine("Enter the date (YYYY-MM-DD) of the entry to delete:");
                string dateInput = Console.ReadLine();

                if (!DateTime.TryParse(dateInput, out DateTime date))
                {
                    Console.WriteLine("Invalid date format.");
                    return;
                }

                int initialCount = entries.Count;
                entries.RemoveAll(e => e.Date == date);

                if (initialCount == entries.Count)
                {
                    Console.WriteLine("\nNo entries found for the given date.");
                }
                else
                {
                    SaveEntries();
                    Console.WriteLine("\nEntries deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the entry: {ex.Message}");
            }
        }

        public void CountEntries()
        {
            try
            {
                Console.WriteLine($"\nTotal entries: {entries.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred while counting the entries: {ex.Message}");
            }
        }

        public void SearchEntries()
        {
            try
            {
                Console.WriteLine("Enter the date (YYYY-MM-DD) or keyword to search:");
                string searchInput = Console.ReadLine();

                var results = entries.Where(e => e.Date.ToString("yyyy-MM-dd").Contains(searchInput) || e.Content.Contains(searchInput)).ToList();

                if (results.Any())
                {
                    foreach (var entry in results)
                    {
                        Console.WriteLine($"{entry.Date:yyyy-MM-dd}");
                        Console.WriteLine(entry.Content);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No entries found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching the entries: {ex.Message}");
            }
        }

        private void LoadEntries()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i += 2)
                    {
                        if (i + 1 < lines.Length && DateTime.TryParse(lines[i], out DateTime date))
                        {
                            entries.Add(new Entry { Date = date, Content = lines[i + 1] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the entries: {ex.Message}");
            }
        }



        private void SaveEntries()
        {
            try
            {
                var lines = new List<string>();
                foreach (var entry in entries)
                {
                    lines.Add(entry.Date.ToString("yyyy-MM-dd"));
                    lines.Add(entry.Content);
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the entries: {ex.Message}");
            }
        }
    }
}
