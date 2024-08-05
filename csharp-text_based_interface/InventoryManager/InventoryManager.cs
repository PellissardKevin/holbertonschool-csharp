using System;
using System.Collections.Generic;
using System.Linq;
using InventoryLibrary;

namespace InventoryManager
{
    public class Program
    {
        private static JSONStorage? storage = new JSONStorage();

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
                storage?.Load();
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

        public static void ShowClassNames()
        {
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

            var classNames = storage.All().Keys.Select(key => key.Split('.')[0]).Distinct();
            Console.WriteLine("Available Class Names:");
            foreach (var className in classNames)
            {
                Console.WriteLine(className);
            }
        }

        private static void ShowAllObjects()
        {
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

            foreach (var obj in storage.All())
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void ShowAllObjectsByClassName(string className)
        {
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

            var objectsByClass = storage.All().Where(obj => obj.Key.StartsWith(className + "."));
            foreach (var obj in objectsByClass)
            {
                Console.WriteLine($"{obj.Key}: {obj.Value}");
            }
        }

        private static void CreateObject(string className)
        {
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

            BaseClass newObject;

            switch (className.ToLower())
            {
                case "item":
                    Console.Write("Enter Item Name: ");
                    string itemName = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(itemName))
                    {
                        PrintError("Item Name is required.");
                        return;
                    }

                    Console.Write("Enter Item Description (optional): ");
                    string? itemDescription = Console.ReadLine();

                    Console.Write("Enter Item Price (optional, default is 0.00): ");
                    if (!float.TryParse(Console.ReadLine(), out float itemPrice))
                    {
                        itemPrice = 0.00f;
                    }

                    Console.Write("Enter Item Tags (comma-separated, optional): ");
                    string itemTagsInput = Console.ReadLine() ?? string.Empty;
                    List<string> itemTags = new List<string>(itemTagsInput.Split(',', StringSplitOptions.RemoveEmptyEntries));

                    newObject = new Item
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Name = itemName,
                        Description = itemDescription,
                        Price = itemPrice,
                        Tags = itemTags
                    };
                    break;

                case "user":
                    Console.Write("Enter User Name: ");
                    string userName = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        PrintError("User Name is required.");
                        return;
                    }

                    newObject = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        Name = userName
                    };
                    break;

                case "inventory":
                    Console.Write("Enter User ID: ");
                    string userId = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Item ID: ");
                    string itemId = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(itemId))
                    {
                        PrintError("User ID and Item ID are required.");
                        return;
                    }

                    Console.Write("Enter Quantity (default is 1): ");
                    if (!int.TryParse(Console.ReadLine(), out int inventoryQuantity) || inventoryQuantity < 0)
                    {
                        inventoryQuantity = 1;
                    }

                    newObject = new Inventory
                    {
                        Id = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        UserId = userId,
                        ItemId = itemId,
                        Quantity = inventoryQuantity
                    };
                    break;

                default:
                    PrintError($"{className} is not a valid object type");
                    return;
            }

            // Add the new object to the storage and save it
            try
            {
                storage.New(newObject);
                storage.Save();
                Console.WriteLine($"{className} created with ID: {newObject.Id}");
            }
            catch (Exception ex)
            {
                PrintError($"Failed to save the {className}: {ex.Message}");
            }
        }

        private static void ShowObject(string className, string id)
        {
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

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
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

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
            if (storage == null)
            {
                PrintError("Storage is not initialized");
                return;
            }

            string key = $"{className}.{id}";
            var allObjects = storage.All(); // Get the dictionary
            if (allObjects.Remove(key)) // Attempt to remove the object
            {
                try
                {
                    storage.Save(); // Save changes to JSON
                    Console.WriteLine($"{className} with ID {id} deleted");
                }
                catch (Exception ex)
                {
                    PrintError($"Error saving changes: {ex.Message}");
                }
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
