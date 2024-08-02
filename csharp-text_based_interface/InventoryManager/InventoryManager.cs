using System;
using System.Collections.Generic;
using System.Linq;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        private static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            // Load data from storage
            LoadStorage();

            // Print initial prompt
            PrintPrompt();

            // Command processing loop
            while (true)
            {
                // Read user input
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                // Split input into command parts
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                // Process commands
                string command = parts[0].ToLower();

                switch (command)
                {
                    case "classnames":
                        ShowClassNames();
                        break;

                    case "all":
                        if (parts.Length == 1)
                        {
                            ShowAllObjects();
                        }
                        else if (parts.Length == 2)
                        {
                            ShowAllObjectsByClassName(parts[1]);
                        }
                        else
                        {
                            PrintError("Invalid command format");
                        }
                        break;

                    case "create":
                        if (parts.Length == 2)
                        {
                            CreateObject(parts[1]);
                        }
                        else
                        {
                            PrintError("Invalid command format");
                        }
                        break;

                    case "show":
                        if (parts.Length == 3)
                        {
                            ShowObject(parts[1], parts[2]);
                        }
                        else
                        {
                            PrintError("Invalid command format");
                        }
                        break;

                    case "update":
                        if (parts.Length == 3)
                        {
                            UpdateObject(parts[1], parts[2]);
                        }
                        else
                        {
                            PrintError("Invalid command format");
                        }
                        break;

                    case "delete":
                        if (parts.Length == 3)
                        {
                            DeleteObject(parts[1], parts[2]);
                        }
                        else
                        {
                            PrintError("Invalid command format");
                        }
                        break;

                    case "exit":
                        return;  // Exit the application

                    default:
                        PrintError("Unknown command");
                        break;
                }

                // Print prompt again
                PrintPrompt();
            }
        }

        private static void LoadStorage()
        {
            try
            {
                storage.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading storage: {ex.Message}");
                Environment.Exit(1);
            }
        }

        private static void PrintPrompt()
        {
            Console.WriteLine("\nInventory Manager");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ClassNames - show all ClassNames of objects");
            Console.WriteLine("All - show all objects");
            Console.WriteLine("All [ClassName] - show all objects of a ClassName");
            Console.WriteLine("Create [ClassName] - create and save a new object of ClassName");
            Console.WriteLine("Show [ClassName] [id] - show an object");
            Console.WriteLine("Update [ClassName] [id] - update the properties of the given object");
            Console.WriteLine("Delete [ClassName] [id] - delete the given object from storage");
            Console.WriteLine("Exit - quit the application");
        }

        private static void ShowClassNames()
        {
            var classNames = storage.All().Keys.Select(key => key.Split('.')[0]).Distinct();
            Console.WriteLine("Available Class Names:");
            foreach (var className in classNames)
            {
                Console.WriteLine(className);
            }
        }

        private static void ShowAllObjects()
        {
            foreach (var obj in storage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void ShowAllObjectsByClassName(string className)
        {
            var objects = storage.All()
                .Where(kvp => kvp.Key.StartsWith(className, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (objects.Count == 0)
            {
                Console.WriteLine($"No objects found for class '{className}'");
                return;
            }

            foreach (var obj in objects)
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void CreateObject(string className)
        {
            BaseClass newObject;

            switch (className.ToLower())
            {
                case "item":
                    newObject = new Item
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Name = "NewItem" // Default value
                    };
                    break;

                case "user":
                    newObject = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Name = "NewUser" // Default value
                    };
                    break;

                case "inventory":
                    newObject = new Inventory
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        UserId = "DefaultUserId",
                        ItemId = "DefaultItemId"
                    };
                    break;

                default:
                    PrintError($"{className} is not a valid object type");
                    return;
            }

            storage.New(newObject);
            storage.Save();
            Console.WriteLine($"{className} created with ID: {newObject.Id}");
        }

        private static void ShowObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (storage.All().TryGetValue(key, out var obj))
            {
                Console.WriteLine($"{key}: {obj}");
            }
            else
            {
                PrintError($"Object {id} could not be found");
            }
        }

        private static void UpdateObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (storage.All().TryGetValue(key, out var obj))
            {
                // Update properties
                Console.WriteLine($"Updating object {id}");
                // Here you could prompt for updates or directly modify properties as needed
                storage.Save();
                Console.WriteLine($"{className} updated");
            }
            else
            {
                PrintError($"Object {id} could not be found");
            }
        }

        private static void DeleteObject(string className, string id)
        {
            string key = $"{className}.{id}";
            if (storage.All().Remove(key))
            {
                storage.Save();
                Console.WriteLine($"{className} with ID {id} deleted");
            }
            else
            {
                PrintError($"Object {id} could not be found");
            }
        }

        private static void PrintError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
