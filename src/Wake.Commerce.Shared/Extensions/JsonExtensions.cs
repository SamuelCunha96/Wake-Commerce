using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Wake.Commerce.Shared.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJsonIgnoringNullValues(this object valor)
        {
            JsonSerializerSettings settings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(valor, settings);
        }
    }
}
