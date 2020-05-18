using System.Text;
using System;
using System.IO;
using System.Threading.Tasks;
using App.Services;
using Newtonsoft.Json;
using Refit;
using System.Net.Http;

namespace App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ValidateArgs(args);
            var token = PegaToken(args);

            var codenationAPI = PegaCodenationService();

            var resultado = await codenationAPI.BuscarDataAsync(token);

            var criptografia = new JulioCesarCriptografia(resultado.Saltos);
            resultado.Decifrado = criptografia.Decifrar(resultado.Cifrado);
            resultado.ResumoCriptografado = Hash.SHA1(resultado.Decifrado);

            using (var stream = new MemoryStream())
            {
                await CriaArquivoAsync(resultado, stream);

                var nota = await SubmeteArquivoAsync(token, codenationAPI, stream);
                Console.WriteLine(nota.StatusCode);
                Console.WriteLine(nota.Content);
            }
        }

        private static async Task<ApiResponse<string>> SubmeteArquivoAsync(string token, ICodenation codenationAPI, MemoryStream stream)
        {
            return await codenationAPI.EnviaRespostaAsync(
                token,
                new ByteArrayPart(stream.ToArray(), "answer.json", "application/json")
            );
        }

        private static async Task CriaArquivoAsync(CodenationResposta resultado, MemoryStream stream)
        {
            using (var file = File.Create("answer.json"))
            {
                await stream.WriteAsync(
                    Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resultado))
                );

                stream.WriteTo(file);
            }
        }

        private static ICodenation PegaCodenationService()
        {
            return RestService.For<ICodenation>(
                hostUrl: "https://api.codenation.dev",
                settings: new RefitSettings(new NewtonsoftJsonContentSerializer())
            );
        }

        private static string PegaToken(string[] args)
        {
            return args[0];
        }

        private static void ValidateArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Informe o seu token");
                Environment.Exit(1);
            }
        }
    }
}
