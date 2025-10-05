using System.Text.Json.Serialization;

namespace APICatalogo.Models.Base
{
    public class BaseRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime DataInsercao { get; set; }

        [JsonIgnore]
        public DateTime? DataExclusao { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public bool Ativo { get; set; }

    }
}