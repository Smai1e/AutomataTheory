using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexic
{
    public class Syntax
    {
        public static bool Check(List<string> lex)
        {
            int condition = 0;

            foreach (string item in lex)
            {
                switch (condition)
                {
                    case 0:
                        if (item == $"<{enumType.Try}>")
                        {
                            condition = 1;
                            break;
                        }
                        return false;
                    case 1:
                        if (item == $"<{enumType.Variable}>")
                        {
                            condition = 2;
                            break;
                        }
                        return false;
                    case 2:
                        if (item == $"<{enumType.Equals}>")
                        {
                            condition = 3;
                            break;
                        }
                        return false;
                    case 3:
                        if (item == $"<{enumType.Variable}>")
                        {
                            condition = 4;
                            break;
                        }
                        if (item == $"<{enumType.Number}>")
                        {
                            condition = 4;
                            break;
                        }
                        return false;
                    case 4:
                        if (item == $"<{enumType.Oper}>")
                        {
                            condition = 3;
                            break;
                        }
                        if (item == $"<{enumType.Semicolon}>")
                        {
                            condition = 5;
                            break;
                        }
                        return false;
                    case 5:
                        if (item == $"<{enumType.Catch}>")
                        {
                            condition = 6;
                            break;
                        }
                        return false;
                    case 6:
                        if (item == $"<{enumType.Variable}>")
                        {
                            condition = 7;
                            break;
                        }
                        return false;
                    case 7:
                        if (item == $"<{enumType.Equals}>")
                        {
                            condition = 8;
                            break;
                        }
                        return false;
                    case 8:
                        if (item == $"<{enumType.Variable}>")
                        {
                            condition = 9;
                            break;
                        }
                        if (item == $"<{enumType.Number}>")
                        {
                            condition = 9;
                            break;
                        }
                        return false;
                    case 9:
                        if (item == $"<{enumType.Oper}>")
                        {
                            condition = 8;
                            break;
                        }
                        if (item == $"<{enumType.Semicolon}>")
                        {
                            condition = 10;
                            break;
                        }
                        return false;
                    case 10:
                        if (item == $"<{enumType.Bracket}>")
                        {
                            condition = 10;
                            break;
                        }
                        return false;
                    default:
                        return false;
                }
            }

            return true;
        }
    }
}
