using RPG.Inventory.Items.Containers.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class WetPaperBag : Container
    {
        public WetPaperBag() : base(3)
        {
            Name = "Wet Paper Sack";
            Description = "Damp and flimsy";
            Type = ItemType.Container;
            Weight = 1;

            AddRestriction(new CapacityRestriction());
            AddRestriction(new MaxWeightRestriction(2));
        }
    }
}
