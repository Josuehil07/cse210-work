using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // ScriptureWord class remains the same
    public class ScriptureWord
    {
        private string _word;
        private bool _isHidden;

        public ScriptureWord(string word)
        {
            _word = word;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _word.Length) : _word;
        }
    }

    // ScriptureReference class remains the same
    public class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int? _endVerse;

        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
        }

        public ScriptureReference(string book, int chapter, int verse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            return _endVerse.HasValue ?
                $"{_book} {_chapter}:{_verse}-{_endVerse}" :
                $"{_book} {_chapter}:{_verse}";
        }
    }

    // Scripture class remains the same
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<ScriptureWord> _words;
        private Random _random;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
            _random = new Random();
        }

        public void HideRandomWords(int count = 3)
        {
            var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
            if (!visibleWords.Any()) return;

            for (int i = 0; i < Math.Min(count, visibleWords.Count); i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(word => word.IsHidden());
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_reference.GetDisplayText());
            Console.WriteLine(string.Join(" ", _words.Select(word => word.GetDisplayText())));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of scriptures from Job and Joshua
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(
                    new ScriptureReference("Job", 19, 25),
                    "I know that my redeemer lives and that in the end he will stand on the earth."
                ),
                new Scripture(
                    new ScriptureReference("Joshua", 1, 9),
                    "Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go."
                ),
                new Scripture(
                    new ScriptureReference("Job", 42, 5, 6),
                    "My ears had heard of you but now my eyes have seen you. Therefore I despise myself and repent in dust and ashes."
                )
            };

            // Randomly select a scripture
            Random random = new Random();
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            while (true)
            {
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Press any key to exit.");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                    break;

                scripture.HideRandomWords();
            }
        }
    }
}