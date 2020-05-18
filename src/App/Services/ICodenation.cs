using System;
using System.Threading.Tasks;
using Refit;

namespace App.Services
{
    public interface ICodenation
    {
        [Get("/v1/challenge/dev-ps/generate-data?token={token}")]
        Task<CodenationResposta> BuscarDataAsync(string token);


        [Multipart]
        [Post("/v1/challenge/dev-ps/submit-solution?token={token}")]
        Task<ApiResponse<string>> EnviaRespostaAsync(string token, [AliasAs("answer")] ByteArrayPart answer);
    }
}