using System;

namespace cadastro_series
{
    class Program
    {

        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {

            string userChoice = GetUserInput();

            while(userChoice.ToUpper() != "X")
            {
                switch (userChoice)
                {
                    case "1": 
                        ListSeries();
                        break; 
                    case "2": 
                        InsertEntry();
                        break; 
                    case "3": 
                        UpdateEntry();
                        break; 
                    case "4": 
                        DeleteEntry();
                        break; 
                    case "5": 
                        ShowEntry();
                        break; 
                    case "C": 
                        Console.Clear();
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException(); 

                }
                userChoice = GetUserInput();
            }
            Console.WriteLine("Thank you for using our services");
            Console.ReadLine();

        }

        private static string GetUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1- List all TV series");
            Console.WriteLine("2- Insert a new title");
            Console.WriteLine("3- Update a title");
            Console.WriteLine("4- Delete a title");
            Console.WriteLine("5- Show TV serie info");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userChoice = Console.ReadLine().ToUpper();

            Console.WriteLine();
            return userChoice;
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listing all TV series");

            var list = repository.list();

            if(list.Count == 0)
            {
                Console.WriteLine("No entries found");
                return;
            }

            foreach(var serie in list)
            {
                bool deleted = serie.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "Deleted" : ""));
            }

        }

        private static void InsertEntry()
        {
            Console.WriteLine("Insert a new TV series:");

            foreach(int i in Enum.GetValues(typeof(Genre))) //if a new genre is added to the library this code remains the same
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Please type the number of a genre among the ones listed above");
            int newGenre = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Please type the Title of the TV series");
            string newTitle = Console.ReadLine(); 

            Console.WriteLine("Please type the year in which it was released");
            int newYear = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Please type a description for the TV series");
            string newDescription = Console.ReadLine(); 

            Serie newSerie = new Serie(id: repository.NextId(),
                                       genre: (Genre)newGenre,
                                       title: newTitle,
                                       year: newYear,
                                       description: newDescription);
            repository.Insert(newSerie);

        }

        private static void UpdateEntry()
        {
            Console.WriteLine("Please type the entry id:");
            int entryId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre))) //if a new genre is added to the library this code remains the same
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Please type the number of a genre among the ones listed above");
            int newGenre = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Please type the Title of the TV series");
            string newTitle = Console.ReadLine(); 

            Console.WriteLine("Please type the year in which it was released");
            int newYear = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Please type a description for the TV series");
            string newDescription = Console.ReadLine(); 

            Serie newSerie = new Serie(id: entryId,
                                       genre: (Genre)newGenre,
                                       title: newTitle,
                                       year: newYear,
                                       description: newDescription);
            repository.Update(entryId, newSerie);
        }

        private static void DeleteEntry()
        {
            Console.WriteLine("Type the TV series ID that you want to delete");
            int index = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Are you sure you want to delete this entry? Y/N");
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if(userInput.ToUpper() == "Y")
                {
                    repository.Delete(index);
                    Console.WriteLine("Entry deleted");   
                    return;
                }
                else if (userInput.ToUpper() == "N")
                {
                    Console.WriteLine("Delete operation aborted.");
                    return;
                }
                else 
                {
                    Console.WriteLine("Please type 'Y' for yes or 'N' for no");
                }
            }while(userInput.ToUpper() != "Y" || userInput.ToUpper() != "N");
            
        }

        private static void ShowEntry()
        {
            Console.WriteLine("Type a TV series ID to show its detailed info");
            int index = int.Parse(Console.ReadLine()); 
            var serie = repository.ReturnById(index);
            Console.WriteLine(serie);
        }
    }
}
