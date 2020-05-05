using System;
using System.Text;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            if (string.Empty == message)
            {
                return string.Empty;
            }

            //transforma a string em bytes
            byte[] asciiBytes = Encoding.ASCII.GetBytes(message.ToLower());
            //instancia um array de bytes
            byte[] asciiBytesReturned = new byte[asciiBytes.Length];

            //percorre o array de bytes
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                //convert o valor do array em inteiro
                var num = Convert.ToInt32(asciiBytes[i]);

                if ((num < 97 || num > 122) && num != 32 && num != 46 && !(num >= 48 && num <= 57))
                {
                    throw new ArgumentOutOfRangeException();
                }

                //32 e 46 nao sao convertidos - espaco e ponto
                if ((num != 32 && num != 46) && (num >= 97))
                {
                    //soma o numero da tabela ascii pelo numero de casas
                    var converted = num + 3;

                    //se for maior que 122 precisa voltar para o 97 primeira letra do alfabeto minusculo na ascii
                    if (converted > 122)
                    {
                        //subtrai o numero convertido pela quantidade de letras do alfabeto + 1
                        var letterReturned = converted - 26;

                        //converte bytes
                        asciiBytesReturned[i] = Convert.ToByte(letterReturned);
                    }
                    else
                    {
                        asciiBytesReturned[i] = Convert.ToByte(converted);
                    }
                }
                else
                {
                    asciiBytesReturned[i] = Convert.ToByte(num);
                }
            }
            //converte os bytes em string para retornar a frase criptografada
            return Encoding.ASCII.GetString(asciiBytesReturned);
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
            {
                throw new ArgumentNullException();
            }

            if (string.Empty == cryptedMessage)
            {
                return string.Empty;
            }

            //transforma a string em bytes
            byte[] asciiBytes = Encoding.ASCII.GetBytes(cryptedMessage.ToLower());
            //instancia um array de bytes
            byte[] asciiBytesReturned = new byte[asciiBytes.Length];

            //percorre o array de bytes
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                //convert o valor do array em inteiro
                var num = Convert.ToInt32(asciiBytes[i]);

                if ((num < 97 || num > 122) && num != 32 && num != 46 && !(num >= 48 && num <= 57))
                {
                    throw new ArgumentOutOfRangeException();
                }

                //32 e 46 nao sao convertidos - espaco e ponto
                if ((num != 32 && num != 46) && (num >= 97))
                {
                    //subtrai o numero da tabela ascii pelo numero de casas
                    var converted = num - 3;

                    //se for menor que 97 precisa voltar para o 122 ultima letra do alfabeto minusculo na ascii
                    if (converted < 97)
                    {
                        var sobra = 97 - converted - 1;
                        //subtrai o numero convertido pela a ultima letra tabela ascii
                        var letterReturned = 122 - sobra;

                        //converte bytes
                        asciiBytesReturned[i] = Convert.ToByte(letterReturned);
                    }
                    else
                    {
                        asciiBytesReturned[i] = Convert.ToByte(converted);
                    }
                }
                else
                {
                    asciiBytesReturned[i] = Convert.ToByte(num);
                }
            }
            //converte os bytes em string para retornar a frase criptografada
            return Encoding.ASCII.GetString(asciiBytesReturned);
        }
    }
}
