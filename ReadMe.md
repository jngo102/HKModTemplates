# Hollow Knight Mod Templates

This is a set of .NET templates for creating Hollow Knight mods. 

## Installation
### From NuGet gallery (recommended)
1.  From a terminal, run `dotnet new -i HKModding.HKMod.Templates`.
### Manual installation
1.  Go to the Releases page (https://github.com/jngo102/HKModTemplates/releases) and download the latest `HKModTemplates.nupkg` file (not the Source Code!). 
2.  From a terminal, run `dotnet new -i {/path/to/downloaded/.nupkg}`. 

## Creating a new mod
Once the templates have been installed, you can create a new Hollow Knight mod using the command `dotnet new {template}`, where `{template}` may be:
- hkmod: The default, barebones mod template
- hkpreloads: A mod template with some structuring for preloads.
- hksettings: A mod template that implements basic settings.
- hkmpaddon: A template for an add-on for HKMP.

There are several parameters you may pass into the `dotnet` command:
- *--modName*: The name of your mod. Should be one word, e.g. "MyMod". Default is "HKMod".
- *--modAuthor*: The mod's author, i.e. your name. Default is blank.
- *--modDescription*: A description of the mod. Default is "A Hollow Knight mod."
- *--hkRefsPath*: The location of your project references. This is the folder that contains the `Assembly-CSharp.dll` file. Default is `$(MSBuildProgramFiles32)/Steam/steamapps/common/Hollow Knight/hollow_knight_Data/Managed/`.
- *--hkRefsPath1*: HKMP add-on template only. The location of your project references for one installation of Hollow Knight. This is the folder that contains the `Assembly-CSharp.dll` file. Default is `$(MSBuildProgramFiles32)/Steam/steamapps/common/Hollow Knight/hollow_knight_Data/Managed/`.
- *--hkRefsPath2*: HKMP add-on template only. The location of your project references for another installation of Hollow Knight. This is the folder that contains the `Assembly-CSharp.dll` file. Default is `$(MSBuildProgramFiles32)/Steam/steamapps/common/Hollow Knight/hollow_knight_Data/Managed/`.


e.g: `dotnet new hkmod --modName "MyMod" --modAuthor "My Name" --modDescription "Description of my mod." --hkRefsPath "C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight\hollow_knight_Data\Managed\"`

## Uninstall
1.  From a terminal, run `dotnet new -u HKModding.HKMod.Templates`.