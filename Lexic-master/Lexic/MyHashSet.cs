using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lexic
{
    public class MyHashSet
    {
        private const int tablesize = 1000;
        private const double C = 0.6180339887;

        private Dictionary<int, Item> dict = new Dictionary<int, Item>();
        private List<int> order = new List<int>();

        private int hash(int key)
        {
            double rez = tablesize * ((C * key) % 1);
            return (int)Math.Ceiling((double)rez);
        }

        private bool predicat(int key, Item item)
        {
            if (!dict.ContainsKey(key))
                return true;
            else if (dict[key].Text == item.Text)
                return true;
            return false;
        }

        private void collisions(int key, Item item)
        {
            if (predicat(key, item))
            {
                dict[key] = item;
                order.Add(key);
                return;
            }
            int tmpKey = key;
            key += 1;
            while (key != tmpKey)
            {
                key = key % tablesize;
                if (predicat(key, item))
                {
                    dict[key] = item;
                    order.Add(key);
                    return;
                }
                else key++;
            }
            throw new Exception("Хеш таблица заполнена!!");
        }

        private int ItemToInt(Item item)
        {
            int itemKey = 0;
            foreach (char i in item.Text)
            {
                itemKey += Convert.ToInt32(i);
            }
            return itemKey;
        }

        public void Clear()
        {
            dict.Clear();
            order.Clear();
        }

        public void push(Item item)
        {
            int intItem = ItemToInt(item);
            int key = hash(intItem);
            try
            {
                collisions(key, item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }    
    }
}
