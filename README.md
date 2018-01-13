Rouge1
==============================
This project was created to become a 2D Roguelike videogame 
The project does not contain any levels but a lot of the functionality is complete
All of the code is written in C# and was created in Unity/Visual Studio

Functionality Highlights
==============================
Scripts were writted for maximum reusability.
examples: the Spawn_enemies Script is able to spawn any type of prefab enemy and simply needs to be placed on the spawner
The FiringPattern and AltFiringPattern scripts can be placed on Any weapon. This enables each gun to have two completely different firing patterns.
Bullets care also modular and each weapon can have different projectiles by simply changing what prefab is spawned by the bullet script
The player has a Roll ability (space) which increases player velocity and shrinks the hitbox.
Enemies will randomly drop loot.
Currently they can drop Stimpacks (to heal the player) and weapon Crates (grant a random weapon)
Some enemies have death animations
All Enemies have movement and attack animations and will turn to face the player and move toward him
The Player has animations to walk in every direction, he will always turn to face the mouse and will shoot torward the mouse pointer.
Healthbar is fully functional (loose health when hit, Gain health when healed(via Stimpack)
2/3 enemies have death animations and will leave a corpse on the battlefield.
Camera will also follow the player

All Art is from https://opengameart.org/ Additional Credits to artists can be found in the credits.txt file

Feel free to use or modify any of my code for your own projects.
Let me know if you have any questions at ZachariBarnes@yahoo.com
Enjoy