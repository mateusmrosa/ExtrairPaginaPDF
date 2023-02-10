using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtrairPaginaPDF
{
    internal class Util
    {
        public string InverterString(string posicao)
        {
            char[] arrChar = posicao.ToCharArray();

            Array.Reverse(arrChar);

            string stringInvertida = new String(arrChar);

            return stringInvertida;
        }

        public string DesinverterString(string stringInvertida)
        {
            char[] arrChar2 = stringInvertida.ToCharArray();

            Array.Reverse(arrChar2);

            string stringOriginal = new String(arrChar2);

            return stringOriginal;
        }

        public string RetornaAnoAtual()
        {
            return DateTime.Now.ToString("yyyy");
        }


    }
}
