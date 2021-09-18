# Unity 2.5D-RPG-Project
This is a Unity Based 2.5d RPG project I dump some hours into every few months or so. Currently the project is composed of 3 scenes.
1. The Title Screen where players can pick a save slot.
2. Character creation Screen, where players can use customization tools to create a character. Visual only right now, the game doesnt have a stats system as of yet
3. The World. I had an old system. ngl, It was bad. Currently I'm writing the new system which is way better. The mesh that composes the world updates and changes dynamically depending on its position, which will be determined relative to the player position. I plan on reintroducing the curved world shader I had before so the player will never actually see the ends of the mesh and thanks to that I'll never have to worry about draw distance. Currently writing out the dynamic texturing system, which works by reassigning the uv mapping coordinates of the overworld mesh on the fly as the mesh changes. The idea behind this is that I can just place the spritesheet containing all the overworld terrain tiles as the designated texture of the overworld, then just map the same bit of that texture to whatever spots of the map need that specific tile. Remapping the uvs should theoretically work way faster than messing around with manually assigning pixels and trying to dynamically create custom textures, which is something I was dumb enough to try the last time I had restarted this game.


Development Trello: https://trello.com/b/j3bCKSAN/25d-rpg



![Lpic2](https://user-images.githubusercontent.com/80863542/125507269-a8fcc5b9-0d6a-4586-82f3-25003c6b13a4.png)
![elpic1](https://user-images.githubusercontent.com/80863542/125507274-fe3ba72f-9962-46e9-bb2d-761d9a67f3f0.png)

