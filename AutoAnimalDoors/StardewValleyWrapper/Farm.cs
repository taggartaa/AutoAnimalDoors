﻿using StardewModdingAPI;
using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace AutoAnimalDoors.StardewValleyWrapper
{
    public class Farm
    {
        public StardewValley.Farm StardewValleyFarm { get; private set; }

        public Farm(StardewValley.Farm farm)
        {
            this.StardewValleyFarm = farm;
        }

        public List<Buildings.Building> Buildings
        {
            get
            {
                List<Buildings.Building> buildings = new();

                if (this.StardewValleyFarm != null)
                {
                    foreach (StardewValley.Buildings.Building stardewBuilding in this.StardewValleyFarm.buildings)
                    {
                        if (stardewBuilding.buildingType.Value.EndsWith("Barn"))
                        {
                            buildings.Add(new Buildings.Barn(stardewBuilding, this));
                        }
                        else if (stardewBuilding.buildingType.Value.EndsWith("Coop"))
                        {
                            buildings.Add(new Buildings.Coop(stardewBuilding, this));
                        }
                        else if (ModConfig.Instance.UnrecognizedAnimalBuildingsEnabled &&
                            stardewBuilding.animalDoor?.X >= 0 && stardewBuilding.animalDoor?.Y >= 0 &&
                            stardewBuilding.indoors.Get() is StardewValley.AnimalHouse)
                        {
                            buildings.Add(new Buildings.UnrecognizedAnimalBuilding(stardewBuilding, this));
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
                List<Buildings.AnimalBuilding> animalBuildings = new();
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
            foreach (Buildings.AnimalBuilding building in this.AnimalBuildings)
            {
                if (!building.AreAllAnimalsHome())
                {
                    return false;
                }
            }

            return true;
        }

        public void SendAllAnimalsHome()
        {
            foreach (Buildings.AnimalBuilding building in this.AnimalBuildings)
            {
                building.SendAllAnimalsHome();
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
