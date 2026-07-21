using OOPProject.Models;
using OOPProject.Services;

namespace OOPProject.Helpers;

public static class RunSystem
{
     public static void Run()
    {
        LibraryBranch branch = DataSeeder.Seed();
        var display = new DisplayService();
        var libraryService = new LibraryService(branch, display);
        bool running = true;
        while (running) {
            try
            {
                ConsoleHelper.ShowMenu();
                string? chocie = Console.ReadLine()?.Trim();
                Console.WriteLine( );
                switch (chocie)
                {
                    case "1":
                        display.ShowBranchInfo(branch);
                        break;
                    case "2":
                        display.ShowAllUsers(branch);
                        break;
                    case "3":
                        display.ShowAvailableCopies(branch);
                        break;
                    case "4":
                        display.ShowAllCopies(branch);
                        break;
                    case "5":
                        libraryService.HandleBorrow();
                        break;
                    case "6":
                        libraryService.HandleReturn();
                        break;
                    case "7":
                        libraryService.HandleHistory();
                        break;
                    case "8":
                        libraryService.HandelRegisterMember();
                        break;
                    case "0":
                        Console.WriteLine("GoodBye!");
                        running = false; 
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Try Again");
                        break;
                }
            }catch(InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            Console.WriteLine("\n Prees Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
