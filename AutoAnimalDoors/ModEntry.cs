﻿using AutoAnimalDoors.StardewValleyWrapper;
using System.Collections.Generic;
using Buildings = AutoAnimalDoors.StardewValleyWrapper.Buildings;

namespace AutoAnimalDoors
{
    class ModEntry : StardewModdingAPI.Mod
    {
        private ModConfig config;

        public override void Entry(StardewModdingAPI.IModHelper helper)
        {
            config = helper.ReadConfig<ModConfig>();
            StardewModdingAPI.Events.TimeEvents.AfterDayStarted += SetupAutoDoorCallbacks;
        }

        private bool IsGoToSleepDialog(StardewValley.Menus.IClickableMenu menu)
        {
            StardewValley.Menus.DialogueBox dialogBox = menu as StardewValley.Menus.DialogueBox;
            if (dialogBox != null)
            {
                List<string> dialogs = this.Helper.Reflection.GetField<List<string>>(dialogBox, "dialogues").GetValue();
                if (dialogs != null && dialogs.Count >= 1)
                {
                    return dialogs[0].Equals(StardewValley.Game1.content.LoadString("Strings\\Locations:FarmHouse_Bed_GoToSleep"));
                }
            }

            return false;
        }

        private void OnMenuChanged(object sender, StardewModdingAPI.Events.EventArgsClickableMenuChanged menuChangedEventArgs)
        {
            if (IsGoToSleepDialog(menuChangedEventArgs.NewMenu))
            {
                SetAnimalDoorsState(Buildings.AnimalDoorState.CLOSED);
                Game.Instance.Farm.SendAllAnimalsHome();
            }
        }

        private void SetupAutoDoorCallbacks(object sender, System.EventArgs eventArgs)
        {
            Game game = Game.Instance;
            if (game.IsLoaded())
            {
                // Remove the subscriptions before adding them, this ensures we are only ever subscribed once
                StardewModdingAPI.Events.MenuEvents.MenuChanged -= this.OnMenuChanged;
                StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged -= this.OpenAnimalDoors;
                StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged -= this.CloseAnimalDoors;

                if (game.Season != Season.WINTER && (game.Weather == Weather.SUNNY || game.Weather == Weather.WINDY))
                {
                    StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged += this.OpenAnimalDoors;
                    StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged += this.CloseAnimalDoors;
                    StardewModdingAPI.Events.MenuEvents.MenuChanged += this.OnMenuChanged;
                }
            }
        }

        private void SetAnimalDoorsState(Buildings.AnimalDoorState state)
        {
            Farm farm = Game.Instance.Farm;
            foreach (Buildings.AnimalBuilding animalBuilding in farm.AnimalBuildings)
            {
                animalBuilding.AnimalDoorState = state;
            }
        }

        private void CloseAnimalDoors(object sender, StardewModdingAPI.Events.EventArgsIntChanged timeOfDayChanged)
        {
            if (timeOfDayChanged.NewInt >= config.AnimalDoorCloseTime)
            {
                Farm farm = Game.Instance.Farm;
                if (farm.AreAllAnimalsHome())
                {
                    StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged -= this.CloseAnimalDoors;
                    SetAnimalDoorsState(Buildings.AnimalDoorState.CLOSED);
                }
            }
        }

        private void OpenAnimalDoors(object sender, StardewModdingAPI.Events.EventArgsIntChanged timeOfDayChanged)
        {
            if (timeOfDayChanged.NewInt >= config.AnimalDoorOpenTime && timeOfDayChanged.NewInt < config.AnimalDoorCloseTime)
            {
                StardewModdingAPI.Events.TimeEvents.TimeOfDayChanged -= this.OpenAnimalDoors;
                SetAnimalDoorsState(Buildings.AnimalDoorState.OPEN);
            }
        }
    }
}