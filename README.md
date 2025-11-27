# Flappy Nemo

A simple Flappy-style game featuring Nemo. This project was created as a promotional initiative by our Robocik Scientific Club to popularize knowledge about modern technologies 
and the Unity engine. Flappy Nemo is an homage to our real-world student project: an autonomous underwater vehicle (AUV) named Nemo, which we use for exploration and research. 
This game aims to be a fun, virtual representation of our robot's spirit: agility, the necessity of avoiding obstacles, and the continuous push to "keep swimming forward."

## Overview
Control Nemo by tapping/clicking/pressing space to make him "flap". Avoid obstacles and score points. The project includes scenes, prefabs, scripts, and UI ready to run in the Unity Editor.

## Requirements
- Unity (use the version recorded in `ProjectSettings/ProjectVersion.txt`)
- Unity Hub to open the project
- Optional: Visual Studio 2022 or JetBrains Rider for C# editing and debugging

## Quick start
1. Clone the repo
2. Open the project in Unity Hub.
3. Wait for Unity to resolve and import packages.
4. Open the main game scene from `Assets/Scenes` (or the scene listed first in `File → Build Settings`).
5. Press Play in the Editor to run the game.

## Controls
- Left mouse click / Space / Touch — flap (jump)

## Project layout
- `Assets/` — game assets (scenes, prefabs, sprites, scripts)
- `Assets/Scripts/` — C# scripts for game logic (e.g., GameManager, PlayerController)
- `Packages/manifest.json` — Unity package dependencies
- `ProjectSettings/` — Unity project settings

## Notable packages (from `Packages/manifest.json`)
- `com.unity.inputsystem` — Input System
- `com.unity.render-pipelines.universal` — Universal Render Pipeline (URP)
- `com.unity.ugui` — UI
- `com.unity.visualscripting` — Visual Scripting
- Additional scoped packages: `com.unity-atoms`, `com.eflatun.scenereference`, etc.

## Build
1. Open `File → Build Settings`.
2. Select target platform (PC, Android, iOS).
3. Ensure required scenes are included in Build Settings.
4. Click `Build` or `Build And Run`.

## Troubleshooting
- Missing packages: open `Window → Package Manager` in Unity and restore packages.
- Unity version mismatch: check `ProjectSettings/ProjectVersion.txt` and use the same or compatible Unity version.
- Compile errors: review Unity Console and fix script references or package conflicts.


