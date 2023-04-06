# KD2Prac
### Jan 3rd 2019
Speedrun practice tool for Koumajou Densetsu II (aka Touhouvania 2)

Download `KD2Prac.zip` from [here](https://github.com/shadax1/KD2Prac/releases) and unzip the 2 .exe files into your game folder. You can either start the game followed by the practice tool or start the practice tool which will automatically start the game.

**Note:** your game must be version 1.02 or 1.02a

## Threadstack
This tool uses `threadstack.exe` which helps locate the proper pointer address to be used by the tool in order to do reads and writes.

This approach is heavily based off [this stackoverflow discussion](https://stackoverflow.com/questions/28620186/using-pointers-found-in-cheat-engine-in-c-sharp).

## Offsets used
Windows 10, game ver1.02a:
```csharp
FIRST_OFFSETS_WIN10_102A = { 0x268, 0xA0 };
```
Windows 10, game ver1.02:
```csharp
FIRST_OFFSETS_WIN10_102 = { 0x278, 0xA0 };
```
Windows 7, game ver1.02a:
```csharp
FIRST_OFFSETS_WIN7_102A = { 0x260, 0xA0 };
```
Windows 7, game ver1.02a:
```csharp
FIRST_OFFSETS_WIN7_102 = { 0x270, 0xA0 };
```
