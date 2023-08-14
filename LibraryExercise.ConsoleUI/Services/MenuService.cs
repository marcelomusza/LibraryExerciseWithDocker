using LibraryExercise.Application.Commands;
using LibraryExercise.Application.Services;
using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.ConsoleUI.Services
{
    internal class MenuService
    {
        private readonly BookService _bookService;

        public MenuService(BookService bookService)
        {
            _bookService = bookService;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Book Library Console Application");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List all Books");
                Console.WriteLine("4. Get Book");
                Console.WriteLine("5. Exit");
                Console.WriteLine("--------------------------------");

                Console.Write("Enter your desired action: ");

                //We'll assume right choices for the sake of this example, feel free to implement further validation 
                var choice = Console.ReadLine();

                var commands = new Dictionary<string, IBookCommand>
                {
                    {"1", new AddBookCommand(_bookService) },
                    {"2", new RemoveBookCommand(_bookService) },
                    {"3", new ListAllBooksCommand(_bookService) },
                    {"4", new GetBookByIdCommand(_bookService) },
                    {"5", new ExitCommand() }
                };

                if (commands.TryGetValue(choice!, out var command))
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press any key and try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}
