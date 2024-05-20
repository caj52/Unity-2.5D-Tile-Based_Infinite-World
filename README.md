# Unity 2.5D-Tile-Based_Infinite World
A 2.5d infinite open world rpg prototype.
If you want to use this project to create your own or want to remix it, conside the following =>

- The mosty valuable thing in this repo is the world generation code itself.
- 
- It handles texturing very quickly. When I was trying to find a suitable approach for a tile-based world that used sprites similar to older 2d rpgs, there werent a lot of solutions I could find at the time. 
The world texture all derives from one overworld spritesheet. Instead of manipulating the worlds texture, it instead manipulates the uvs of the overworld mesh in order to render the desired texture at that position. This is extremely fast however requires a sacrifice in terms of vertex count. The vertex amount is nearly twice as much as they would be for the overworld mesh.

- It does not use a chunk-based approach. Instead I opted to have the landscape mesh move with the player and dynamically reconfigure its own vertices in order to match the landscape at the part. Almost like the mesh is a portal that reveals what the landscape thats there. This is also incredibly fast since changing an existing meshes vertex locations is so incredibly cheap. If you wanted to retrofit these tools to support even larger landscapes, the inclusion of some multithreading would really bring it to the next level.

Its decently documented in the codebase and has a handful of enums setup for easy implementaiton of biomes and object types going forward.
The object spawning and the way biomes are being determined could use a little love but their basic implementation is functional.

![Lpic2](https://user-images.githubusercontent.com/80863542/125507269-a8fcc5b9-0d6a-4586-82f3-25003c6b13a4.png)
![elpic1](https://user-images.githubusercontent.com/80863542/125507274-fe3ba72f-9962-46e9-bb2d-761d9a67f3f0.png)

![GameHud](https://user-images.githubusercontent.com/80863542/143786550-50a429e5-5e1f-4834-b2d1-caeb547a60db.png)
