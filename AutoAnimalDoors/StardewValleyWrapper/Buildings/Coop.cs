namespace AutoAnimalDoors.StardewValleyWrapper.Buildings
{
    public class Coop : AnimalBuilding
    {
        public Coop(StardewValley.Buildings.Building coop, Farm farm) :
            base(coop, farm)
        {
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
    }
}
