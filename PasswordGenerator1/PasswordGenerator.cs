

namespace PasswordGenerator1
{
    class PasswordGenerator
    {
        private List<string> uppercaseLetters;
        private List<string> lowercaseLetters;
        private List<string> numericCharacters;
        private List<string> specialCharacters;

        private HashSet<string> selectedCharacters;

        public PasswordGenerator()
        {
            uppercaseLetters = GetAlphabetLetters('A', 'Z');
            lowercaseLetters = GetAlphabetLetters('a', 'z');
            numericCharacters = GetNumericCharacters();
            specialCharacters = GetSpecialCharacters();

            selectedCharacters = new HashSet<string>();
        }

        private static List<string> GetAlphabetLetters(char start, char end)
        {
            List<string> letters = new List<string>();
            for (char c = start; c <= end; c++)
            {
                letters.Add(c.ToString());
            }
            return letters;
        }

        private static List<string> GetNumericCharacters()
        {
            List<string> numericCharacters = new List<string>();
            for (int i = 0; i <= 9; i++)
            {
                numericCharacters.Add(i.ToString());
            }
            return numericCharacters;
        }

        private static List<string> GetSpecialCharacters()
        {
            return new List<string> { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "[", "]", "{", "}", ";", ":", "'", "\"", "<", ">", ",", ".", "?", "/" };
        }

        public PasswordOptions GetUserPreferences()
        {
            PasswordOptions options = new PasswordOptions();

            Console.WriteLine("Wybierz kategorie do uwzględnienia:");
            IncludeCategory("Wielkie litery", uppercaseLetters);
            IncludeCategory("Małe litery", lowercaseLetters);
            IncludeCategory("Cyfry", numericCharacters);
            IncludeCategory("Znaki specjalne", specialCharacters);

            Console.Write("Podaj długość hasła: ");
            options.Length = GetValidLength();

            return options;
        }

        private void IncludeCategory(string categoryName, List<string> categoryCharacters)
        {
            Console.Write($"{categoryName} (Tak/Nie): ");
            bool includeCategory = Console.ReadLine().Trim().Equals("Tak", StringComparison.OrdinalIgnoreCase);

            if (includeCategory)
            {
                selectedCharacters.UnionWith(categoryCharacters);
            }
        }

        public string GeneratePassword(PasswordOptions options)
        {
            if (options.Length == 0 || selectedCharacters.Count == 0)
            {
                Console.WriteLine("Nie można wygenerować hasła. Proszę wybrać przynajmniej jeden parametr.");
                return string.Empty;
            }

            Random random = new Random();
            string[] password = new string[options.Length];

            for (int i = 0; i < options.Length; i++)
            {
                password[i] = selectedCharacters.ElementAt(random.Next(selectedCharacters.Count));
            }

            return string.Concat(password);
        }

        private static int GetValidLength()
        {
            int length;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out length) && length > 0)
                    return length;
                else
                    Console.Write("Proszę podać poprawną długość hasła: ");
            }
        }
    }
}
