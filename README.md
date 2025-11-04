# [Desire Paths (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3555461401)

![Image](https://i.postimg.cc/1X4HT06h/Info.png)

Update of Fluffys mod https://steamcommunity.com/sharedfiles/filedetails/?id=2072410063
Based on the 1.5 version by Cybranian https://steamcommunity.com/sharedfiles/filedetails/?id=3263698071

- Added setting to control how much impact animals has on path generation
- Added setting to ignore wet terrain
- Removed the unsafe code
- To control where pawns walk, please use [Pathfinding Avoidance](https://steamcommunity.com/sharedfiles/filedetails/?id=3530140490) by llunak

![Image](https://i.postimg.cc/8csH3dWV/Notice.png)
	
![Image](https://i.postimg.cc/hvhrw8xB/Original-Description.png)

Creates packed dirt paths when colonists frequently take the same path.

## Features


Packed dirt has a higher move speed than most other 'natural' terrains, but it does track a lot of dirt around and has no fertility. If your colonists frequently walk through your farms, they will eventually trample the fields.

Packed dirt paths will form when colonists frequently take the same path over grass, soil, dirt and other natural terrain. The packed dirt paths will eventually degrade back into the original terrain if not walked on. In the real world, such paths are called [desire paths](https://en.wikipedia.org/wiki/Desire_path), Elephant paths, pirate paths, or just simply shortcuts.

![Image](https://i.ibb.co/gF6Sw3t/image.png)

## Recommended


If you find that your colonists keep walking through your fields, I recommend using this together with
[Path Avoid](https://steamcommunity.com/sharedfiles/filedetails/?id=1180719857), so that you can better steer where your colonists may and may not walk.

For problematic trade caravans, you may want to use [KV's Trading Spot](https://steamcommunity.com/sharedfiles/filedetails/?id=1180719658).

That said, if such desire paths form where you don't want them, it's really a sign that you need to change your base design!

## Known Issues


None

## For Modders


By default, any terrain that has the XML tag TakeFootprints' set to true will be 'packable', and given enough traffic, packed dirt paths will appear. As of version 0.7.97, the mod reads a DefModExtension on terrain defs. This extension has two fields, 'disabled' and 'packedTerrain'. These allow you to disable desire paths' behaviour for a specific terrain, or specify which terrain def should be used for the created path.

This extension can either be added directly on modded terrainDefs, or be injected with a patch. Desire Paths itself uses such a patch to disable its' behaviour for Ice terrain, so that might be a good place to start.

## Think you found a bug?


Please read [this guide](http://steamcommunity.com/sharedfiles/filedetails/?id=725234314) before creating a bug report

## Older versions


All current and past versions of this mod can be downloaded from [GitHub](https://github.com/fluffy-mods/DesirePaths/releases).

## License


All original code in this mod is licensed under the [MIT license](https://opensource.org/licenses/MIT). Do what you want, but give me credit.
All original content (e.g. text, imagery, sounds) in this mod is licensed under the [CC-BY-SA 4.0 license](http://creativecommons.org/licenses/by-sa/4.0/).

Parts of the code in this mod, and some of the content may be licensed by their original authors. If this is the case, the original author &amp;amp; license will either be given in the source code, or be in a LICENSE file next to the content. Please do not decompile my mods, but use the original source code available on [GitHub](https://github.com/fluffy-mods/DesirePaths/), so license information in the source code is preserved.

Parts of this mod were created by, or derived from works created by;


- surang: road preview icon ([BY-NC](https://www.flaticon.com/authors/surang))- Smashicons: path preview icon ([BY-NC](https://www.flaticon.com/authors/smashicons))- Freepik: landscape preview icon ([BY-NC](https://www.freepik.com/))


![Image](https://i.postimg.cc/x8qR7GH9/Reporting-Issues.png)



-  See if the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Always post your log using the [Log Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404)
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/DesirePaths?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3555461401) | tags:  colonists,  traffic
