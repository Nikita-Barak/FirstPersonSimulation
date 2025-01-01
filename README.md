# First Person Simulation
 
The following project is a first person simulation, made as an exercise in our Game Development course via university.
In this simulation, we cover basic first person controls: walking, camera control, running and jumping.
We also created a small environment to demonstrate further features.

[Itch.io link](https://nikitabarak.itch.io/first-person-simulator)

## Game Controls

- **Movement** - WASD
- **Camera Control** - Mouse
- **Run** - Hold Shift
- **Jump** - Spacebar
- **Interact / Grab** - E
- **Throw Grabbed Object** - L-Mouse

## Added Features

### First Feature - First Person Character Controls

In addition to the features made in the lecture, we also added running and jumping to our players' movement, all of which are managed via the following scripts:

- The [Input Manager](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Movement/InputManager.cs) - controlling the players' inputs using the other movement scripts and the [inputSystem file](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Input/InputSystem_Actions.cs), created via the editor.
- The [Player Mover](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Movement/PlayerMover.cs) - contributing handle functions for the input manager to use, and manges the different states in which the players could be.
- The [Player Looker](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Movement/PlayerLook.cs) - handling the player's camera control via the mouse.

### Second Feature - Gravity "Gun"

Not really a gun, more of a "superpower" the player possesses to lift up boxes via the game world and being able to shooting it away - giving him telekinetic powers.
This was done by having the player raycast in the camera's direction, and interacting with the box (in the grabbable layer) to lift it up to follow an empty object in front of the player (if close enough).

Corresponding script could be found [here](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Gravity%20Gun/GravityController.cs).

### Third Feature - Interactions

Aside from the gravity gun, 2 more interactions were made for the game, controlled via the scripts in the [Interactions scripts folder](https://github.com/Nikita-Barak/FirstPersonSimulation/tree/main/Assets/Scripts/Interactions).
This was done by creating an [interface Interactable script](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Interactions/Interactable.cs) and 2 child components - the Button and the BananaMan.

- [Button](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Interactions/Button.cs) - interaction leads to opening a door.
- [BananaMan](https://github.com/Nikita-Barak/FirstPersonSimulation/blob/main/Assets/Scripts/Interactions/BananaMan.cs) - A t-posed character from Unity's asset store saying hello upon interaction.

The interactions are handled via the PlayerInteract script, also projecting a raycast and handling only interactable objects if hit (similarily to the gravity gun, but over a different object layer called "Interactable").
