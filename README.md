# [Desire Paths (Continued)]()

![Image](https://i.imgur.com/buuPQel.png)

Update of Fluffys mod https://steamcommunity.com/sharedfiles/filedetails/?id=2072410063
Based on the 1.5 version by Cybranian https://steamcommunity.com/sharedfiles/filedetails/?id=3263698071

- Added setting to control how much impact animals has on path generation
- Added setting to ignore wet terrain
- Removed the unsafe code

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

Creates packed dirt paths when colonists frequently take the same path.

![Image](https://headers.karel-kroeze.nl/title/Features.png)

Packed dirt has a higher move speed than most other 'natural' terrains, but it does track a lot of dirt around and has no fertility. If your colonists frequently walk through your farms, they will eventually trample the fields.

Packed dirt paths will form when colonists frequently take the same path over grass, soil, dirt and other natural terrain. The packed dirt paths will eventually degrade back into the original terrain if not walked on. In the real world, such paths are called [desire paths](https://en.wikipedia.org/wiki/Desire_path), Elephant paths, pirate paths, or just simply shortcuts.

![Image](https://i.ibb.co/gF6Sw3t/image.png)

![Image](https://headers.karel-kroeze.nl/title/Recommended.png)

If you find that your colonists keep walking through your fields, I recommend using this together with
[Path Avoid](https://steamcommunity.com/sharedfiles/filedetails/?id=1180719857), so that you can better steer where your colonists may and may not walk.

For problematic trade caravans, you may want to use [KV's Trading Spot](https://steamcommunity.com/sharedfiles/filedetails/?id=1180719658).

That said, if such desire paths form where you don't want them, it's really a sign that you need to change your base design!

![Image](https://headers.karel-kroeze.nl/title/Known%20Issues.png)

None

![Image](https://headers.karel-kroeze.nl/title/For%20Modders.png)

By default, any terrain that has the XML tag TakeFootprints' set to true will be 'packable', and given enough traffic, packed dirt paths will appear. As of version 0.7.97, the mod reads a DefModExtension on terrain defs. This extension has two fields, 'disabled' and 'packedTerrain'. These allow you to disable desire paths' behaviour for a specific terrain, or specify which terrain def should be used for the created path.

This extension can either be added directly on modded terrainDefs, or be injected with a patch. Desire Paths itself uses such a patch to disable its' behaviour for Ice terrain, so that might be a good place to start.

![Image](https://headers.karel-kroeze.nl/title/Think%20you%20found%20a%20bug%3F.png)

Please read [this guide](http://steamcommunity.com/sharedfiles/filedetails/?id=725234314) before creating a bug report,
and then create a bug report [here](https://github.com/fluffy-mods/DesirePaths/issues)

![Image](https://headers.karel-kroeze.nl/title/Older%20versions.png)

All current and past versions of this mod can be downloaded from [GitHub](https://github.com/fluffy-mods/DesirePaths/releases).

![Image](https://headers.karel-kroeze.nl/title/License.png)

All original code in this mod is licensed under the [MIT license](https://opensource.org/licenses/MIT). Do what you want, but give me credit.
All original content (e.g. text, imagery, sounds) in this mod is licensed under the [CC-BY-SA 4.0 license](http://creativecommons.org/licenses/by-sa/4.0/).

Parts of the code in this mod, and some of the content may be licensed by their original authors. If this is the case, the original author &amp; license will either be given in the source code, or be in a LICENSE file next to the content. Please do not decompile my mods, but use the original source code available on [GitHub](https://github.com/fluffy-mods/DesirePaths/), so license information in the source code is preserved.

Parts of this mod were created by, or derived from works created by;


- surang: road preview icon ([BY-NC](https://www.flaticon.com/authors/surang))- Smashicons: path preview icon ([BY-NC](https://www.flaticon.com/authors/smashicons))- Freepik: landscape preview icon ([BY-NC](https://www.freepik.com/))


![Image](https://headers.karel-kroeze.nl/title/Are%20you%20enjoying%20my%20mods%3F.png)

Normally, this is where I ask you to show you appreciation by buying me a coffee.

These are not normal times. Ukraine is being invaded by Russia, at the whim of a ruthless dictator. Innocent people are loosing their lives, and fighting for their continued freedom.

This is not a matter of politics. This is not a debate. Putins' bloody campaign in Ukraine is illegal, and he will stop at nothing to get what he wants, when he wants it, no matter the cost. The Russian army is invading a country without provocation, bombing civilians and murdering innocents.

The prospect of waking up to see my country at war is alien to me, as it must have seemed to most Ukrainians. I can do little to influence the outcome of current affairs, but I will do whatever I can.

**I ask you to join me in supporting the people of Ukraine**

![Image](https://headers.karel-kroeze.nl/title/Humanitarian%20Aid.png)

If you can, donate to the various charities providing humanitarian aid. If you don't know where to donate, Global Citizen maintains a list of charitable organizations active in the region.

[https://www.globalcitizen.org/en/content/ways-to-help-ukraine-conflict/](https://www.globalcitizen.org/en/content/ways-to-help-ukraine-conflict/)

![Image](https://headers.karel-kroeze.nl/title/Speak%20up.png)

Leaders around the world are deciding on how to respond to Putins' aggression. They are balancing their conscience, and their desire to be re-elected. Many are afraid to impose heavy sanctions because the economic repercussions might loose them votes. The Dutch government, my government, has hinted that they are unwilling to accept Ukranian refugees, and has played a part in allowing Russia to have continued access to international finance. I am ashamed of these actions, taken in my name.

Whereever your live, please let your government know you care more about supporting the people of Ukraine than you do about the price of gas. Join a protest, write letters, call your representatives, and

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using the [Log Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods


