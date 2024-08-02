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
            return new Dictionary<string, BaseClass>(objects);
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
            string directoryPath = "storage";
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
            string filePath = Path.Combine("storage", "inventory_manager.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The JSON file does not exist.", filePath);

            string jsonString = File.ReadAllText(filePath);

            objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            }) ?? new Dictionary<string, BaseClass>();
        }

    }
}
