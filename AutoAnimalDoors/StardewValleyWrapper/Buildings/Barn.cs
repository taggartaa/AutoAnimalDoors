namespace AutoAnimalDoors.StardewValleyWrapper.Buildings
{
    public class Barn : AnimalBuilding
    {

        public Barn(StardewValley.Buildings.Building barn, Farm farm) :
            base(barn, farm)
        {
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
                    default:
                        return 4;
                }
            }
        }
    }
}
