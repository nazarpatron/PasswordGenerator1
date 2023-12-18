using PasswordGenerator1;
class Program
{
    static void Main()
    {
        Console.WriteLine("Witaj w generatorze haseł!");

        do
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Wygeneruj hasło");
            Console.WriteLine("2. Wyjście");

            Console.Write("Twój wybór: ");
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    GenerateAndDisplayPassword();
                    break;

                case "2":
                    Console.WriteLine("Dziękujemy za korzystanie z generatora haseł!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }

        } while (true);
    }

    static void GenerateAndDisplayPassword()
    {
        PasswordGenerator generator = new PasswordGenerator();
        PasswordOptions options = generator.GetUserPreferences();

        string password = generator.GeneratePassword(options);

        if (!string.IsNullOrEmpty(password))
        {
            Console.WriteLine($"Wygenerowane hasło: {password}");

            Console.Write("Czy chcesz wygenerować kolejne hasło? (Tak/Nie): ");
            if (!Console.ReadLine().Trim().Equals("Tak", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Dziękujemy za korzystanie z generatora haseł!");
                Environment.Exit(0);
            }
            Console.Clear();
        }
    }
}