using System;

namespace Lexic
{
    class Lexema
    {
        /// <summary>
        /// Арифметический Оператор
        /// </summary>
        public static bool IsArithmOperator(string text)
        {
            return (text == "+" || text == "-" || text == "*" || text == "/");
        }

        public static bool IsEquals(string text)
        {
            return (text == "=");
        }

        /// <summary>
        /// Число
        /// </summary>
        public static bool IsNumber(string text)
        {
            double x;
            return double.TryParse(text, out x);
        }

        /// <summary>
        /// Похоже на переменную
        /// </summary>
        public static bool CanBeVariable(string text)
        {
            bool CanBe = true;

            if (text.Length == 0 || !Char.IsLetter(text[0]))
                CanBe = false;
            else 
                foreach (char s in text)
                {
                    if (s != '_' && !Char.IsDigit(s) && !Char.IsLetter(s))
                        CanBe = false;
                }
            return CanBe;
        }

        /// <summary>
        /// ;
        /// </summary>
        public static bool IsSemicolon(string text)
        {
            return (text == ";");
        }
        
        /// <summary>
        /// Скобка
        /// </summary>
        public static bool IsBracket(string text)
        {
            return (text == "}");
        }

        /// <summary>
        /// Try
        /// </summary>
        public static bool IsTry(string text)
        {
            return (text == "try{");
        }

        /// <summary>
        /// Catch
        /// </summary>
        public static bool IsCatch(string text)
        {
            return (text == "}catch{");
        }
    }
}
