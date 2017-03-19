# AutoAnimalDoors
This is a mod created for StardewValley which will automate the animal door opening/closing process for all your barns and coop.

## Features
### Opening animal doors automatically
Your animal doors will open automatically at the time you specified in the config file no matter where your character is in the game world (you will hear the door opening sound). 

If that time never occurs during the day (for instance, you specified 730 (meaning 7:30 am) but you woke up after that time because you passed out in the mines) the doors will still open unless it is past your specified doors close time.

Doors will not open in the Winter or on Rainy/Thunder Stormy days.

You could disable the animal doors opening automatically by setting the time to anything larger than your animal door close time.

### Closing animal doors automatically
Your animal doors will close automatically at the time you specified in the config file if all your animals are inside. If they are not yet inside, the doors will wait for all the animals to enter their homes before closing any doors. 

If you go to bed before your animal door close time, your animal doors will be closed, and all your animals will be warped back to their homes to keep them safe from attacks ;)

Note: The current implementation closes the animal doors and warps the animals back as soon as you get into bed (even if you select "No" from the "Go to sleep now?" dialog). It is difficult (impossible?) to warp your animals back to safty on time once "Yes" is pressed.

## Config File

The config file is where all the options for this mod can be set. It will be automatically created the first time the game is launched with this mod installed.

You can find it in the mods install directory.

### Values

**AnimalDoorOpenTime**  - The time animal doors are scheduled to open. (730 = 7:30 am, 1310 = 1:10 pm)
**AnimalDoorCloseTime** - The time animal doors are scheduled to close. (730 = 7:30 am, 1310 = 1:10 pm)

### Example config.json

```json
{
  "AnimalDoorOpenTime": 730,
  "AnimalDoorCloseTime": 1800
}
```

## Building the Code
I use a system enviroment variable named STARDEWVALLEY_HOME to install the mod every time the code is built. You'll need to define that before building to point to the installation directory of StardewValley.

This mod ustilizes the SMAPI API. So if you get any issues regarding not being able to resolve StardewModdingAPI.Whatever you likely need to do some of the setup described here: http://canimod.com/for-devs/creating-a-smapi-mod
