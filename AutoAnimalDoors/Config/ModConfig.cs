

using AutoAnimalDoors.Config;

namespace AutoAnimalDoors.StardewValleyWrapper
{
    public class ModConfig
    {
        public static ModConfig Instance { get; set; }

        public int AnimalDoorOpenTime { get; set; } = 730;
        public int AnimalDoorCloseTime { get; set; } = 1800;
        public int CoopRequiredUpgradeLevel { get; set; } = 1;
        public int BarnRequiredUpgradeLevel { get; set; } = 1;
        public bool UnrecognizedAnimalBuildingsEnabled { get; set; } = false;
        public bool AutoOpenEnabled { get; set; } = true;
        public bool OpenDoorsWhenRaining { get; set; } = false;
        public bool OpenDoorsDuringWinter { get; set; } = false;
        public bool CloseAllBuildingsAtOnce { get; set; } = true;
        public bool DoorEventPopupEnabled { get; set; } = false;
        public DoorSoundSetting DoorSoundSetting { get; set; } = DoorSoundSetting.ONLY_ON_FARM;
    }
}
