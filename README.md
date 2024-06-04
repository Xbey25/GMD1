# GMD-1-Projects
### By yours truly, Xbey25 and Bianca Badeu

## Purpose

This repository hold the main project related to the game development course at VIA University College.

It will hold both the source code for these projects and a development blog which should be updated weekly.


## Development Blog

### Roll-a-ball (12/02/2024)

This project was the first one of the course, we were tasked with creating the roll-a-ball exercise from the Unity learning platform.
Since this tutorial is made for complete beginners it is assumed that the only thing you have at your disposal is Unity installed. I have worked with Unity before in a casual way, mostly creating 3D assets or assembling prefabs to make structures in a Sims kind of way. Therefore, it was good to go back to the programming perspective.

Playing around with the editor to get the feeling again was a nice experience, I started by following the tutorial, creating the plane, the 3D shapes (our playable character) and setting the basic scene.

Then started the interesting part, getting the player to move, as Unity uses C# the code itself was not the issue, but more of understanding how the game engine processes it, we just needed to be able to get the input on x and y axis for now, so that we can move the ball around. Furthermore, I implemented the camera mechanics by making it follow the player and improving the perspective.

After additional tweaking to the scene, such as adding walls and increasing the playable area. I proceeded to create the so-called “collectables”, which consist of 3D cubes that are rotating through a script that keeps them in constant movement every frame. The idea of these collectables is to make them easy to place and replicate, so I made them prefabs and set them around the scene.

Now to the interesting part, making the player “pick up” the collectables, since it's a straightforward game we have to pretend that we are picking them up, the way to set this up was by modifying the player controller script to handle what will happen if the current player touches an object with a specific tag. Otherwise, every object that touches the player would disappear!

After adding tags it was time to make the small UI for the game, by creating text meshes, we could display some basic text such as a current score that had a number variable which would update based on the amount of times the OnTrigger action would be called in the player script. The good thing about unity is that moving text around the screen is easy although difficult without a mouse in the sense of mobility.

Finally, I added the victory text once all 6 cubes were picked up and built my game by using the build feature on Unity.

The interesting part/takeaway was the fact that all objects are there at all times, we just make them disappear when we don't need them but that is only a visual change, the cube is still there, it's just invisible, and so is the winning screen.

Labyrinth's extension:

In addition to the tutorial, I decided to expand on the playability aspect of it. The first thing that I decided to do was implement a labyrinth that the ball would have to navigate in order to collect to the pick-ups. The labyrinth would become progressively harder to get through as we try to collect all of them.

To make it more immersive I played a bit with the camera view so that it's zoomed in more on the ball and the field of view doesn't reveal a lot of the labyrinth, keeping us guessing. As I was testing it, I imagined being a player that would open this game and it would be too easy and frankly, boring. So to add a bit of a challenge, I thought of adding a losing condition: when the ball would collide with the labyrinth's walls, the ball would stop and the wall that was hit would turn red, the collision leading to an instadeath. It was a bit tricky to figure it out before the physics lesson but it became a lot more fun, increased the playtime, and helped me win a lot of bets with my friends who were convinced could get through it on their first run: spoiler alert, they didn't.

Overall, we are excited for the next lesson and getting some more experience in the programming side of Unity.



### Game Design document
---


## Milestones

Initially, we did not establish any milestones for the project, but we have decided to set some in order to keep track of the project and to have a clear goal in mind and to give some structure to the project.

These are the milestones that we have set for the project:



`
[x] Roll-a-ball `
[x] Game design document
[] Development Blogs
[x] V1.0C (Basic Functionality)
[x] V1.0B (Playable Labyrinth Version)
[] V1.0A (Playable Arcade Version)
[] V1.0 (Final Version)

## Development Blog 1

This is the first development update of the dead cells project. 

For starters, the initial stages of the project are complete, they involved creating a solid foundation for the project to be able to receive updates, track tasks and issues, as well as establishing realistic goals.

Firstly, the project was initialized using Unity Cloud Control in order to maintain versioning and roll back in case of any unforseen issues. However, it was determined that this option would require us to start a Unity organization which involved more work than just using git. Therefore, we settled on using GitHub Desktop to keep track of the project files as well as using it for commits and branches as it is quite user-friendly and very easy to set up in a new machine.

Once the project was initialized, one of the first tasks was to ideate prefabs that would come in hand very early, one of them being the player. Hence, we created a player prefab by creating movement and camera scripts on which we also used a state machine pattern (movement script) to demonstrate the different kinds of movement the player could make. Furthermore, we also created the structure of the maze which consists of several empty object groups which contain the ground, the ceilling, the inside walls, and the outside walls. 

