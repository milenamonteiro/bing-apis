using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace restsharptest
{
    public partial class FreteAntt
    {
        [JsonProperty("TipoCargaEnum")]
        public long TipoCargaEnum { get; set; }

        [JsonProperty("TipoCargaStr")]
        public string TipoCargaStr { get; set; }

        [JsonProperty("TotalEixo")]
        public long TotalEixo { get; set; }

        [JsonProperty("DistanciaKM")]
        public long DistanciaKm { get; set; }

        [JsonProperty("PossuiRetorno")]
        public long PossuiRetorno { get; set; }

        [JsonProperty("ValorFrete")]
        public double ValorFrete { get; set; }

        [JsonProperty("ValorFreteABCAM")]
        public double ValorFreteAbcam { get; set; }

        [JsonProperty("CargaRetorno")]
        public string CargaRetorno { get; set; }
    }

    public partial class FreteAntt
    {
        public static FreteAntt FromJson(string json) => JsonConvert.DeserializeObject<FreteAntt>(json, Converter.Settings);
    }
}
