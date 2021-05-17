using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Albelli.OrderManager.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductType
    {
        [EnumMember(Value = "PhotoBook")]
        PhotoBook = 1,
        [EnumMember(Value = "Calendar")]
        Calendar = 2,
        [EnumMember(Value = "Canvas")]
        Canvas = 3,
        [EnumMember(Value = "Cards")]
        Cards = 4,
        [EnumMember(Value = "Mug")]
        Mug = 5
    }
}
