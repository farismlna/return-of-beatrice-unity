# Return of Beatrice

A third-person 3D action RPG built in **Unity** and **C#** by an intern team at **PT Falah Inovasi Teknologi** (October 2022 – January 2023).

![Gameplay](docs/gameplay.gif)
Record it with ScreenToGif or OBS, then put the file in a docs/ folder. -->

## About the game

One day Beatrice is coming back from hunting and exploring the jungle, but from far away she saw a huge plume of smoke in the distance, coming from the direction of his village. The village is under attack! she need to help the village free from the monster and helping the captured villager. Follows quests and talks to NPCs, fights skeleton enemies, and faces the King Skull boss. The story is told through in-engine cutscenes.


## Features

- **Action combat:** third-person melee combat with weapon slots, stamina and focus bars, critical-hit colliders and a bow with projectiles.
- **Inventory:** weapon inventory with quick slots and an equipment window, plus consumables such as healing flasks and a healing spell.
- **Enemy AI:** a state machine (idle, patrol, chase, attack) with field-of-view detection and NavMesh pathfinding, plus a boss encounter.
- **Interactive puzzles:** keys, locked doors, chests and a cage mechanism that gate progress.
- **Quests and dialogue:** a quest system with an on-screen quest arrow, and a dialogue system driven by ScriptableObject conversations.
- **Presentation:** Timeline cutscenes, an audio manager with terrain-aware footsteps, menus, settings and scene loading.

## My contributions

I worked as a **game programmer** on this team. I built:

- the player controller and action combat (`Assets/Script/NEW/Player/`)
- the inventory and item system (`Assets/Script/NEW/Items/`, `Assets/Script/NEW/UI/`)
- the interactive puzzle mechanics: doors, keys, chests and the cage (`Assets/Script/NEW/Other Mechanic/`)
- enemy behavior (`Assets/Script/Enemy/`)

I also optimized game performance and set up environment scenes.

## Tech stack

- Unity **2021.3.25f1** (LTS), C#
- NavMesh Components, Timeline, LeanTween
- Invector Third Person Controller LITE as a base, and Asset Store art packs (see Credits)

## Getting started

1. Install **Unity 2021.3.25f1** through Unity Hub.
2. Clone the repository and open the folder in Unity Hub (**Add project from disk**).
3. Open `Assets/MainScene/Opening.unity` and press **Play**.

The build order is: Opening → CutScene1 → OP2CS 1 → TestingLoad → GameMain → SceneKingSkull → EndGame.

## Project structure

```text
Assets/
├── Script/         # Game code: player, combat, items, enemy AI, quests, dialogue, UI, audio
├── MainScene/      # Playable scenes (opening, cutscenes, main game, boss, ending)
├── Prefab/         # Player, weapons and level prefabs
├── PrefabEnemy/    # Enemy prefabs
├── Scriptable Obj/ # Dialogue and character data (ScriptableObjects)
└── ...             # Third-party art, animation and audio packs
```

## Team

Made by the intern team at PT Falah Inovasi Teknologi

## Credits

This project uses third-party assets from the Unity Asset Store, including Invector Third Person Controller LITE, LeanTween, Kevin Iglesias animations, POLYGON Fantasy packs, Suntail Village, Polytope Studio, Polygonal Particles and Ultimate 10+ Shaders. All rights to those assets belong to their creators.
