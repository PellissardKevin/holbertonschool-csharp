using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        // Dictionary to hold objects
        private Dictionary<string, BaseClass> objects = new Dictionary<string, BaseClass>();

        // Property to access objects dictionary
        public Dictionary<string, BaseClass> All()
        {
            return new Dictionary<string, BaseClass>(objects);
        }

        // Method to add a new object
        public void New(BaseClass obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            string key = $"{obj.GetType().Name}.{obj.Id}";
            if (objects.ContainsKey(key))
                throw new InvalidOperationException($"Object with key {key} already exists.");

            objects[key] = obj;
        }

        // Method to save objects to JSON file
        public void Save()
        {
            // Ensure the directory exists
            string directoryPath = "storage";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "inventory_manager.json");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // For easier readability
                Converters = { new JsonStringEnumConverter() }
            };

            // Serialize dictionary to JSON
            string jsonString = JsonSerializer.Serialize(objects, options);

            // Write JSON to file
            File.WriteAllText(filePath, jsonString);
        }

        // Method to load objects from JSON file
        public void Load()
        {
            string filePath = Path.Combine("storage", "inventory_manager.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The JSON file does not exist.", filePath);

            string jsonString = File.ReadAllText(filePath);

            // Deserialize JSON to dictionary
            objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            });
        }
    }
}
