# Hollow Knight Mod Templates

This is a set of .NET templates for creating Hollow Knight mods. 

## Installation
1.  Go to the Releases page (https://github.com/jngo102/HKModTemplates/releases) and download the latest `HKModTemplates.nupkg` file (not the Source Code!). 
2.  From a terminal, run `dotnet new --install {/path/to/downloaded/.nupkg}`. 

## Creating a new mod
Once the templates have been installed, you can create a new Hollow Knight mod using the command `dotnet new hkmod`. There are several parameters you may pass in:
- --modName: The name of your mod. Should be one word, e.g. "MyMod". Default is "HKMod".
- --modAuthor: The mod's author, i.e. your name. Default is blank.
- --modDescription: A description of the mod. Default is "A Hollow Knight mod."
- --hkInstallPath: The install location of Hollow Knight on your PC. This is the folder that contains the hollow_knight executable file. Default is `$(HOME)/.local/share/Steam/steamapps/common/Hollow Knight/`.
- --exportPath: Where you want to export your packaged mod to on your PC. Default is `$(HOME)/.local/share/Steam/steamapps/common/Hollow Knight/hollow_knight_Data/Managed/Export/`.

e.g: `dotnet new hkmod --modName "MyMod" --modAuthor "My Name" --modDescription "Description of my mod."`

## Uninstall
1.  To uninstall the .NET templates, run `dotnet new --uninstall HKModding.HKMod.Templates` from a terminal.