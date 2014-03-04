using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class AdvancedInteractionManager : InteractionManager
    {
        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            
            switch (locationTypeString)
            {
                case "mine":
                    return new Mine(locationName);
           
                case "forest":
                    return new Forest(locationName);
                
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            

        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {

            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    return person;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherItem(actor, commandWords[2]);
                    return;
                    
                case "craft":
                    this.HandleCraftItem(actor, commandWords[2], commandWords[3]);
                    return;

                default:
                    base.HandlePersonCommand(commandWords, actor);
                    return;
            }

        }

        private void HandleCraftItem(Person actor, string type, string itemName)
        {
            foreach (var item in actor.ListInventory())
            {

                if (type == "armor")
                if (item.ItemType.Equals(ItemType.Iron))
                {
                    var itemm = new Armor(itemName);
                    actor.AddToInventory(itemm);
                    ownerByItem[itemm] = actor;
                    break;
                }

                if (type == "weapon")
                if (item.ItemType.Equals(ItemType.Wood))
                {
                    var itemm = new Weapon(itemName);
                    actor.AddToInventory(itemm);
                    ownerByItem[itemm] = actor;
                    break;
                }
            }
        }

        private void HandleGatherItem(Person actor, string itemName)
        {
            var actLocation = actor.Location as IGatheringLocation;
            if (actLocation!=null)
            foreach (var item in actor.ListInventory())
            {
                if (item.ItemType == actLocation.RequiredItem)
                {
                    var itemm = actLocation.ProduceItem(itemName);
                        actor.AddToInventory(itemm);
                        ownerByItem[itemm] = actor;
                       
                    }
            }
        }

      
    }
}