To create the maze structure we settled on using an image of an actual maze and building on top of it to have some sort of perspective on the actual structure. This resulted in several hallways which provide that feeling of being trapped in a real maze, which was of couse what we were aiming for. 

Another important task during these early stages was to create a start menu. The background image for this menu was created through AI but resulted in a very weird image. Therefore, it was modified in Adobe in order to match the theme and vibe of the game. 

The image was of course a small part of the menu development, the interesting part of it was how Unity handles it. The menu is a scene like a playable one but in which there is no player but clickable buttons and text. Once you click the start button, it selects the maze scene we created earlier and you start playing with the prefab player.

## Development Blog 2 V1.0B

This is the second development update of the dead cells project.

The main focus of this development blog 2 is to showcase the technical aspects of the project and their approaches.

One of the main technical aspects of the project is the Enemy. There is not a lot of suspense if there is no enemy to chase you around the maze. Therefore, we created an enemy prefab which is a simple capsule that moves around the maze. The enemy prefab was set up with a script that contains several behaviour traits, idle, chase, and attack. The enemy will start in idle mode and will only chase the player if it sees the player. Once the enemy catches up to the player, it will attack the player and the player will die. Initially we created several scripts for the enemy, but we decided to merge them into one script to make it easier to manage.

Apart from the enemy, great emphasis was placed on the door mechanic. The door is a prefab object that requires a specific key to open. The key is another prefab object that is placed in the maze. The player must collect the key in order to open the door and proceed to the next section of the maze. The door is set up with a script that checks if the player has the key and if the player is in the trigger zone of the door. If both conditions are met, the door will open and the player can proceed to the next level. It contains door opening and closing animations as well as a sound effect to make the experience more immersive. 

For additional UI elements, the menu screen was finished with some settings for brightness to make the gamer more inmersive. 

On a smaller detail scale, there is the UI scripts which are currently not doing a lot, and there is an additional type of door in development which contains a keypad.

In the final stages of this version we added the enemy model as well as some animations by using external assets but creating our own animation controller. 

## Development Blog 2/1 V1.0Bb

On a smaller note, the input system proved a bit tricky to implement as it was not as straightforward as we thought. 

The keypad door was a bit tricky to implement therefore we settled on using an external script and adapting it to our needs. The player has to input a code in order to open the door, the code is x. The code is checked by a script that checks if the player has input the correct code. If the player inputs the correct code, the door will trigger an event for the door opening animation and can proceed further, here we thought of notes that could be found in the maze that would give the player the code.

## Development Blog 3 V1.0A

This is the third development update of the dead cells project.

During the development of this version, we struggle a lot with the inputs and the arcade machine. We had to create a new input system and set up the player movement script to work with it. The new input system allows the game to work on the arcade machine as well as on a regular computer.

One of the main concerns was how to set up the menu inputs to work with the arcade machine. We had to adapt the previous menu script to work with the new input system. The new input system allows the player to navigate the menu using the joystick and the buttons on the arcade machine.

Additionally, this created a new challenge for the player movement script. We had to adapt the player movement script to work with the new input system. Initially, the player was thought of as having 2 joysticks, one for movement and one for camera rotation. However, we had to adapt the script to work with only one joystick, as both of the arcade machine joysticks are connected to the same input. The workaround was to use it only for movement, reducing the movement options to forward and backward, and using the x and b buttons for camera rotation. This created a complex movement system with an unintended tweak in difficulty.

We also have started working on additional traps. The idea is for spike traps to be placed around the maze. The spike traps will be triggered by the player stepping on a cube with a trigger. Furthermore.

Since we are working a lot with possible death and victory conditions, we have started working on a game over screen. The game over screen will be triggered when the player dies, the screen for now contains the option to go to the main menu or quit.

During the development of this version, a lot of time was wasted thinking of creative ways to get around the input system, such as an overlay for the keypad that would trigger whenever the player would interact with it and would disable the player controls and have a virtual keyboard for the player to input the code. However, we decided to go with the simpler solution of having the player input the code using the joystick and the buttons on the arcade machine.


Finally, we rearranged the maze to have a sense of progression, the maze now contains several color-coded doors and the final door is the keypad door.


# External Assets Used:

Dungeon - Low Poly Toon Battle Arena / Tower Defense Pack by AurynSky / available on Unity Asset Store https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-low-poly-toon-battle-arena-tower-defense-pack-109791

Dungeon Monster - Wolfboss by HatoGames / available on Unity Asset Store https://assetstore.unity.com/packages/3d/characters/creatures/01-monster-wolf-boss-189463
