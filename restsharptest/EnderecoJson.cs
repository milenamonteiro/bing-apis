using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace restsharptest
{
    public partial class EnderecoJson
    {
        [JsonProperty("CEP")]
        public string Cep { get; set; }

        [JsonProperty("UF")]
        public string Uf { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("District")]
        public string District { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }

    public partial class EnderecoJson
    {
        public static EnderecoJson FromJson(string json) => JsonConvert.DeserializeObject<EnderecoJson>(json, Converter.Settings);
    }
}
