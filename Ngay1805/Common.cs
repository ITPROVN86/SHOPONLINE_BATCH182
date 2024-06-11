using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1805
{
    public class Common
    {
        public static string CurrencyFormat(string Number)
        {
            if (Number.Length <= 3)
                return Number;
            int commasPos = 0;
            String tmpFormated = String.Empty, Formated = String.Empty;
            for (int i = Number.Length - 1; i >= 0; i--)
            {
                commasPos++;
                tmpFormated += Number[i];
                if ((commasPos == 3) && (i != 0))
                {
                    tmpFormated += ",";
                    commasPos = 0;
                }
            }
            for (int i = tmpFormated.Length - 1; i >= 0; i--)
            {
                Formated += tmpFormated[i];
            }
            return Formated;
        }

    }
}
