# PandaQuest
## Voxel block game A.K.A a Minecraft clone

### Goals
#### Features
MVP is currently an infinitely generating world with terrain.
Feature parity with Minecraft Infdev would be a nice to have, plus additional features.

#### Design
Using [MonoGame](https://www.monogame.net/) for rendering, input, and utility functions.
Eventually I would like to roll my own to take advantage of DirectX 12 and as a good learning experience.
The same can be said for using libraries for logging, IoC containers, testing, and maybe configuration.
TLDR: no external dependencies.

### Running
Pretty sure this requires Windows.

### Testing
All tests are in PandaQuest.Tests, run them via `dotnet test` in /src or via a GUI.
