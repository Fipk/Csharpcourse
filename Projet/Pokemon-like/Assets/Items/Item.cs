using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_like
{
    public class Item
    {
        private string name;
        private int price;
        public Item(int m_price, string m_name)
        {
            this.price = m_price;
            this.name = m_name;
        }

        public string GetName() { return name; }
        public int GetPrice() { return price; }

        public void SetName(string m_name) { this.name = m_name; }
        public void SetPrice(int m_price) { this.price = m_price; }
    }
}
