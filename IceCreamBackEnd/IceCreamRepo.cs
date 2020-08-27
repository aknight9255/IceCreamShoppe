using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamBackEnd
{
    public class IceCreamRepo
    {
        private readonly List<IceCream> _iceCreamInventory = new List<IceCream>();

        public List<IceCream> ReturnIceCreamInventory()
        {
            return _iceCreamInventory;
        }

        public bool AddNewIceCream(IceCream item)
        {
            var startingCount = _iceCreamInventory.Count();
            _iceCreamInventory.Add(item);
            if (startingCount < _iceCreamInventory.Count)
            {
                return true;
            }
            else { return false; }
        }

        public IceCream FindbyFlavor(string flavorName)
        {
            foreach (var iceCream in _iceCreamInventory)
            {
                if (flavorName.ToLower() == iceCream.Flavor.ToLower())
                {
                    return iceCream;
                }
            }
            return null;
        }

        public bool DeleteByFlavor(string flavor)
        {
            var toBeDeleted = FindbyFlavor(flavor);
            return _iceCreamInventory.Remove(toBeDeleted);
        }

        public void UpdateFullIceCreamObject(IceCream newIceCreamInfo)
        {
            foreach (var iceCream in _iceCreamInventory)
            {
                if (newIceCreamInfo.Flavor == iceCream.Flavor)
                {
                    iceCream.ContainsDairy = newIceCreamInfo.ContainsDairy;
                    iceCream.ContainsNuts = newIceCreamInfo.ContainsNuts;
                    iceCream.Texture = newIceCreamInfo.Texture;
                    iceCream.Quantity = newIceCreamInfo.Quantity;
                }
            }
        }


