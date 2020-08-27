using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamBackEnd
{
    public class IceCream
    {
        public IceCream(string flavor, bool dairy, bool nuts,string texture,int quantity)
        {
            Flavor = flavor;
            ContainsDairy = dairy;
            ContainsNuts = nuts;
            Texture = texture;
            Quantity = quantity;
        }
        public IceCream() { Quantity = 42; }
        public string Flavor { get; set; }
        public bool ContainsDairy { get; set; }
        public bool ContainsNuts { get; set; }
        public string Texture { get; set; }
        public int Quantity { get; set; }
    }
}
