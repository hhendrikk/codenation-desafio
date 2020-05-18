using System.Text;
using System;

namespace App
{
    public class JulioCesarCriptografia
    {
        private const int ASCII_PRIMEIRA_LETRA = 97;
        private const int ASCII_ULTIMA_LETRA = 122;
        private int saltos;

        public JulioCesarCriptografia(int saltos)
        {
            this.saltos = saltos;
        }

        public string Cifrar(string texto)
        {
            texto = TrataTexto(texto);

            var cifrado = new StringBuilder();

            foreach (var caracter in texto)
            {
                if (EstaEntreAeZ(caracter))
                {
                    var novoCaracter = CifraComOsSaltos(caracter);
                    cifrado.Append(novoCaracter);
                }
                else
                {
                    cifrado.Append(caracter);
                }
            }

            return cifrado.ToString();
        }

        public string Decifrar(string cifrado)
        {
            cifrado = TrataTexto(cifrado);

            var decifrado = new StringBuilder();

            foreach (var caracter in cifrado)
            {
                if (EstaEntreAeZ(caracter))
                {
                    var caracterVerdadeiro = DecifraComOsSaltos(caracter);
                    decifrado.Append(caracterVerdadeiro);
                }
                else
                {
                    decifrado.Append(caracter);
                }
            }

            return decifrado.ToString();
        }

        private string TrataTexto(string texto)
        {
            if (texto == null)
                return string.Empty;

            return texto.ToLower();
        }

        private char CifraComOsSaltos(int caracter)
        {
            if (EhReinicializarOAlfabetoAoCifrar(caracter))
            {
                var diferenca = (caracter + this.saltos) - ASCII_ULTIMA_LETRA;
                var novoCaracter = (ASCII_PRIMEIRA_LETRA - 1) + diferenca;
                return (char)novoCaracter;
            }

            return (char)(caracter + this.saltos);
        }

        private bool EhReinicializarOAlfabetoAoCifrar(int caracterInteiro) =>
            (caracterInteiro + this.saltos) > ASCII_ULTIMA_LETRA;

        private bool EhReinicializarOAlfabetoAoDecifrar(int caracterInteiro) =>
            (caracterInteiro - this.saltos) < ASCII_PRIMEIRA_LETRA;

        private static bool EstaEntreAeZ(char caracter) =>
            caracter >= ASCII_PRIMEIRA_LETRA &&
            caracter <= ASCII_ULTIMA_LETRA;

        private char DecifraComOsSaltos(int caracter)
        {
            if (EhReinicializarOAlfabetoAoDecifrar(caracter))
            {
                var diferenca = ASCII_PRIMEIRA_LETRA - (caracter - this.saltos);
                var novoCaracter = (ASCII_ULTIMA_LETRA + 1) - diferenca;
                return (char)novoCaracter;
            }

            return (char)(caracter - this.saltos);
        }
    }
}