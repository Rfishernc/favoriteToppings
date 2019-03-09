using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FavoriteToppings
{
    class Pizza
    {
       public int Popularity { get; set; }
        public List<string> Toppings { get; set; }
    }
}
