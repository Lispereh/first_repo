using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_App
{
    internal class Expression
    {
        public string ExpressionString { get; set; } = string.Empty;
        public decimal Result { get; private set; } = 0;

        public void CountResult()
        {
            string[] expressionArr = ExpressionString.Split(new char[] { '+', '-', '/', '*' }, StringSplitOptions.RemoveEmptyEntries);
            string currentOperation = string.Empty;

            for (int i = 0; i < expressionArr.Length; i++)
            {
                if (i == 0)
                {
                    Result = Convert.ToDecimal(expressionArr[i]);
                }
                else
                {
                    if (i > 0)
                    {
                        currentOperation = ExpressionString[ExpressionString.IndexOf(expressionArr[i - 1]) + expressionArr[i - 1].Length].ToString();
                    }

                    if (currentOperation == "+")
                        Result += Convert.ToDecimal(expressionArr[i]);
                    else if (currentOperation == "-")
                        Result -= Convert.ToDecimal(expressionArr[i]);
                    else if (currentOperation == "*")
                        Result *= Convert.ToDecimal(expressionArr[i]);
                    else if (currentOperation == "/")
                        Result /= Convert.ToDecimal(expressionArr[i]);
                }
            }
        }
    }
}