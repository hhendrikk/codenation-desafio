using Xunit;
using App;

namespace Testes
{
    public class JulioCesarTests
    {
        [Fact]
        public void DeveCriarUmaCriptografiaJulioCesar()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "a b c d");
        }

        [Fact]
        public void DeveCifrarUmaLetra()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "a");

            Assert.Equal("d", cifrado);
        }

        [Fact]
        public void DeveCifrarComDuasLetras()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "ad");

            Assert.Equal("dg", cifrado);
        }

        [Fact]
        public void DeveCifrarComEspacosEntreLetras()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "a d");

            Assert.Equal("d g", cifrado);
        }

        [Fact]
        public void DeveCifrarComNumerosEPontos()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "a.d,e12345678");

            Assert.Equal("d.g,h12345678", cifrado);
        }

        [Fact]
        public void DeveCifrarComALetraZ()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar("z");

            Assert.Equal("c", cifrado);
        }

        [Fact]
        public void DeveCifrarComALetraW()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar("w");

            Assert.Equal("z", cifrado);
        }

        [Fact]
        public void DeveCifrarComALetraAEmMaiusculo()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(texto: "A");

            Assert.Equal("d", cifrado);
        }

        [Fact]
        public void DeveCifrarOAlfabeto()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(
                texto: "a b c d e f g h i j k l m n o p q r s t u v w x y z a"
            );

            Assert.Equal(
                "d e f g h i j k l m n o p q r s t u v w x y z a b c d",
                cifrado
            );
        }

        [Fact]
        public void DeveCifrarUmTexto()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string cifrado = criptografia.Cifrar(
                texto: "a ligeira raposa marrom saltou sobre o cachorro cansado"
            );

            Assert.Equal(
                "d oljhlud udsrvd pduurp vdowrx vreuh r fdfkruur fdqvdgr",
                cifrado
            );
        }

        [Fact]
        public void DeveDecifrarALetraD()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string decifrado = criptografia.Decifrar(cifrado: "d");

            Assert.Equal(
                "a",
                decifrado
            );
        }

        [Fact]
        public void DeveDecifrarALetraA()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string decifrado = criptografia.Decifrar(cifrado: "a");

            Assert.Equal(
                "x",
                decifrado
            );
        }

        [Fact]
        public void DeveDecifrarUmTexto()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string decifrado = criptografia.Decifrar(
                cifrado: "d oljhlud udsrvd pduurp vdowrx vreuh r fdfkruur fdqvdgr"
            );

            Assert.Equal(
                "a ligeira raposa marrom saltou sobre o cachorro cansado",
                decifrado
            );
        }

        [Fact]
        public void DeveDecifrarOAlfabeto()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string decifrado = criptografia.Decifrar(
                cifrado: "d e f g h i j k l m n o p q r s t u v w x y z a b c d"
            );

            Assert.Equal(
                "a b c d e f g h i j k l m n o p q r s t u v w x y z a",
                decifrado
            );
        }

        [Fact]
        public void DeveDecifrarComNumerosEPontos()
        {
            var criptografia = new JulioCesarCriptografia(saltos: 3);
            string decifrado = criptografia.Decifrar(cifrado: "d.g,h12345678");

            Assert.Equal("a.d,e12345678", decifrado);
        }
    }
}