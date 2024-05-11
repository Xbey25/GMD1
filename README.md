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

For references, see

### Game Design document
---


## Milestones

`
[x] Roll-a-ball `
[x] Game design document
[] Development Blogs
[] V1.0 (Playable Arcade Version)

## Development Blog 1

This is the first development update of the dead cells project. 

For starters, the initial stages of the project are complete, they involved creating a solid foundation for the project to be able to receive updates, track tasks and issues, as well as establishing realistic goals.

Firstly, the project was initialized using Unity Cloud Control in order to maintain versioning and roll back in case of any unforseen issues. However, it was determined that this option would require us to start a Unity organization which involved more work than just using git. Therefore, we settled on using GitHub Desktop to keep track of the project files as well as using it for commits and branches as it is quite user-friendly and very easy to set up in a new machine.

Once the project was initialized, one of the first tasks was to ideate prefabs that would come in hand very early, one of them being the player. Hence, we created a player prefab by creating movement and camera scripts on which we also used a state machine pattern (movement script) to demonstrate the different kinds of movement the player could make. Furthermore, we also created the structure of the maze which consists of several empty object groups which contain the ground, the ceilling, the inside walls, and the outside walls. 

To create the maze structure we settled on using an image of an actual maze and building on top of it to have some sort of perspective on the actual structure. This resulted in several hallways which provide that feeling of being trapped in a real maze, which was of couse what we were aiming for. 

Another important task during these early stages was to create a start menu. The background image for this menu was created through AI but resulted in a very weird image. Therefore, it was modified in Adobe in order to match the theme and vibe of the game. 

The image was of course a small part of the menu development, the interesting part of it was how Unity handles it. The menu is a scene like a playable one but in which there is no player but clickable buttons and text. Once you click the start button, it selects the maze scene we created earlier and you start playing with the prefab player.

## Development Blog 2


