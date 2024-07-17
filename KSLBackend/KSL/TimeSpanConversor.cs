
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace KSL;

public class TimeSpanConversor: JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var timeSpan = (TimeSpan)value;
        writer.WriteValue(timeSpan.ToString(@"hh\:mm"));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer)
    {
        return TimeSpan.Parse((string)reader.Value);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TimeSpan);
    }
}