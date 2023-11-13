using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using verivox.Models;

namespace verivox.Converters
{
    public class TarifConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return (typeToConvert == typeof(TariffBase));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var type = jsonObject?["Type"]?.Value<byte>();
            TariffBase tariff;
            
            var name = jsonObject?["Name"]?.Value<string>();
            var baseCost = jsonObject?["BaseCost"]?.Value<double>();
            var additionalKwhCost = jsonObject?["AdditionalKwhCost"]?.Value<double>();
            var includedKwh = jsonObject?["IncludedKwh"]?.Value<int>();

            if(!ValidateTariff(name, type, baseCost, additionalKwhCost, includedKwh))
            {
                throw new InvalidCastException("Parse error. Tariff is not valid");
            }

            tariff = type switch
            {
                1 => new ProductATariff(name!, type!.Value, baseCost!.Value, additionalKwhCost!.Value),
                2 => new ProductBTariff(name!, type!.Value, baseCost!.Value, additionalKwhCost!.Value, includedKwh!.Value),
                _ => throw new NotImplementedException($"Unknown tariff product type {type}")
            };

            serializer.Populate(jsonObject?.CreateReader()!, tariff);
            return tariff;
        }

        private static bool ValidateTariff(string? name, byte? type, double? baseCost, double? additionalKwhCost, int? includedKwh)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            
            if(!type.HasValue || !baseCost.HasValue || !additionalKwhCost.HasValue)
            {
                return false;
            }

            if(type == 2 && !includedKwh.HasValue)
            {
                return false;
            }

            return true;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
