using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    abstract public class GetharingLocation : Location, IGatheringLocation
    {

        public GetharingLocation(string name, LocationType type, ItemType gatheredType, ItemType requiredItem)
            : base(name, type)
        {
            this.RequiredItem = requiredItem;
            this.GatheredType = gatheredType;
        }
        public ItemType GatheredType
        {
            get;
            private set;
        }

        public ItemType RequiredItem
        {
            get;
            private set;
        }

        public abstract Item ProduceItem(string name);
       
    }
}
