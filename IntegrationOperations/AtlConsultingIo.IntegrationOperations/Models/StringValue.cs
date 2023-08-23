namespace AtlConsultingIo.IntegrationOperations;

/// <summary>
/// Intended use is for instances where I need to restrict a generic to value types only, but I want to allow string as well.
/// Should be used sparingly as it can impact memory consumption
/// </summary>
public readonly struct StringValue : IEquatable<StringValue>
{
    private readonly string value;

    public StringValue(string value)
    {
        this.value = value;
    }

    public string Value => value;

    public override bool Equals(object? obj)
    {
        return obj is StringValue other && Equals(other);
    }

    public bool Equals(StringValue other)
    {
        return string.Equals(value, other.value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return value?.GetHashCode() ?? 0;
    }

    public static bool operator ==(StringValue left, StringValue right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(StringValue left, StringValue right)
    {
        return !left.Equals(right);
    }

    public override string ToString()
    {
        return value ?? string.Empty;
    }

    public static readonly StringValue NullPrintString = new StringValue("NULL");
    public static readonly StringValue EmptryPrintString = new StringValue("EMPTY");
    public static readonly StringValue Empty = new StringValue(String.Empty);

    public static implicit operator string(StringValue value)
    {
        return value.Value;
    }

    public static implicit operator StringValue(string value)
    {
        return new StringValue(value);
    }

    public static implicit operator StringValue( Guid _ )
        => new StringValue( _.ToString() );
}



public class StringValueJsonConverter : JsonConverter<StringValue>
{
    public override void WriteJson(JsonWriter writer, StringValue value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Value);
    }

    public override StringValue ReadJson(JsonReader reader, Type objectType, StringValue existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
            return StringValue.Empty;

        return new StringValue((string)reader.Value);
    }
}
