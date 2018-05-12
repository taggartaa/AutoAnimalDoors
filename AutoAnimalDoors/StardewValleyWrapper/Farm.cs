using System.Collections.Generic;
using System.Linq;

namespace AutoAnimalDoors.StardewValleyWrapper
{
    class Farm
    {
        private StardewValley.Farm farm;

        public Farm(StardewValley.Farm farm)
        {
            this.farm = farm;
        }

        public List<Buildings.Building> Buildings
        {
            get
            {
                List<Buildings.Building> buildings = new List<Buildings.Building>();

                if (farm != null)
                {
                    foreach (StardewValley.Buildings.Building stardewBuilding in farm.buildings)
                    {
                        if (stardewBuilding is StardewValley.Buildings.Barn || stardewBuilding is StardewValley.Buildings.Coop)
                        {
                            buildings.Add(new Buildings.AnimalBuilding(stardewBuilding));
                        }
                        else
                        {
                            buildings.Add(new Buildings.Building(stardewBuilding));
                        }
                    }
                }

                return buildings;
            }
        }

        public List<Buildings.AnimalBuilding> AnimalBuildings
        {
            get
            {
                List<Buildings.AnimalBuilding> animalBuildings = new List<Buildings.AnimalBuilding>();
                foreach (Buildings.Building building in Buildings)
                {
                    Buildings.AnimalBuilding animalBuilding = building as Buildings.AnimalBuilding;
                    if (animalBuilding != null)
                    {
                        animalBuildings.Add(animalBuilding);
                    }
                }

                return animalBuildings;
            }
        }

        public bool AreAllAnimalsHome()
        {
            foreach (StardewValley.FarmAnimal farmAnimal in farm.animals.Values)
            {
                if (farmAnimal.home != null)
                {
                    return false;
                }
            }

            return true;
        }

        public void SendAllAnimalsHome()
        {
            SetAnimalDoorsState(StardewValleyWrapper.Buildings.AnimalDoorState.CLOSED);
            var farmAnimals = farm.animals;
            for (int i = farmAnimals.Count - 1; i >= 0; i--) 
            {
                StardewValley.FarmAnimal farmAnimal = farm.animals.ElementAt(i).Value;
                farmAnimal.warpHome(farm, farmAnimal);
            }
        }

        public void SetAnimalDoorsState(Buildings.AnimalDoorState state)
        {
            foreach (Buildings.AnimalBuilding animalBuilding in this.AnimalBuildings)
            {
                animalBuilding.AnimalDoorState = state;
            }
        }
    }
}
