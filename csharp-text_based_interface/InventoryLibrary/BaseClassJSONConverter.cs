using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using InventoryLibrary; // Ensure this points to the correct namespace

public class BaseClassJsonConverter : JsonConverter<BaseClass>
{
	public override BaseClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		using (var jsonDoc = JsonDocument.ParseValue(ref reader))
		{
			var root = jsonDoc.RootElement;
			var typeProperty = root.GetProperty("Type").GetString();
			if (string.IsNullOrEmpty(typeProperty))
			{
				throw new InvalidOperationException("The 'Type' property cannot be null or empty.");
			}

			var type = Type.GetType(typeProperty);
			if (type == null) throw new InvalidOperationException($"Unknown type: {typeProperty}");

			var obj = JsonSerializer.Deserialize(root.GetRawText(), type, options);
			return obj as BaseClass ?? throw new InvalidOperationException("Deserialization failed");
		}
	}

	public override void Write(Utf8JsonWriter writer, BaseClass value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();
		writer.WriteString("Type", value.GetType().AssemblyQualifiedName);
		foreach (var property in value.GetType().GetProperties())
		{
			var propValue = property.GetValue(value);
			if (propValue != null)
			{
				writer.WritePropertyName(property.Name);
				JsonSerializer.Serialize(writer, propValue, options);
			}
		}
		writer.WriteEndObject();
	}
}
