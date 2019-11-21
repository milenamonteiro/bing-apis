using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restsharptest
{
    public partial class UnidadeCadastro
    {
        [JsonProperty("unidade_cadastro")]
        public List<UnidadeCadastroElement> UnidadeCadastroUnidadeCadastro { get; set; }
    }

    public partial class UnidadeCadastroElement
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }
    }
}
