using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        private Dictionary<string, BaseClass> objects = new Dictionary<string, BaseClass>();

        public Dictionary<string, BaseClass> All()
        {
            return objects;
        }


        public void New(BaseClass obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            string key = $"{obj.GetType().Name}.{obj.Id}";
            if (objects.ContainsKey(key))
                throw new InvalidOperationException($"Object with key {key} already exists.");

            objects[key] = obj;
        }

        public void Save()
        {
            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            if (parentDirectory == null)
                throw new InvalidOperationException("Parent directory not found.");

            string directoryPath = Path.Combine(parentDirectory, "storage");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "inventory_manager.json");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string jsonString = JsonSerializer.Serialize(objects, options);
            File.WriteAllText(filePath, jsonString);
        }


        public void Load()
        {
            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            if (parentDirectory == null)
                throw new InvalidOperationException("Parent directory not found.");

            string filePath = Path.Combine(parentDirectory, "storage", "inventory_manager.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The JSON file does not exist.", filePath);

            string jsonString = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(jsonString))
                throw new InvalidOperationException("The input does not contain any JSON tokens.");

            objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            }) ?? new Dictionary<string, BaseClass>();
        }

    }
}
