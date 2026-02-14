# Copilot Instructions for RimWorld Mod: Show Possible Materials

## Mod Overview and Purpose
"Show Possible Materials" is a quality-of-life enhancement mod for the game RimWorld. It enhances the player experience by allowing them to easily identify and select available materials for crafting recipes at workbenches. By holding the CTRL key while viewing the list of bills at a workbench, players can see all possible items on the map that can be used to fulfill a recipe, marked with arrows for easy identification. Additionally, players can interactively select these items for crafting by right-clicking, streamlining the resource management process.

## Key Features and Systems
- **Interactive Material Selection**: By pressing CTRL, players can view all eligible crafting materials available in their colony, highlighted with arrows.
- **Right-click Material Selection**: This feature allows players to select all marked materials with a single right-click, expediting the setup process for production tasks.
- **Compatibility**: Designed to work alongside other mods that modify the list of bills, ensuring a seamless integration with modded game content.

## Coding Patterns and Conventions
- **Static Classes**: Utilized for utility methods and extensions to existing RimWorld classes to avoid instantiation overhead when adding features.
- **Modifiers**: Adherence to modifier use with `public static` class pattern ensuring ease of access and thread safety given the mod's passive data-tracking nature.
- **Consistent Naming**: Class and method names follow PascalCase convention, with clear, descriptive identifiers for readability and maintainability.

## XML Integration
- **Def XMLs**: While not detailed in the provided project files, integrate XML changes per RimWorld standards to define custom recipe modifications or XML-based data serialization.
- **Integration Points**: Ensure XML configuration matches C# class usage to leverage RimWorld's def framework correctly, maintaining data integrity and compatibility.

## Harmony Patching
- **Harmony Library Usage**: If modifications involve patching vanilla classes, leverage the Harmony library to apply runtime method interception.
- **Patch Decorators**: Use `[HarmonyPatch]` attributes to specify exactly which methods should be patched, along with `Prefix`, `Postfix`, or `Transpiler` methods where applicable.
- **Backup Vanilla Calls**: Implement `Ref` and `Out` parameters carefully in Harmony patches to preserve original game behavior and prevent conflicts with other mods.

## Suggestions for Copilot
- **Method Autocompletion**: Gear Copilot suggestions toward locating available items and dynamically interfacing the bill system via user input hooks.
- **Error Handling**: Prompt suggestions for robust error checking when interacting with game data to prevent crashes due to null references or invalid operations.
- **Performance Optimizations**: Recommend practices for efficient searching and highlighting of items within active game maps, mindful of game performance implications.
- **User Interface Enhancements**: Suggest Copilot integrations to optimize and streamline UI modifications, ensuring that new features mesh cleanly with RimWorld's existing interfaces.

By adhering to these guidelines and using the aforementioned patterns effectively, contributors can extend the "Show Possible Materials" mod while ensuring high levels of performance and compatibility within the complex ecosystem of RimWorld mods.
