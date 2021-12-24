using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexic
{
    public class Item
    {
        public string Text;
        public enumType enumType;

        public Item(string text, enumType type)
        {
            Text = text;
            enumType = type;
        }
    }
}
