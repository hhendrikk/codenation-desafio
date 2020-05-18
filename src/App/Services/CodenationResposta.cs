using Newtonsoft.Json;

namespace App.Services
{
    public class CodenationResposta
    {
        [JsonProperty("numero_casas")]
        public int Saltos { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("cifrado")]
        public string Cifrado { get; set; }

        [JsonProperty("decifrado")]
        public string Decifrado { get; set; }

        [JsonProperty("resumo_criptografico")]
        public string ResumoCriptografado { get; set; }
    }
}