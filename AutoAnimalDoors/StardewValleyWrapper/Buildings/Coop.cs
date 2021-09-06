using AutoAnimalDoors.Config;
using Netcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnimalDoors.StardewValleyWrapper.Buildings
{
    class Coop : AnimalBuilding
    {
        private StardewValley.Buildings.Coop StardewCoop { get; set; }

        public Coop(StardewValley.Buildings.Coop coop, Farm farm) :
            base(coop, farm)
        {
            StardewCoop = coop;
        }

        public override AnimalBuildingType Type => AnimalBuildingType.COOP;

        public override int UpgradeLevel
        {
            get
            {
                switch (building.buildingType.Value.ToLower())
                {
                    case "coop":
                        return 1;
                    case "big coop":
                        return 2;
                    case "deluxe coop":
                        return 3;
                }

                return 4;
            }
        }

        protected override void AnimateDoorStateChange()
        {
            // Need to use reflection to animate the door changing state because it is private
            var prop = StardewCoop.GetType().GetField("animalDoorMotion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            NetInt animalDoorMotion = prop.GetValue(StardewCoop) as NetInt;
            animalDoorMotion.Value = StardewCoop.animalDoorOpen.Value ? (-2) : 2;
        }
    }
}
