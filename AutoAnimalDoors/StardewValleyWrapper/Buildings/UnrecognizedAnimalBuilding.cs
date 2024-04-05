using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAnimalDoors.StardewValleyWrapper.Buildings
{
    public class UnrecognizedAnimalBuilding : AnimalBuilding
    {
        public UnrecognizedAnimalBuilding(StardewValley.Buildings.Building building, Farm farm) : base(building, farm)
        {
        }

        public override AnimalBuildingType Type => AnimalBuildingType.OTHER;

        public override int UpgradeLevel => 1;

        //protected override void AnimateDoorStateChange()
        //{

        //}
    }
}
