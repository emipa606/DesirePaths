# GitHub Copilot Instructions for RimWorld Mod: Desire Paths (Continued)

## Mod Overview and Purpose
The "Desire Paths (Continued)" mod is an update of Fluffy's original mod. It is based on version 1.5 by Cybranian. This mod introduces a dynamic terrain system where colonists' frequent paths turn into "packed dirt" paths. These paths are represented by trampled terrain, also known as "desire paths." They have a higher movement speed than many natural terrains but result in dirt tracking and lack fertility. Over time, if paths are not used, they will degrade back to their original terrain type.

## Key Features and Systems
- **Packed Dirt Paths**: Areas frequently traversed by colonists are converted into packed dirt paths. This affects movement speed and can have secondary impacts such as dirt tracking.
- **Path Degradation**: Paths revert to their original terrain if not consistently used.
- **XML Configuration**: Customizable through XML tags, allowing modders to dictate which terrains can form packed dirt paths.
- **Mod Extensions**: Utilize DefModExtension to disable paths for specific terrains or change the type of terrain that forms when packed. 

## Coding Patterns and Conventions
- **Naming Conventions**: Classes and methods follow standard C# camelCase and PascalCase conventions.
- **Use of Interfaces**: Implements interfaces such as ICellBoolGiver to manage terrain visuals.
- **Static Classes**: Utilizes static classes for shared resources and game settings.

## XML Integration
- **DefModExtension**: The mod uses the `DefModExtension_PackedTerrain` class for XML integration. This allows for terrain customization by setting the `TakeFootprints` tag to `true` in terrain defs. Additional fields like `disabled` and `packedTerrain` can be applied to control the behavior of paths.

## Harmony Patching
- **Harmony Patch File**: The file `Patch_DoPlaySettingsGlobalControls.cs` applies patches to integrate seamlessly with the game's UI settings. This is a recommended pattern for modifying or extending the game’s existing functionalities without directly changing the game code.

## Suggestions for Copilot
- **Terrain Handling**: When enhancing terrain handling via Copilot, consider common scenarios where paths form or degrade, and ensure methods in `DesireGrid` handle terrain checks efficiently.
- **User Interface**: Assist with UI elements related to path settings in `Settings.cs` for better customization options.
- **Optimizing Code**: Use Copilot to suggest performance-based changes, especially in reiterative methods within `DesireGrid` such as `DoPathDrawerUpdate`.
- **Localization Support**: Utilize `I18n.cs` for managing translations and localization, encouraging seamless integration of different language packs.
- **DefModExtension Examples**: Offer code suggestions on creative uses of `DefModExtension` to expand the mod’s functionalities.

This document aims to serve as a comprehensive guide for using GitHub Copilot to contribute to the continuous enhancement and updating of the Desire Paths (Continued) mod, ensuring it remains a staple feature for RimWorld mod environments.

This document provides detailed guidance on the mod’s structure and integration, helping developers to smoothly contribute using GitHub Copilot.
