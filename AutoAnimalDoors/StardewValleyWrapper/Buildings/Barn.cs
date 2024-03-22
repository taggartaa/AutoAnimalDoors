using AutoAnimalDoors.Config;
using Netcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnimalDoors.StardewValleyWrapper.Buildings
{
    public class Barn : AnimalBuilding
    {
        private StardewValley.Buildings.Building StardewBarn { get; set; }

        public Barn(StardewValley.Buildings.Building barn, Farm farm) :
            base(barn, farm)
        {
            StardewBarn = barn;
        }

        public override AnimalBuildingType Type => AnimalBuildingType.BARN;

        public override int UpgradeLevel
        {
            get
            {
                switch (this.building.buildingType.Value.ToLower())
                {
                    case "barn":
                        return 1;
                    case "big barn":
                        return 2;
                    case "deluxe barn":
                        return 3;
                }

                return 4;
            }
        }

        //protected override void AnimateDoorStateChange()
        //{
        //    try
        //    {
        //        // Need to use reflection to animate the door changing state because it is private
        //        var prop = StardewBarn.GetType().GetField("animalDoorMotion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //        NetInt animalDoorMotion = prop.GetValue(StardewBarn) as NetInt;
        //        animalDoorMotion.Value = StardewBarn.animalDoorOpen.Value ? (-3) : 2;
        //    }
        //    catch (Exception)
        //    {
        //        Logger.Instance.Log("Motion nicht möglich");
        //    }
        //}
    }
}
