using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class Book

    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public bool isNew { get; set; }
        public decimal inStock { get; set; }

        public override string ToString()
        {
            return $" '{Name}' by {Author}, in the {Genre} genre, with {Pages} pages and {inStock} in stock ";
        }



    }
}
